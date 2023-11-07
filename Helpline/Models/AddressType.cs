using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// Type of the Address. One 
    /// to many relationship with 
    /// the Address Model.
    /// </summary>
    public class AddressType
    {                
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}