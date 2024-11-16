using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                // Questions related to CourseId
                new Question
                {
                    Id = 1,
                    CourseId = 1,
                    Description = "What is the basic unit of life?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 2,
                    CourseId = 1,
                    Description = "Which organelle is known as the powerhouse of the cell?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 3,
                    CourseId = 2,
                    Description = "What is the function of ribosomes?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 4,
                    CourseId = 2,
                    Description = "What is the role of the cell membrane?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 5,
                    CourseId = 2,
                    Description = "What is osmosis?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },

                // Questions related to SubCategoryId
                new Question
                {
                    Id = 6,
                    SubCategoryId = 1,
                    Description = "What is the primary function of the digestive system?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 7,
                    SubCategoryId = 1,
                    Description = "How does the body absorb nutrients?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 8,
                    SubCategoryId = 2,
                    Description = "What are the main components of the digestive system?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 9,
                    SubCategoryId = 2,
                    Description = "What is the role of enzymes in digestion?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 10,
                    SubCategoryId = 3,
                    Description = "What is the process of peristalsis?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },

                // Questions related to BlogId
                new Question
                {
                    Id = 11,
                    BlogId = 1,
                    Description = "What are the key structures of the human body?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 12,
                    BlogId = 1,
                    Description = "How does the muscular system work?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 13,
                    BlogId = 2,
                    Description = "What is the importance of studying anatomy?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 14,
                    BlogId = 2,
                    Description = "What are the different systems of the human body?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 15,
                    BlogId = 3,
                    Description = "What role does the nervous system play in body functions?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },

                // Questions related to TestId
                new Question
                {
                    Id = 16,
                    TestId = 1,
                    Description = "What is the primary function of red blood cells?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 17,
                    TestId = 1,
                    Description = "How does the immune system protect the body?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 18,
                    TestId = 2,
                    Description = "What are the stages of the cell cycle?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 19,
                    TestId = 2,
                    Description = "What is apoptosis?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 20,
                    TestId = 2,
                    Description = "What role does DNA play in inheritance?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                }
            );
        }
    }
}
