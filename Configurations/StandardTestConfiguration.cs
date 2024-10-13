using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Educational_Medical_platform.Helpers;

namespace Educational_Medical_platform.Configurations
{
    public class StandardTestConfiguration : IEntityTypeConfiguration<StandardTest>
    {
        public void Configure(EntityTypeBuilder<StandardTest> builder)
        {
            builder.HasData(
                 new StandardTest()
                 {
                     Id = 1,
                     Title = "Test1",
                     DurationInMinutes = 60,
                     Fullmark = 100,
                     CategoryId = 13,
                     SubCategoryId = 25,
                     Difficulty = TestDifficulty.Easy,
                 },
                 new StandardTest()
                 {
                     Id = 2,
                     Title = "Test2",
                     DurationInMinutes = 100,
                     Fullmark = 150,
                     CategoryId = 14,
                     SubCategoryId = 27,
                     Difficulty = TestDifficulty.Intermediate,
                 },
                 new StandardTest()
                 {
                     Id = 3,
                     Title = "Test3",
                     DurationInMinutes = 200,
                     Fullmark = 300,
                     CategoryId = 15,
                     SubCategoryId = 29,
                     Difficulty = TestDifficulty.Hard,
                 }
                );
        }
    }
}