using Helpline.Data;
using Helpline.Repository.Interfaces;
using Helpline.ViewModels.StatisticsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class SatisticRepository : ISatisticRepository
    {
        private HelplineDbContext _dbContext;

        public SatisticRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        /// <summary>
        /// This method gathers data and creates the View Model for the County Information View. This gathers the data about the 
        /// relationship between Counties and Programs. The two numeric fields are the number of tickets under a selected program 
        /// per selected date, and the second numeric field is the overall number of programs for that county.        
        /// </summary>
        /// <param name="date">Certain Date user selects</param>
        /// <param name="programId">Selected Program compared to the Counties</param>
        /// <returns></returns>
        public IEnumerable<SatisticListViewModel> GetSatistics(DateTime date, int programId)
        {
            int physicalTypeId = GetAddressTypeId("Physical");
            //Ensures that the tickets created on the selected date will show up
            TimeSpan oneDay = TimeSpan.FromDays(1); 
            DateTime? EndDate = date.AddDays(1);
            DateTime? StartDate = date - oneDay;
            IEnumerable<SatisticListViewModel> model = _dbContext.Counties.Select(c => new SatisticListViewModel()
            {
                CountyId = c.Id,
                CountyName = c.Name,
                OneDayRequest = _dbContext.Tickets.GroupJoin(_dbContext.Routes, t => t.Id, r => r.TicketId, (t, r) => new
                {
                    Ticket = t,
                    Route = r.OrderByDescending(rt => rt.CreationDate).FirstOrDefault()
                }).GroupJoin(_dbContext.Addresses, t => t.Ticket.Id, a => a.TicketId, (t, a) => new
                {
                    t.Ticket,
                    t.Route,
                    Address = a.Where(ad => ad.AddressTypeId == physicalTypeId).FirstOrDefault()
                }).Where(t => t.Address.CountyId == c.Id && t.Route.ProgramId == programId 
                    && t.Route.CreationDate <= EndDate && t.Route.CreationDate >= date).Count(),
                TotalRequest = _dbContext.Tickets.GroupJoin(_dbContext.Routes, t => t.Id, r => r.TicketId, (t, r) => new
                {
                    Ticket = t,
                    Route = r.OrderByDescending(rt => rt.CreationDate).FirstOrDefault()
                }).GroupJoin(_dbContext.Addresses, t => t.Ticket.Id, a => a.TicketId, (t, a) => new
                {
                    t.Ticket,
                    t.Route,
                    Address = a.Where(ad => ad.AddressTypeId == physicalTypeId).FirstOrDefault()
                }).Where(t => t.Address.CountyId == c.Id && t.Route.ProgramId == programId).Count()                                
            });
            

            return model;
        }         

        //This private method is used in the main GetSatistics method. and is used to get the Id of the physical address type in the database
        private int GetAddressTypeId(string addressType)
        {
            return _dbContext.AddressTypes.Where(a => a.Name == addressType).Select(s => s.Id).FirstOrDefault();
        }

    }
}