using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{
    /// <summary>
    /// This view model is used 
    /// for the view that creates 
    /// and edits office locations.
    /// </summary>
    public class UpdateOfficeLocationViewModel
    {
        /// <summary>
        /// This will have a value for the Edit 
        /// Office View.
        /// </summary>
        public int? OfficeLocationId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
        public string? UserName { get; set; }
    }
}