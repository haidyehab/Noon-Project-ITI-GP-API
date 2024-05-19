using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Contract
{
    public interface IPrdouctBrandRepository
    {
        Task<IEnumerable<PrdouctBrand>> GetAllAsync();
        Task<PrdouctBrand> GetAsync(int id);
        Task AddAsync(PrdouctBrand prdouctBrand);
        Task UpdateAsync(PrdouctBrand prdouctBrand);
        Task DeleteAsync(int id);
        Task <IEnumerable<PrdouctBrand>> ProductBrandCategoryAsync(int id);
    }
}
