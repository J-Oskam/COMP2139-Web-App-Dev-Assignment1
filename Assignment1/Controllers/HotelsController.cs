﻿using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
    public class HotelsController : Controller
    {

        private readonly AppDbContext _db;
        public HotelsController(AppDbContext db)
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


        public IActionResult Details(int id)
        {
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
