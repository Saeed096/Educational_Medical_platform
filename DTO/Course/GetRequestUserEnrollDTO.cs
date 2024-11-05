using Educational_Medical_platform.Helpers;

namespace Educational_Medical_platform.DTO.Course
{
    public class GetRequestUserEnrollDTO
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }

        public string InstructorId { get; set; }
        public string InstructorName { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        //----------------------------------

        public DateTime StartDate { get; set; }

        public EnrollRequestStatus Status { get; set; } = EnrollRequestStatus.PendingApproval;

        public string StatusName { get; set; }

        public string TransactionImageURL { get; set; } = string.Empty;
    }
}