using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.TicketDTOs
{
    /// <summary>
    /// This DTO is used as a list item 
    /// for the Ticket Index View that 
    /// displays a list of Tickets.
    /// </summary>
    public class TicketListDTO
    {
        /// <summary>
        /// Id of the Ticket.
        /// </summary>
        public int TicketId { get; set; }
        
        /// <summary>
        /// User who created ticket.
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Date ticket was created.
        /// </summary>
        public DateTime CreationDate { get; set; }
        
        /// <summary>
        /// Date as a string value for the data table.
        /// </summary>
        public string DisplayDate { get; set; }
        
        /// <summary>
        /// First name of the caller under the ticket.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name of the caller under the ticket.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Full name used in the data table.
        /// </summary>
        public string ContactName { get; set; }
        
        /// <summary>
        /// County the ticket is under.
        /// </summary>
        public string County { get; set; }
        
        /// <summary>
        /// Contact phone number under the ticket.
        /// </summary>
        public string ContactPhone { get; set; }
        
        /// <summary>
        /// Request type of the ticket.
        /// </summary>
        public string RequestType { get; set; }
        
        /// <summary>
        /// Current routing category of the ticket.
        /// </summary>
        public string RoutingCategory { get; set; }
        
        /// <summary>
        /// Current program the ticket is under.
        /// </summary>
        public string Program { get; set; }
        
        /// <summary>
        /// Current status of the ticket.
        /// </summary>
        public string Status { get; set; }
    }
}