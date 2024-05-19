using AliExpress.Application.Contract;
using AliExpress.Application.IServices;
using AliExpress.Application.Services;
using AliExpress.Dtos.Cart;
using AliExpress.Dtos.Product;
using AliExpress.Dtos.Rate;
using AliExpress.Models;
using AliExpress.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace AliExpress.Api.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateService _rateService;
        private readonly IorderItemService _orderItemService;
        private readonly IRateRepository _rateRepository;

        public RateController(IRateService rateService, IorderItemService orderItemService, IRateRepository rateRepository)
        {
            _rateService = rateService;
            _orderItemService = orderItemService;
            _rateRepository = rateRepository;
        }


        [Authorize]
        [HttpPost("addRate")]
        public async Task<IActionResult> AddRate([FromBody] RateDto rateDto)
        {
            Console.WriteLine(rateDto);
            Console.WriteLine("rateDtorateDtorateDtorateDtorateDtorateDtorateDtorateDtorateDtorateDto");
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    var orderItem = await _orderItemService.GetOrderItemAsync(userId, rateDto.ProductId);


                    if (orderItem == null)
                    {
                        return BadRequest("u don't order have this product");
                    }
                    else
                    {
                        await _rateService.AddRate(rateDto);
                        return Ok();
                    }

                }
                else
                    return BadRequest("no foudn user");
            }
            return BadRequest();

        }

        [Authorize]
        [HttpPut("updateRate/{rateId}")]
        public async Task<IActionResult> UpdateRate(int rateId, [FromBody]RateUpdateDto rateUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return BadRequest("User not found.");
            }



            try
            {
                await _rateService.UpdateRateAsync(rateId, rateUpdateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getRate/{rateId}")]
        public async Task<IActionResult> GetRate(int rateId)
        {
            try
            {
                var rateDto = await _rateService.GetRateAsync(rateId);
                if (rateDto == null)
                {
                    return NotFound();
                }
                return Ok(rateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("deleteRate/{rateId}")]
        public async Task<IActionResult> DeleteRate(int rateId)
        {
            try
            {
                // Get the currently authenticated user ID
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized();
                }

                // Retrieve the rate by its ID
                var rateDto = await _rateService.GetRateAsync(rateId);
                if (rateDto == null)
                {
                    return NotFound();
                }

                // Check if the authenticated user is the owner of the rate
                if (rateDto.UserId != userId)
                {
                    return Forbid();
                }

                // Delete the rate
                await _rateService.DeleteRateAsync(rateId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getRateByUserAndProduct/{userId}/{productId}")]
        public async Task<IActionResult> GetRateByUserAndProduct(string userId, int productId)
        {
            try
            {
                var rateDto = await _rateService.GetRateByUserIdAndProductIdAsync(userId, productId);
                if (rateDto == null)
                {
                    return NotFound();
                }
                return Ok(rateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getAllRatesForProduct/{productId}")]
        public async Task<IActionResult> GetAllRatesForProduct(int productId)
        {
            try
            {
                var ratesDto = await _rateService.GetAllRatesForProductAsync(productId);

                var rates = await _rateRepository.GetAllRatesForProductAsync(productId);

                double averageDegreeRate = rates.Any() ? rates.Average(r => r.DegreeRate) : 0;

                var response = new { Rates = ratesDto, AverageDegreeRate = averageDegreeRate };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("user-rate-counts/{productId}")]
        public async Task<IActionResult> GetUserRateCountsForProduct(int productId)
        {
            try
            {
                var userRateCounts = await _rateService.GetUserRateCountsForProductAsync(productId);
                return Ok(userRateCounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
