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
        // GET: CarRentalsController
        [HttpGet]
        public IActionResult Index()
        {
            var carRentals = _db.CarRentals.OrderBy(r => r.RentalId).ToList();

            return View(carRentals);
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

        // GET: CarRentalsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarRentalsController/Create
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
