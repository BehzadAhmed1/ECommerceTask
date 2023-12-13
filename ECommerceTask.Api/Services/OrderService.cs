using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTask.Api.DTOs;
using ECommerceTask.Domain.Aggregates.Order;
using ECommerceTask.Domain.Aggregates.Order.Entities;
using ECommerceTask.Domain.Contracts;
using ECommerceTask.Domain.Entities;
using ECommerceTask.Infrastructure.Repositories;

namespace ECommerceTask.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> CreateOrderAsync(OrderDto orderDto)
        {
            var customer = await GetOrCreateCustomer(orderDto.CustomerEmail, orderDto.CustomerName);

            var order = new Order { CreatedAt = DateTime.UtcNow, CustomerId = customer.Id };

            foreach (var item in orderDto.OrderItems)
            {
                var product = await _orderRepository.GetProductByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new ArgumentException($"Product {item.ProductName} with ID {item.ProductId} does not exist.");
                }

                order.AddOrderItem(product, item.Quantity, item.Price);
            }

            var orderId = await _orderRepository.AddOrderAsync(order);

            await _orderRepository.SaveChangesAsync();

            return orderId;
        }

        private async Task<Customer> GetOrCreateCustomer(string email, string name)
        {
            var customer = await _orderRepository.GetCustomerByEmailAndNameAsync(email, name);

            if (customer == null)
            {
                customer = new Customer { Name = name, Email = email };
                await _orderRepository.AddCustomerAsync(customer);
                await _orderRepository.SaveChangesAsync();
            }

            return customer;
        }




    }

}
