using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers {
    public class BookingsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
