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

    public enum CourseStatus
    {
        PendingApproval = 0,

        Approved = 1,

        PendingDeletion = 2
    }

}