using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment1.Controllers
{
    public class TransportationController : Controller
    {
        private AppDbContext _db{ get; set; }

        public TransportationController(AppDbContext db)
        {
            _db= db;
        }
        // GET: TransportationController
        public ActionResult Index()
        {
            var flights = _db.Flights.OrderBy(m => m.FlightId).ToList();
            return View(flights);
        }

        // GET: TransportationController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransportationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportationController/Create
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


        // GET: TransportationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransportationController/Edit/5
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

        // GET: TransportationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransportationController/Delete/5
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
