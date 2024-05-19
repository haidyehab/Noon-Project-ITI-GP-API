using AliExpress.Application.Contract;
using AliExpress.Context;
using AliExpress.Dtos.Product;
using AliExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace None.Infrastructure
{
    public class ProductRepository : Repoditory<Product, int>, IProductRepository
    {
        private readonly AliExpressContext _context;

        public ProductRepository(AliExpressContext context) : base(context)
        {
            _context = context;
        }

      

        public async Task<int> CoutProducts()
        {
            int counts = await _context.Products.CountAsync();
            return counts;
        }

        

        public async Task<IEnumerable<Product>> GetAllAsync(string searchValue, string category, int page, int pageSize, decimal minPrice, decimal maxPrice, string brandName)
        {
            IQueryable<Product> query = _context.Products;

            // Include images
            query = query.Include(product => product.Images);

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(p => p.Title.ToLower().Contains(searchValue.ToLower()));
            }
            else if (!string.IsNullOrEmpty(category))
            {
                var cat = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == category.ToLower());
                if (cat != null)
                {
                    //query = query.Where(p => p.Category == cat.Id.ToString());
                    query = query.Where(p => p.ProductCategories.Any(pc => pc.Category.Name.ToLower() == category.ToLower()));

                }
            }

            if(minPrice!=-1) 
            {
                query = query.Where(p => p.Price >= minPrice);
            }

            if(maxPrice!=-1) 
            {
                query=query.Where(p => p.Price <= maxPrice);
            }


            if(!string.IsNullOrEmpty(brandName))
            {
                query=query.Where(p=>p.Brand==brandName);
            }

            int skip = (page - 1) * pageSize;
            query = query.Skip(skip).Take(pageSize);

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsWithAverageDegreeRateAsync(double targetAverageRate)
        {
            // Calculate the rounded average degree rate within the 1 to 5 range
            int roundedAverageRate = (int)Math.Min(Math.Max(Math.Ceiling(targetAverageRate), 1), 5);

            // Fetch products with their average degree rate rounded to the nearest integer within the calculated range
            
            var productsWithTargetAverageRate = await _context.Products
           .Include(product => product.Images)
           .Where(product => product.Rates.Any())
           .Select(product => new
           {
               Product = product,
               AverageDegreeRate = Math.Ceiling(product.Rates.Average(rate => rate.DegreeRate))
           })

            .Select(result => new
            {
                result.Product,
                RoundedAverageDegreeRate = result.AverageDegreeRate > 5 ? 5 : (result.AverageDegreeRate < 1 ? 1 : (int)result.AverageDegreeRate)
            })
            .Where(result => result.RoundedAverageDegreeRate == roundedAverageRate)
            .Select(result => result.Product)
            .ToListAsync();

            return productsWithTargetAverageRate;
        }






        public async Task<List<Product>> SearchByName(string name)
        {
            var product =_context.Products.Where(u => u.Title.ToLower().Contains(name)).ToList();
            return product;
        }

        
    }
}
