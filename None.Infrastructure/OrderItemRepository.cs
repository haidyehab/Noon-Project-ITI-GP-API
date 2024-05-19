using AliExpress.Application.Contract;
using AliExpress.Context;
using AliExpress.Models.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace None.Infrastructure
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AliExpressContext _context;

        public OrderItemRepository(AliExpressContext context)
        {
            _context = context;
        }
        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
           
            if (orderItem != null)
            {
                var order = await _context.Orders.FindAsync(orderItem.OrderId);
                if (order != null)
                {
                    order.Subtotal -= orderItem.Price * orderItem.Quantity;
                    // Update the order in the database if necessary
                    
                }

                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OrderItem> GetOrderItemAsync(string userId, int productId)
        {
            var orderItem = await _context.OrderItems
             .Include(oi => oi.Order) // Include the Order navigation property
             .FirstOrDefaultAsync(oi =>
                 oi.ProductId == productId && // productId is the ID of the product
                 oi.Order.AppUserId == userId); // userId is the ID of the user

            return orderItem;

        }

        public Task<OrderItem> GetOrderItemAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
