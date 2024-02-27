using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_1.Controllers
{
    public class HotelsController : Controller
    {

        private readonly AppDbContext _db;
        public HotelsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string searchString, DateOnly? departureDate, DateOnly? arrivalDate, string AddFlight)
        {
            if (string.IsNullOrEmpty(AddFlight))
            {
                HttpContext.Session.SetString("AddFlight", "No");
            }
            else
            {
                HttpContext.Session.SetString("AddFlight", AddFlight);
            }

            if (arrivalDate.HasValue && departureDate.HasValue)
            {
                HttpContext.Session.SetString("ArrivalDate", arrivalDate.Value.ToString("yyyy-MM-dd"));
                HttpContext.Session.SetString("DepartureDate", departureDate.Value.ToString("yyyy-MM-dd"));
            }

            var searchQuery = _db.Hotels
                            .Include(h => h.City)
                            .ThenInclude(c => c.Country)
                            .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                searchQuery = searchQuery.Where(h => h.HotelName.Contains(searchString) ||
                                                     h.City.CityName.Contains(searchString) ||
                                                     h.City.Country.CountryName.Contains(searchString));
            }

            var hotels = await searchQuery.ToListAsync();
            return View(hotels);
        }


        public IActionResult Details(int id)
        {
            var addFlight = HttpContext.Session.GetString("AddFlight");
            var departureDate = HttpContext.Session.GetString("DepartureDate");
            var arrivalDate = HttpContext.Session.GetString("ArrivalDate");
            ViewBag.AddFlight = addFlight;

            var hotel = _db.Hotels.Include(h => h.City).
                                   FirstOrDefault(h => h.HotelId == id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }
    }
}
