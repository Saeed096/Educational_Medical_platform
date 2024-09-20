using Educational_Medical_platform.DTO.Answer;

namespace Educational_Medical_platform.DTO.Question
{
    public class AddQuestionDTO
    {
        public int? TestId { get; set; }
        public int? SubCategoryId { get; set; }  // nullable as this question may not be related to any question bank but related to course questions 
        public int? CourseId { get; set; }
        public int? BlogId { get; set; }
        public List<AddAnswerDTO> Answers { get; set; }
    }
}
