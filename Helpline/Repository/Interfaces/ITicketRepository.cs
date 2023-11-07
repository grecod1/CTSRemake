using Helpline.Models;
using Helpline.ViewModels;
using Helpline.ViewModels.RouteViewModels;
using Helpline.ViewModels.TicketViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface ITicketRepository
    {              
        int GetAddressTypeId(string addressType);        

        IEnumerable<TicketListViewModel> GetTickets(TicketIndexViewModel parameters, 
            int physicalAddressId,
            int disabledStatusId,
            int amount);
        IEnumerable<TicketListViewModel> GetTicketHistory(TicketIndexViewModel model);
        int GetTicketSatistics(TicketIndexViewModel model);                        
        void UpdatePhoneNumberList(UpdateTicketViewModel model);
    }
}
