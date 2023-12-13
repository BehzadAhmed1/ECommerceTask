using System.ComponentModel.DataAnnotations;

namespace ECommerceTask.Api.DTOs
{
    public class OrderDto
    {
        [Required]
        public string CustomerName { get; set; }

        [Required, EmailAddress]
        public string CustomerEmail { get; set; }

        [Required]
        public List<OrderItemDto> OrderItems { get; set; }
    }
}