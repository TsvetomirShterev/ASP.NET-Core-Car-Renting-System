namespace CarRentingSystem.Test.Controller
{
    using System.Linq;
    using CarRentingSystem.Controllers;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Services.Cars;
    using CarRentingSystem.Services.Statistics;
    using CarRentingSystem.Test.Mocks;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using System.Collections.Generic;
    using FluentAssertions;
    using CarRentingSystem.Services.Cars.Models;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
            => MyMvc
                .Pipeline()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index())
                .Which(controller => controller
                    .WithData(GetCars()))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<List<LatestCarServiceModel>>()
                    .Passing(m => m.Should().HaveCount(3)));

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            //Arrange
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            var cars = GetCars();

            data.Cars.AddRange(cars);
            data.Users.Add(new User());
            data.SaveChanges();

            var carService = new CarService(data, mapper);
            var statisticsService = new StatisticsService(data);

            //var homeController = new HomeController(carService,);

            //Act
            //var result = homeController.Index();

            //Assert
            //Assert.NotNull(result);

            //var viewResult = Assert.IsType<ViewResult>(result);

            //var model = viewResult.Model;

            //var indexViewModel = Assert.IsType<List<LatestCarServiceModel>>(model);

            //Assert.Equal(3, indexViewModel.Count);
        }


        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arrange
            var homeController = new HomeController(null, null);

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }


        private static IEnumerable<Car> GetCars()
            => Enumerable.Range(0, 10).Select(c => new Car());
    }
}
