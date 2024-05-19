using AliExpress.Application.IServices;
using AliExpress.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Noon.MVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
           var bransds = await _brandService.GetAllBrands();
            return View(bransds);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
     
        [HttpPost]
        public async Task<IActionResult> Create(BrandDto brandDto, IFormFile ImagePath)
        {
            if (ModelState.IsValid)
            {
                if (ImagePath != null && ImagePath.Length > 0)
                {
                   
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", fileName);

                   
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImagePath.CopyToAsync(fileStream);
                    }

                    brandDto.ImagePath = "/photos/" + fileName;
                }

                await _brandService.AddBrand(brandDto);
            }
            return View(brandDto);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandDto brandDto, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", fileName);

                   
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }

                  
                    brandDto.ImagePath = "/photos/" + fileName;
                }

                await _brandService.UpdateBrand(brandDto);
            }
            return View(brandDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
              await  _brandService.DeleteBrand(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
