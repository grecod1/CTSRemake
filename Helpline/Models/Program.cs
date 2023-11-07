using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This involves the current program 
    /// the ticket is currently assigned to.    
    /// This Program Model has a one to many
    /// relationship to the Route Model. The 
    /// reason why this model is related to the 
    /// Route Model instead of the Ticket Model 
    /// is because if a ticket changes programs, 
    /// then there has to be some way to keep 
    /// record of the older programs and that 
    /// way is to store them in the older routes. 
    /// Whenever a user updates the program "under 
    /// the ticket" then a whole new route under 
    /// the ticket automatically gets created with 
    /// the different program.
    /// </summary>
    public class Program
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Full name of the Program
        /// </summary>
        [RegularExpression(@"^[^@$%\/\^\(\)\?\*<>+=]*$", ErrorMessage = "Invalid characters")]
        [Display(Name = "Full Name")]
        [Required]
        public string LongName { get; set; }

        /// <summary>
        /// Initials of the program. 
        /// </summary>
        [RegularExpression(@"^[^@$%\/\^\(\)\?\*<>+=]*$", ErrorMessage = "Invalid characters")]
        [Display(Name ="Abbreviation")]
        [Required]
        public string ShortName { get; set; }
        
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}