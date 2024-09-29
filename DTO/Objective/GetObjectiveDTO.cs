using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.Objective
{
    public class GetObjectiveDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        //public Course Course { get; set; }

        public int CourseId { get; set; }
    }
}
