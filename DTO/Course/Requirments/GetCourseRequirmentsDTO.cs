using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course.Requirments
{
    public class GetCourseRequirmentsDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }
    }
}