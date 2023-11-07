using Helpline.Services;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpline.Controllers
{    
    public class HomeController : Controller
    {
        UserServices UserServices = new UserServices();        
        
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }        

        public JsonResult FullName()
        {
            string fullName = UserServices.GetFullName(User.Identity.Name);

            return Json(fullName, JsonRequestBehavior.AllowGet);
        }
    }
}