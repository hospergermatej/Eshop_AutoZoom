using Org.BouncyCastle.Bcpg.Sig;
using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Entities;
using REAL_EshopProjectHosperger.Models.Brand;
using System.ComponentModel.DataAnnotations;

namespace REAL_EshopProjectHosperger.Models.Car
{
    public class CarViewModel
    {

        

        [Required]
        
        public int ID { get; set; }
        [Required]
        [MaxLength(64)]
        [RegularExpression("@^[A-Z][a-zA-Z0-9&\\- ]{1,19}$")]
        public string Brand { get; set; }
        [Required]
        [MaxLength(64)]
        [RegularExpression("@^[A-Za-z0-9\\- ]{2,30}$")]
        public string Model { get; set; }
        [Required]
        [MaxLength(255)]
        [RegularExpression("@^[\\w\\d\\s.,!&'’\"()-]{10,500}$")]
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
