using System.ComponentModel.DataAnnotations;

namespace REAL_EshopProjectHosperger.Models.Brand
{
    public class BrandViewModel
    {

        public int ID { get; set; }

        [RegularExpression("@^[A-Z][a-zA-Z0-9&\\- ]{1,19}$")]
        public string Brand_ { get; set; }

        public BrandViewModel()
        {
            ID = 0;
            Brand_ = string.Empty;
        }

        public BrandViewModel(int id, string brand)
        {
            ID = id;
            Brand_ = brand;
        }
    }
}
