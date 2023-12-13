using ECommerceTask.Domain.Aggregates.Order;
using ECommerceTask.Domain.Entities;
using ECommerceTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Infrastructure.Contracts
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();


        public async Task<Customer?> GetCustomerByEmailAndNameAsync(string customerEmail, string customerName)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == customerEmail && c.Name == customerName);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddCustomerAsync(Customer customer)
        {          

            await _context.AddAsync(customer);
        }

        public async Task<int> AddOrderAsync(Order order)
        {
            await _context.AddAsync(order);
            return order.Id;
        }
    }
}
