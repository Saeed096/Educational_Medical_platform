using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.PayPal
{
    public class CreatePlanRequestDTO
    {
        [Required(ErrorMessage = "ProductId is required.")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fixed Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a valid number with up to two decimal places.")]
        public decimal FixedPrice { get; set; }

        [Required(ErrorMessage = "Tax percentage is required.")]
        [Range(0, 100, ErrorMessage = "Tax percentage must be between 0 and 100.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Tax percentage must be a valid number with up to two decimal places.")]
        public decimal TaxesPercentage { get; set; }
    }
}