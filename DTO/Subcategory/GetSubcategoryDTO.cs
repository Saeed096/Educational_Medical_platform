using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Blog;
using Educational_Medical_platform.DTO.Question;

namespace Educational_Medical_platform.DTO.Subcategory
{
    public class GetSubcategoryDTO
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public List<GetCourseDTO>? Courses { get; set; }
        //public List<getbookdto>? Books { get; set; }  // till maher push
        public List<GetBlogsDTO>? Blogs { get; set; }
        public List<GetQuestionDTO>? QuestionBank { get; set; }

    }
}
