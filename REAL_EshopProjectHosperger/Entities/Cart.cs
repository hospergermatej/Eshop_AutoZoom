namespace REAL_EshopProjectHosperger.Entities
{
    public class Cart
    {
        
        public int ID { get; set; }
        public List<Car> Cars { get; set; }
        public decimal TotalPrice { get; set; }

        
        public Cart()
        {
            ID = 0;
            Cars = new List<Car>();
            TotalPrice = 0;
        }

        
    }
}
