using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.InformationLinkViewModels
{
    public class UpdateInformationLinkViewModel
    {
        public int InformationLinkId { get; set; }

        [Display(Name = "Information Link Name")]
        [RegularExpression(@"^[A-Z|a-z|\s|'|,|-]+$", ErrorMessage = "A name should only contain letters, no numbers or foriegn characters")]
        [Required]        
        public string Name { get; set; }

        [Display(Name = "URL Address")]
        [Required]
        public string URL { get; set; }
        public bool IsActive { get; set; }
    }
}