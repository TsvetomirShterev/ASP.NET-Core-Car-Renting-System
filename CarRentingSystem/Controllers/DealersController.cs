﻿namespace CarRentingSystem.Controllers
{
    using System.Linq;

    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Infrastructure.Extentions;
    using CarRentingSystem.Models.Dealers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    public class DealersController : Controller
    {
        private readonly CarRentingDbContext data;

        public DealersController(CarRentingDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeDealerFormModel dealer)
        {
            var userId = this.User.Id();

            var userIsAlreadyDealer = this.data
                .Dealers
                .Any(d => d.UserId == userId);

            if (userIsAlreadyDealer)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            var dealerData = new Dealer
            {
                Name = dealer.Name,
                PhoneNumber = dealer.PhoneNumber,
                UserId = userId,
            };

            this.data.Dealers.Add(dealerData);
            this.data.SaveChanges();

            this.TempData[GlobalMessageKey] = "Thank you for becomming a dealer!";

            return RedirectToAction("All", "Cars");
        }
    }
}
