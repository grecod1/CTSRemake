using Helpline.Models;
using Helpline.ViewModels.TicketViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.RouteViewModels
{
    /// <summary>
    /// This is a sub view model that is used 
    /// within the Ticket Details View Model. 
    /// This is only to display routing information 
    /// on the Ticket Details View. 
    /// </summary>
    public class RouteDisplayViewModel
    {        
        public int RouteCategoryId { get; set; }
        public string Category { get; set; }                
        public string Program { get; set; }        
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }

    }
}