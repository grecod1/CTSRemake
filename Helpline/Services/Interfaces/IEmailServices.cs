using Helpline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface IEmailServices
    {
        bool SendEmail(UpdateTicketViewModel model, bool updateTicket, string reason);
        //bool SendUpdateEmail(UpdateTicketViewModel model)
        void SendErrorEmail(string errorType, string task, string message, string userName, DateTime time);
    }
}
