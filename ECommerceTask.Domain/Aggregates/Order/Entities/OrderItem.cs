
using ECommerceTask.Domain.Entities;

namespace ECommerceTask.Domain.Aggregates.Order.Entities
{
    public class OrderItem : Entity
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}



