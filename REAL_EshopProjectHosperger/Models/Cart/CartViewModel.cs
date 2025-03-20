using REAL_EshopProjectHosperger.Models.Car;

namespace REAL_EshopProjectHosperger.Models.Cart
{
    public class CartViewModel
    {
        

        public string Username { get; set; }

        public List<CarViewModel> cars = new List<CarViewModel>();


        public CartViewModel()
        {
            Username = string.Empty;
            cars = new List<CarViewModel>();
        }

    }
}
