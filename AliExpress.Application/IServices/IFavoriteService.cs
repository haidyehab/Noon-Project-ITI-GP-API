using AliExpress.Dtos.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.IServices
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteDto>> GetAllAsync(string userId);
        Task CreateFavoriteAsync(FavoriteCreateDTO favoriteCreateDTO);
        Task RemoveFavoriteAsync(string userId, int productId);
    }
}
