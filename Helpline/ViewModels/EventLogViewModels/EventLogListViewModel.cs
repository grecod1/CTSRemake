using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.EventLogViewModels
{
    public class EventLogListViewModel
    {
        public string TrackingNumber { get; set; }
        public string EventLogType { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}