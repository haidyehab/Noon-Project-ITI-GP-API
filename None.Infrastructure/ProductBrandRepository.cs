using AliExpress.Application.Contract;
using AliExpress.Context;
using AliExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace None.Infrastructure
{
    public class ProductBrandRepository: IPrdouctBrandRepository
    {
        private readonly AliExpressContext _context;

        public ProductBrandRepository(AliExpressContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PrdouctBrand productBrand)
        {
            _context.AddAsync(productBrand);
            await _context.SaveChangesAsync();
        }

        

     

        public async Task DeleteAsync(int id)
        {
            var productBrand = await _context.ProductBrands.FirstOrDefaultAsync(B => B.Id == id);
            _context.ProductBrands.Remove(productBrand);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrdouctBrand>> GetAllAsync()
        {
            var productBrands = await _context.ProductBrands.ToListAsync();
            return productBrands;
        }

        public async Task<PrdouctBrand> GetAsync(int id)
        {
            var prdouctBrand = await _context.ProductBrands.FindAsync(id);
            return prdouctBrand;
        }

        public async Task<IEnumerable<PrdouctBrand>> ProductBrandCategoryAsync(int id)
        {
            var productBrand = await _context.ProductBrands.Where(pb => pb.BrandId == id).ToListAsync();

            return productBrand;
        }

        public async Task UpdateAsync(PrdouctBrand prdouctBrand)
        {
            _context.Update(prdouctBrand);
            await _context.SaveChangesAsync();
        }
    }
}
