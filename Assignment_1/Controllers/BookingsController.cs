using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
