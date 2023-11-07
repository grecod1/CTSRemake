using Helpline.Repository;
using Helpline.Repository.Interfaces;
using Helpline.Services.Interfaces;
using Helpline.ViewModels.StatisticsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Services
{
    public class SatisticServices : ISatisticServices
    {
        ITicketRepository TicketRepository = new TicketRepository();
        ISatisticRepository SatisticRepository = new SatisticRepository();

        public SatisticsViewModel GetInitialSatisticViewModel()
        {
            SatisticsViewModel model = new SatisticsViewModel()
            {
                Date = null,
                Programs = TicketRepository.GetPrograms()                
            };

            return model;
        }

        public List<Object> GetData(DateTime? date, int programId)
        {
            date = date == null ? DateTime.Now.AddDays(1) : date;
            var results = new List<Object>();
            IEnumerable<SatisticListViewModel> model = SatisticRepository.GetSatistics((DateTime)date, programId);            

            foreach (SatisticListViewModel satistic in model)
            {
                results.Add(new
                {
                    CountyName = satistic.CountyName,
                    OneDayRequest = satistic.OneDayRequest,
                    TotalRequest = satistic.TotalRequest
                });
            }

            return results;
        }
    }
}