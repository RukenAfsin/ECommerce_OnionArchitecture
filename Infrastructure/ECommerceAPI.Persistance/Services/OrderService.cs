using ECommerceAPI.Application.Abstractions.DTOs.Order;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository  _orderWriteRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder  createOrder)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address= createOrder.Address,
                BasketId=Guid.Parse(createOrder.BasketId),
                Description=createOrder.Description
            });

            await _orderWriteRepository.SaveAsync();
        }
    }
}
