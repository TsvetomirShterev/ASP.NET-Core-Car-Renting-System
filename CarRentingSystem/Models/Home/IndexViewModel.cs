namespace CarRentingSystem.Models.Home
{
    using CarRentingSystem.Services.Cars.Models;
    using System.Collections.Generic;
    public class IndexViewModel
    {
        public int TotalCars { get; init; }

        public int TotalUsers { get; init; }

        public int TotalRents { get; init; }

        public IList<LatestCarsServiceModel> Cars { get; init; }
    }
}
