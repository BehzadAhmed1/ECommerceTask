using ECommerceTask.Domain.Aggregates.Order;

namespace ECommerceTask.Domain.Entities
{

    public class Customer : Entity
    {
        public ICollection<Order> Orders { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}






