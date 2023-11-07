using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// These routing cateogories represent 
    /// areas within DPI that handle a ticket 
    /// from CTS. This model has a one to many 
    /// relationship with the Route Model because 
    /// it is important to keep track of the previous 
    /// areas (routing categories) that handled the 
    /// ticket. There is a list of emails under the 
    /// routing category so if a ticket is moved to a 
    /// new routing category or updated then all emails
    /// under the routing category get an email.
    /// </summary>
    public class RoutingCategory
    {
        public int Id { get; set; }        
        public string Name { get; set; }

        /// <summary>
        /// List of emails under a routing category.
        /// </summary>
        public ICollection<RoutingEmail> RoutingEmails { get; set; }

        /// <summary>
        /// This is now a redundant property in CTS.
        /// </summary>
        [RegularExpression(@"^[^$%\/\^\(\)\?\*<>+=]*$", ErrorMessage = "Invalid characters")]
        public string Email { get; set; }
        
        /// <summary>
        /// This determines if the routing category 
        /// is in the Helpline Area, or the Web Form 
        /// Area which is not implemented into CTS 
        /// yet. The only possible value for this is 
        /// currently "Helpline".
        /// </summary>
        public string Area { get; set; }
        
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}