using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tripodea.BusDataAccess.Repositories;
using Tripodea.ServiceLayer.Bus;

namespace Tripodea.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IBusService _busService;
        //
        // GET: /Bus/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            ViewBag.LocationList = _unitOfWork.LocationRepository.Get();
            return PartialView("_search");
        }

        public ActionResult Result()
        {
            
            return PartialView("_result");
        }
	}
}