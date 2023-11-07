using Helpline.Services;
using Helpline.Services.Interfaces;
using Helpline.ViewModels.StatisticsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Helpline.Controllers
{
    public class SatisticsController : Controller
    {
        ISatisticServices SatisticsServices = new SatisticServices();


        public ActionResult Index()
        {
            return View();
        }

        // GET: Satistics
        public ActionResult CountyPrograms()
        {
            SatisticsViewModel model = SatisticsServices.GetInitialSatisticViewModel();            

            return View(model);
        }

        public JsonResult GetCountyProgramData(DateTime? date, int programId)
        {            
            IEnumerable<SatisticListViewModel> model = new List<SatisticListViewModel>();
            List<Object> results = SatisticsServices.GetData(date, programId);

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}