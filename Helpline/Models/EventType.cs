using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// Type of event log. This 
    /// model as a one to many 
    /// relationship with the 
    /// Event Log Model.
    /// </summary>
    public class EventType
    {
        public int Id { get; set; }
        public string EventTypeName { get; set; }
        public string CreatedBy_UserName { get; set; }        
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }        
        public DateTime ModifiedDate { get; set; }
    }
}