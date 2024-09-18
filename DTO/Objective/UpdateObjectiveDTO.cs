using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.Objective
{
    public class UpdateObjectiveDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
