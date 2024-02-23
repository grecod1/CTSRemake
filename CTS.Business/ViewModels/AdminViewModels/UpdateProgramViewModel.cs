using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{
    /// <summary>
    /// This view model is used for the 
    /// view that creates and edits programs.
    /// </summary>
    public class UpdateProgramViewModel
    {
        /// <summary>
        /// This will have a value for the 
        /// Edit Program View.
        /// </summary>
        public int? ProgramId { get; set; }

        [Display(Name = "Short Name")]
        public string? ShortName { get; set; }

        [Display(Name = "Long Name")]
        [Required]        
        public string? LongName { get; set; }

        public string? UserName { get; set; }

        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
    }
}