using Educational_Medical_platform.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class SubCategory
    {
        // pk
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string Name { get; set; }

        // fk  
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Course>? Courses { get; set; }
        public List<Book>? Books { get; set; } 
        public List<Blog>? Blogs { get; set; }
        public List<Question>? QuestionBank { get; set; }

        public SubCategoryType Type { get; set; }
    }
}
