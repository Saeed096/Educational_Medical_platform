using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.DTO.Requirement;
using Educational_Medical_platform.DTO.Objective;
using Educational_Medical_platform.DTO.Video;
using Educational_Medical_platform.DTO.Question;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class AddCourseDTO
    {
        [Required] 
        public string Title { get; set; }
        public IFormFile? Thumbnail { get; set; }
        //public float DurationInhours { get; set; }   // calculated based on videos length not taken as input from user
        public string? Preview { get; set; }
        public List<AddRequirementDTO>? Requirements { get; set; }
        public List<AddObjectiveDTO>? Objectives { get; set; }
        //[Required] 
        //public List<AddVideoDTO> Videos { get; set; }

        [Required]
        public List<IFormFile> Videos { get; set; }


        public List<AddQuestionDTO>? Questions { get; set; }
        [Required] 
        public int SubCategoryId { get; set; }
        [Required]
        public int InstructorId { get; set; }

    }
}
