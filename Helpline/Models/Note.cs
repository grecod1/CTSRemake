using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// The represents the written notes 
    /// under the ticket. CTS users have 
    /// the ability to add comments under 
    /// tickets. The three parts of the 
    /// comments include the Caller Remarks, 
    /// Comments, and Resolution. There can 
    /// be as many notes as possible under 
    /// a ticket.
    /// </summary>
    public class Note
    {
        public int Id { get; set; }      
        
        /// <summary>
        /// What the caller stated.
        /// </summary>
        public string CallerRemarks { get; set; }
        
        /// <summary>
        /// General comments.
        /// </summary>
        public string Comments { get; set; }
        
        /// <summary>
        /// The final resolution of the call.
        /// </summary>
        public string Resolution { get; set; }
        
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        
        public string CreatedBy_UserName { get; set; }        
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }       
        public DateTime ModifiedDate { get; set; }
    }
}