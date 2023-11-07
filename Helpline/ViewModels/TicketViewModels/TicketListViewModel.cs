using Helpline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.TicketViewModels
{
    public class TicketListViewModel
    {
        public int TicketId { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactName { get; set; }        
        public string County { get; set; }
        public string ContactPhone { get; set; }
        public string RequestType { get; set; }
        public string RoutingCategory { get; set; }
        public string Program { get; set; }
        public string Status { get; set; }        
    }
}