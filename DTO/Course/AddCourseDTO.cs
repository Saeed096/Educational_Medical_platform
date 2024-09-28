using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class AddCourseDTO
    {
        [Required(ErrorMessage = "InstructorID is required")]
        public string InstructorID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "DurationInhours is required")]
        public float DurationInhours { get; set; }

        [Required(ErrorMessage = "Preview is required")]
        public string Preview { get; set; }

        public IFormFile? Thumbnail { get; set; }

        [Required(ErrorMessage = "SubCategoryId is required")]
        public int SubCategoryId { get; set; }

        public List<AddCourseRequirmentDTO>? Requirements { get; set; }

        public List<AddCourseObjectiveDTO>? Objectives { get; set; }
    }
}