using Helpline.DTOs.AdministratorDTOs;
using Helpline.Models;
using Helpline.Repository;
using Helpline.ViewModels;
using Helpline.ViewModels.EventLogViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace Helpline.Services
{
    public class EventLogServices
    {
        private UnitOfWork _data;
        private UserServices _userServices;

        public EventLogServices()
        {
            _data = new UnitOfWork();
            _userServices = new UserServices();
        }

        #region Public Methods that Deal with the Event Log Index View

        public EventLogIndexViewModel GetIntialEventLogIndexViewModel()
        {
            EventLogIndexViewModel model = new EventLogIndexViewModel()
            {
                Select_EventType = _data.EventTypes.GetList()
            };

            return model;
        }

        /// <summary>
        /// Gets a list of objects that get translated into JSON data for the Event Log Index View.
        /// </summary>
        /// <param name="eventTypeId">Id of the Type of Event User wants to view</param>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns>List of Objects used as JSON data for the Data Table</returns>
        public IEnumerable<EventLogDTO> GetEventLogData(int? eventTypeId,
            DateTime? startDate,
            DateTime? endDate,
            string userName,
            string trackingNumber)
        {
            IEnumerable<EventLogDTO> eventLogs = _data.EventLogs
                .GetList(e => e.EventTypeId == eventTypeId || eventTypeId == null, "EventType")
                .Where(e => e.CreationDate >= startDate || startDate == null)
                .Where(e => e.CreationDate <= endDate || endDate == null)
                .Where(e => e.CreatedBy_UserName.Contains(userName) || userName == null || userName == string.Empty)
                .Where(e => e.TicketTrackingNumber.Contains(trackingNumber) || trackingNumber == null)
                .OrderByDescending(e => e.CreationDate)
                .Take(300)
                .Select(e => new EventLogDTO()
                {
                    EventType = e.EventType.EventTypeName,
                    TrackingNumber = e.TicketTrackingNumber,
                    Email = e.Email,
                    UserName = _userServices.GetFullName(e.CreatedBy_UserName),
                    Time = e.CreationDate.ToString()
                });

            return eventLogs;
        }

        #endregion


        #region Public Methods that Add EventLogs

        //Event Log that gets created when a ticket is created
        public void AddEventLogTicketCreate(UpdateTicketViewModel model)
        {
            try
            {
                int createdTicketId = _data.EventTypes.GetFirst(e => e.EventTypeName.Equals("Add Ticket")).Id;
                EventLog eventLog = new EventLog()
                {
                    EventTypeId = createdTicketId,
                    TicketTrackingNumber = model.TicketId.ToString(),
                    Email = "",
                    CreatedBy_UserName = model.AssignedUserName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = model.AssignedUserName,
                    ModifiedDate = DateTime.Now
                };

                _data.EventLogs.Create(eventLog);
                _data.Save();
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Add Event Log for ticket creation",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Add Event Log for ticket creation",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Add Event Log for ticket creation",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
        }

        //Event log that gets created when a Ticket is updated
        public void AddEventLogTicketEdit(UpdateTicketViewModel model)
        {
            try
            {
                int editTicketId = _data.EventTypes.GetFirst(e => e.EventTypeName.Equals("Edit Ticket")).Id;
                EventLog eventLog = new EventLog()
                {
                    EventTypeId = editTicketId,
                    TicketTrackingNumber = model.TicketId.ToString(),
                    Email = "",
                    CreatedBy_UserName = model.AssignedUserName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = model.AssignedUserName,
                    ModifiedDate = DateTime.Now
                };

                _data.EventLogs.Create(eventLog);
                _data.Save();
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Add Event Log for ticket creation",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Add Event Log for ticket creation",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Add Event Log for ticket creation",
                    exception.Message,
                    model.AssignedUserName);
                throw;
            }
        }

        /// <summary>
        /// Event log that gets created for every email sent
        /// </summary>
        /// <param name="email">Email address that got the email</param>
        /// <param name="ticketId">Ticket related to the email</param>
        /// <param name="userName">User who performed the action</param>
        public void AddEventLogEmailSent(string email, int ticketId, string userName)
        {
            try
            {
                int sentEmailId = _data.EventTypes.GetFirst(e => e.EventTypeName.Equals("Email Sent")).Id;
                EventLog eventLog = new EventLog()
                {
                    EventTypeId = sentEmailId,
                    TicketTrackingNumber = ticketId.ToString(),
                    Email = email,
                    CreatedBy_UserName = userName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = userName,
                    ModifiedDate = DateTime.Now
                };

                _data.EventLogs.Create(eventLog);
                _data.Save();

            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Add Event Log for sending email",
                    exception.Message,
                    userName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception",
                    "Add Event Log for sending email",
                    exception.Message,
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Add Event Log for sending email",
                    exception.Message,
                    userName);
                throw;
            }
        }

        #endregion
    }
}