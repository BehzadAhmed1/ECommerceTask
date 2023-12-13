using ECommerceTask.Domain.Aggregates.Order.Entities;
using ECommerceTask.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ECommerceTask.Domain.Aggregates.Order
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _orderItems;

        public Order()
        {
            _orderItems = new List<OrderItem>();
        }
        public int CustomerId { get; set; }

        public Customer Customer;

        public List<OrderItem> OrderItems => _orderItems;
        public DateTime CreatedAt { get; set; }

     
        public void AddOrderItem(Product product, int quantity, decimal price)
        {           
            if (product.Quantity == 0) {
                throw new ArgumentException($"Product {product.Name} is out of stock.");

            }
            if (quantity > product.Quantity)
            {
                throw new ArgumentException($"Not enough {product.Name} in stock to fulfill order.");
            }

            if (price != product.Price)
            {
                throw new ArgumentException("Price does not match");
            }


            var orderItem = new OrderItem
            {
                Product = product,
                Quantity = quantity
            };

            _orderItems.Add(orderItem);
        }
    }
}
