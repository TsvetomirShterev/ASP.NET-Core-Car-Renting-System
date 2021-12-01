namespace CarRentingSystem.Controllers
{
    using System.Linq;
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Data;
    using CarRentingSystem.Models;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Services.Statistics;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        private readonly CarRentingDbContext data;

        public HomeController(IStatisticsService statistics,CarRentingDbContext data)
        {
            this.statistics = statistics;
            this.data = data;
        }

        public IActionResult Index()
        {

            var cars = this.data
                .Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarIndexViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                })
                .Take(3)
                .ToList();

            var statistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalUsers = statistics.TotalUsers,
                TotalCars = statistics.TotalCars,
                Cars = cars,
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
