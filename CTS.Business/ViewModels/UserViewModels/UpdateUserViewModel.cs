using Helpline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.UserViewModels
{
    /// <summary>
    /// This view model is used to build the Create 
    /// and Edit User View.
    /// </summary>
    public class UpdateUserViewModel
    {
        /*View Model used for the Create and Edit User View*/
        
        //Select lists used to determine the role and location of the user
        [Display(Name = "Role and Authorization")]        
        public int RoleId { get; set; } 
        public IEnumerable<Role> Select_Role { get; set; } 

        [Display(Name = "Office Location")]
        public int OfficeLocationId { get; set; } 
        public IEnumerable<OfficeLocation> Select_OfficeLocations { get; set; }

        //Select list only used in Edit View, used to either activate or deactivate a user
        [Display(Name = "Status")]
        public int StatusId { get; set; } 
        public IEnumerable<Object> Select_Status { get; set; }

        //This value is assigned in the User Service Method based on the StatusId value
        public bool IsActive { get; set; }


        /// <summary>
        /// User name of the user being updated or created.
        /// </summary>
        [Display(Name = "User Name")]
        [RegularExpression(@"^[A-Z|a-z|0-9|\s|\\]+$", ErrorMessage ="Invalid characters for a user name, no need to input 'DOACS\', only the last name and first initial")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z|a-z|\s|'|,]+$", ErrorMessage = "A name should only contain letters, no numbers or foriegn characters")]
        [MaxLength(25, ErrorMessage = "Too many characters")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z|a-z|\s|'|,]+$", ErrorMessage = "A name should only contain letters, no numbers or foriegn characters")]
        [MaxLength(25, ErrorMessage = "Too many characters")]
        [Required]
        public string LastName { get; set; }        
                

        /// <summary>
        /// Id of the user
        /// </summary>
        public int Id { get; set; }

    }
}