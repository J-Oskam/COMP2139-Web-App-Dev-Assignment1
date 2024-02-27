using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_1.Controllers
{
    public class CarRentalsController : Controller
    {
        private AppDbContext _db { get; set; }

        public CarRentalsController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            //var departureDate = HttpContext.Session.GetString("DepartureDate");
            //var arrivalDate = HttpContext.Session.GetString("ArrivalDate");

            var searchQuery = from r in _db.CarRentals
                              select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchQuery = searchQuery.Where(r => r.Location.Contains(searchString) ||
                                                     r.CarModel.Contains(searchString) ||
                                                     r.CarMake.Contains(searchString) ||
                                                     r.RentalCompany.Contains(searchString));
            }

            var flights = await searchQuery.ToListAsync();
            return View(flights);
        }

        // GET: CarRentalsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Specifications(int id)
        {
            var rental = _db.CarRentals.FirstOrDefault(f => f.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        [HttpGet]
        public IActionResult BookRental(int id)
        {
            var rental = _db.CarRentals.FirstOrDefault(r => r.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }
            //Display form
            return View(rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookRentalConfirm(int RentalId)
        {
            var rental = _db.CarRentals.Find(RentalId);
            if (rental != null)
            {
                rental.Availability -= 1;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

                //tie the flight to the user ID as well

            }
            //Only here if project is null
            return NotFound();
        }

        [HttpGet("CreateRental")]
        public ActionResult CreateRental()
        {
            return View();
        }

        // POST: Rentals controller create
        [HttpPost("CreateRental")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRental(CarRental rental)
        {

            if (ModelState.IsValid)
            {
                _db.CarRentals.Add(rental);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental);
        }

        // GET: CarRentalsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarRentalsController/Edit/5
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

        // GET: CarRentalsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarRentalsController/Delete/5
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
