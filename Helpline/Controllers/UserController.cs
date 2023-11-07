using Helpline.DTOs.AdministratorDTOs;
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
    public class UserController : Controller
    {
        // Must finish Edit View 

        private EmailServices _emailServices;
        private UserServices _userServices;

        public UserController()
        {
            _emailServices = new EmailServices();
            _userServices = new UserServices();
        }

        #region GET

        // GET: User

        [HttpGet]
        public ActionResult Index()
        {
            // Index View for Users

            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            if (isSupervisor)
            {
                TempData["Access"] = "Allowed";

                // 1 means both active and disabled users
                AdminIndexViewModel model = new AdminIndexViewModel();

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "Your role is not a supervisor, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            if (isSupervisor)
            {
                TempData["Access"] = "Allowed";
                UpdateUserViewModel model = _userServices.GetCreateViewModel(User.Identity.Name);

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "Your role is not a supervisor, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id, bool? newEntry)
        {
            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            if (isSupervisor)
            {
                TempData["Access"] = "Allowed";
                UpdateUserViewModel model = _userServices.GetEditViewModel(id, User.Identity.Name);
                if (newEntry != null)
                {
                    if (newEntry == true)
                    {
                        TempData["AlertSuccess"] = "User Created";
                    }
                }

                return View(model);
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "Your role is not a supervisor, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region Post

        [HttpPost]
        public ActionResult Create(UpdateUserViewModel model)
        {
            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            if (isSupervisor)
            {
                if (ModelState.IsValid)
                {
                    int userId = _userServices.CreateUser(model, User.Identity.Name);
                
                    // 0 means the entry already exist
                    if (userId == 0)
                    {
                        TempData["Alert"] = "User Already Exists";

                        return RedirectToAction("Create");
                    }
                    else
                    {
                        return RedirectToAction("Edit", new { id = userId, newEntry = true });
                    }
                }
                else
                {
                    TempData["Invalid"] = "Invalid Entry";
                    _emailServices.SendErrorEmail("Malicious Input", 
                        "Create User", 
                        "Invalid Input", 
                        User.Identity.Name, 
                        DateTime.Now);

                    return RedirectToAction("Create");
                }
                
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "Your role is not a supervisor, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(UpdateUserViewModel model)
        {
            bool isSupervisor = _userServices.IsSupervisor(User.Identity.Name);
            if (isSupervisor)
            {
                if (ModelState.IsValid)
                {
                    bool alreadyExist = _userServices.DuplicateUserName(model.UserName, model.Id);
                    if (alreadyExist)
                    {
                        TempData["AlertPreExist"] = "User Name Already Exist";

                        return RedirectToAction("Edit", new { id = model.Id });
                    }
                    else
                    {
                        int userId = _userServices.Edit(model, User.Identity.Name);
                        TempData["AlertSuccess"] = "Update Complete";

                        return RedirectToAction("Edit", new { @id = userId });
                    }
                }
                else
                {
                    TempData["Invalid"] = "Invalid Entry";
                    _emailServices.SendErrorEmail("Malicious Input", 
                        "Edit User", 
                        "Invalid Input", 
                        User.Identity.Name, 
                        DateTime.Now);

                    return RedirectToAction("Edit", new { id = model.Id });
                }
                
            }
            else
            {
                TempData["Access"] = "Denied";
                TempData["Restricted"] = "Your current role is not a supervisor, therefore you are not authorized";

                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region JSON

        public JsonResult GetUserData(bool? status)
        {
            IEnumerable<UserListDTO> results = _userServices.GetUserData(status);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}