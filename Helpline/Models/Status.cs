using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This represents the current 
    /// status of the ticket. This has 
    /// a one to many relationship with 
    /// the Ticket Model. The only three
    /// types of statuses are Pending, 
    /// Complete, and Disabled.
    /// </summary>
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}