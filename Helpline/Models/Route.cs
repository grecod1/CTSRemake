using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This keeps record of all Routing Categories, 
    /// and Programs that the ticket was under. During 
    /// the lifetime of a ticket, there is the potential 
    /// that a ticket can be moved to different areas 
    /// aka routing categories. Whenever a user either 
    /// changes the routing cateogory or program "under 
    /// the ticket" then a new route auatomatically gets 
    /// created. The most recently created route is 
    /// determined to be the current route of the ticket 
    /// while all other routes are consider previous routes.
    /// </summary>
    public class Route
    {
        public int Id { get; set; }
        
        /// <summary>
        /// The routing category represents 
        /// the area in DPI that handles the 
        /// ticket. If the route is current 
        /// then the area/routing category is 
        /// currently handling the ticket.
        /// </summary>
        public int RoutingCategoryId { get; set; }

        /// <summary>
        /// The routing category represents 
        /// the area in DPI that handles the 
        /// ticket. If the route is current 
        /// then the area/routing category is 
        /// currently handling the ticket.
        /// </summary>
        public RoutingCategory RoutingCategory { get; set; }
        
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        
        /// <summary>
        /// The program of the ticket is linked 
        /// the the route of the ticket.
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// The program of the ticket is linked 
        /// the the route of the ticket.
        /// </summary>
        public Program Program { get; set; }        
        
        public bool IsActive { get; set; }
        
        public string CreatedBy_UserName { get; set; }        
        
        /// <summary>
        /// This particular field detemines if this 
        /// is the current routing category or if it's 
        /// an older routing category.
        /// </summary>
        public DateTime CreationDate { get; set; }
        
        public string LastModifiedBy_UserName { get; set; }        
        
        public DateTime ModifiedDate { get; set; }
    }
}