using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Educational_Medical_platform.DTO
{
    public class CategoryDTO
    {
        public int? Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string Name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CategoryType Type { get; set; }
    }
}