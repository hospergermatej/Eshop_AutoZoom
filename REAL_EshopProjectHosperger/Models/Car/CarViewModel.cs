using REAL_EshopProjectHosperger.Entities;

namespace REAL_EshopProjectHosperger.Models.Car
{
    public class CarViewModel
    {
       
        public int ID { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        


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
