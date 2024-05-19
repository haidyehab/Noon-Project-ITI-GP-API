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
    public class RateRepository:IRateRepository
    {
       
        private readonly AliExpressContext _context;
        
        public RateRepository(AliExpressContext context) {
            _context = context;
        }

        public async Task AddAsync(Rate rate)
        {
            var existingProduct = await _context.Products.FindAsync(rate.ProductId);
            if (existingProduct != null)
            {
                rate.Product = existingProduct;
            }
            await _context.Rates.AddAsync(rate);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Rate> GetAsync(int rateId)
        {
            return await _context.Rates.FindAsync(rateId);
        }


        public async Task<Rate> GetRateByUserIdAndProductIdAsync(string userId, int productId)
        {
            return await _context.Rates.Include(r => r.User).Include(r => r.Product) 
                .FirstOrDefaultAsync(r =>
                    r.UserId == userId &&
                    r.ProductId == productId);
        }

        public async Task DeleteAsync(int rateId)
        {
            var rate = await _context.Rates.FindAsync(rateId);
            if (rate != null)
            {
                _context.Rates.Remove(rate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rate>> GetAllRatesForProductAsync(int productId)
        {
            return await _context.Rates
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Rate rate)
        {
            _context.Rates.Update(rate);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetUserCountByRateForProductAsync(int productId, int rate)
        {
            return await _context.Rates
                .Where(r => r.ProductId == productId && r.DegreeRate == rate)
                .GroupBy(r => r.UserId)
                .CountAsync();
        }

    }
}
