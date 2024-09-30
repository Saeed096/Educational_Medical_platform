using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class EditCourseVideoDTO
    {
        [Required(ErrorMessage = "VideoId is required")]
        public int VideoId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public int Number { get; set; }

        public string? Description { get; set; }

        [FromForm]
        public IFormFile? video { get; set; } // Optional video file
    }
}