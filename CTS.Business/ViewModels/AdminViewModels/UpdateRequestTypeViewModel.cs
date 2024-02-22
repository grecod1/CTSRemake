using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{
    /// <summary>
    /// This is the view model for the 
    /// Create and Edit Request Type View.
    /// </summary>
    public class UpdateRequestTypeViewModel
    {
        /// <summary>
        /// This has a value if the user is editing 
        /// the request type.
        /// </summary>
        public int RequestTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public string UserName { get; set; }
    }
}