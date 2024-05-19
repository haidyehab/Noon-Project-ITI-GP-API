using AliExpress.Application.Contract;
using AliExpress.Application.IServices;
using AliExpress.Dtos.Order;
using AliExpress.Dtos.Product;
using AliExpress.Models;
using AliExpress.Models.Orders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Services
{
    public class OrderItemService : IorderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository,
            IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            await _orderItemRepository.DeleteOrderItemAsync(orderItemId);
        }

        public  async Task<OrderItemDto> GetOrderItemAsync(string userId, int productId)
        {
            var orderItem = await _orderItemRepository.GetOrderItemAsync(userId, productId);
            var orderItemDto = _mapper.Map<OrderItem, OrderItemDto>(orderItem);
            return orderItemDto;
        }

       
    }
}
