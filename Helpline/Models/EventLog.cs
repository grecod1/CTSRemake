using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// Used to store events that 
    /// include creating or editing 
    /// models, and keeps track of 
    /// emails being sent out.
    /// </summary>
    public class EventLog
    {
        public int Id { get; set; }                
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public string Email { get; set; }
        public string TicketTrackingNumber { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}