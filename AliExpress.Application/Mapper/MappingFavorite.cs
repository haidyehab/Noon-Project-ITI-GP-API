using AliExpress.Dtos.Favorites;
using AliExpress.Dtos.Product;
using AliExpress.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Mapper
{
    public class MappingFavorite : Profile
    {
        public MappingFavorite()
        {
            CreateMap<Favorite, FavoriteDto>()
                .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => MapProductToProductViewDto(src.Product)));
        }

        private List<ProductViewDto> MapProductToProductViewDto(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new List<ProductViewDto>
        {
            new ProductViewDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Title_AR = product.Title_AR,
                Description_AR = product.Description_AR,
                Price = product.Price,
                Image = product.Images?.Select(image => image.Url).ToList() 
            }
        };
        }
    }


}
