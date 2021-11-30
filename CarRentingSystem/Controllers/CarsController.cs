
namespace CarRentingSystem.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Cars;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System;

    public class CarsController : Controller
    {
        private readonly CarRentingDbContext data;

        public CarsController(CarRentingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddCarFormModel
        {
            Categories = this.GetCarCategories(),
        });

        public IActionResult All(string searchTerm)
        {
            var carsQuery = this.data.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery
                    .Where(c => (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower())
                || c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            var cars = carsQuery
                .OrderByDescending(c => c.Id)
                .Select(c => new CarListingViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                    Category = c.Category.Name
                })
                .ToList();

            var carBrands = this.data
                .Cars
                .Select(c => c.Brand)
                .Distinct()
                .ToList();

            return this.View(new AllCarsQueryModel
            {
                Brands = carBrands,
                Cars = cars,
                SearchTerm = searchTerm,
            });
        }

        [HttpPost]
        public IActionResult Add(AddCarFormModel car, IFormFile image)
        {

            if (!this.data.Categories.Any(c => c.Id == car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();

                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId,
            };

            this.data.Cars.Add(carData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<CarCategryViewModel> GetCarCategories()
            => this.data
            .Categories
            .Select(c => new CarCategryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToList();

    }
}
