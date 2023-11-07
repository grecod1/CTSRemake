using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        /*This object is used for all views that require special permission. This 
         *View Model involves logical proceedures and gets retrieved in the Action Result 
         * that need special permission, the boolean values which are IsAdministrator and 
         * POSTEnabled are used depending on the permission level of the page, and if the 
         * boolean is false, the user gets redirected back to the home page, while if the 
         * value is true, the user gets directed back to the view.*/

        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsCoordinator { get; set; }
        public bool POSTEnabled { get; set; }
    }
}