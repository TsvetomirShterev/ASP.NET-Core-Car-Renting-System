﻿namespace CarRentingSystem.Services.Cars.Models
{
    public class CarServiceModel : ICarModel
    {
        public int Id { get; init; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public string CategoryName { get; set; }

        public bool IsPublic { get; init; }
    }
}
