using Helpline.Models;
using Helpline.Repository;
using Helpline.ViewModels;
using Helpline.ViewModels.TicketViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;

namespace Helpline.Services
{
    public class EmailServices
    {
        private UnitOfWork _data;

        public EmailServices()
        {
            _data = new UnitOfWork();
        }

        
        

        /// <summary>
        /// This method sends an email to different routing categories. All emails under the selected Routing Catgegory will 
        /// recieve an email. This happens either when a ticket is created or when the Routing Category changes in the ticket.
        /// </summary>
        /// <param name="model">The Update View Model when the Ticket was updated or created</param>
        /// <param name="updateTicket">Indicates if the ticket is being updated or not</param>
        /// /// <param name="reason">This is the heading on the email that describtes why the email was sent to the recipient</param>
        /// <returns>Returns true if an email was sent</returns>
        public bool SendEmail(UpdateTicketViewModel model, bool updateTicket, string reason)
        {
            try
            {
                //The Ticket Details View Model is nessescary because it holds all of the information needed in the email.                

                Ticket ticket = _data.Tickets
                    .GetFirst(t => t.Id == model.TicketId, 
                        "Status", 
                        "CommunicationType", 
                        "RequestType", 
                        "Addresses");

                Route currentTicketRoute = _data.Routes
                    .GetList(r => r.TicketId == model.TicketId,
                        "RoutingCategory", "Program")
                    .OrderByDescending(r => r.CreationDate)
                    .FirstOrDefault();
                                        

                string ticketNumber = model.TicketId.ToString();

                string emailSubject = updateTicket ? $"Ticket {ticketNumber} Under Your Routing Category Has Been Updated"
                    : $"Ticket {ticketNumber} Has Been Routed to Your Area";

                reason = reason.Replace("(Route)", currentTicketRoute.RoutingCategory.Name);
                if (reason.Contains("(TicketStatus)"))
                {
                    reason = reason.Replace("(TicketStatus)", ticket.Status.Name);
                }

                //By default return value is false, unless an email is sent
                bool emailSent = false;

                IEnumerable<string> emails = _data.RoutingEmails
                    .GetList(r => r.RoutingCategoryId == model.RouteCategoryId )
                    .Select(r => r.EmailAddress);                                        
                
                
                foreach (string email in emails)
                {
                    if (validateEmail(email))
                    {
                        string emailTemplate = generateEmailTemplate(ticket, currentTicketRoute, reason);

                        MailMessage message = new MailMessage();
                        message.IsBodyHtml = true;
                        message.From = (new MailAddress("DPIHELPLINE@fdacs.gov", "DPI Communication Tracking System"));
                        message.To.Add(new MailAddress(email));
                        message.Subject = emailSubject;
                        message.Body = emailTemplate;

                        SmtpClient client = new SmtpClient("relay.fdacs.gov", 25);
                        client.Send(message);

                        //The instance one email is sent, the return value automatically changes to true
                        emailSent = true;
                        _data.EventLogServices.AddEventLogEmailSent(email, model.TicketId, model.AssignedUserName);
                    }
                }

                return emailSent;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", "Sending Email", exception.Message, model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Sending Email", exception.Message, model.AssignedUserName);
                throw;
            }
        }

        

        /// <summary>
        /// This method is called whenever any exception happens. What happens is that an email gets sent to me (Daniel Greco) when 
        /// an exception happens. 
        /// </summary>
        /// <param name="errorType">Type of exception</param>
        /// <param name="task">What the user was trying to do </param>
        /// <param name="message">Exception message</param>
        /// <param name="userName">User who expereinced the issue</param>
        /// <param name="time">Time of the exception</param>
        public void SendErrorEmail(string errorType, string task, string message, string userName, DateTime time)
        {
            string emailTemplate = generateErrorEmailTemplate(errorType, task, message, userName, time);
            
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.From = (new MailAddress("DPIHELPLINE@FDACS.gov", "DPI Communication Tracking System"));
            mailMessage.To.Add(new MailAddress("daniel.greco@FDACS.gov"));
            mailMessage.To.Add(new MailAddress("drake.dawkins@FDACS.gov"));
            mailMessage.Subject = "Error on Helpline Application";
            mailMessage.Body = emailTemplate;

            SmtpClient client = new SmtpClient("relay.fdacs.gov", 25);
            client.Send(mailMessage);            
        }

