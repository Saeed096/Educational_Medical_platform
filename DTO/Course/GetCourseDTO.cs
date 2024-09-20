using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Educational_Medical_platform.DTO.Requirement;
using Educational_Medical_platform.DTO.Objective;
using Educational_Medical_platform.DTO.Video;
using Educational_Medical_platform.DTO.Question;
using System.ComponentModel.DataAnnotations;
namespace Educational_Medical_platform.DTO.Course
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public string? ThumbnailURL { get; set; }
        public float DurationInhours { get; set; }
        public string? Preview { get; set; }
        public List<GetRequirementDTO>? Requirements { get; set; }
        public List<GetObjectiveDTO>? Objectives { get; set; }
        public List<GetVideoDTO> Videos { get; set; }
        public List<GetQuestionDTO>? Questions { get; set; }
        public int SubCategoryId { get; set; }
        public int InstructorId { get; set; }
    }
}
