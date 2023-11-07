using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This is the request type of the ticket. 
    /// This has a one to many relationship with 
    /// the Ticket Model.
    /// </summary>
    public class RequestType
    {
        public int Id { get; set; }
        
        [RegularExpression(@"^[^@$%\/\^\(\)\?\*<>+=]*$", ErrorMessage = "Invalid characters")]
        [Required]
        public string Name { get; set; }

        public string Area { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}