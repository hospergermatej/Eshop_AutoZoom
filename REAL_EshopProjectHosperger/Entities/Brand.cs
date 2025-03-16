using System.ComponentModel.DataAnnotations.Schema;

namespace REAL_EshopProjectHosperger.Entities
{
    [Table("brand")]
    public class Brand
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("brand")]
        public string Brand_ { get; set; }

        virtual public List<Car> Cars { get; set; }


        public Brand()
        {
            ID = 0;
            Brand_ = string.Empty;
            Cars = new List<Car>();
        }

        public Brand(int id, string brand)
        {
            ID = id;
            Brand_ = brand;
            Cars = new List<Car>();
        }
    }
}
