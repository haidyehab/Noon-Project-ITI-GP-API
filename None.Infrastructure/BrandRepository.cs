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
    public class BrandRepository : IBrandRepository
    {
        private readonly AliExpressContext _context;

        public BrandRepository(AliExpressContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Brand brand)
        {
              _context.AddAsync(brand);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var brand=await _context.Brands.FirstOrDefaultAsync(B => B.Id ==id);
            _context.Brands.Remove(brand);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            var brands =await _context.Brands.ToListAsync();
            return brands;
        }

        public async Task<Brand> GetAsync(int id)
        {
              var brand= await _context.Brands.FindAsync(id);
            return brand;
        }

        public async Task UpdateAsync(Brand brand)
        {
            _context.Update(brand);
           await _context.SaveChangesAsync();
        }
    }
}
