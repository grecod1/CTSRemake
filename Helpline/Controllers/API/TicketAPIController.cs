using Helpline.DTOs.TicketDTOs;
using Helpline.Services;
using Helpline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Helpline.Controllers.API
{
    public class TicketAPIController : ApiController
    {
        private TicketServices _ticketService;

        public TicketAPIController()
        {
            _ticketService = new TicketServices();
        }

        [HttpGet]
        [Route("API/TicketAPI/Tickets")]
        public IEnumerable<TicketListDTO> GetTickets([FromUri]TicketIndexViewModel model)
        {
            return _ticketService.GetTickets(model);
        }

        [HttpGet]
        [Route("API/TicketAPI/Count")]
        public int GetCount([FromUri]TicketIndexViewModel model)
        {
            return _ticketService.GetTicketCount(model);
        }
    }
}
