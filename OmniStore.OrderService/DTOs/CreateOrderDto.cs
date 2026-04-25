using System.ComponentModel.DataAnnotations;
namespace OmniStore.OrderService.DTOs
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Customer name must be between 2 and 100 characters.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Total amount must be greater than zero.")]
        public decimal TotalAmount { get; set; }
    }
}
