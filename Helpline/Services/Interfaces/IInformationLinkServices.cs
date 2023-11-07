using Helpline.ViewModels.InformationLinkViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface IInformationLinkServices
    {
        InformationLinkIndexViewModel GetInformationLinkIndex(string userName);
    }
}
