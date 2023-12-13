using ECommerceTask.Domain.Aggregates.Order.Entities;
using ECommerceTask.Domain.Aggregates.Order;
using ECommerceTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECommerceTask.Infrastructure
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);
        }
    }
}
