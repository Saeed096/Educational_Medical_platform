﻿namespace Educational_Medical_platform.Models
{
    public class StudentCourses
    {
        // comp 1ry key
        public int StudentId { get; set; } 
        public int CourseId { get; set; }

        public float? Degree { get; set; }

        // to be handeled
        public int Progress { get; set; } = 0;


    }
}
