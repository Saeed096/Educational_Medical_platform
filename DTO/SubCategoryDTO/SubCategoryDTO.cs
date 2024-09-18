using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.SubCategoryDTO
{
    public class SubCategoryDTO
    {
        public int? Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string? Name { get; set; }

        public int CategoryId { get; set; }


    }
}
