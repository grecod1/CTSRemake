using Helpline.ViewModels.StatisticsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface ISatisticRepository
    {
        IEnumerable<SatisticListViewModel> GetSatistics(DateTime date, int programId);        
    }
}
