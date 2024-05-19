using AliExpress.Application.Contract;
using AliExpress.Context;
using AliExpress.Dtos.Favorites;
using AliExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace None.Infrastructure
{
    public class FavoriteRepository : IFavoriterRepository
    {
        private readonly AliExpressContext _context;

        public FavoriteRepository(AliExpressContext context)
        {
            _context = context;
        }
        public async Task AddFavoriteAsync(Favorite favorite)
        {
           _context.Favorites.Add(favorite);
           await _context.SaveChangesAsync();

        }

        public async Task DeleteFavoriteAsync(string userId, int productId)
        {
            var oldFavorite =await _context.Favorites.FirstOrDefaultAsync(f => f.AppUserId == userId
            && f.ProductId == productId);
            if(oldFavorite != null)
            {
              _context.Favorites.Remove(oldFavorite);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesAsync(string userId)
        {
            var favorites=await _context.Favorites.Include(f => f.Product).ThenInclude(fp =>fp.Images).Where(f => f.AppUserId ==userId).ToListAsync();
            return favorites;
        }
    }
}
