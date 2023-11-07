using Helpline.ViewModels;
using Helpline.ViewModels.EventLogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface IEventLogServices
    {
        //Public Methods that Deal with the Event Log Index View
        EventLogIndexViewModel GetIntialEventLogIndexViewModel();
        List<Object> GetEventLogData(int? eventTypeId, DateTime? startDate, DateTime? endDate, string userName, string trackingNumber);
        // Public Methods that add event logs
        void AddEventLogTicketCreate(UpdateTicketViewModel model);
        void AddEventLogTicketEdit(UpdateTicketViewModel model);
        void AddEventLogEmailSent(string email, int ticketId, string userName);
    }
}
