using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO
{
    public class CategoryDTO
    {
        public int? Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string Name { get; set; }

        //public List<SubCategory>? SubCategories { get; set; }
        //public List<Book>? Books { get; set; }
        //public List<Educational_Medical_platform.Models.Blog>? Blogs { get; set; }

    }

}
