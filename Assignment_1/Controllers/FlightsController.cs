using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_1.Controllers
{
    //[Route("Transportation")]
    public class FlightsController : Controller
    {
        private AppDbContext _db { get; set; }

        public FlightsController(AppDbContext db)
        {
            _db = db;
        }
        // GET: FlightController
        public ActionResult Index()
        {

            var departureDate = HttpContext.Session.GetString("DepartureDate");
            var arrivalDate = HttpContext.Session.GetString("ArrivalDate");

            var flights = _db.Flights.OrderBy(m => m.FlightId).ToList();
            return View(flights);
        }

        // GET: FlightController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Specifications(int id)
        {
            var flight = _db.Flights.FirstOrDefault(f => f.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult BookFlight(int id)
        {
            var departureDate = HttpContext.Session.GetString("DepartureDate");
            var arrivalDate = HttpContext.Session.GetString("ArrivalDate");

            var flight = _db.Flights.FirstOrDefault(f => f.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            //Display form
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookFlightConfirm(int FlightId)
        {
            var flight = _db.Flights.Find(FlightId);
            if (flight != null)
            {
                flight.Availability -= 1;
                _db.SaveChanges();
                HttpContext.Session.SetInt32("FlightId", FlightId);
                RedirectToAction("CreateGuestUser", "User");

                //tie the flight to the user ID as well

            }
            //Only here if project is null
            return NotFound();
        }


        // GET: FlightController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightController/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            if (flight.ArrivalTime < flight.DepartureTime)
            {
                ModelState.AddModelError("ArrivalDate", "Arrival date must be after the departure date");
                return View(flight);
            }
            if (ModelState.IsValid)
            {
                _db.Flights.Add(flight);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public IActionResult Cancel() { return View(); }

        public IActionResult AddFlight() { return View(); }

        public IActionResult AddCarRental() { return View(); }


        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
