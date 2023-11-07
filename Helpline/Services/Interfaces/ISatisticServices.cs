using Helpline.ViewModels.StatisticsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface ISatisticServices
    {
        SatisticsViewModel GetInitialSatisticViewModel();
        List<Object> GetData(DateTime? date, int programId);
    }
}
