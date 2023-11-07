using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This is the office location 
    /// of the CTS user. This has a 
    /// one to many relationship with 
    /// the User Model.
    /// </summary>
    public class OfficeLocation
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z|a-z|\s|'|,]+$", ErrorMessage = "An office location name should only contain letters, no numbers or foriegn characters")]
        [Required]
        public string Name { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy_UserName { get; set; }        
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }        
        public DateTime ModifiedDate { get; set; }
    }
}