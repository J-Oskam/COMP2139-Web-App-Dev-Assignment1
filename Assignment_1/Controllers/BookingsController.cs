using Assignment_1.Data;
using Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _db;
        public BookingsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Bookings.ToList());
        }

        public IActionResult Create(int hotelId, int userId)
        {
            var cityName = (from hotel in _db.Hotels
                            join city in _db.Cities on hotel.CityId equals city.CityId
                            where hotel.HotelId == hotelId
                            select city.CityName)
                            .FirstOrDefault();
            
            if (cityName != null)
            {
                ViewBag.City = cityName;
            }

            ViewBag.HotelId = hotelId;
            ViewBag.UserId = userId;
            var departureDate = HttpContext.Session.GetString("DepartureDate");
            var arrivalDate = HttpContext.Session.GetString("ArrivalDate");
            ViewBag.DepartureDate = departureDate;
            ViewBag.ArrivalDate = arrivalDate;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            ViewBag.DepartureDate = HttpContext.Session.GetString("DepartureDate");
            ViewBag.ArrivalDate = HttpContext.Session.GetString("ArrivalDate");

            if (ModelState.IsValid)
            {
                _db.Bookings.Add(booking);
                _db.SaveChanges();
                return RedirectToAction("Confirm");
            }
            //ViewBag.Cities = new SelectList(_db.Cities, "CityId", "CityName");
            return View(booking);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}