using AliExpress.Application.Contract;
using AliExpress.Application.IServices;
using AliExpress.Dtos.Favorites;
using AliExpress.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriterRepository _favoriterRepository;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoriterRepository favoriterRepository,IMapper mapper)
        {
            _favoriterRepository = favoriterRepository;
            _mapper = mapper;
        }
        public async Task CreateFavoriteAsync(FavoriteCreateDTO favoriteCreateDTO)
        {
            //var mappedFavorite = _mapper.Map<FavoriteCreateDTO, Favorite>(favoriteCreateDTO);
            //await  _favoriterRepository.AddFavoriteAsync(mappedFavorite);
            var favorite = new Favorite
            {
                AppUserId = favoriteCreateDTO.UserId,
                ProductId = favoriteCreateDTO.ProductId
            };
            await _favoriterRepository.AddFavoriteAsync(favorite);
        }

        public async Task<IEnumerable<FavoriteDto>> GetAllAsync(string userId)
        {
            var favorites =await _favoriterRepository.GetFavoritesAsync(userId);
            var favoritesDto = _mapper.Map<IEnumerable<Favorite>, IEnumerable<FavoriteDto>>(favorites);
            return favoritesDto;
        }

        public async Task RemoveFavoriteAsync(string userId, int productId)
        {
            await _favoriterRepository.DeleteFavoriteAsync(userId, productId);
        }
    }
}
