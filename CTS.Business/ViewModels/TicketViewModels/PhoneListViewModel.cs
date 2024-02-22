using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// This is a sub view model that is used 
/// within the Ticket Details View Model. 
/// This is only to display phone numbers 
/// on the Ticket Details View. 
/// </summary>
namespace Helpline.ViewModels.TicketViewModels
{
    public class PhoneListViewModel
    {
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Phone Type")]
        public string PhoneNumberType { get; set; }
    }
}