using Helpline.DTOs.ImageDTOs;
using Helpline.DTOs.TicketDTOs;
using Helpline.Models;
using Helpline.Repository;
using Helpline.ViewModels;
using Helpline.ViewModels.RouteViewModels;
using Helpline.ViewModels.TicketViewModels;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Image = Helpline.Models.Image;

namespace Helpline.Services
{

    public class TicketServices
    {
        private UnitOfWork _data;
        private EmailServices _emailServices;
        private RouteServices _routeServices;
        private UserServices _userServices;

        public TicketServices()
        {
            _data = new UnitOfWork();
            _emailServices = new EmailServices();
            _routeServices = new RouteServices();
            _userServices = new UserServices();
        }

        #region Public methods that create View Models for Views        

        // This Method gets the view model for the Ticket Details View
        /// <summary>
        /// Gets the view model for the Ticket Details View
        /// </summary>
        /// <param name="id">Id for Ticket</param>
        /// <param name="userName">DOACS user name</param>
        /// <param name="emailSent">true if emails were previously sent</param>
        /// <returns>View model</returns>
        public TicketDetailsViewModel Details(int id, string userName, bool emailSent)
        {
            try
            {
                Ticket ticket = _data.Tickets
                    .GetFirst(t => t.Id == id,
                        "Status", "CommunicationType", "RequestType", "Addresses");

                IEnumerable<Route> routes = _data.Routes
                    .GetList(r => r.TicketId == id, "RoutingCategory", "Program");

                string emailaddress = _data.Emails
                    .GetFirst(e => e.TicketId == id)
                    ?.EmailAddress;

                // Gets the full name of the user who created the ticket
                string createdBy = _userServices.GetFullName(ticket.CreatedBy_UserName);

                TicketDetailsViewModel model = new TicketDetailsViewModel()
                {
                    TicketId = ticket.Id,
                    TrackingNumber = ticket.TrackingNumber,
                    Status = ticket.Status.Name,
                    AssignedUser = ticket.AssignedUser,
                    RequestTypeName = ticket.RequestType.Name,
                    CommunicationTypeName = ticket.CommunicationType.Name,
                    ReferredFrom = ticket.ReferredFrom,
                    Bureau = ticket.Bureau,
                    FirstName = ticket.FirstName,
                    LastName = ticket.LastName,
                    Affiliation = ticket.Affiliation,
                    EmailSent = emailSent,
                    PostEnabled = _userServices.CanEditInformation(userName),
                    IsAdministrator = _userServices.IsSupervisor(userName),
                    Email = emailaddress,
                    CreationDate = ticket.CreationDate,
                    CreatedBy = createdBy ?? ticket.CreatedBy_UserName
                };

                // Get the current route for the ticket, and assign it to the ticket view model
                model.CurrentRoute = routes
                    .Select(r => new RouteDisplayViewModel()
                    {
                        RouteCategoryId = r.RoutingCategoryId,
                        Category = r.RoutingCategory.Name,
                        Program = r.Program.LongName,
                        CreatedBy = _userServices
                            .GetFullName(r.CreatedBy_UserName) ?? r.CreatedBy_UserName,
                        CreationDate = r.CreationDate
                    })
                    .OrderByDescending(r => r.CreationDate)
                    .FirstOrDefault();

                // Get a list of preivous routes for the ticket
                model.DisplayPreviousRoutes = routes
                    .Where(r => r.IsActive == false)
                    .Select(r => new RouteDisplayViewModel()
                    {
                        RouteCategoryId = r.RoutingCategoryId,
                        Category = r.RoutingCategory.Name,
                        Program = r.Program.LongName,
                        CreatedBy = _userServices
                            .GetFullName(r.CreatedBy_UserName) ?? r.CreatedBy_UserName,
                        CreationDate = r.CreationDate
                    });

                // Get all addresses that are involved with the ticket
                model.Addresses = _data.Addresses
                    .GetList(a => a.TicketId == id, "County", "AddressType")
                    .Select(a => new AddressListViewModel()
                    {
                        AdddressNumber = a.StreetNumber ?? "",
                        AddressStreetName = a.StreetName ?? "",
                        AptNumber = a.AptNumber ?? "",
                        City = a.City ?? "No City Provided",
                        State = a.State ?? "",
                        Zip = a.Zip ?? "",
                        CountyName = a.County.Name,
                        AddressType = a.AddressType.Name
                    });

                // Get a list of phone numbers under the ticket
                model.PhoneNumbers = _data.PhoneNumbers
                    .GetList(p => p.TicketId == id, "PhoneType")
                    .Select(p => new PhoneListViewModel()
                    {
                        PhoneNumber = p.Number,
                        PhoneNumberType = p.PhoneType.PhoneTypeName
                    });

                //Get all ticket notes and comments
                model.DisplayTicketNotes = _data.Notes
                    .GetList(n => n.TicketId == id)
                    .OrderByDescending(n => n.CreationDate)
                    .Select(n => new NoteDetailsViewModel()
                    {
                        Id = n.Id,
                        CallerRemarks = n.CallerRemarks,
                        Resolutions = n.Resolution,
                        Comments = n.Comments,
                        CreationDate = n.CreationDate,
                        UserName = _userServices
                            .GetFullName(n.CreatedBy_UserName),
                        CreatedBy_UserName = n.CreatedBy_UserName
                    });

                model.TicketImageIds = _data.Images
                    .GetList(t => t.TicketId == id)
                    .Select(i => i.Id);

                if (emailSent)
                {
                    /*This detemines if an email was sent. If an email was sent, 
                     * then a modal with the emails involved will display to the user.*/
                    model.RoutingEmails = _data.RoutingEmails
                        .GetList(r => r.RoutingCategoryId == model.CurrentRoute.RouteCategoryId)
                        .Select(routingEmail => routingEmail.EmailAddress);

                }

                return model;
            }
            catch (NullReferenceException exception)
            {
                //This just returns a page if the user puts in an invalid ticket number in the URL bar
                TicketDetailsViewModel model = new TicketDetailsViewModel()
                {
                    TicketId = 0
                };

                return model;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Get Ticket Details",
                    exception.Message,
                    userName);
                throw;
            }
        }

