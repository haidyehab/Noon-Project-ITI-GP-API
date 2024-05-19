using AliExpress.Dtos.Product;
using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.IServices
{
    public interface IPrdouctBrandService
    {
        Task<IEnumerable<PrdouctBrandDto>> GetAllPrdouctBrands();
        Task<PrdouctBrandDto> GetPrdouctBrand(int id);
        Task AddPrdouctBrand(PrdouctBrandDto prdouctBrandDto);
        Task UpdatePrdouctBrand(PrdouctBrandDto prdouctBrandDto);
        Task DeletePrdouctBrand(int id);
        Task<IEnumerable<PrdouctBrandDto>> ProductBrandCategoryAsync(int id);

    }
}
