using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Contract
{
    public interface IRateRepository
    {
        Task AddAsync(Rate rate);
        Task UpdateAsync(Rate rate);
        Task<Rate> GetAsync(int rateId);
        Task<Rate> GetRateByUserIdAndProductIdAsync(string userId, int productId);

        Task DeleteAsync(int rateId);
        Task<IEnumerable<Rate>> GetAllRatesForProductAsync(int productId);
        Task<int> GetUserCountByRateForProductAsync(int productId, int rate);
    }
}
