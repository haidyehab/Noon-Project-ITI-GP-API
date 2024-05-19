using AliExpress.Dtos.Favorites;
using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Contract
{
    public interface IFavoriterRepository
    {
        Task<IEnumerable<Favorite>> GetFavoritesAsync(string userId);
        Task AddFavoriteAsync(Favorite favorite);
        Task DeleteFavoriteAsync(string userId, int productId);
    }
}
