using Helpline.DTOs.AdministratorDTOs;
using Helpline.Repository;
using Helpline.Services;
using Helpline.ViewModels.EventLogViewModels;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpline.Controllers
{
    public class EventLogController : Controller
    {
        private UserServices _userServices;
        private EventLogServices _eventLogServices;

        public EventLogController()
        {
            _userServices = new UserServices();
            _eventLogServices = new EventLogServices();
        }

        /* User View Model is used to determine if the user is an administartor. 
            If the user is not an administrator they will be redirected to the home page, 
            and a modal will show up with the message that has the value as TempData["Restricted"]*/

        // GET: EventLog
        // Event Log Index View
        [HttpGet]
        public ActionResult Index()
        {
            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            if (isSupervisor)
            {
                TempData["Access"] = "Allowed";
                EventLogIndexViewModel model = _eventLogServices.GetIntialEventLogIndexViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = $"Your role is not a supervisor role, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }

        }

        //Gathers JSON data for the Data Table in the Event Log Index View for the administrator to see
        public JsonResult GetEventLogData(int? eventTypeId, DateTime? startDate, DateTime? endDate, string userName, string trackingNumber)
        {
            IEnumerable<EventLogDTO> results = _eventLogServices.GetEventLogData(eventTypeId, startDate, endDate, userName, trackingNumber);

            return Json(results, JsonRequestBehavior.AllowGet);
        }
        
    }
}