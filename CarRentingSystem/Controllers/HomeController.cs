namespace CarRentingSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Services.Statistics;
    using AutoMapper;
    using CarRentingSystem.Services.Cars;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ICarService cars;
        private readonly IStatisticsService statistics;

        public HomeController( ICarService cars, IStatisticsService statistics)
        {
            this.cars = cars;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {

            var latestCars = this.cars.Latest().ToList();

            var statistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalUsers = statistics.TotalUsers,
                TotalCars = statistics.TotalCars,
                Cars = latestCars,
            });
        }

        public IActionResult Error()
            => View();
    }
}
