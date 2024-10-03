using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class EditCourseDTO
    {
        [Required(ErrorMessage = "CourseID is required")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CourseType is required ( 0 => free , 1 => paid)")]
        public CourseType Type { get; set; }

        //[Required(ErrorMessage = "InstructorID is required")]
        //public string InstructorID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "DurationInhours is required")]
        public float DurationInhours { get; set; }

        [Required(ErrorMessage = "Preview is required")]
        public string Preview { get; set; }

        public IFormFile? Thumbnail { get; set; }

        [Required(ErrorMessage = "SubCategoryId is required")]
        public int SubCategoryId { get; set; }

        [FromForm]
        public List<AddCourseRequirmentDTO>? Requirements { get; set; }

        [FromForm]
        public List<AddCourseObjectiveDTO>? Objectives { get; set; }
    }
}