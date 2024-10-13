using Educational_Medical_platform.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string Name { get; set; }

        public List<SubCategory>? SubCategories { get; set; }

        public List<Book>? Books { get; set; }

        public List<Blog>? Blogs { get; set; }

        public CategoryType Type { get; set; }
    }
}