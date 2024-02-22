using Helpline.DTOs.TicketDTOs;
using Helpline.Models;
using Helpline.ViewModels.TicketViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels
{
    public class TicketIndexViewModel
    {        
        /*View Model for the Ticket Index and Ticket History */

        //Select list dates, and text input fields to narrow search criteria including the returning ids of the lists

        //Drop down lists
        [Display(Name = "Program")]
        public int? ProgramId { get; set; }
        public IEnumerable<Program> Select_Program { get; set; }

        [Display(Name = "Request Type")]
        public int? RequestTypeId { get; set; }
        public IEnumerable<RequestType> Select_RequestType { get; set; }

        [Display(Name ="Communication Type")]
        public int? CommunicationTypeId { get; set; }
        public IEnumerable<CommunicationType> Select_CommunicationType { get; set; }

        [Display(Name = "Routing Category")]
        public int? RouteCategoryId { get; set; }
        public IEnumerable<RoutingCategory> Select_RoutingCategory { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }
        public IEnumerable<Status> Select_Status { get; set; }

        [Display(Name = "How did the caller hear about us?")]
        public string ReferredFrom { get; set; }
        public IEnumerable<string> Select_ReferredFrom { get; set; }

        public string Bureau { get; set; }
        public IEnumerable<string> Select_Bureau { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "County")]
        public int? CountyId { get; set; }
        public IEnumerable<County> Select_Counties { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
        public IEnumerable<string> Select_States { get; set; }        

        // Inputs to narrow by date range
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        
        //text fields to narrow or search by caller name, tracking number, or user id who created the ticket.
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Affiliation { get; set; }

        [Display(Name = "Ticket Number")]
        public string TrackingNumber { get; set; }

        [Display(Name = "User Name Who Created Ticket")]
        public string CreatedBy_UserName { get; set; }

        public bool CanViewReports { get; set; }


        //Used for recording user actions
        public string UserName { get; set; }


        //List is converted into JSON Data in the Ticket Service Class
        public IEnumerable<TicketListDTO> DisplayTickets { get; set; }

    }
}