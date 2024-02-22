using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.TicketViewModels
{
    /// <summary>
    /// This is a sub view model that is used 
    /// within the Ticket Details View Model. 
    /// This is only to display address information 
    /// information on the Ticket Details View. 
    /// </summary>
    public class AddressListViewModel
    {
        public string AddressType { get; set; }
        public string AdddressNumber { get; set; }
        public string AddressStreetName { get; set; }
        public string AptNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountyName { get; set; }
    }
}