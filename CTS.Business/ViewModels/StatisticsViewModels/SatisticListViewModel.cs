using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.StatisticsViewModels
{
    public class SatisticListViewModel
    {
        /*Used as the list objects in the County Information View. */
        public int? CountyId { get; set; }
        public string? CountyName { get; set; }
        public int? OneDayRequest { get; set; }
        public int? TotalRequest { get; set; }
    }
}