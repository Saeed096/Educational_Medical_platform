using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Educational_Medical_platform.DTO.Answer;
namespace Educational_Medical_platform.DTO.Question
{
    public class GetQuestionDTO
    {
        public int Id { get; set; }


        public int? TestId { get; set; }

        public int? SubCategoryId { get; set; }  // nullable as this question may not be related to any question bank but related to course questions 

        public int? CourseId { get; set; }

        public int? BlogId { get; set; }
        public List<GetAnswerDTO> Answers { get; set; }

    }
}
