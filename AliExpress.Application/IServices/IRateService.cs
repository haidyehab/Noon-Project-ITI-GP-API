using AliExpress.Dtos.Product;
using AliExpress.Dtos.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.IServices
{
    public interface IRateService
    {
        Task AddRate(RateDto rateDto);
        Task UpdateRateAsync(int rateId, RateUpdateDto rateUpdateDto);
        Task<RateDto> GetRateAsync(int rateId);
        Task<RateDto> GetRateByUserIdAndProductIdAsync(string userId, int productId);
        Task DeleteRateAsync(int rateId);
        Task<IEnumerable<RateDto>> GetAllRatesForProductAsync(int productId);
        Task<Dictionary<int, int>> GetUserRateCountsForProductAsync(int productId);
    }
}
