using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.PayPal
{
    public class CreateProductRequestDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}