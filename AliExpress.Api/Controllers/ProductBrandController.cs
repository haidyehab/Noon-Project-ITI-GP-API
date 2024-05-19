using AliExpress.Application.IServices;
using AliExpress.Dtos.Product;
using Microsoft.AspNetCore.Mvc;

namespace AliExpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : Controller
    {
        private readonly IPrdouctBrandService _prdouctBrandService;

        public ProductBrandController(IPrdouctBrandService prdouctBrandService)
        {
            _prdouctBrandService = prdouctBrandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrdouctBrandDto>>> getPrdductBrandCategory(int id)
        {
            var productbrands = await _prdouctBrandService.ProductBrandCategoryAsync(id);
            return Ok(productbrands);
        }
    }
}