        /// <summary>
        /// Get the image for the Ticket Image file result within the Ticket Controller
        /// </summary>
        /// <param name="id">The id of the Image</param>
        /// <returns>Array of bytes that gets translated into an image</returns>        
        public byte[] GetImage(int id)
        {
            Image image = _data.Images
                .GetFirst(u => u.Id == id);

            byte[] content = image.CharacterSet;

            return content;
        }

        /// <summary>
        /// Method used to see how many images are under a ticket. Returns true if at most 
        /// 6 images are uploaded to a ticket and false if greater than 6
        /// </summary>
        /// <param name="id">id of the ticket</param>
        /// <returns>boolean value if there are 6 or less images to a ticket</returns>
        public bool CheckImagesCount(int id)
        {
            int count = _data.Images.GetList(i => i.TicketId == id).Count();
            bool validCount = (count >= 0 && count < 6);
            return validCount;
        }

        /// <summary>
        /// This gets the initial Ticket Index View Model for the Ticket Index View and Ticket History View.
        /// This method gathers drop down lists for the user.
        /// </summary>
        /// <param name="userName">DOACS user name</param>
        /// <returns>View Model for the Ticket Search</returns>        
        public TicketIndexViewModel Index(string userName)
        {
            try
            {
                TicketIndexViewModel model = new TicketIndexViewModel()
                {
                    StartDate = null,
                    EndDate = null,
                };

                model.Select_RoutingCategory = _data.RoutingCategories
                    .GetList(r => r.IsActive == true)
                    .OrderBy(routingCategory => routingCategory.Name);

                model.Select_Program = _data.Programs
                    .GetList(p => p.IsActive == true)
                    .OrderBy(program => program.LongName);

                model.Select_RequestType = _data.RequestTypes
                    .GetList(r => r.IsActive == true)
                    .OrderBy(requestType => requestType.Name);

                model.Select_CommunicationType = _data.CommunicationTypes.GetList();

                model.Select_Counties = _data.Counties.GetList()
                    .OrderBy(c => c.Name);

                model.Select_Status = _data.Statuses.GetList();

                model.Select_States = getStates();
                model.Select_ReferredFrom = getCallerSources();
                model.Select_Bureau = getBureaus();


                model.CanViewReports = _userServices.IsCoordinator(userName);

                return model;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Ticket Index",
                    exception.Message,
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Ticket Index",
                    exception.Message,
                    userName);
                throw;
            }
        }

        /// <summary>
        /// Gets the intial Update Ticket View Model for the Create Ticket View. Gathers the proper drop down lists for the view. 
        /// </summary>
        /// <param name="userName">DOACS user name</param>
        /// <returns>View Model that is being Edited</returns>        
        public UpdateTicketViewModel GetCreateViewModel(string userName)
        {
            try
            {

                // Generate lists for drop down lists
                List<County> counties = _data.Counties.GetList()
                    .OrderBy(c => c.Name)
                    .ToList();

                IEnumerable<RoutingCategory> routingCategories = _data.RoutingCategories
                    .GetList(r => r.IsActive == true)
                    .OrderBy(routingCategory => routingCategory.Name);

                IEnumerable<Program> programs = _data.Programs
                    .GetList(p => p.IsActive == true)
                    .OrderBy(program => program.LongName);

                IEnumerable<RequestType> requestTypes = _data.RequestTypes
                    .GetList(r => r.IsActive == true)
                    .OrderBy(requestType => requestType.Name);

                int pendingStatusId = _data.Statuses
                    .GetFirst(s => s.Name == "Pending")
                    .Id;

                //The phone type ids are used for the values in a jQuery made dropdown list
                int homePhoneTypeId = _data.PhoneTypes
                    .GetFirst(p => p.PhoneTypeName == "Home Phone")
                    .Id;

                int workPhoneTypeId = _data.PhoneTypes
                    .GetFirst(p => p.PhoneTypeName == "Work Phone")
                    .Id;

                int mobilePhoneTypeId = _data.PhoneTypes
                    .GetFirst(p => p.PhoneTypeName == "Mobile Number")
                    .Id;

                //The county Id is assigned so the model state will be valid during the Post Action Result
                int noneCountyId = _data.Counties
                    .GetFirst(c => c.Name == "None")
                    .Id;

                // Create View Model
                UpdateTicketViewModel model = new UpdateTicketViewModel()
                {
                    Select_States = getStates(),
                    Select_Counties = counties,
                    Select_RoutingCategory = routingCategories,
                    Select_CommunicationType = _data.CommunicationTypes.GetList(),
                    Select_RequestType = requestTypes,
                    Select_Program = programs,
                    Select_ReferredFrom = getCallerSources(),
                    Select_Bureau = getBureaus(),
                    StatusId = pendingStatusId,
                    HomePhoneTypeId = homePhoneTypeId,
                    WorkPhoneTypeId = workPhoneTypeId,
                    MobilePhoneTypeId = mobilePhoneTypeId,
                    MailingAddress_CountyId = noneCountyId,
                    PhysicalAddress_CountyId = noneCountyId
                };

                return model;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Get Update Ticket View Model for ticket creation",
                    exception.Message,
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Get Update Ticket View Model for ticket creation",
                    exception.Message,
                    userName);
                throw;
            }
        }

        /// <summary>
        /// This method gathers the view model 
        /// for the Edit Ticket View.
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <param name="userName">Username who is performing action</param>
        /// <returns>View model</returns>
        public UpdateTicketViewModel GetEditViewModel(int id, string userName)
        {
            try
            {

                //Get Ticket with related objects
                Ticket ticket = _data.Tickets
                    .GetFirst(t => t.Id == id, "Status", "CommunicationType", "RequestType", "Addresses");

                /*Get the current route of the ticket based on when it was last updated.
                 * This is done over any possible chance all routes are inactive.*/
                Route route = _data.Routes
                    .GetList(r => r.TicketId == id, "RoutingCategory", "Program")
                    .OrderByDescending(r => r.ModifiedDate)
                    .FirstOrDefault();

                //Must get address type ids to get the mailing and physical address of the ticket
                int mailingTypeId = _data.AddressTypes
                    .GetFirst(a => a.Name == "Mailing")
                    .Id;

                int physicalTypeId = _data.AddressTypes
                    .GetFirst(a => a.Name == "Physical")
                    .Id;

                /*Get addresses assocated with the ticket. This needs to be done in a seperate 
                 request because the address type object is required. */
                Address mailingAddress = _data.Addresses
                    .GetFirst(a => a.TicketId == id && a.AddressTypeId == mailingTypeId, "County", "AddressType");

                Address physicalAddress = _data.Addresses
                    .GetFirst(a => a.TicketId == id && a.AddressTypeId == physicalTypeId, "County", "AddressType");


                /*These phone type ids are required because these are placed in hidden input fields 
                 within the Edit Ticket View.*/
                int homePhoneTypeId = _data.PhoneTypes
                    .GetFirst(p => p.PhoneTypeName == "Home Phone")
                    .Id;

                int workPhoneTypeId = _data.PhoneTypes
                    .GetFirst(p => p.PhoneTypeName == "Work Phone")
                    .Id;

                int mobilePhoneTypeId = _data.PhoneTypes
                    .GetFirst(p => p.PhoneTypeName == "Mobile Number")
                    .Id;

                IEnumerable<PhoneNumber> phoneNumbers = _data.PhoneNumbers
                    .GetList(p => p.TicketId == id, "PhoneType");

                //Get the email address under the ticket
                string emailAddress = _data.Emails
                    .GetList(e => e.TicketId == id)
                    .FirstOrDefault()?.EmailAddress;

                /*Checks the boolean property of the mailing address that determines 
                 if the mailing address is a po box or not. If this mailing address 
                is a PO box then the string variable is assigned the value of the 
                street name because that is where the PO Box is stored. */
                string poBox = mailingAddress != null && mailingAddress.IsPOBox ?
                    mailingAddress.StreetName : null;

                //Build view model
                UpdateTicketViewModel model = new UpdateTicketViewModel()
                {
                    TicketId = ticket.Id,
                    AssignedUserName = ticket.AssignedUser,
                    StatusId = ticket.StatusId,
                    CommunicationTypeId = ticket.CommunicationTypeId,
                    ProgramId = route.ProgramId,
                    RouteCategoryId = route.RoutingCategoryId,
                    RequestTypeId = ticket.RequestTypeId,
                    FirstName = ticket.FirstName,
                    LastName = ticket.LastName,
                    PhoneNumbers = phoneNumbers,
                    Email = emailAddress,
                    ReferredFrom = ticket.ReferredFrom,
                    Bureau = ticket.Bureau,
                    Affilation = ticket.Affiliation,
                    MailingAddress_POBox = poBox,
                    MailingAddress_StreetNumber = mailingAddress?.StreetNumber,
                    MailingAddress_StreetName = mailingAddress?.StreetName,
                    MailingAddress_AptNumber = mailingAddress?.AptNumber,
                    MailingAddress_City = mailingAddress?.City,
                    MailingAddress_State = mailingAddress?.State,
                    MailingAddress_Zip = mailingAddress?.Zip,
                    PhysicalAddress_StreetNumber = physicalAddress?.StreetNumber,
                    PhysicalAddress_StreetName = physicalAddress?.StreetName,
                    PhysicalAddress_AptNumber = physicalAddress?.AptNumber,
                    PhysicalAddress_City = physicalAddress?.City,
                    PhysicalAddress_State = physicalAddress?.State,
                    PhysicalAddress_Zip = physicalAddress?.Zip,
                    IsPOBox = mailingAddress != null ? mailingAddress.IsPOBox : false,
                    HomePhoneTypeId = homePhoneTypeId,
                    WorkPhoneTypeId = workPhoneTypeId,
                    MobilePhoneTypeId = mobilePhoneTypeId

                };

                // Generate drop down lists
                model.Select_States = getStates();

                model.Select_Counties = _data.Counties
                    .GetList()
                    .OrderBy(c => c.Name)
                    .ToList();

                model.Select_Status = _data.Statuses
                    .GetList();

                model.Select_CommunicationType = _data.CommunicationTypes
                    .GetList();

                /*The three following drop down lists created either return 
                 active objects or objects that are associated with the ticket. 
                 This is done to prevent an exception due to the possiblity that
                 a inactive object could be related to the ticket. */
                model.Select_RequestType = _data.RequestTypes
                    .GetList(r => r.IsActive || r.Id == ticket.RequestTypeId)
                    .OrderBy(r => r.Name);

                model.Select_RoutingCategory = _data.RoutingCategories
                    .GetList(r => r.IsActive || r.Id == route.RoutingCategoryId)
                    .OrderBy(r => r.Name);

                model.Select_Program = _data.Programs
                    .GetList(p => p.IsActive || p.Id == route.ProgramId)
                    .OrderBy(p => p.LongName);

                model.Select_ReferredFrom = getCallerSources();
                model.Select_Bureau = getBureaus();

                int noneCountyId = _data.Counties
                    .GetFirst(c => c.Name == "None")
                    .Id;

                //Makes sure there is a value for the counties on both addresses
                model.MailingAddress_CountyId = mailingAddress != null ? mailingAddress.CountyId : noneCountyId;
                model.PhysicalAddress_CountyId = physicalAddress != null ? physicalAddress.CountyId : noneCountyId;

                model.Select_EditOption = new List<string>()
                {
                    "Just Add Notes",
                    "Edit Ticket Information",
                    "Edit Routing Information",
                    "Edit Ticket, Routing Information, or Status",
                    "Change the Ticket Status"
                };

                //The default option is to update the ticket status
                model.EditOption = "Change the Ticket Status";

                return model;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Get Update Ticket View Model for editing ticket",
                    exception.Message,
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Get Update Ticket View Model for editing ticket",
                    exception.Message,
                    userName);
                throw;
            }
        }

        /// <summary>
        /// Gets the Udpate Note View Model for users who want to edit their notes
        /// </summary>
        /// <param name="id">Id of the Note being Updated</param>
        /// <param name="userName">DOACS user name</param>
        /// <returns>View Model</returns>        
        public UpdateNoteViewModel GetUpdateNotesViewModel(int id, string userName)
        {
            try
            {
                Note note = _data.Notes
                    .GetFirst(n => n.Id == id);

                UpdateNoteViewModel model = new UpdateNoteViewModel()
                {
                    NoteId = note.Id,
                    TicketId = note.TicketId,
                    CallerRemarks = note.CallerRemarks,
                    Comments = note.Comments,
                    Resolution = note.Resolution,
                    CreatedByUser = note.CreatedBy_UserName,
                    CreationDate = note.CreationDate.ToShortDateString()
                };

                return model;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Get Update Note View Model",
                    exception.Message,
                    userName);
                throw;
            }

        }

        #endregion        


        #region Public Method that involves the creation and update of the ticket and other object

        /// <summary>
        /// This is the Primary Method that involves the creation of the ticket. This involves calling multiple 
        /// private methods within this Ticket Service Class. 
        /// </summary>
        /// <param name="model">Update Ticket View Model that holds user input</param>
        /// <returns>Id of the newly created ticket</returns>
        public int Create(UpdateTicketViewModel model)
        {
            try
            {
                //Creation of the Ticket and notes under the Ticket

                int resolvedCategoryId = _data.RoutingCategories
                    .GetFirst(r => r.Name == "Resolved")
                    .Id;

                if (model.RouteCategoryId == resolvedCategoryId)
                {
                    /*This executes when the user choose the "Resolved" Routing Category, 
                     * which would result in the ticket automatically 
                     being completed when it is created*/
                    model.StatusId = _data.Statuses
                        .GetFirst(s => s.Name == "Complete")
                        .Id;
                }

                //Create new ticket
                Ticket ticket = new Ticket()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AssignedUser = model.AssignedUserName,
                    StatusId = model.StatusId,
                    RequestTypeId = model.RequestTypeId,
                    CommunicationTypeId = model.CommunicationTypeId,
                    ReferredFrom = model.ReferredFrom,
                    Bureau = model.Bureau,
                    Affiliation = model.Affilation,
                    CreatedBy_UserName = model.AssignedUserName,
                    LastModifiedBy_UserName = model.AssignedUserName,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                _data.Tickets.Create(ticket);
                _data.Save();

                model.TicketId = ticket.Id;

                //Create note
                CreateNote(model);

                if (model.AddressInvolved)
                {
                    //This executes when the user selects "yes" if an address is involved on the Create Ticket View
                    if (model.PhysicalSameAsMailingAddress)
                    {
                        /*This executes if the user clicks on the checkbox that indicates if the mailing address 
                         * is the same as the physical address */

                        sameAsMailingAddress(model);
                    }
                    else if (model.IsPOBox)
                    {
                        /*This executes if the user clicks on the checkbox if the mailing address is a PO Box. 
                         * This means the mailing and physical address must be different */

                        model.MailingAddress_StreetNumber = "";
                        model.PhysicalAddress_AptNumber = "";
                        model.MailingAddress_StreetName = model.MailingAddress_POBox;
                    }

                    //Create mailing address

                    int mailingAddresstypeId = _data.AddressTypes
                        .GetFirst(a => a.Name == "Mailing")
                        .Id;

                    Address mailingAddress = new Address()
                    {
                        AddressTypeId = mailingAddresstypeId,
                        TicketId = model.TicketId,
                        CountyId = model.MailingAddress_CountyId,
                        StreetNumber = model.MailingAddress_StreetNumber,
                        StreetName = model.MailingAddress_StreetName,
                        AptNumber = model.MailingAddress_AptNumber,
                        City = model.MailingAddress_City,
                        State = model.MailingAddress_State,
                        Zip = model.MailingAddress_Zip,
                        IsPOBox = model.IsPOBox,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now
                    };

                    //Create physical address

                    int physicalAddressTypeId = _data.AddressTypes
                        .GetFirst(a => a.Name == "Physical")
                        .Id;

                    Address physicalAddress = new Address()
                    {
                        AddressTypeId = physicalAddressTypeId,
                        TicketId = model.TicketId,
                        CountyId = model.PhysicalAddress_CountyId,
                        StreetNumber = model.PhysicalAddress_StreetNumber,
                        StreetName = model.PhysicalAddress_StreetName,
                        AptNumber = model.PhysicalAddress_AptNumber,
                        City = model.PhysicalAddress_City,
                        State = model.PhysicalAddress_State,
                        Zip = model.PhysicalAddress_Zip,
                        IsPOBox = false,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now
                    };

                    _data.Addresses.Create(mailingAddress);
                    _data.Addresses.Create(physicalAddress);
                    _data.Save();
                }

                if (model.PhoneNumbers != null)
                {
                    //This executes if the user enters at least one phone number
                    foreach (PhoneNumber phoneNumber in model.PhoneNumbers)
                    {

                        if (phoneNumber.Number != null)
                        {
                            //prevents null reference exception.
                            phoneNumber.TicketId = model.TicketId;
                            phoneNumber.Number = phoneNumber.Number.Trim();
                            phoneNumber.CreatedBy_UserName = model.AssignedUserName;
                            phoneNumber.CreationDate = DateTime.Now;
                            phoneNumber.LastModifiedBy_UserName = model.AssignedUserName;
                            phoneNumber.ModifiedDate = DateTime.Now;

                            _data.PhoneNumbers.Create(phoneNumber);
                            _data.Save();
                        }
                    }
                }

                if (model.Email != null)
                {
                    //This executes if the user inputs an email address                    

                    Email email = new Email()
                    {
                        TicketId = model.TicketId,
                        EmailAddress = model.Email,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now
                    };

                    _data.Emails.Create(email);
                    _data.Save();
                }

                //Checks to see if an Image is included with the Ticket, and if it's the proper image type. 
                bool imageIncluded =
                    model.TicketImage?.ContentType == "image/png" || model.TicketImage?.ContentType == "image/jpeg";

                if (imageIncluded)
                {
                    byte[] charset = new byte[model.TicketImage.InputStream.Length];
                    model.TicketImage.InputStream.Read(charset, 0, charset.Length);

                    Image image = new Image()
                    {
                        TicketId = ticket.Id,
                        CharacterSet = charset,
                        Description = "Image was uploaded during ticket creation.",
                        IsActive = true,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now
                    };

                    _data.Images.Create(image);
                    _data.Save();

                }

                return model.TicketId;
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Create Ticket",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Create Ticket",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Create Ticket",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
        }

        /// <summary>
        /// Creates an image under a ticket.
        /// </summary>
        /// <param name="ticketId">Id of the ticket</param>
        /// <param name="imageFile">Image file from the form</param>
        /// <param name="description">Image Description</param>
        /// <param name="userName">User who is performing action.</param>
        /// <returns>List of DTOs that represent all images including new one under the ticket.</returns>
        public IEnumerable<ImageDTO> Create(int ticketId, HttpPostedFile imageFile, string userName)
        {
            try
            {
                if (ticketId > 0)
                {
                    byte[] charset = new byte[imageFile.InputStream.Length];
                    imageFile.InputStream.Read(charset, 0, charset.Length);
                    Image image = new Image()
                    {
                        TicketId = ticketId,
                        CharacterSet = charset,
                        IsActive = true,
                        CreatedBy_UserName = userName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = userName,
                        ModifiedDate = DateTime.Now,
                    };

                    _data.Images.Create(image);
                    _data.Save();

                    return GetImageDTOs(ticketId);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception exception)
            {

                _data.ErrorRepository.LogError("Unknown",
                    "Create Ticket",
                    exception.Message,
                    userName);

                throw;
            }



        }

        /// <summary>
        /// This method hard deletes images 
        /// from the database.
        /// </summary>
        /// <param name="id">Id of the image</param>
        /// <returns>
        /// Returns a list of image data so the images refresh in the view.
        /// </returns>
        public IEnumerable<ImageDTO> Remove(int id, string userName)
        {
            try
            {
                Image image = _data.Images.GetFirst(i => i.Id == id);

                _data.Images.Remove(image);
                _data.Save();

                return GetImageDTOs(image.TicketId);
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Delete Image",
                    exception.Message,
                    userName);
                throw;
            }

        }

        /// <summary>
        /// This is the new primary public method when the user updates the ticket. The Edit Option property of the View Model
        /// determines what other methods will be called. 
        /// </summary>
        /// <param name="model">View Model that holds information from the view</param>
        /// <returns>true if an email was sent, false if no email was sent</returns>
        public bool Edit(UpdateTicketViewModel model)
        {
            try
            {
                bool emailSent = false;

                int pendingId = _data.Statuses
                    .GetFirst(s => s.Name == "Pending")
                    .Id;

                switch (model.EditOption)
                {
                    case "Just Add Notes":
                        {
                            // If the user just wants to add notes to the ticket
                            CreateNote(model);

                            if (model.StatusId == pendingId)
                            {
                                string emailReason = "Additional notes have been made on a " +
                                    "ticket under your routing category <strong>(Route)</strong>, " +
                                    "please review the notes";

                                emailSent = _emailServices.SendEmail(model, true, emailReason);
                            }

                            break;
                        }
                    case "Edit Ticket Information":
                        {
                            //If the user is updating ticket information but not routing information
                            model.TicketId = editTicket(model);

                            if (model.StatusId == pendingId)
                            {
                                string emailReason = "Information on a ticket under your routing category " +
                                    "<strong>(Route)</strong> has been updated, please review ticket " +
                                    "information and notes";
                                emailSent = _emailServices.SendEmail(model, true, emailReason);
                            }

                            break;
                        }
                    case "Edit Routing Information":
                        {
                            // If the using is updating routing information but not the ticket information
                            _routeServices.Update(model);
                            CreateNote(model);

                            if (model.StatusId == pendingId)
                            {
                                string emailReason = "Information on a ticket under your routing category has been updated, " +
                                    "or a pre-existing ticket was sent to your routing category at <strong>(Route)</strong>  " +
                                    "please review the ticket information and notes";
                                
                                emailSent = _emailServices.SendEmail(model, false, emailReason);
                            }

                            break;
                        }
                    case "Edit Ticket, Routing Information, or Status":
                        {
                            //If the user intends to update the ticket, routing, and Status information
                            model.TicketId = editTicket(model);
                            _routeServices.Update(model);

                            if (model.StatusId == pendingId)
                            {
                                string emailReason = "Information on a ticket under your routing category has been updated, " +
                                    "or a pre-existing ticket was sent to your routing category at <strong>(Route)</strong>  " +
                                    "please review the ticket information and notes. The status of the ticket under your " +
                                    "routing category <strong>(Route)</strong> has changed to (TicketStatus)";
                                
                                emailSent = _emailServices.SendEmail(model, false, emailReason);
                            }

                            break;
                        }
                    case "Change the Ticket Status":
                        {
                            // If the user wants to update the Ticket Status.  
                            model.TicketId = editTicket(model);

                            if (model.StatusId == pendingId)
                            {
                                string emailReason = "The status of the ticket under your routing category " +
                                    "<strong>(Route)</strong> has changed to (TicketStatus)";
                                
                                emailSent = _emailServices.SendEmail(model, true, emailReason);
                            }

                            break;
                        }
                    default:
                        {
                            _data.ErrorRepository.LogError("Invalid Edit Option",
                                "Edit Ticket",
                                "Invalid Edit Option",
                                model.AssignedUserName);
                            break;
                        }
                }

                return emailSent;
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Update Ticket",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Update Ticket",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Update Ticket",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
        }



        /// <summary>
        /// New notes always get created when a ticket either gets created, updated, or users 
        /// can just add extra notes under a ticket
        /// </summary>
        /// <param name="model">The View Model that contains the Note being Updated</param>        
        public void CreateNote(UpdateTicketViewModel model)
        {
            /*The "blank" value is the default value for Caller Remarks if the text area is not 
             * shown, this is because the Caller Remark field is required and must have a value 
             * during the Post Action Result, so if that field is hidden in the Edit Ticket View, 
             * a "blank" value will automatically be assigned so the model state will be valid and 
             * then will be null once this Create Note method is called. */
            model.CallerRemarks = model.CallerRemarks == "blank" ? null : model.CallerRemarks;

            if ((model.Comments == null || model.Comments.Trim() == string.Empty)
                && (model.CallerRemarks == null || model.CallerRemarks.Trim() == string.Empty)
                && (model.Resolution == null || model.Resolution.Trim() == string.Empty))
            {
                //This code executes if the comments, resoluation and reason for call is all blank
                model.Comments = $"Ticket updated on {DateTime.Now.ToString()} by user {model.AssignedUserName}";
            }

            Note note = new Note()
            {
                CallerRemarks = model.CallerRemarks,
                Resolution = model.Resolution,
                Comments = model.Comments,
                TicketId = model.TicketId,
                CreatedBy_UserName = model.AssignedUserName,
                CreationDate = DateTime.Now,
                LastModifiedBy_UserName = model.AssignedUserName,
                ModifiedDate = DateTime.Now
            };

            _data.Notes.Create(note);
            _data.Save();
        }

        /// <summary>
        /// Executes if the user decides to edit the notes they have written
        /// </summary>
        /// <param name="model">View Model being Updated</param>        
        public void UpdateNote(UpdateNoteViewModel model)
        {
            try
            {
                model.CallerRemarks = model.CallerRemarks == "blank" ? null : model.CallerRemarks;
                if ((model.Comments == null || model.Comments.Trim() == string.Empty)
                    && (model.CallerRemarks == null || model.CallerRemarks.Trim() == string.Empty)
                    && (model.Resolution == null || model.Resolution.Trim() == string.Empty))
                {
                    //This code executes if the comments, resoluation and reason for call is all blank
                    model.Comments = $"Note updated on {DateTime.Now.ToString()} by user {model.LastModifiedByUserName}";
                }

                Note note = _data.Notes
                    .GetFirst(n => n.Id == model.NoteId);

                note.CallerRemarks = model.CallerRemarks;
                note.Comments = model.Comments;
                note.Resolution = model.Resolution;
                note.LastModifiedBy_UserName = model.LastModifiedByUserName;
                note.ModifiedDate = DateTime.Now;

                _data.Notes.Edit(note);
                _data.Save();
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Update Note",
                    exception.Message,
                    model.LastModifiedByUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Update Note",
                    exception.Message,
                    model.LastModifiedByUserName);
                throw;
            }
        }


        #endregion


        #region Methods that deal with the Excel Generators

        /// <summary>
        /// This method creates an excel file 
        /// for the ticket index view.
        /// </summary>
        /// <param name="parameters">The view model holds parameters</param>
        /// <param name="userName">User who is performing action</param>
        /// <returns>Excel file user is downloading</returns>
        public byte[] GetExcelTicketData(TicketIndexViewModel parameters, string userName)
        {
            try
            {
                int physicalAddressTypeId = _data.AddressTypes
                    .GetFirst(a => a.Name == "Physical")
                    .Id;

                int disabledStatusId = _data.Statuses
                    .GetFirst(s => s.Name == "Disabled")
                    .Id;

                int ticketCount = _data.Tickets
                    .GetList()
                    .Count();

                IEnumerable<TicketListDTO> tickets = _data.TicketRepository
                    .GetTickets(parameters, physicalAddressTypeId, disabledStatusId, ticketCount);

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Tickets");

                    sheet.Cells["A1"].Value = "Tracking Number";
                    sheet.Cells["B1"].Value = "Routing Category";
                    sheet.Cells["C1"].Value = "Program";
                    sheet.Cells["D1"].Value = "Create Date";
                    sheet.Cells["E1"].Value = "Request Type";
                    sheet.Cells["F1"].Value = "Caller Name";
                    sheet.Cells["G1"].Value = "County";
                    sheet.Cells["H1"].Value = "Status";

                    int row = 2;

                    foreach (TicketListDTO ticket in tickets)
                    {
                        sheet.Cells[$"A{row}"].Value = ticket.TicketId;
                        sheet.Cells[$"B{row}"].Value = ticket.RoutingCategory;
                        sheet.Cells[$"C{row}"].Value = ticket.Program;
                        sheet.Cells[$"D{row}"].Value = ticket.DisplayDate;
                        sheet.Cells[$"E{row}"].Value = ticket.RequestType;
                        sheet.Cells[$"F{row}"].Value = ticket.ContactName;
                        sheet.Cells[$"G{row}"].Value = ticket.County;
                        sheet.Cells[$"H{row}"].Value = ticket.Status;

                        row++;
                    }

                    var range = sheet.Row(1);


                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(1, 0, 56, 128);
                    range.Style.Font.Color.SetColor(0, 255, 255, 255);


                    sheet.Cells["A:H"].AutoFitColumns();

                    return package.GetAsByteArray();
                }


            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Get Excel Data",
                    exception.Message,
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Other",
                    "Get Excel Data",
                    exception.Message,
                    userName);
                throw;
            }
        }


        #endregion


        #region public methods that gather data for JSON objects        

        /// <summary>
        /// Gets a list of data representing tickets. 
        /// This is intended for the Ticket Index View
        /// </summary>
        /// <param name="model">View model that holds parameters.</param>
        /// <returns>DTOs representing ticket data.</returns>
        public IEnumerable<TicketListDTO> GetTickets(TicketIndexViewModel model)
        {

            int phsyicalAddressId = _data
                .AddressTypes
                .GetFirst(a => a.Name == "Physical")
                .Id;

            int disabledStatusId = _data
                .Statuses
                .GetFirst(s => s.Name == "Disabled")
                .Id;

            return _data.TicketRepository
                .GetTickets(model, phsyicalAddressId, disabledStatusId, 2000);
        }

        
        /// <summary>
        /// Gets the count of tickets 
        /// based on the search parameters.
        /// </summary>
        /// <param name="model">View model that holds search parameters.</param>
        /// <returns>Count of tickets based on search parameters</returns>
        public int GetTicketCount(TicketIndexViewModel model)
        {
            int phsyicalAddressId = _data
                .AddressTypes
                .GetFirst(a => a.Name == "Physical")
                .Id;
            
            int disabledStatusId = _data
                .Statuses
                .GetFirst(s => s.Name == "Disabled")
                .Id;

            return _data.TicketRepository
                .GetTicketCount(model, phsyicalAddressId, disabledStatusId);            
            
        }

        /// <summary>
        /// This method returns of list of dtos 
        /// that are translated into JSON objects 
        /// and used to display images in the Images View.
        /// </summary>
        /// <param name="ticketId">Id of the ticket the images are under.</param>
        /// <returns>DTOs that provide image data.</returns>
        public IEnumerable<ImageDTO> GetImageDTOs(int ticketId)
        {
            return _data.Images.GetList(i => i.TicketId == ticketId)
                .Select(i => new ImageDTO()
                {
                    Id = i.Id
                });

        }

        #endregion


        #region private methods that create database objects                               

        /// <summary>
        /// This has been changed to a private method that is only called in the Update Method and always 
        /// changing the ticket information
        /// </summary>
        /// <param name="model">Update Ticket View Model that holds user input</param>
        /// <returns>Id of the ticket being updated</returns>
        private int editTicket(UpdateTicketViewModel model)
        {
            //Ticket gets updated and new notes under the ticket are created

            Ticket ticket = _data.Tickets
                .GetFirst(t => t.Id == model.TicketId);

            ticket.CommunicationTypeId = model.CommunicationTypeId;
            ticket.RequestTypeId = model.RequestTypeId;
            ticket.FirstName = model.FirstName;
            ticket.LastName = model.LastName;
            ticket.StatusId = model.StatusId;
            ticket.ReferredFrom = model.ReferredFrom;
            ticket.Bureau = model.Bureau;
            ticket.Affiliation = model.Affilation;
            ticket.LastModifiedBy_UserName = model.AssignedUserName;
            ticket.ModifiedDate = DateTime.Now;

            _data.Tickets.Edit(ticket);
            _data.Save();

            if ((model.Comments == null || model.Comments.Trim() == string.Empty)
                && model.EditOption == "Change the Ticket Status")
            {
                // Edit Option 5 means that the user is changing the status of the ticket                  
                string status = _data.Statuses
                    .GetFirst(s => s.Id == model.StatusId)
                    .Name;

                model.Comments = $"Status changed to {status}";
            }

            CreateNote(model);

            if (model.AddressInvolved)
            {
                //This executes when the user selects "yes" if an address is involved on the Create Ticket View
                if (model.PhysicalSameAsMailingAddress)
                {
                    /*This executes if the user clicks on the checkbox that indicates if the mailing address 
                     * is the same as the physical address */

                    sameAsMailingAddress(model);
                }
                else if (model.IsPOBox)
                {
                    //This executes if the user clicks on the checkbox if the mailing address is a PO Box.
                    //This means the mailing and physical address must be different
                    model.MailingAddress_StreetNumber = "";
                    model.PhysicalAddress_AptNumber = "";
                    model.MailingAddress_StreetName = model.MailingAddress_POBox;
                }

                int addressTypeId = _data.AddressTypes
                    .GetFirst(a => a.Name == "Mailing")
                    .Id;

                Address mailingAddress = _data.Addresses
                    .GetFirst(a => a.TicketId == model.TicketId
                        && a.AddressTypeId == addressTypeId);

                if (mailingAddress == null)
                {
                    mailingAddress = new Address()
                    {
                        TicketId = model.TicketId,
                        AddressTypeId = addressTypeId,
                        CountyId = model.MailingAddress_CountyId,
                        IsPOBox = model.IsPOBox,
                        StreetNumber = model.MailingAddress_StreetNumber,
                        StreetName = model.MailingAddress_StreetName,
                        AptNumber = model.MailingAddress_AptNumber,
                        City = model.MailingAddress_City,
                        State = model.MailingAddress_State,
                        Zip = model.MailingAddress_Zip,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now
                    };

                    _data.Addresses.Create(mailingAddress);
                    _data.Save();
                }
                else
                {
                    mailingAddress.IsPOBox = model.IsPOBox;
                    mailingAddress.StreetNumber = model.MailingAddress_StreetNumber;
                    mailingAddress.StreetName = model.MailingAddress_StreetName;
                    mailingAddress.AptNumber = model.MailingAddress_AptNumber;
                    mailingAddress.City = model.MailingAddress_City;
                    mailingAddress.State = model.MailingAddress_State;
                    mailingAddress.Zip = model.MailingAddress_Zip;
                    mailingAddress.CountyId = model.MailingAddress_CountyId;
                    mailingAddress.LastModifiedBy_UserName = model.AssignedUserName;
                    mailingAddress.ModifiedDate = DateTime.Now;

                    _data.Addresses.Edit(mailingAddress);
                    _data.Save();
                }

                addressTypeId = _data.AddressTypes
                    .GetFirst(a => a.Name == "Physical")
                    .Id;

                Address physicalAddress = _data.Addresses
                    .GetFirst(a => a.TicketId == model.TicketId
                        && a.AddressTypeId == addressTypeId);

                if (physicalAddress == null)
                {
                    physicalAddress = new Address()
                    {
                        TicketId = model.TicketId,
                        AddressTypeId = addressTypeId,
                        CountyId = model.PhysicalAddress_CountyId,
                        IsPOBox = false,
                        StreetNumber = model.PhysicalAddress_StreetNumber,
                        StreetName = model.PhysicalAddress_StreetName,
                        AptNumber = model.PhysicalAddress_AptNumber,
                        City = model.PhysicalAddress_City,
                        State = model.PhysicalAddress_State,
                        Zip = model.PhysicalAddress_Zip,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now,
                    };

                    _data.Addresses.Create(physicalAddress);
                    _data.Save();
                }
                else
                {
                    physicalAddress.IsPOBox = false;
                    physicalAddress.StreetNumber = model.PhysicalAddress_StreetNumber;
                    physicalAddress.StreetName = model.PhysicalAddress_StreetName;
                    physicalAddress.AptNumber = model.PhysicalAddress_AptNumber;
                    physicalAddress.City = model.PhysicalAddress_City;
                    physicalAddress.State = model.PhysicalAddress_State;
                    physicalAddress.Zip = model.PhysicalAddress_Zip;
                    physicalAddress.CountyId = model.PhysicalAddress_CountyId;
                    physicalAddress.LastModifiedBy_UserName = model.AssignedUserName;
                    physicalAddress.ModifiedDate = DateTime.Now;

                    _data.Addresses.Edit(physicalAddress);
                    _data.Save();
                }
            }

            updatePhoneNumbers(model);

            Email email = _data.Emails
                .GetFirst(e => e.TicketId == model.TicketId);

            if (email != null)
            {
                email.EmailAddress = model.Email;
                email.LastModifiedBy_UserName = model.AssignedUserName;
                email.ModifiedDate = DateTime.Now;

                _data.Emails.Edit(email);
                _data.Save();
            }
            else if (model.Email != null)
            {
                /*This executes if the user adds a 
                 new email on a pre-existing ticket. */
                email = new Email()
                {
                    TicketId = model.TicketId,
                    EmailAddress = model.Email,
                    CreatedBy_UserName = model.AssignedUserName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = model.AssignedUserName,
                    ModifiedDate = DateTime.Now
                };

                _data.Emails.Create(email);
                _data.Save();
            }

            return model.TicketId;

        }

        private void updatePhoneNumbers(UpdateTicketViewModel model)
        {
            IEnumerable<PhoneNumber> phoneNumbers = _data.PhoneNumbers
                .GetList(p => p.TicketId == model.TicketId);

            if (phoneNumbers?.Count() > 0)
            {
                foreach (PhoneNumber phoneNumber in phoneNumbers)
                {
                    _data.PhoneNumbers.Remove(phoneNumber);
                }
                _data.Save();
            }

            if (model.PhoneNumbers?.Count() > 0)
            {
                foreach (PhoneNumber phoneNumberFromForm in model.PhoneNumbers)
                {
                    PhoneNumber phoneNumberInDB = new PhoneNumber()
                    {
                        TicketId = model.TicketId,
                        Number = phoneNumberFromForm.Number,
                        PhoneTypeId = phoneNumberFromForm.PhoneTypeId,
                        CreatedBy_UserName = model.AssignedUserName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = model.AssignedUserName,
                        ModifiedDate = DateTime.Now,
                    };

                    _data.PhoneNumbers.Create(phoneNumberInDB);
                }
                _data.Save();
            }
        }

        #endregion


        #region private method that fixes the data for the parcel address if the parcel address is the same as the mailing address

        /// <summary>
        /// Method that fixes the data for the parcel address if the parcel address is the same as the mailing address
        /// </summary>
        /// <param name="model">View Model being Updated</param>
        private static void sameAsMailingAddress(UpdateTicketViewModel model)
        {
            model.PhysicalAddress_StreetNumber = model.MailingAddress_StreetNumber;
            model.PhysicalAddress_StreetName = model.MailingAddress_StreetName;
            model.PhysicalAddress_AptNumber = model.MailingAddress_AptNumber;
            model.PhysicalAddress_City = model.MailingAddress_City;
            model.PhysicalAddress_State = model.MailingAddress_State;
            model.PhysicalAddress_Zip = model.MailingAddress_Zip;
            model.PhysicalAddress_CountyId = model.MailingAddress_CountyId;
        }

        #endregion


        #region private method that generates drop down list that only contain strings

        /// <summary>
        /// Generates list of States for drop down list
        /// </summary>
        /// <returns>List of States</returns>        
        private static IEnumerable<string> getStates()
        {
            List<string> states = new List<string>();
            states.Add("AL");
            states.Add("AK");
            states.Add("AZ");
            states.Add("AR");
            states.Add("CA");
            states.Add("COS");
            states.Add("CT");
            states.Add("DE");
            states.Add("FL");
            states.Add("GA");
            states.Add("HI");
            states.Add("ID");
            states.Add("IL");
            states.Add("IN");
            states.Add("IA");
            states.Add("KS");
            states.Add("KY");
            states.Add("LA");
            states.Add("ME");
            states.Add("MD");
            states.Add("MA");
            states.Add("MI");
            states.Add("MN");
            states.Add("MS");
            states.Add("MO");
            states.Add("MT");
            states.Add("NE");
            states.Add("NV");
            states.Add("NH");
            states.Add("NJ");
            states.Add("NM");
            states.Add("NY");
            states.Add("NC");
            states.Add("ND");
            states.Add("OH");
            states.Add("OK");
            states.Add("OR");
            states.Add("PA");
            states.Add("RI");
            states.Add("SC");
            states.Add("SD");
            states.Add("TN");
            states.Add("TX");
            states.Add("UT");
            states.Add("VT");
            states.Add("VA");
            states.Add("WA");
            states.Add("WV");
            states.Add("WI");
            states.Add("WY");

            return states;
        }

        /// <summary>
        /// The list of Sources for drop down list
        /// </summary>
        /// <returns>List of Sources</returns>
        private IEnumerable<string> getCallerSources()
        {
            return new List<string>()
            {
                "Billboard",
                "Bus Stop",
                "Magazine",
                "Newspaper",
                "Personal Reference",
                "Printed Handout",
                "Radio",
                "Television",
                "Vehicle Wrap",
                "Other"
            };
        }

        /// <summary>
        /// List of Bureaus for drop down list
        /// </summary>
        /// <returns>List of Bureaus</returns>
        private IEnumerable<string> getBureaus()
        {
            return new List<string>()
            {
                "Plant Inspection",
                "Apiary Inspection",
                "Entomology",
                "Botany",
                "Nematology",
                "Plant Pathology",
                "Methods",
                "Pest Eradication",
                "Citrus Budwood Registration",
                "Other"
            };
        }

        #endregion
    }
}