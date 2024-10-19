using Educational_Medical_platform.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class StandardTest
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Fullmark { get; set; }

        public int Price { get; set; }

        public TestType Type { get; set; }

        public TestDifficulty Difficulty { get; set; }

        // can be ignored and handdled in front >> min foreach question 
        public int DurationInMinutes { get; set; }

        //----------------------------------------------------

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        //  ==========================

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //----------------------------------------------------

        public List<Question> Question { get; set; }
    }
}