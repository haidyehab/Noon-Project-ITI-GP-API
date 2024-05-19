using AliExpress.Application.Contract;
using AliExpress.Application.IServices;
using AliExpress.Dtos.Cart;
using AliExpress.Dtos.Rate;
using AliExpress.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        public RateService(IRateRepository RateRepository,
            IMapper mapper)
        {
            _rateRepository = RateRepository;
            _mapper = mapper;
        }
        public async Task AddRate(RateDto rateDto)
        {
            var mappedRate = _mapper.Map<RateDto, Rate>(rateDto);
            await _rateRepository.AddAsync(mappedRate);
        }

        public async Task UpdateRateAsync(int rateId, RateUpdateDto rateUpdateDto)
        {
            var existingRate = await _rateRepository.GetAsync(rateId);
            if (existingRate == null)
            {
                throw new Exception("Rate not found.");
            }

            // Update properties of the existing rate with the values from the DTO
            existingRate.Type = rateUpdateDto.Type;
            existingRate.Comment = rateUpdateDto.Comment;
            existingRate.DegreeRate = rateUpdateDto.DegreeRate;

            // Update the rate in the database
            await _rateRepository.UpdateAsync(existingRate);
        }

        public async Task<RateDto> GetRateAsync(int rateId)
        {
            var rate = await _rateRepository.GetAsync(rateId);
            return _mapper.Map<RateDto>(rate);


        }

        public async Task<RateDto> GetRateByUserIdAndProductIdAsync(string userId, int productId)
        {
            var rate = await _rateRepository.GetRateByUserIdAndProductIdAsync(userId, productId);
            return _mapper.Map<RateDto>(rate);
        }

        public async Task DeleteRateAsync(int rateId)
        {
            await _rateRepository.DeleteAsync(rateId);
        }

        public async Task<IEnumerable<RateDto>> GetAllRatesForProductAsync(int productId)
        {
            var rates = await _rateRepository.GetAllRatesForProductAsync(productId);
            return _mapper.Map<IEnumerable<RateDto>>(rates);
        }


        public async Task<Dictionary<int, int>> GetUserRateCountsForProductAsync(int productId)
        {
            try
            {
                Dictionary<int, int> userRateCounts = new Dictionary<int, int>();

                // Get counts for each rate
                for (int i = 5; i >= 0; i--)
                {
                    int count = await _rateRepository.GetUserCountByRateForProductAsync(productId, i);
                    userRateCounts.Add(i, count);
                }

                return userRateCounts;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception("Error getting user rate counts for product.", ex);
            }
        }
    }
}

