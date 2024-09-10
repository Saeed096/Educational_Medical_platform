﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Answer
    {
        // pk
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        // fk
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
