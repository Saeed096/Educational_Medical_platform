
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Helpers
{
    public enum Gender
    {
        Male = 0,

        Female = 1,
    }

    public enum Role
    {
        Student = 0,

        Instructor = 1,

        Admin = 2,
    }

    public enum CourseType
    {
        Free = 0 ,

        Paid = 1 ,
    }

    public enum CategoryType
    {
        Courses = 0 ,
        Books = 1 ,
        Blogs = 2 ,
        Exams= 3 ,

    }
    
    public enum SubCategoryType
    {
        Courses = 0 ,
        Books = 1 ,
        Blogs = 2 ,
        Exams= 3 ,

    }

}