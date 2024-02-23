using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{    
    /// <summary>
    /// This View Model is used in the create and create and edit Routing Category views.
    /// </summary>
    public class UpdateRoutingCategoryViewModel
    {
        /*Unlike other objects the Administrator adds or updates the Routing Category has 
         *its own Update View Model because the Routing Category has it's own list of emails 
         the Administrator can add or remove.*/
        public int? Id { get; set; }
        
        [RegularExpression(@"^[^@$%\/\^\?\*<>+=]*$", ErrorMessage = "Invalid characters")]
        [Required]
        public string? Name { get; set; }
        public IEnumerable<string>? Emails { get; set; }
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
    }
}