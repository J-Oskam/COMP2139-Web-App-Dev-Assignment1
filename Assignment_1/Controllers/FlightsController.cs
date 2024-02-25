using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_1.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AppDbContext _db;
        public FlightsController(AppDbContext db)
        {
            _db = db;
        }
        // GET: FlightsController
        [HttpGet]
        public IActionResult Index()
        {
            //var flights = _db.Flights.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(List<Flight> flights)
        {
            /*
            Debug.WriteLine("posted");
            var bookedFlights = flights.Where(box => box.IsChecked).ToList();
    
            foreach (var flight in bookedFlights)
            {
                flight.bookSeat();
            }
            //userId can now be tied to flight

            return View(_db.Flights.OrderBy(m => m.FlightId).ToList());
            */

            return View();
        }

        // GET: FlightsController/Details/5

        public ActionResult Specifications(int id)
        {
            var flight = _db.Flights.FirstOrDefault(f => f.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }



        // GET: FlightsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        public IActionResult Cancel() { return View(); }

        public IActionResult AddFlight() { return View(); }

        public IActionResult AddCarRental() { return View(); }


        // GET: FlightsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightsController/Edit/5
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

        // GET: FlightsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightsController/Delete/5
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
