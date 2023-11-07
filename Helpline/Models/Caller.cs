using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    public class Caller
    {
        public int Id { get; set; }        
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}