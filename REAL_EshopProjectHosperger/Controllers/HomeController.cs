using Microsoft.AspNetCore.Mvc;
using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Models;
using System.Diagnostics;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

    }
}
