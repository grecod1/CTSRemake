using Helpline.Services;
using Helpline.Services.Interfaces;
using Helpline.ViewModels.InformationLinkViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpline.Controllers
{
    public class InformationLinkController : Controller
    {
        IInformationLinkServices InformationLinkServices = new InformationLinkServices();

        // GET: InformationLink
        public ActionResult Index()
        {
            InformationLinkIndexViewModel model = InformationLinkServices.GetInformationLinkIndex(User.Identity.Name);

            return View(model);
        }        
    }
}