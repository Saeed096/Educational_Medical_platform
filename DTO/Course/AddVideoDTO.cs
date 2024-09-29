using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class AddVideoDTO
    {
        public int Number { get; set; }    // no of video in this course videos 

        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        public string? Description { get; set; }

        //public string? videoURL { get; set; }

        [FromForm]
        public IFormFile video { get; set; }

        //[ForeignKey(nameof(Course))]
        //public int CourseId { get; set; }
    }
}