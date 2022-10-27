using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.BLL.API;
using WeatherApp.DAL.Entity;
using WeatherApp.Web.Models;

namespace WeatherApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult WeatherInfo() => View(_context.locations.ToList());

        [HttpPost]
        public async Task<IActionResult> Index(Location location)
        {
            var api = new GetWeatherApi();
            var local = new Location
            {
                City = location.City,
                TemperatureC =
                    api.GetWeather
                        ($"http://api.openweathermap.org/data/2.5/weather?q={location.City}&units=metric&appid=25d1404d4513477a5c396ad4d61aa32a",
                            "brest")
            };

            _context.locations.Add(local);
            await _context.SaveChangesAsync();
            return RedirectToAction("WeatherInfo");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}