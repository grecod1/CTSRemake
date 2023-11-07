using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This represents the phone numbers 
    /// under a single ticket. There can be 
    /// at most five phone numbers under a 
    /// ticket. 
    /// </summary>
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string Number { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }        
        public string CreatedBy_UserName { get; set; }        
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }        
        public DateTime ModifiedDate { get; set; }
    }
}
