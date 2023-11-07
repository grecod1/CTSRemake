using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    
    /// <summary>
    /// This model repesents images under a ticket. 
    /// The image is stored as an array of bytes.
    /// </summary>
    public class Image
    {
        public int Id { get; set; }
        
        /// <summary>
        /// The Image is stored as an array of bytes
        /// </summary>
        public byte[] CharacterSet { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}