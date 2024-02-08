using AuthorizeAndAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthorizeAndAuthentication.Controllers
{
    [Authorize(Roles ="Admin")]
    /*[Authorize(Roles ="UI")]*/ //cookie'de g�nderdi�im role admin oldu�u i�in bu kod a��k olursa giri� yap ekran�ndan ba�ka bir yere y�nlendirmez.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
