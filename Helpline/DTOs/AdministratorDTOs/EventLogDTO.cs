using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    /// <summary>
    /// This DTO is used for JSON 
    /// data in the data table that
    /// displays a list of event logs 
    /// in the Event Log Index View.
    /// </summary>
    public class EventLogDTO
    {
        public string EventType { get; set; }
        public string TrackingNumber { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Time { get; set; }

    }
}