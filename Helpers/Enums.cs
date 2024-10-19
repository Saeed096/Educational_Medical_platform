using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Helpers
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 0,

        [Display(Name = "Female")]
        Female = 1,
    }

    public enum Role
    {
        [Display(Name = "Student Role")]
        Student = 0,

        [Display(Name = "Instructor Role")]
        Instructor = 1,

        [Display(Name = "Admin Role")]
        Admin = 2,
    }



    public enum CategoryType
    {
        [Display(Name = "Course Category")]
        Courses = 0,

        [Display(Name = "Book Category")]
        Books = 1,

        [Display(Name = "Blog Category")]
        Blogs = 2,

        [Display(Name = "Exam Category")]
        Exams = 3,
    }

    public enum SubCategoryType
    {
        [Display(Name = "Course SubCategory")]
        Courses = 0,

        [Display(Name = "Book SubCategory")]
        Books = 1,

        [Display(Name = "Blog SubCategory")]
        Blogs = 2,

        [Display(Name = "Exam SubCategory")]
        Exams = 3,
    }

    public enum CourseType
    {
        [Display(Name = "Free Course")]
        Free = 0,

        [Display(Name = "Paid Course")]
        Paid = 1,
    }

    public enum CourseStatus
    {
        [Display(Name = "Pending Approval")]
        PendingApproval = 0,

        [Display(Name = "Approved")]
        Approved = 1,

        [Display(Name = "Pending Deletion")]
        PendingDeletion = 2,

        [Display(Name = "Rejected")]
        Rejected = 3,
    }

    public enum TestType
    {
        [Display(Name = "Free Test")]
        Free = 0,

        [Display(Name = "Premium Test")]
        Premium = 1,
    }

    public enum TestDifficulty
    {
        [Display(Name = "Easy Level")]
        Easy = 0,

        [Display(Name = "Intermediate Level")]
        Intermediate = 1,

        [Display(Name = "Hard Level")]
        Hard = 2,
    }
}