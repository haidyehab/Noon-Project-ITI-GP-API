using AliExpress.Application.IServices;
using AliExpress.Application.Services;
using AliExpress.Dtos.Product;
using Microsoft.AspNetCore.Mvc;

namespace Noon.MVC.Controllers
{
    public class ProductBrandController : Controller
    {
        private readonly IPrdouctBrandService _prdouctBrandService;
        private readonly IBrandService  _brandService;

        public ProductBrandController(IPrdouctBrandService prdouctBrandService, IBrandService brandService)
        {
            _prdouctBrandService = prdouctBrandService;
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
            var bransds = await _prdouctBrandService.GetAllPrdouctBrands();
            return View(bransds);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await (_brandService.GetAllBrands());
            ViewBag.Cat = brands;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrdouctBrandDto brandDto, IFormFile image)
        {
            var brands = await (_brandService.GetAllBrands());
            ViewBag.Cat = brands;
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

                    brandDto.Image = "/photos/" + fileName;
                }
                //brandDto.BrandId = brandDto.BrandDto.Id;

                await _prdouctBrandService.AddPrdouctBrand(brandDto);
            }
            return View(brandDto);
        }

        [HttpGet]
        public async Task<IActionResult>  Edit(int id)
        {
            var productBrand = await _prdouctBrandService.GetPrdouctBrand(id);
            var brands = await(_brandService.GetAllBrands());
            ViewBag.Cat = brands;
            return View(productBrand);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PrdouctBrandDto brandDto, IFormFile image)
        {
            
            var brands = await (_brandService.GetAllBrands());
            ViewBag.Cat = brands;
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


                    brandDto.Image = "/photos/" + fileName;
                }

                await _prdouctBrandService.UpdatePrdouctBrand(brandDto);
            }
            return View(brandDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _prdouctBrandService.DeletePrdouctBrand(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
