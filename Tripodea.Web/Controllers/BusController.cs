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
        //initialize bus service interface
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        // the home page
        public ActionResult Index()
        {
            return View();
        }

        // search journeys
        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.LocationList = _busService.GetLocations();
            return PartialView("_search");
        }
        // journey search results
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

        // seat selection
        [HttpGet]
        public ActionResult SeatSelect(int scheduleId)
        {
            SeatSelectionDto seats = _busService.GetSeats(scheduleId);
            return PartialView("_seats", seats);
        }

        [Authorize]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Order(string seats, int scheduleId)
        {
            //_busService.Order(seats, scheduleId);
            ViewBag.ScheduleId = scheduleId;
            ViewBag.Seats = seats;
            return View();
        }


        public ActionResult Result()
        {
            var results = _busService.GetSchedules();
            return PartialView("_result", results);
        }
    }
}