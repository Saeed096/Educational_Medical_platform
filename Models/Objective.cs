﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Objective
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }

        [ForeignKey ("Course")]
        public int CourseId { get; set; }
    }
}
