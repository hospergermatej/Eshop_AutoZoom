using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Models.Car;
using REAL_EshopProjectHosperger.Entities;
using Microsoft.AspNetCore.Mvc;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class CarController : Controller
    {
        private DatabaseContext _context;
        private IWebHostEnvironment _webHostEnvironment;


        public CarController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment=webHostEnvironment;
        }



        public IActionResult List(CarViewModel carViewModel)
        {
            List<Car> cars = _context.Cars.ToList();

            List<CarViewModel> carViewModels = cars.Select(c =>
            new CarViewModel(c.ID, c.Brand, c.Model, c.Description, c.Year, c.Price))
                .ToList();
            
            



            return View(carViewModel);
        }
    }
}
