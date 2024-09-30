using Educational_Medical_platform.Helpers;
using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        //[NotMapped]
        //public IFormFile? Thumbnail { get; set; }

        public string? ThumbnailURL { get; set; }

        public float DurationInhours { get; set; }

        public string? Preview { get; set; }

        public CourseType Type { get; set; } = CourseType.Free; // 0 => free , 1 => paid

        //----------------------------------------------------

        public string InstructorId { get; set; }

        public ApplicationUser Instructor { get; set; }
            
        //----------------------------------------------------

        // Navigation property for enrolled users
        public List<User_Enrolled_Courses>? EnrolledUsers { get; set; }

        //----------------------------------------------------

        public List<Requirement>? Requirements { get; set; }

        public List<Objective>? Objectives { get; set; }

        public List<Video> Videos { get; set; }

        public List<Question>? Questions { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }
    }
}