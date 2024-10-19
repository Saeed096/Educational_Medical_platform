using Educational_Medical_platform.Helpers;

namespace Educational_Medical_platform.DTO.StandardTestDTO
{
    public class StandardTestDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Fullmark { get; set; }

        public int Price { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string? SubCategoryName { get; set; }

        public int? SubCategoryId { get; set; }

        public int DurationInMinutes { get; set; }

        //------------------------------------

        public TestType Type { get; set; }

        public string TypeName { get; set; }

        //------------------------------------


        public TestDifficulty Difficulty { get; set; }

        public string DifficultyName { get; set; }

        //------------------------------------

    }
}