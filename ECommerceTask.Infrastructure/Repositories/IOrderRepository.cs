using ECommerceTask.Domain.Aggregates.Order;
using ECommerceTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTask.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task SaveChangesAsync();
        Task<int> AddOrderAsync(Order order);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Customer?> GetCustomerByEmailAndNameAsync(string customerEmail, string customerName);
        Task AddCustomerAsync(Customer customer);
    }
}