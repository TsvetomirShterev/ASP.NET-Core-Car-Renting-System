﻿namespace CarRentingSystem.Models.Cars
{
    using CarRentingSystem.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Car;

    public class AddCarFormModel
    {
        [Required]
        [StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
        public string Brand { get; init; }

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = "The field Description must be a string with a minimum length of '{2}'.")]
        public string Description { get; init; }

        [Url]
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Range(YearMinValue, YearMaxValue)]
        public int Year { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<CarCategryViewModel> Categories { get; set; }
    }
}
