    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    namespace Educational_Medical_platform.DTO.Course
    {
        public class AddCourseVideosDTO
        {
            [Required(ErrorMessage = "CourseId is required")]
            public int CourseId { get; set; }

            public int Number { get; set; }    

            [Required(ErrorMessage = "Title is required")]
            public string Title { get; set; }

            public string? Description { get; set; }

            [FromForm]
            public IFormFile video { get; set; }
        }
    }