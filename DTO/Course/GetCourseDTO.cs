using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.Helpers;

namespace Educational_Medical_platform.DTO.Course
{
    public class GetCourseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        //public IFormFile? Thumbnail { get; set; }

        public string? ThumbnailURL { get; set; }

        public float DurationInhours { get; set; }

        public string? Preview { get; set; }

        public CourseType Type { get; set; }

        public string TypeName { get; set; }

        public CourseStatus Status { get; set; }

        public string StatusName { get; set; }

        public string? RejectionReason { get; set; }

        //----------------------------------------------------

        public string InstructorId { get; set; }

        public string InstructorFullName { get; set; }

        //public ApplicationUser Instructor { get; set; }

        //----------------------------------------------------

        // Navigation property for enrolled users
        //public List<User_Enrolled_Courses>? EnrolledUsers { get; set; }

        //----------------------------------------------------

        public List<GetCourseRequirmentsDTO>? Requirements { get; set; }

        public List<GetCourseObjectiveDTO>? Objectives { get; set; }

        public List<GetVideoDTO>? Videos { get; set; }

        //public List<Question>? Questions { get; set; }

        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //public SubCategory? SubCategory { get; set; }
    }
}