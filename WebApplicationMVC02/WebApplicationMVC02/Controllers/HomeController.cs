using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVC02.Models;

namespace WebApplicationMVC02.Controllers
{
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

        public IActionResult Informacion()
        {
            return View();
        }


        [HttpGet]
        public JsonResult horaserver()
        {
            DateTime time = DateTime.Now;
            string rpta = "{\"hora\":\"" + time.ToString() + "}";
            return Json(rpta);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}