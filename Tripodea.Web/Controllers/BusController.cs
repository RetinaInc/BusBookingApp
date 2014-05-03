using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tripodea.BusDataAccess.Repositories;
using Tripodea.ServiceLayer.Bus;
using Tripodea.ServiceLayer.DTOs.Bus;

namespace Tripodea.Web.Controllers
{
    //this is the main controller
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        //
        // GET: /Bus/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.LocationList = _busService.GetLocations();
            return PartialView("_search");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchDto searchQuery)
        {
            if (ModelState.IsValid)
            {
                var result = _busService.SearchBus(searchQuery);
                return PartialView("_result", result);
            }
            else
            {
                RedirectToAction("Index");
                return null;
            }
        }

        public ActionResult Result()
        {
            var results = _busService.GetSchedules();
            return PartialView("_result", results);
        }
    }
}