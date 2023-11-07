using Helpline.Models;
using Helpline.ViewModels.EventLogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface IEventLogRepository
    {
        //Query
        IEnumerable<EventType> GetEventTypes();
        IEnumerable<EventLogListViewModel> GetEventLogs(int? eventTypeId, DateTime? startDate, DateTime? endDate, string userName, string trackingNumber);
        int GetEventTypeId(string eventTypeName);
        //Insert
        void AddEventLog(EventLog eventLog);
    }
}
