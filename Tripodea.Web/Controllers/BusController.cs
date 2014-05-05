using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        // the bus home page
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
        //create a pending order
        [Authorize]
        [HttpGet]
        public ActionResult Order(string seats, int scheduleId)
        {
            System.Web.HttpContext.Current.User.Identity.GetUserId();
            var customer = System.Web.HttpContext.Current.User.Identity.Name;
            var order = _busService.Order(seats, scheduleId, customer);
            return View(order);
        }

        [HttpPost]
        public ActionResult OrderConfirm(string seats, int scheduleId)
        {
            var customer = System.Web.HttpContext.Current.User.Identity.Name;
            _busService.BuyTicket(seats, scheduleId, customer);
            return View();
        }
        public ActionResult Result()
        {
            var results = _busService.GetSchedules();
            return PartialView("_result", results);
        }

        //the about page
        public ActionResult About()
        {
            return View();
        }
    }
}