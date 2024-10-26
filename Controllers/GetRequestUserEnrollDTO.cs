﻿using Educational_Medical_platform.Helpers;

namespace Educational_Medical_platform.Controllers
{
    public class GetRequestUserEnrollDTO
    {
        public string StudentId { get; set; }

        public string InstructorId { get; set; }

        public int CourseId { get; set; }

        //----------------------------------

        public DateTime StartDate { get; set; }

        public EnrollRequestStatus Status { get; set; } = EnrollRequestStatus.PendingApproval;

        public string StatusName { get; set; }

        public string TransactionImageURL { get; set; } = string.Empty;
    }
}
