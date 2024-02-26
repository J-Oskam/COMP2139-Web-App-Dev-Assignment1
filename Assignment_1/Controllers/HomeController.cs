using Assignment_1.Models;
using Assignment_1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string searchString)
        {
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
