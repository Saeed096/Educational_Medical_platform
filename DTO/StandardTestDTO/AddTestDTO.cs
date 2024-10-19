using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.StandardTestDTO
{
    public class AddTestDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fullmark is required")]
        public int Fullmark { get; set; }

        //public int CategoryId { get; set; }

        [Required(ErrorMessage = "SubCategoryId is required")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "DurationInMinutes is required")]
        public int DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Price is required (Note : price = 0 if the test type is free)")]
        public int Price { get; set; }

        //------------------------------------

        [Required(ErrorMessage = "TestType is required ( free => 0 , Premium => 1)")]
        public TestType Type { get; set; }

        //------------------------------------

        [Required(ErrorMessage = "TestDifficulty is required (Easy => 0 , Intermediate => 1 , Hard => 2)")]
        public TestDifficulty Difficulty { get; set; }

        //------------------------------------
    }
}