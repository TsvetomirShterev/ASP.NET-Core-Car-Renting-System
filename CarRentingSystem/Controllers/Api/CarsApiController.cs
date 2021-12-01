namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Models.Api.Cars;
    using Microsoft.AspNetCore.Mvc;
    using CarRentingSystem.Services.Cars;

    [ApiController]
    [Route("api/cars")]
    public class CarsApiController : ControllerBase
    {
        private readonly ICarService cars;

        public CarsApiController(ICarService cars)
            => this.cars = cars;

        [HttpGet]
        public CarQueryServiceModel All([FromQuery] AllCarsApiRequestModel query) 
            => this.cars.All(
                query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.CarsPerPage);
    }
}
