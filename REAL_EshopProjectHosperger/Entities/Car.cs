using System.ComponentModel.DataAnnotations.Schema;

namespace REAL_EshopProjectHosperger.Entities
{
    [Table("car")]
    public class Car
    {
        [Column("id")]
        public int ID { get; set; }
        
        [Column("brand")]
        public string Brand { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        public Car()
        {
            ID = 0;
            Brand = string.Empty;
            Model = string.Empty;
            Description = string.Empty;
            Year = 0;
            Price = 0;
        }

        public Car(int id, string brand, string model, string? description, int year, decimal price)
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
