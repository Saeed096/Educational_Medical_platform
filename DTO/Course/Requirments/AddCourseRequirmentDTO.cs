using Microsoft.AspNetCore.Mvc;

namespace Educational_Medical_platform.DTO.Course.Requirments
{
    public class AddCourseRequirmentDTO
    {
        //public int Id { get; set; }

        [FromForm]
        public string Description { get; set; }

        //public int CourseId { get; set; }
    }
}