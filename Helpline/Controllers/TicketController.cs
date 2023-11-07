using Helpline.Services;
using Helpline.ViewModels;
using Helpline.ViewModels.TicketViewModels;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpline.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private TicketServices _ticketServices;
        private RouteServices _routeServices;
        private UserServices _userServices;
        private EventLogServices _eventLogServices;
        private EmailServices _emailServices;

        public TicketController()
        {
            _ticketServices = new TicketServices();
            _routeServices = new RouteServices();
            _userServices = new UserServices();
            _eventLogServices = new EventLogServices();
            _emailServices = new EmailServices();
        }
        /* TempData["Access"] just determines what modal will show up
        User View Model is used to determine if the user is authorized 
        to access the page. If the user is not authorized to access the 
        page, the user will be redirected back to the Home Page with a 
        modal that will have the text provided by TempData["Restricted"]        
        The emailSent parameter is only true when an email was sent to a 
        routing category and that would mean the user would get a modal 
        informing them that emails were sent TempData["AlertSuccess"] 
        determines if a Fading Success Alert will show up in the details 
        view right after a user creates a Ticket, edits a Ticket, or edits 
        a note */


        #region GET        

        //Ticket Index View
        public ActionResult Index()
        {
            //Creates select list for Ticket Index View
            TicketIndexViewModel model = _ticketServices.Index(User.Identity.Name);

            return View(model);
        }

        [HttpGet]
        // The email boolean tells if an email is sent when Creating a ticket,
        // and the fromIndex boolean is for when the User is navigating from the Index view.
        public ActionResult Details(int id, bool email = false, bool fromIndex = false)
        {
            TicketDetailsViewModel model = _ticketServices.Details(id, User.Identity.Name, email);
            model.FromIndex = fromIndex;

            return View(model);
        }

        //Create Ticket View
        [HttpGet]
        public ActionResult Create()
        {
            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);
            if (canEdit)
            {
                UpdateTicketViewModel model = _ticketServices.GetCreateViewModel(User.Identity.Name);

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not currently authorized to edit tickets.";

                return RedirectToAction("Index", "Home");
            }
        }

        //Edit Ticket View Model
        [HttpGet]
        public ActionResult Edit(int id)
        {
            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);
            if (canEdit)
            {
                UpdateTicketViewModel model = _ticketServices.GetEditViewModel(id, User.Identity.Name);

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are currently not authorized to edit tickets.";

                return RedirectToAction("Index", "Home");
            }
        }

        //View for editing notes
        [HttpGet]
        public ActionResult EditNote(int id)
        {
            UpdateNoteViewModel model = _ticketServices.GetUpdateNotesViewModel(id, User.Identity.Name);

            //The User View Model is being used because it contains properties that are needed ni this Action Result
            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);

            //Only the user who created the notes or an administartor is allowed in this view
            if (isSupervisor || User.Identity.Name == model.CreatedByUser && canEdit)
            {
                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";

                return RedirectToAction("Details", new { id = model.TicketId });
            }
        }

        [HttpGet]
        public ActionResult Images(int id)
        {
            // The id is the ticket id.

            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);
            if (canEdit)
            {
                TicketImagesViewModel model = new TicketImagesViewModel(id);

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not currently authorized to edit tickets.";

                return RedirectToAction("Index", "Home");
            }            
        }

        #endregion


        #region POST


        [HttpPost] //Create Ticket
        public ActionResult Create(UpdateTicketViewModel model)
        {
            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);

            if (ModelState.IsValid && canEdit)
            {                
                model.AssignedUserName = User.Identity.Name;
                int ticketId = _ticketServices.Create(model);
                model.TicketId = ticketId;
                _routeServices.Create(model);                
                string emailReason = "A ticket has been created and routed to your area <strong>(Route)</strong>";
                bool emailSent = _emailServices.SendEmail(model, false, emailReason);
                _eventLogServices.AddEventLogTicketCreate(model);

                TempData["AlertSuccess"] = "Ticket Created";

                return RedirectToAction("Details", new { id = ticketId, email = emailSent });
            }
            else if (!canEdit)
            {
                //If the user is not authorized to create tickets

                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not currently authorized to edit tickets.";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //If model state is not valid and input
                TempData["Invalid"] = "Invalid Input";
                _emailServices.SendErrorEmail("Malicious Input", 
                    "Create Ticket", 
                    "Invalid Input", 
                    User.Identity.Name, 
                    DateTime.Now);

                return RedirectToAction("Create");
            }

        }

        [HttpPost] //Update Ticket
        public ActionResult Edit(UpdateTicketViewModel model)
        {
            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);

            if (ModelState.IsValid && canEdit)
            {
                int ticketId = model.TicketId;
                model.AssignedUserName = User.Identity.Name;
                bool emailSent = _ticketServices.Edit(model);

                _eventLogServices.AddEventLogTicketEdit(model);
                TempData["AlertSuccess"] = "Update Complete";

                return RedirectToAction("Details", new { id = ticketId, email = emailSent });
            }
            else if (!canEdit)
            {
                // If user is not authorized to edit ticket

                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not currently authorized to edit tickets.";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //If model state is not valid
                TempData["Invalid"] = "Invalid Input";
                _emailServices.SendErrorEmail("Malicious Input", 
                    "Create Ticket", 
                    "Invalid Input", 
                    User.Identity.Name, 
                    DateTime.Now);

                return RedirectToAction("Edit", new { id = model.TicketId });
            }


        }

        [HttpPost] //Update Note
        public ActionResult EditNote(UpdateNoteViewModel model)
        {
            bool canEdit = _userServices.CanEditInformation(User.Identity.Name);

            if (ModelState.IsValid && canEdit)
            {
                model.LastModifiedByUserName = User.Identity.Name;
                _ticketServices.UpdateNote(model);
                TempData["AlertSuccess"] = "Update Complete";

                return RedirectToAction("Details", new { id = model.TicketId });
            }
            else if (!canEdit)
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = $"You are not authorized to edit notes";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Invalid"] = "Invalid Input";
                _emailServices.SendErrorEmail("Malicious Input", 
                    "Edit Notes", 
                    "Invalid Input", 
                    User.Identity.Name, 
                    DateTime.Now);

                return RedirectToAction("EditNote", new { id = model.NoteId });
            }

        }

        #endregion        


        #region Image

        [HttpGet]
        public FileResult Image(int id)
        {
            byte[] data = _ticketServices.GetImage(id);
            return File(data, "image/jpeg");
        }

        #endregion


        #region Excel Data

        [HttpGet]
        public FileResult Excel(TicketIndexViewModel model)
        {
            byte[] data = _ticketServices.GetExcelTicketData(model, User.Identity.Name);

            string contentType =
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            string fileName = "Report.xlsx";

            return File(data, contentType, fileName);
        }

        #endregion

    }
}
