using Helpline.Models;
using Helpline.ViewModels.RouteViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.TicketViewModels
{
    /// <summary>
    /// This is the view model for the Ticket Details View. 
    /// Along with this Ticket Details View Model, other 
    /// sub view models are called within this view model.
    /// </summary>
    public class TicketDetailsViewModel
    {        
       
        public int TicketId { get; set; }
        
        /// <summary>
        /// This is the same as the Ticket Id 
        /// except it is in the form of a string 
        /// that is meant to display to the user.
        /// </summary>
        public string TrackingNumber { get; set; }
        
        /// <summary>
        /// This status can either be pending, 
        /// complete, or disabled.
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// This represents the individual who 
        /// created the ticket.
        /// </summary>
        public string  AssignedUser { get; set; }          
        public string RequestTypeName { get; set; }
        public string CommunicationTypeName { get; set; }
        public string ReferredFrom { get; set; }
        public string Bureau { get; set; }
        public string Affiliation { get; set; }
        
        /// <summary>
        /// This represents the current route the ticket is 
        /// under which is the current program and routing 
        /// category (area in DPI). The current route is the 
        /// route with the latest creation date under the ticket.
        /// </summary>
        public RouteDisplayViewModel CurrentRoute { get; set; }                
        
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        
        /// <summary>
        /// This determines if the user has the ability 
        /// to edit the ticket.
        /// </summary>
        public bool PostEnabled { get; set; }
        public bool IsAdministrator { get; set; }        
        public IEnumerable<AddressListViewModel> Addresses { get; set; }
        public IEnumerable<PhoneListViewModel> PhoneNumbers { get; set; }
        public IEnumerable<int> TicketImageIds { get; set; }
        public string Email { get; set; }       
        
        /// <summary>
        /// This represents the previous routes that 
        /// the ticket was sent to. Whenver a user 
        /// updates the program or routing category 
        /// then a new route gets created and the 
        /// previous route is added to this list.
        /// </summary>
        public IEnumerable<RouteDisplayViewModel> DisplayPreviousRoutes { get; set; }
        
        /// <summary>
        /// This represents the notes each user entered under a ticket.
        /// </summary>
        public IEnumerable<NoteDetailsViewModel> DisplayTicketNotes { get; set; }
        
        /// <summary>
        /// This list will only populate if emails were sent
        /// prior before the Ticket Details page loads.
        /// </summary>
        public IEnumerable<string> RoutingEmails { get; set; }
        
        /// <summary>
        /// This determines if emails were sent prior
        /// before the Ticket Details page loads.
        /// </summary>
        public bool EmailSent { get; set; }
        
        /// <summary>
        /// This determines if the user 
        /// entered into the Ticket Details 
        /// page from the Ticket Index View.
        /// </summary>
        public bool FromIndex { get; set; }
        public DateTime CreationDate { get; set; }        
        public string CreatedBy { get; set; }              
    }
}