using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This is the type of phone number. 
    /// This model as a one to many 
    /// relationship with the Phone Model. 
    /// The three entries in this table 
    /// include Mobile Number, Home Phone, 
    /// and Work Phone.
    /// </summary>
    public class PhoneType
    {        
        public int Id { get; set; }
        public string PhoneTypeName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }        
        public DateTime ModifiedDate { get; set; }
    }
}