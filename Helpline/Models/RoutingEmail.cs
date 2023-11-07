using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This represents the list of 
    /// emails under a routing category.
    /// A routing category can have multiple 
    /// email addresses under it, to where 
    /// emails would be sent to those addresses 
    /// if a ticket was created or moved in that 
    /// routing category.
    /// </summary>
    public class RoutingEmail
    {
        public int Id { get; set; }
        public int RoutingCategoryId { get; set; }
        public RoutingCategory RoutingCategory { get; set; }
        public string EmailAddress { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}