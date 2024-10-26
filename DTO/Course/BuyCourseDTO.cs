using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class BuyCourseDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}