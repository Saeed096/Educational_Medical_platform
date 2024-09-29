using Microsoft.AspNetCore.Mvc;

namespace Educational_Medical_platform.DTO.Course.Objectives
{
    public class AddCourseObjectiveDTO
    {
        //public int Id { get; set; }

        [FromForm]
        public string Description { get; set; }

        //public int CourseId { get; set; }
    }
}