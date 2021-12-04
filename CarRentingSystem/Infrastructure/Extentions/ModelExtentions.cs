namespace CarRentingSystem.Infrastructure.Extentions
{
    using CarRentingSystem.Services.Cars.Models;

    public static class ModelExtentions
    {
        public static string GetInformation(this ICarModel car) 
            => car.Brand + "-" + car.Model + "-" + car.Year;
    }
}
