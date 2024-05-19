using AliExpress.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.IServices
{
    public interface IorderItemService
    {
        Task DeleteOrderItemAsync(int orderItemId);
        Task <OrderItemDto> GetOrderItemAsync(string userId, int product);
    }
}
