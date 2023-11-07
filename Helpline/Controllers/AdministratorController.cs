using Helpline.Models;
using Helpline.Services;
using Helpline.ViewModels.AdminViewModels;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpline.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private AdministratorServices _administratorServices;
        private UserServices _userServices;

        public AdministratorController()
        {
            _administratorServices = new AdministratorServices();
            _userServices = new UserServices();
        }
        /* 
         * User View Model is used to determine if the User is an administrator and able to access the View and perform operations       
        TempData["Access"] just determines what modal will pop up
        If user is not an administrator they will be redirected to the Home Page with a modal that will display the TempData["Restricted"] Message
        TempData["AlertSuccess"] is used for Fading Alerts that show up when the user succeeds in creating or updating an object 
        newEntry parameter is used to indicate if the user created a new object and therefore a Fading Success Alert will show up
        */

        #region GET Programs

        // GET: Administrator                

        [HttpGet]
        public ActionResult Programs()
        {
            //Index View for Programs

            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);

            if (isSupervisor)
            {
                //1 means display both active and disabled Programs
                TempData["Access"] = "Allowed";
                AdminIndexViewModel model = new AdminIndexViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }
        
        [HttpGet]
        public ActionResult Program(int id, bool? newEntry)
        {
            //Edit  View for Program

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                UpdateProgramViewModel model = _administratorServices.GetUpdateProgramViewModel(id);

                //Executes when the administrator previously created this Program, Fading Success Alert shows
                if (newEntry == true) TempData["AlertSuccess"] = "Program Created";

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult AddProgram()
        {
            //Create Program View

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                UpdateProgramViewModel model = new UpdateProgramViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region GET Request Types

        
        [HttpGet]
        public ActionResult RequestTypes()
        {
            //Index View for Request Types

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                
                AdminIndexViewModel model = new AdminIndexViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RequestType(int id, bool? newEntry)
        {
            //Edit View for Request Type

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                UpdateRequestTypeViewModel model = _administratorServices.GetEditRequestTypeViewModel(id);

                if (newEntry == true)
                {
                    //Executes when the administrator previously created this Request Type, Fading Success Alert shows
                    TempData["AlertSuccess"] = "Request Type Created";
                }

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AddRequestType()
        {
            //Create View for Request Type

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                UpdateRequestTypeViewModel model = new UpdateRequestTypeViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region GET Routing Categories

        [HttpGet]
        public ActionResult RoutingCategories()
        {
            //Index View for Routing Categories

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                                
                AdminIndexViewModel model = new AdminIndexViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult RoutingCategory(int id, bool? newEntry)
        {
            //Edit and Details View for Routing Category

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                UpdateRoutingCategoryViewModel model = _administratorServices.GetEditRoutingCategoryViewModel(id);

                if (newEntry == true)
                {
                    //Executes when the administrator previously created this Routing Category, Fading Success Alert shows
                    TempData["AlertSuccess"] = "Routing Category Created";
                }

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AddRoutingCategory()
        {
            //Create Routing Category View

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                UpdateRoutingCategoryViewModel model = new UpdateRoutingCategoryViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region GET Office Locations

        [HttpGet]
        public ActionResult OfficeLocations()
        {
            //Index View for Office Locations

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                
                // 1 means display both active and disabled office locations
                AdminIndexViewModel model = new AdminIndexViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult OfficeLocation(int id, bool? newEntry)
        {
            //Edit and Details View for Office Location

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";
                UpdateOfficeLocationViewModel model = _administratorServices.GetOfficeLocation(id);

                if (newEntry == true)
                {
                    //Executes when the administrator previously created this Office Location, Fading Success Alert shows
                    TempData["AlertSuccess"] = "Office Location Created";
                }

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AddOfficeLocation()
        {
            //Create View for Office Location

            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);

            if (isAdministrator)
            {
                TempData["Access"] = "Allowed";

                UpdateOfficeLocationViewModel model = new UpdateOfficeLocationViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region Reports

        public ActionResult Reports()
        {
            bool isCoordinator = _userServices.IsCoordinator(User.Identity.Name);
            if (isCoordinator)
            {
                ReportViewModel model = _administratorServices.GetReportViewModel();

                return View(model);
            }
            else
            {
                TempData["Restricted"] = "Your current role is not a supervisor, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region POST


        [HttpPost] 
        public ActionResult Program(UpdateProgramViewModel model)
        {
            //Edit Program
            // Checks to see if user is authorized
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);

            //Checks to see if there is any duplicate values
            bool duplicate = _administratorServices.PreExistingProgram(model.LongName, model.ProgramId);

            if (ModelState.IsValid && !duplicate && isAdministrator)
            {
                model.UserName = User.Identity.Name;

                int programId = _administratorServices.Edit(model);

                TempData["AlertSuccess"] = "Update Complete"; //Used for Fading Success Alert

                return RedirectToAction("Program", new { id = programId });

            }
            else if (!isAdministrator)
            {
                // If the user is not an administrator
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                // If there is a duplicate entry
                TempData["AlertPreExist"] = "Program Already Exist"; //Creates a Fading Danger(red) Alert

                return RedirectToAction("Program", new { id = model.ProgramId, newEntry = false });
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("Program", new { id = model.ProgramId, newEntry = false });
            }
        }

        [HttpPost] 
        public ActionResult AddProgram(UpdateProgramViewModel model)
        {
            //Create Program

            // Checks to see if user is authorized
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);

            //Checks to see if there is any duplicate values
            bool duplicate = _administratorServices.PreExistingProgram(model.LongName);

            model.UserName = User.Identity.Name;
            model.IsActive = true;
            if (ModelState.IsValid && isAdministrator && !duplicate)
            {
                int programId = _administratorServices.Create(model);

                return RedirectToAction("Program", new { id = programId, newEntry = true });
            }
            else if (!isAdministrator)
            {
                //Executes if the user is not authorized
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                // Executes if this is a duplicate entry
                TempData["AlertPreExist"] = "Duplicate Entry"; //Creates a Fading Danger(red) Alert

                return RedirectToAction("AddProgram");

            }
            else
            {
                TempData["Error"] = "Invalid Input";
                return RedirectToAction("AddProgram");
            }
        }

        [HttpPost] 
        public ActionResult RequestType(UpdateRequestTypeViewModel model)
        {
            //Edit Request Type
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            bool duplicate = _administratorServices.PreExistingRequestType(model.Name, model.RequestTypeId);

            if (ModelState.IsValid && isAdministrator && !duplicate)
            {
                model.UserName = User.Identity.Name;
                int requestTypeId = _administratorServices.Edit(model);

                //Used for Fading Success Alert
                TempData["AlertSuccess"] = "Update Complete"; 

                return RedirectToAction("RequestType", new { id = requestTypeId, newEntry = false });
            }
            else if (!isAdministrator)
            {
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                //Creates a Fading Danger(red) Alert
                TempData["AlertPreExist"] = "Request Type Already Exist"; 
                
                return RedirectToAction("RequestType", new { id = model.RequestTypeId, newEntry = false });
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("RequestType", new { id = model.RequestTypeId, newEntry = false });
            }
        }

        [HttpPost] 
        public ActionResult AddRequestType(UpdateRequestTypeViewModel model)
        {
            //Create Request Type
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            bool duplicate = _administratorServices.PreExistingRequestType(model.Name);

            model.UserName = User.Identity.Name;
            model.IsActive = true;
            if (ModelState.IsValid && !duplicate && isAdministrator)
            {
                int requestTypeId = _administratorServices.Create(model);

                //Used for Fading Success Alert
                TempData["AlertSuccess"] = "Update Complete"; 
                
                //newEntry boolean value is used for Fading Success Alert in the Request Type ActionResult                
                return RedirectToAction("RequestType", new { id = requestTypeId, newEntry = true });
            }
            else if (!isAdministrator)
            {
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                //Creates a Fading Danger(red) Alert
                TempData["AlertPreExist"] = "Request Type Name Already Exists"; 

                return RedirectToAction("AddRequestType");
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("AddRequestType");
            }
        }

        [HttpPost] 
        public ActionResult RoutingCategory(UpdateRoutingCategoryViewModel model)
        {
            //Edit Routing Category
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            bool duplicate = _administratorServices.PreExistingRoutingCategory(model.Name, model.Id);

            if (ModelState.IsValid && isAdministrator && !duplicate)
            {
                //create service method that deals with the view model instead
                int routingCategoryId = _administratorServices.Edit(model, User.Identity.Name);

                //Used for Fading Success Alert
                TempData["AlertSuccess"] = "Update Complete"; 

                return RedirectToAction("RoutingCategory", new { id = routingCategoryId, newEntry = false });

            }
            else if (!isAdministrator)
            {
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                //Creates a Fading Danger(red) Alert
                TempData["AlertPreExist"] = "Routing Category Already Exists"; 

                return RedirectToAction("RoutingCategory", new { id = model.Id, newEntry = false });
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("RoutingCategory", new { id = model.Id, newEntry = false });
            }
        }

        [HttpPost] 
        public ActionResult AddRoutingCategory(UpdateRoutingCategoryViewModel model)
        {
            //Create Routing Category
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            bool duplicate = _administratorServices.PreExistingRoutingCategory(model.Name);

            if (ModelState.IsValid && !duplicate && isAdministrator)
            {
                int routingCategoryId = _administratorServices.Create(model, User.Identity.Name);

                //newEntry boolean value is used for Fading Success Alert in the Routing Category ActionResult
                return RedirectToAction("RoutingCategory", new { id = routingCategoryId, newEntry = true });
            }
            else if (!isAdministrator)
            {
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                //Creates a Fading Danger(red) Alert
                TempData["AlertPreExist"] = "Routing Category Already Exist"; 

                return RedirectToAction("AddRoutingCategory");
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("AddRoutingCategory");
            }
        }

        [HttpPost] 
        public ActionResult OfficeLocation(UpdateOfficeLocationViewModel model)
        {
            //Edit Office Location
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            bool duplicate = _administratorServices.PreExistingOfficeLocation(model.Name, model.OfficeLocationId);
            model.UserName = User.Identity.Name;
            if (ModelState.IsValid && !duplicate && isAdministrator)
            {
                int officeLocationId = _administratorServices.Edit(model);

                //Used for Fading Success Alert
                TempData["AlertSuccess"] = "Update Complete"; 

                return RedirectToAction("OfficeLocation", new { id = officeLocationId, newEntry = false });

            }
            else if (!isAdministrator)
            {
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                //Creates a Fading Danger(red) Alert
                TempData["AlertPreExist"] = "Office Location Already Exist"; 

                return RedirectToAction("OfficeLocation", new { id = model.OfficeLocationId, newEntry = false });
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("OfficeLocation", new { id = model.OfficeLocationId, newEntry = false });
            }




        }

        [HttpPost] 
        public ActionResult AddOfficeLocation(UpdateOfficeLocationViewModel model)
        {
            //Create Office Location
            bool isAdministrator = _userServices.IsSupervisor(User.Identity.Name);
            bool duplicate = _administratorServices.PreExistingOfficeLocation(model.Name);
            model.UserName = User.Identity.Name;
            if (ModelState.IsValid && !duplicate && isAdministrator)
            {
                int regionId = _administratorServices.Create(model);

                //newEntry boolean value is used for Fading Success Alert in the Office Location ActionResult
                return RedirectToAction("OfficeLocation", new { id = regionId, newEntry = true });

            }
            else if (!isAdministrator)
            {
                TempData["Restricted"] = "You are not an Administrator therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
            else if (duplicate)
            {
                //Creates a Fading Danger(red) Alert
                TempData["AlertPreExist"] = "Office Location Already Exists"; 

                return RedirectToAction("AddOfficeLocation");
            }
            else
            {
                TempData["Error"] = "Invalid Input";

                return RedirectToAction("AddOfficeLocation");
            }
        }


        #endregion


        #region JSON

        //JsonResults are used to gather JSON data for the Data Tables in the Index Views to display to to the user

        [HttpGet]
        public JsonResult ProgramData(bool? status)
        {            
            var results = _administratorServices.GetPrograms(status);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RequestTypeData(bool? status)
        {
            var results = _administratorServices.GetRequestTypes(status);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RoutingCategoryData(bool? status)
        {
            var results = _administratorServices.GetRoutingCategories(status);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OfficeLocationData(bool? status)
        {
            var results = _administratorServices.GetOfficeLocations(status);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult BarChartData(DateTime startDate, DateTime? endDate)
        {
            //Gets data for the bar graph.
            var results = _administratorServices.GetBarChartData(startDate, endDate);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LineChartData(int programId,
            DateTime startDate,
            DateTime? endDate,
            int? routingCategoryId,
            int? requestTypeId,
            int? communicationTypeId,
            int? countyId,
            string city,
            string streetName)
        {
            var results = _administratorServices.GetLineChartData(programId,
                startDate,
                endDate,
                routingCategoryId,
                requestTypeId,
                communicationTypeId,
                countyId,
                city,
                streetName);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}