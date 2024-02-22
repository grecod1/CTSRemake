using Helpline.Objects.DropDownListObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{
    /// <summary>
    /// This view model is used for the User, 
    /// Office Location, Program, Request Type, 
    /// and Routing Category index views.
    /// </summary>
    public class AdminIndexViewModel
    {                
        public bool? Status { get; set; }
        public IEnumerable<BooleanDropDownListObject> Select_Status { get; set; }

        /// <summary>
        /// There is no need to create a 
        /// method in any service class to 
        /// build this view model because the 
        /// only information required is a 
        /// drop down list that contains 3 values.
        /// </summary>
        public AdminIndexViewModel()
        {
            Status = null;
            Select_Status = new List<BooleanDropDownListObject>()
            {
                new BooleanDropDownListObject(true, "Active"),
                new BooleanDropDownListObject(false,"Inactive")
            };
        }
    }
}