using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.Requirement
{
    public class GetRequirementDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int CourseId { get; set; }
    }
}
