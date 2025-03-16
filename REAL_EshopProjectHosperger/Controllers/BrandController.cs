using Microsoft.AspNetCore.Mvc;
using REAL_EshopProjectHosperger.Database;
using REAL_EshopProjectHosperger.Entities;
using REAL_EshopProjectHosperger.Models.Brand;

namespace REAL_EshopProjectHosperger.Controllers
{
    public class BrandController : BaseController
    {
        private DatabaseContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public BrandController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult ListBrand()
        {
           List<Brand> brands = _context.Brands.ToList();
            
            List<BrandViewModel> brandViewModels = brands.Select(b =>
                new BrandViewModel(b.ID, b.Brand_))
                .ToList();

            return View( brandViewModels);
        }
    }
}
