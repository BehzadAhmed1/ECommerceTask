using ECommerceTask.Domain.Aggregates.Order;
using ECommerceTask.Domain.Aggregates.Order.Entities;

namespace ECommerceTask.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }

}




