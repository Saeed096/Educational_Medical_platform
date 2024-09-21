﻿using Educational_Medical_platform.DTO.Answer;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Question
{
    public class AddQuestionDTO
    {
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Description Must be within (3-200) chars")]
        public string Description { get; set; }

        public List<AddAnswerDTO> Answers { get; set; }
    }
}