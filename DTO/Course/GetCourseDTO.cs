using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;

namespace Educational_Medical_platform.DTO.Course
{
    public class GetCourseDTO
    {
        public int Id { get; set; }

        public String Title { get; set; }

        //public IFormFile? Thumbnail { get; set; }

        public string ThumbnailURL { get; set; }

        public float DurationInhours { get; set; }

        public string? Preview { get; set; }

        //----------------------------------------------------

        public string InstructorId { get; set; }

        //public ApplicationUser Instructor { get; set; }

        //----------------------------------------------------

        // Navigation property for enrolled users
        //public List<User_Enrolled_Courses>? EnrolledUsers { get; set; }

        //----------------------------------------------------

        public List<GetCourseRequirmentsDTO>? Requirements { get; set; }

        public List<GetCourseObjectiveDTO>? Objectives { get; set; }

        //public List<Video> Videos { get; set; }

        //public List<Question>? Questions { get; set; }

        public int? SubCategoryId { get; set; }

        //public SubCategory? SubCategory { get; set; }
    }
}