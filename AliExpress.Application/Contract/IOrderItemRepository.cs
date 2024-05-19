using AliExpress.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Contract
{
    public interface IOrderItemRepository
    {
        Task DeleteOrderItemAsync(int orderItemId);
        Task <OrderItem> GetOrderItemAsync(string userId,int Product);

    }
}
