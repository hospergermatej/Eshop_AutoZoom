using Microsoft.AspNetCore.Mvc;
using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Entities;
using REAL_EshopProjectHosperger.Models.Car;
using REAL_EshopProjectHosperger.Models.Cart;
using System.Collections.Generic;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class CartController : BaseController
    {
        private DatabaseContext _context;
        
        public CartController(DatabaseContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.ToList();

            List<CarViewModel> carViewModels = cars.Select(c =>
            new CarViewModel(c.ID, c.Brand, c.Model, c.Description, c.Year, c.Price))
                .ToList();

            return View(carViewModels);
        }

        public IActionResult AddToCart(int id)
        {
            

            Car car = _context.Cars.SingleOrDefault(c => c.ID == id);


            CarViewModel carViewModel = new CarViewModel(
               car.ID,
               car.Brand,
               car.Model,
               car.Description!,
               car.Year,
               car.Price
           );

            CartViewModel cart = HttpContext.Session.GetObject<CartViewModel>("Cart") ?? new CartViewModel();

            
            cart.cars.Add(carViewModel);
            


            HttpContext.Session.SetObject("Cart", cart);


            return RedirectToAction("Index");
        }

        public IActionResult GetCart()
        {
            CartViewModel cart = HttpContext.Session.GetObject<CartViewModel>("Cart") ?? new CartViewModel();

            return View(cart);
        }

        public IActionResult RemoveFromCart(int id)
        {
            CartViewModel cart = HttpContext.Session.GetObject<CartViewModel>("Cart") ?? new CartViewModel();

            //CarViewModel carViewModel = cart.SingleOrDefault(c => c.ID == id);

            //cart.Remove(carViewModel);

            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToAction("Index");
        }
    }
}