        /// <summary>
        /// This method generates the Email Template for the Routing Categories. This private method is called in the Send Email public  
        /// method where emails get sent to a routing category. This method takes the html file, and replaces the text with the properties 
        /// of the Ticket Details View Model.
        /// </summary>
        /// <param name="model">Ticket Details View Model which holds all proper information for the email.</param>
        /// <returns>string value which is the html email template used as the body of the email</returns>
        private string generateEmailTemplate(Ticket ticket, Route route, string reason)
        {

            // Create urls for the links to the tickets
            string desktopUrl = "http://helpline.doacs.state.fl.us";
            string mobileUrl = "https://helpline-freshfromflorida.msappproxy.net";

            if(HttpContext.Current.Request.Url.Host.Contains("local") 
                || HttpContext.Current.Request.Url.Host.Contains("dev"))
            {
                desktopUrl = "http://helplinedev.doacs.state.fl.us";
            }
            else if (HttpContext.Current.Request.Url.Host.Contains("test"))
            {
                desktopUrl = "http://helplinetest.doacs.state.fl.us";
                mobileUrl = "https://helplinetest-freshfromflorida.msappproxy.net";
            }


            string emailTemplate = "";
            string path = HostingEnvironment.MapPath("~/") + "MailTemplate/EmailTemplate.html";
            string statusColor = ticket.Status.Name == "Pending" ? "darkorange" : "mediumseagreen";
            //mediumgreen darkorange
            using (StreamReader streamreader = new StreamReader(path))
            {
                emailTemplate = streamreader.ReadToEnd();
            }
            emailTemplate = emailTemplate.Replace("(DesktopUrl)", desktopUrl);
            emailTemplate = emailTemplate.Replace("(MobileUrl)", mobileUrl);
            emailTemplate = emailTemplate.Replace("(Reason)", reason);
            emailTemplate = emailTemplate.Replace("(TicketNumber)", ticket.Id.ToString());
            emailTemplate = emailTemplate.Replace("(RoutingCategory)", route.RoutingCategory.Name);
            emailTemplate = emailTemplate.Replace("(CreationDate)", ticket.CreationDate.ToString());
            emailTemplate = emailTemplate.Replace("(CreatedBy)", ticket.AssignedUser.Substring(6));
            emailTemplate = emailTemplate.Replace("(RequestType)", ticket.RequestType.Name);
            emailTemplate = emailTemplate.Replace("(CommunicationType)", ticket.CommunicationType.Name);
            emailTemplate = emailTemplate.Replace("(ProgramName)", route.Program.LongName);
            emailTemplate = emailTemplate.Replace("(StatusColor)", statusColor);
            emailTemplate = emailTemplate.Replace("(Status)", ticket.Status.Name);




            IEnumerable<Address> addresses = _data.Addresses
                .GetList(a => a.TicketId == ticket.Id, "AddressType", "County");

            IEnumerable<PhoneNumber> phoneNumbers = _data.PhoneNumbers
                .GetList(p => p.TicketId == ticket.Id, "PhoneType");

            string email = _data.Emails.GetFirst(e => e.TicketId == ticket.Id)?.EmailAddress;

            Note note = _data.Notes
                .GetList(n => n.TicketId == ticket.Id)
                .OrderByDescending(n => n.CreationDate)
                .FirstOrDefault();
                        
            string addressDisplay = "";
            string phoneNumberDisplay = "";

            //Makes sure only one Anonymous word displays on Details Page

            if(ticket.FirstName == "Anonymous" && ticket.LastName == "Anonymous")
            {
                ticket.FirstName = "";
            }

            if (addresses != null && addresses.Count() > 0)
            {                
                foreach(Address address in addresses)
                {
                    addressDisplay = $"{addressDisplay}" +
                        $"<h5 style=\"margin-left:30%;\">{address.AddressType.Name}</h5>" +
                        $"<p style=\"margin-left:30%;\" >" +
                        $"{address.StreetNumber} {address.StreetName} " +
                        $"<br /> {address.City} {address.State} {address.Zip} "+
                        $"<strong>County: </strong> {address.County.Name}</p>";
                }                
            }
            else
            {
                addressDisplay = "<p style=\"margin-left:30%;\"><em>No addresses to display</em></p>";                
            }
            
            if (phoneNumbers!= null && phoneNumbers.Count() > 0)
            {                
                foreach (PhoneNumber phoneNumber in phoneNumbers)
                {
                    phoneNumberDisplay = $"{phoneNumberDisplay}" +
                        $"<h5 style=\"margin-left:30%;\">{phoneNumber.PhoneType.PhoneTypeName}</h5>" +
                        $"<p style=\"margin-left:30%;\">{phoneNumber.Number} </p>";
                }                
            }
            else
            {
                phoneNumberDisplay = "<p style=\"margin-left:30%;\"><em>No addresses to display</em></p>";                
            }
                                   
            note.CallerRemarks = note.CallerRemarks ?? "";
            note.Resolution = note.Resolution ?? "";
            note.Comments = note.Comments ?? "";
            email = email ?? "<em>No emails to display</em>";

            emailTemplate = emailTemplate.Replace("(ContactName)", $"{ticket.FirstName} {ticket.LastName}");
            emailTemplate = emailTemplate.Replace("(Addresses)", addressDisplay);
            emailTemplate = emailTemplate.Replace("(PhoneNumbers)", phoneNumberDisplay);
            emailTemplate = emailTemplate.Replace("(Email)", email);
            emailTemplate = emailTemplate.Replace("(CallerRemarks)", note.CallerRemarks);
            emailTemplate = emailTemplate.Replace("(Resolution)", note.Resolution);
            emailTemplate = emailTemplate.Replace("(Comments)", note.Comments);
            
            return emailTemplate;
        }

