using Helpline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface IInformationLinkRepository
    {
        IEnumerable<InformationLink> GetInformationLinks();
    }
}
