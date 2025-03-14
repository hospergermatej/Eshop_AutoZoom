﻿using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Models.Car;
using REAL_EshopProjectHosperger.Entities;
using Microsoft.AspNetCore.Mvc;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class CarController : BaseController
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
            new CarViewModel(c.ID, c.Brand, c.Model, c.Description!, c.Year,c.Price))
                .ToList();
            
            



            return View(carViewModels);
        }

        public IActionResult Add()
        {
            return View(new CarViewModel());
        }

        
        [HttpPost]
        public IActionResult Add(CarViewModel carViewModel)
        {
            if (carViewModel.Image != null)
            {
                if (carViewModel.Image.Length > 10 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image","Fotka auta nesmí být větší než 10MB!");
                    return View(carViewModel);
                }
                if(Path.GetExtension(carViewModel.Image.FileName).ToLower() != ".png")
                {

                   ModelState.AddModelError("Image","Fotka auta musí být ve formátu PNG!");
                    return View(carViewModel);
                }

            }


            if (!ModelState.IsValid)
            {
                return View(carViewModel);
            }


            Car car = new Car(
                carViewModel.ID,
                carViewModel.Brand, 
                carViewModel.Model,
                carViewModel.Description,
                carViewModel.Year,
                carViewModel.Price
            );


            _context.Cars.Add(car);
            _context.SaveChanges();

            if(carViewModel.Image != null)
            {
                string dirPath = Path.Combine(_webHostEnvironment.WebRootPath,"img","cars");

                if(!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string filePath = Path.Combine(dirPath, $"{car.ID}.png");
                using FileStream fileStream = new FileStream(filePath,FileMode.Create);
                carViewModel.Image.CopyTo(fileStream);
            }

            TempData["Message"] = $"Auto značka:{car.Brand} model:{car.Model} bylo úspěšně přidáno!";
            TempData["MessageType"] = "success";

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            Car car = _context.Cars.SingleOrDefault(c => c.ID == id)!;

            if (car==null)
            {
                TempData["Message"] = "Auto nebylo nalezeno!";
                TempData["MessageType"] = "danger";
            }

            CarViewModel carViewModel = new CarViewModel(
                car.ID,
                car.Brand,
                car.Model,
                car.Description!,
                car.Year,
                car.Price
            );



            return View(carViewModel);
        }


        [HttpPost]
        public IActionResult Edit(CarViewModel carViewModel)
        {
            
            if (carViewModel.Image != null)
            {
                if (carViewModel.Image.Length > 10 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "Fotka auta nesmí být větší než 10MB!");
                    return View(carViewModel);
                }
                if (Path.GetExtension(carViewModel.Image.FileName).ToLower() != ".png")
                {

                    ModelState.AddModelError("Image", "Fotka auta musí být ve formátu PNG!");
                    return View(carViewModel);
                }

            }

            if (!ModelState.IsValid)
            {
                return View(carViewModel);
            }

            Car? car = _context.Cars.SingleOrDefault(c => c.ID == carViewModel.ID)!;
            if (car == null)
            {
                TempData["Message"] = "Auto nebylo nalezeno!";
                TempData["MessageType"] = "danger";
            }

            car.Brand = carViewModel.Brand;
            car.Model = carViewModel.Model;
            car.Description = carViewModel.Description;
            car.Year = carViewModel.Year;
            car.Price = carViewModel.Price;

            _context.Cars.Update(car);
            _context.SaveChanges();

            if(carViewModel.Image != null)
            {
                string dirPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "cars");

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string filePath = Path.Combine(dirPath, $"{car.ID}.png");
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                carViewModel.Image.CopyTo(fileStream);
            }

            TempData["Message"] = $"Auto značka:{car.Brand} model:{car.Model} bylo úspěšně editováno!";
            TempData["MessageType"] = "success";

            return RedirectToAction("List");
        }
    }
}
