using REAL_EshopProjectHosperger.Entities;
using System.ComponentModel.DataAnnotations;

namespace REAL_EshopProjectHosperger.Models.Car
{
    public class CarViewModel
    {
        [Required]
        
        public int ID { get; set; }
        [Required]
        [MaxLength(64)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(64)]
        public string Model { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [Range(0.01, 999999999)]
        public decimal Price { get; set; }

        public IFormFile? Image { get; set; }

        public string PriceText => $"{Price:N0} CZK";

       




        public CarViewModel()
        {
            ID = 0;
            Brand = string.Empty;
            Model = string.Empty;
            Description = string.Empty;
            Year = 0;
            Price = 0;
        }
        public CarViewModel(int id, string brand, string model, string description, int year, decimal price)
        {
            ID = id;
            Brand = brand;
            Model = model;
            Description = description;
            Year = year;
            Price = price;
        }

    }
}
