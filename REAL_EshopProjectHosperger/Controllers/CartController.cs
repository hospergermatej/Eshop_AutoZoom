using Microsoft.AspNetCore.Mvc;
using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Entities;
using REAL_EshopProjectHosperger.Models.Car;
using System.Collections.Generic;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class CartController : Controller
    {
        private DatabaseContext _context;

        public CartController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.ToList(); // Ensure this returns a non-null list

            List<CarViewModel> carViewModels = cars.Select(c =>
            new CarViewModel(c.ID, c.Brand, c.Model, c.Description!, c.Year, c.Price))
                .ToList();

            return View(carViewModels);
        }
    }
}
