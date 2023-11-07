using Helpline.Models;
using Helpline.ViewModels;
using Helpline.ViewModels.RouteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    /// <summary>
    /// Contains ontains a list of methods that 
    /// involve updating and creating new route models under 
    /// a ticket.
    /// </summary>
    interface IRouteServices
    {
        /// <summary>
        /// Create New Route
        /// </summary>
        /// <param name="model">View model that holds form data</param>
        void Create(UpdateTicketViewModel model);

        /// <summary>
        /// This creates a new route as well, but the difference is that this 
        /// happens when the ticket updates and either the Program 
        /// or Routing Category changes.
        /// </summary>
        /// <param name="model">Update Ticket View Model used when the Ticket gets updated</param>
        /// <returns>returns true if at least one email was sent</returns>
        void Update(UpdateTicketViewModel model);        
    }
}