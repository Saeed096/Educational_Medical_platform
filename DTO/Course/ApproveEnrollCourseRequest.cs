﻿using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Course
{
    public class ApproveEnrollCourseRequest
    {
        [Required(ErrorMessage = "StudentId is required")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "InstructorId is required")]
        public string InstructorId { get; set; }

        [Required(ErrorMessage = "CourseId is required")]
        public int CourseId { get; set; }
    }
}