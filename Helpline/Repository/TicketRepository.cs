using Helpline.Data;
using Helpline.DTOs.TicketDTOs;
using Helpline.Models;
using Helpline.ViewModels;
using Helpline.ViewModels.RouteViewModels;
using Helpline.ViewModels.TicketViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class TicketRepository
    {
        private HelplineDbContext _dbContext;

        public TicketRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        public TicketRepository(HelplineDbContext context)
        {
            _dbContext = context;
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        #region Query        
        
        

        /// <summary>
        /// This specific method had to be created for 
        /// the ticket index view. The Query in the ticket 
        /// index view requires a Join clause. The generic 
        /// repository methods would cause a memory isusue 
        /// so this method had to be made for memory efficiency.
        /// </summary>
        /// <param name="model">View model that holds paramters</param>
        /// <param name="physicalAddressId">Id of the Physical Address Type is needed.</param>
        /// <param name="disabledStatusId">Id of the disabled Status Id is required.</param>
        /// <returns>List of view models that gets translated into JSON data for 
        /// the ticket index view. </returns>
        public IEnumerable<TicketListDTO> GetTickets(TicketIndexViewModel model, 
            int physicalAddressId,
            int disabledStatusId,
            int amount)
        {
                        

            /*In the where clauses there are certain fields that check if the certain parameters are
             both a blank string or null. The reason why is this method is used to get excel data
            in the mvc action result while the other way this method is used is to get JSON data 
            through an AJAX call. In the user does not type in anyhing in certain parameters for the 
            AJAX JSON call then those parameters will be a blank string, but if the use types in nothing 
            and this is a excel file call then those parameters will be a null value.*/
            var tickets = _dbContext.Tickets
                .Include("RequestType")
                .Include("Status")
                .Include("PhoneNumbers")
                .Include("Addresses")
                .Include("County")
                .Include("Routes")
                .Include("RoutingCategory")
                .Include("Program")
                .Include("Emails")
                .Join(_dbContext.Users, 
                    ticket => ticket.CreatedBy_UserName, 
                    user => user.UserName,
                    (ticket, user) => new
                    {
                        /*The inner join is needed because only th user names fields are used to join 
                         * the ticket and user model. */
                        Ticket = ticket,
                        RequestType = ticket.RequestType.Name,
                        Status = ticket.Status.Name,
                        Email = ticket.Emails.FirstOrDefault(),
                        PhysicalAddress = ticket.Addresses
                            .FirstOrDefault(address => address.AddressTypeId == physicalAddressId),
                        County = ticket.Addresses
                            .FirstOrDefault(address => address.AddressTypeId == physicalAddressId).County.Name,
                        CurrentRoute = ticket.Routes
                            .OrderByDescending(route => route.CreationDate)
                            .FirstOrDefault(),
                        RoutingCategory = ticket.Routes
                            .OrderByDescending(route => route.CreationDate)
                            .Select(route => route.RoutingCategory.Name)
                            .FirstOrDefault(),
                        Program = ticket.Routes
                            .OrderByDescending(route => route.CreationDate)
                            .Select(route => route.Program.LongName)
                            .FirstOrDefault(),
                        FullUserName = string.Concat(user.FirstName, " ", user.LastName)
                    })
                .Where(ticket => model.CommunicationTypeId == null 
                    || ticket.Ticket.CommunicationTypeId == model.CommunicationTypeId)
                .Where(ticket => model.RequestTypeId == null 
                    || ticket.Ticket.RequestTypeId == model.RequestTypeId)
                .Where(ticket => string.IsNullOrEmpty(model.ReferredFrom)
                    || ticket.Ticket.ReferredFrom == model.ReferredFrom)
                .Where(ticket => string.IsNullOrEmpty(model.Bureau)
                    || ticket.Ticket.Bureau == model.Bureau)
                .Where(ticket => model.EndDate == null 
                    || ticket.Ticket.CreationDate <= model.EndDate)
                .Where(ticket => model.StartDate == null 
                    || ticket.Ticket.CreationDate >= model.StartDate)
                .Where(ticket => 
                    (model.StatusId == null && ticket.Ticket.StatusId != disabledStatusId) 
                    || ticket.Ticket.StatusId == model.StatusId)
                .Where(ticket => model.RouteCategoryId == null 
                    || ticket.CurrentRoute.RoutingCategoryId == model.RouteCategoryId)
                .Where(ticket => model.ProgramId == null 
                    || ticket.CurrentRoute.ProgramId == model.ProgramId)
                .Where(ticket => string.IsNullOrEmpty(model.PhoneNumber)
                    || ticket.Ticket.PhoneNumbers.Any(p => p.Number.Contains(model.PhoneNumber)))
                .Where(ticket => string.IsNullOrEmpty(model.StreetNumber)
                    || ticket.PhysicalAddress.StreetNumber.Contains(model.StreetNumber))
                .Where(ticket => string.IsNullOrEmpty(model.StreetName)
                    || ticket.PhysicalAddress.StreetName.Contains(model.StreetName))
                .Where(ticket => string.IsNullOrEmpty(model.City)
                    || ticket.PhysicalAddress.City.Contains(model.City))
                .Where(ticket => model.CountyId == null 
                    || ticket.PhysicalAddress.CountyId == model.CountyId)
                .Where(ticket => string.IsNullOrEmpty(model.State)
                    || ticket.PhysicalAddress.State == model.State)
                .Where(ticket => string.IsNullOrEmpty(model.TrackingNumber)
                    || ticket.Ticket.Id.ToString().Contains(model.TrackingNumber.Trim()))
                .Where(ticket => string.IsNullOrEmpty(model.FirstName)
                    || ticket.Ticket.FirstName.Contains(model.FirstName.Trim()))
                .Where(ticket => string.IsNullOrEmpty(model.LastName)
                    || ticket.Ticket.LastName.Contains(model.LastName.Trim()))
                .Where(ticket => string.IsNullOrEmpty(model.Affiliation)
                    || ticket.Ticket.Affiliation.Contains(model.Affiliation))                
                .Where(ticket => string.IsNullOrEmpty(model.Email) 
                    // Must ALWAYS make sure email is not null.                    
                    || (ticket.Email != null && ticket.Email.EmailAddress.Contains(model.Email)))
                .Where(ticket => string.IsNullOrEmpty(model.CreatedBy_UserName)
                    || ticket.Ticket.CreatedBy_UserName.Contains(model.CreatedBy_UserName)
                    || ticket.FullUserName.Contains(model.CreatedBy_UserName))
                .OrderByDescending(ticket => ticket.Ticket.CreationDate)
                .Take(amount)
                .ToList()
                .Select(t => new TicketListDTO()
                {
                    TicketId = t.Ticket.Id,
                    DisplayDate = t.Ticket.CreationDate.ToShortDateString(),
                    Status = t.Status,
                    RequestType = t.RequestType,
                    RoutingCategory = t.RoutingCategory,
                    Program = t.Program,
                    ContactName = $"{t.Ticket.FirstName} {t.Ticket.LastName}",
                    County = t.County
                });

            return tickets;
        }
        

        /// <summary>
        /// Gets the count of tickets based on the search parameters.
        /// </summary>
        /// <param name="model">View model that holds search parameters.</param>
        /// <param name="physicalAddressId">Physical Address Id</param>
        /// <param name="disabledStatusId">Disabled Ticket Id</param>
        /// <returns>Count of tickets based on search parameters.</returns>
        public int GetTicketCount(TicketIndexViewModel model, 
            int physicalAddressId, 
            int disabledStatusId)
        {            
            //Ensures that the tickets created on a certain date will show up                                
            TimeSpan oneDay = TimeSpan.FromDays(1); 
            DateTime? EndDate = model.EndDate + oneDay;

            return _dbContext.Tickets
                .Include("PhoneNumbers")
                .Include("Emails")
                .GroupJoin(_dbContext.Routes, t => t.Id, r => r.TicketId,
                (t, r) => new
                {
                    Ticket = t,                    
                    t.PhoneNumbers,
                    Email = t.Emails.FirstOrDefault(),
                    //only the active or most recent route is linked to the ticket
                    Route = r.OrderByDescending(rt => rt.CreationDate)
                        .FirstOrDefault() 
                })
                .GroupJoin(_dbContext.Addresses, 
                    t => t.Ticket.Id, 
                    a => a.TicketId,                     
                    (t, a) => new
                    {
                        t.Ticket,    
                        t.Email,
                        t.PhoneNumbers,
                        t.Route,
                        Address = a.Where(ad => ad.AddressTypeId == physicalAddressId).FirstOrDefault()
                    })
                .Join(_dbContext.Users, 
                    t => t.Ticket.CreatedBy_UserName, 
                    u => u.UserName, 
                    (t, u) => new
                    {
                        t.Ticket,      
                        t.Email,
                        t.PhoneNumbers,
                        t.Route,
                        t.Address,
                        User = string.Concat(u.FirstName, " ", u.LastName)
                    })
                .Where(t => model.CommunicationTypeId == null 
                    || t.Ticket.CommunicationTypeId == model.CommunicationTypeId) 
                .Where(t => string.IsNullOrEmpty(model.ReferredFrom)
                    || t.Ticket.ReferredFrom == model.ReferredFrom)
                .Where(t => string.IsNullOrEmpty(model.Bureau) 
                    || t.Ticket.Bureau == model.UserName)
                .Where(t => model.RequestTypeId == null 
                    || t.Ticket.RequestTypeId == model.RequestTypeId)
                .Where(t => model.EndDate == null 
                    || t.Ticket.CreationDate <= EndDate)
                .Where(t => model.StartDate == null 
                    || t.Ticket.CreationDate >= model.StartDate)
                .Where(t => model.StatusId == null 
                    || t.Ticket.StatusId == model.StatusId)
                .Where(t => model.RouteCategoryId == null 
                    || t.Route.RoutingCategoryId == model.RouteCategoryId)
                .Where(t => model.ProgramId == null 
                    || t.Route.ProgramId == model.ProgramId)
                .Where(t => string.IsNullOrEmpty(model.PhoneNumber)
                    || t.PhoneNumbers.Any(p => p.Number.Contains(model.PhoneNumber)))
                .Where(t => string.IsNullOrEmpty(model.StreetNumber) 
                    || t.Address.StreetNumber.Contains(model.StreetNumber.Trim()))
                .Where(t => string.IsNullOrEmpty(model.StreetName) 
                    || t.Address.StreetName.Contains(model.StreetName.Trim()))
                .Where(t => string.IsNullOrEmpty(model.City) 
                    || t.Address.City.Contains(model.City.Trim()))
                .Where(t => model.CountyId == null 
                    || t.Address.CountyId == model.CountyId)
                .Where(t => string.IsNullOrEmpty(model.State)
                    || t.Address.State == model.State)
                .Where(t => string.IsNullOrEmpty(model.TrackingNumber) 
                    || t.Ticket.Id.ToString().Contains(model.TrackingNumber.Trim()))
                .Where(t => string.IsNullOrEmpty(model.FirstName) 
                    || t.Ticket.FirstName.Trim() == model.FirstName.Trim())
                .Where(t => string.IsNullOrEmpty(model.LastName) 
                    || t.Ticket.LastName.Trim() == model.LastName.Trim())
                .Where(t => string.IsNullOrEmpty(model.Affiliation) 
                    || t.Ticket.Affiliation == model.Affiliation)
                .Where(ticket =>
                    (model.StatusId == null && ticket.Ticket.StatusId != disabledStatusId)
                    || ticket.Ticket.StatusId == model.StatusId)
                .Where(t => string.IsNullOrEmpty(model.Email) 
                    || (t.Email != null && t.Email.EmailAddress.Contains(model.Email)))
                .Where(t => string.IsNullOrEmpty(model.CreatedBy_UserName)
                    || t.Ticket.CreatedBy_UserName.Contains(model.CreatedBy_UserName)
                    || t.User.Contains(model.CreatedBy_UserName))
                .Count();
            
        }
        

        #endregion
    }
}