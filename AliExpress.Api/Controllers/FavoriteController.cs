using AliExpress.Application.IServices;
using AliExpress.Dtos.Favorites;
using AliExpress.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliExpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

      
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(string userId)
        {
            var favorites = await _favoriteService.GetAllAsync(userId);
            return Ok(favorites);
        }
        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] FavoriteCreateDTO favoriteCreateDTO)
        {
            if (!ModelState.IsValid)
            {
              
                return BadRequest(ModelState);
            }

            try
            {
                
              
                await _favoriteService.CreateFavoriteAsync(favoriteCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"An error occurred while adding the favorite: {ex.Message}");
            }
        }


        [HttpDelete("{userId}/{productId}")]

        public async Task<IActionResult> RemoveFavorite(string userId, int productId)
        {
           await _favoriteService.RemoveFavoriteAsync(userId, productId);
            return Ok();
        }


    }
}
