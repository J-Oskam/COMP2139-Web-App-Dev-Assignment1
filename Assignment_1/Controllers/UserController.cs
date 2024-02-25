using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;

namespace Assignment_1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() // We can implement an administrative user portal here at a later time, if needed
        {
            return View();
        }

        public IActionResult CreateGuestUser(int hotelId)
        {
            ViewData["HotelId"] = hotelId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGuestUser(User guestUser, int hotelId)
        {
            if (ModelState.IsValid)
            {
                guestUser.IsGuest = true;
                _db.Users.Add(guestUser);
                await _db.SaveChangesAsync();
                return RedirectToAction("CreateBooking", "Bookings", new { hotelId = hotelId, userId = guestUser.UserId });
            }

            return View(guestUser);
        }
    }
}
