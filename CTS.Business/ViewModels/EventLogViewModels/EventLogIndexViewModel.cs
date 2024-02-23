using CTS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.EventLogViewModels
{
    /// <summary>
    /// This is the view model for the 
    /// event type view model.
    /// </summary>
    public class EventLogIndexViewModel
    {
        /*Unlike other administrator related objects, the Event Log has 
         *its own seperate Index View Model, because the administrator 
         needs to sort the Event Logs by the Date, and Event Type.*/

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "User Who Performed Action")]
        public string? UserName { get; set; }

        [Display(Name = "Ticket Number")]
        public string? TicketTrackingNumber { get; set; }

        [Display(Name = "Event Type")]
        public int EventTypeId { get; set; }
        public IEnumerable<EventType> Select_EventType{ get; set; }        
    }
}