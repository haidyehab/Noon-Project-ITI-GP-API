using AliExpress.Dtos.Product;
using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.IServices
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrands();
        Task<BrandDto> GetBrand(int id);
        Task AddBrand(BrandDto brandDto);
        Task UpdateBrand(BrandDto brandDto);
        Task DeleteBrand(int id);
    }
}
