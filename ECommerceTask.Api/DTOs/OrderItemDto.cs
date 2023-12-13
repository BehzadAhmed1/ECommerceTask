using System.ComponentModel.DataAnnotations;

namespace ECommerceTask.Api.DTOs
{
    public class OrderItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Quantity must be between 1 and 100000.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, 10000000, ErrorMessage = "Price must be a positive value and less than ten million.")]
        public decimal Price { get; set; }
    }
}
