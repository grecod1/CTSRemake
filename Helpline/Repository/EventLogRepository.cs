using Helpline.Data;
using Helpline.Models;
using Helpline.Repository.Interfaces;
using Helpline.ViewModels.EventLogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class EventLogRepository 
    {
        private HelplineDbContext _dbContext;

        public EventLogRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        public EventLogRepository(HelplineDbContext context)
        {
            _dbContext = context;
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        #region Query

        public IEnumerable<EventLogListViewModel> GetEventLogs(int? eventTypeId, DateTime? startDate, DateTime? endDate, string userName, string trackingNumber)
        {
            IEnumerable<EventLogListViewModel> eventLogs = _dbContext.EventLogs
                .Join(_dbContext.EventTypes, e => e.EventTypeId, t => t.Id, (e, t) => new
                {
                    EventLog = e,                    
                    EventType = t.EventTypeName                     
                })
                .Join(_dbContext.Users, e => e.EventLog.CreatedBy_UserName, u => u.UserName, (e, u) => new
                {
                    e.EventLog,                    
                    e.EventType,
                    User = u.FirstName + " " + u.LastName
                }).Where(e => e.EventLog.EventTypeId == eventTypeId || eventTypeId == null)
                .Where(e => e.EventLog.CreationDate >= startDate || startDate == null).Where(e => e.EventLog.CreationDate <= endDate || endDate == null)
                .Where(e => e.EventLog.CreatedBy_UserName.Contains(userName) || e.User.Contains(userName) || userName == null || userName == string.Empty)
                .Where(e => e.EventLog.TicketTrackingNumber.Contains(trackingNumber) || trackingNumber == null || trackingNumber == string.Empty)
                .OrderByDescending(e => e.EventLog.CreationDate).Take(300).Select(e => new EventLogListViewModel()
                {
                    EventLogType = e.EventType,
                    TrackingNumber = e.EventLog.TicketTrackingNumber,
                    Email = e.EventLog.Email,
                    UserName = e.User,
                    CreationDate = e.EventLog.CreationDate
                }).ToList();

            return eventLogs;
        }

        public int GetEventTypeId(string eventTypeName)
        {
            int eventTypeId = _dbContext.EventTypes.Where(e => e.EventTypeName == eventTypeName).Select(e => e.Id).FirstOrDefault();

            return eventTypeId;
        }

        #endregion


        #region Insert

        public void AddEventLog(EventLog eventLog)
        {
            _dbContext.EventLogs.Add(eventLog);
            _dbContext.SaveChanges();            

        }

        #endregion

    }
}