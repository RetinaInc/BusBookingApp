using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tripodea.BusDataAccess.Repositories;

namespace Tripodea.Web.Controllers
{
    public class BusController : Controller
    {
        private UnitOfWork unit_of_work = new UnitOfWork();
        //
        // GET: /Bus/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            ViewBag.LocationList = unit_of_work.LocationRepository.Get();
            return PartialView("_search");
        }

        public ActionResult Result()
        {
            return PartialView("_result");
        }
	}
}