        /// <summary>
        /// This creates an email template for the error emails that get sent. This generates a string from the html file, which is used 
        ///as the body of the email.
        /// </summary>
        /// <param name="errorType">Type of exception</param>
        /// <param name="task">What the user was trying to do</param>
        /// <param name="message">Exception message</param>
        /// <param name="userName">User who experienced the exception</param>
        /// <param name="time">time of the exception</param>
        /// <returns></returns>
        private string generateErrorEmailTemplate(string errorType, string task, string message, string userName, DateTime time)
        {
            string template = "";

            string path = HostingEnvironment.MapPath("~/") + "MailTemplate/ErrorEmailTemplate.html";

            using (StreamReader streamreader = new StreamReader(path))
            {
                template = streamreader.ReadToEnd();
            }
            template = template.Replace("(ErrorType)", errorType);
            template = template.Replace("(Task)", task);
            template = template.Replace("(Message)", message);
            template = template.Replace("(User)", userName);
            template = template.Replace("(Time)", time.ToString());

            return template;
        }

        /// <summary>
        /// This method takes an email under the Routing Category and makes sure the email is legitimate. This private method is called 
        /// each time in the Public Send Email method for every email under the Routing Category.
        /// </summary>
        /// <param name="email">Email being tested</param>
        /// <returns>returns true if Email is legitimate</returns>
        private bool validateEmail(string email)
        {
            Regex regex = new Regex(@"^[a-z|A-Z|1-9|\.|_|-]+[@]{1}[a-z|A-Z|1-9|\.|_|-]+[\.]{1}[a-zA-z]{1,5}$");
            if(email == null)
            {
                return false;
            }
            else if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}