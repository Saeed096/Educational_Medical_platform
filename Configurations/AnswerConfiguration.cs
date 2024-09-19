using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(
                // Answers for Course-related Questions
                new Answer { Id = 1, QuestionId = 1, Description = "Cell", IsCorrect = true },
                new Answer { Id = 2, QuestionId = 1, Description = "Tissue", IsCorrect = false },
                new Answer { Id = 3, QuestionId = 1, Description = "Organ", IsCorrect = false },

                new Answer { Id = 4, QuestionId = 2, Description = "Mitochondria", IsCorrect = true },
                new Answer { Id = 5, QuestionId = 2, Description = "Nucleus", IsCorrect = false },
                new Answer { Id = 6, QuestionId = 2, Description = "Ribosome", IsCorrect = false },

                new Answer { Id = 7, QuestionId = 3, Description = "Protein synthesis", IsCorrect = true },
                new Answer { Id = 8, QuestionId = 3, Description = "Energy production", IsCorrect = false },
                new Answer { Id = 9, QuestionId = 3, Description = "DNA replication", IsCorrect = false },

                new Answer { Id = 10, QuestionId = 4, Description = "Protects the cell", IsCorrect = true },
                new Answer { Id = 11, QuestionId = 4, Description = "Stores DNA", IsCorrect = false },
                new Answer { Id = 12, QuestionId = 4, Description = "Produces energy", IsCorrect = false },

                new Answer { Id = 13, QuestionId = 5, Description = "Movement of water", IsCorrect = true },
                new Answer { Id = 14, QuestionId = 5, Description = "Transport of nutrients", IsCorrect = false },
                new Answer { Id = 15, QuestionId = 5, Description = "Protein synthesis", IsCorrect = false },

                // Answers for SubCategory-related Questions
                new Answer { Id = 16, QuestionId = 6, Description = "Breaks down food", IsCorrect = true },
                new Answer { Id = 17, QuestionId = 6, Description = "Circulates blood", IsCorrect = false },
                new Answer { Id = 18, QuestionId = 6, Description = "Transports oxygen", IsCorrect = false },

                new Answer { Id = 19, QuestionId = 7, Description = "Through the walls of the intestines", IsCorrect = true },
                new Answer { Id = 20, QuestionId = 7, Description = "Via the bloodstream", IsCorrect = false },
                new Answer { Id = 21, QuestionId = 7, Description = "By chewing", IsCorrect = false },

                new Answer { Id = 22, QuestionId = 8, Description = "Mouth, esophagus, stomach", IsCorrect = true },
                new Answer { Id = 23, QuestionId = 8, Description = "Brain, heart, lungs", IsCorrect = false },
                new Answer { Id = 24, QuestionId = 8, Description = "Skin, muscles, bones", IsCorrect = false },

                new Answer { Id = 25, QuestionId = 9, Description = "They speed up chemical reactions", IsCorrect = true },
                new Answer { Id = 26, QuestionId = 9, Description = "They are absorbed", IsCorrect = false },
                new Answer { Id = 27, QuestionId = 9, Description = "They break down food", IsCorrect = false },

                new Answer { Id = 28, QuestionId = 10, Description = "The wave-like motion that moves food", IsCorrect = true },
                new Answer { Id = 29, QuestionId = 10, Description = "The absorption of nutrients", IsCorrect = false },
                new Answer { Id = 30, QuestionId = 10, Description = "The secretion of enzymes", IsCorrect = false },

                // Answers for Blog-related Questions
                new Answer { Id = 31, QuestionId = 11, Description = "Organs and systems", IsCorrect = true },
                new Answer { Id = 32, QuestionId = 11, Description = "Cells only", IsCorrect = false },
                new Answer { Id = 33, QuestionId = 11, Description = "Muscles only", IsCorrect = false },

                new Answer { Id = 34, QuestionId = 12, Description = "By contracting and relaxing", IsCorrect = true },
                new Answer { Id = 35, QuestionId = 12, Description = "By sending signals", IsCorrect = false },
                new Answer { Id = 36, QuestionId = 12, Description = "By absorbing nutrients", IsCorrect = false },

                new Answer { Id = 37, QuestionId = 13, Description = "To understand the human body", IsCorrect = true },
                new Answer { Id = 38, QuestionId = 13, Description = "To pass exams", IsCorrect = false },
                new Answer { Id = 39, QuestionId = 13, Description = "To perform surgeries", IsCorrect = false },

                new Answer { Id = 40, QuestionId = 14, Description = "Nervous, muscular, skeletal", IsCorrect = true },
                new Answer { Id = 41, QuestionId = 14, Description = "Respiratory, circulatory", IsCorrect = false },
                new Answer { Id = 42, QuestionId = 14, Description = "Digestive, excretory", IsCorrect = false },

                new Answer { Id = 43, QuestionId = 15, Description = "Controls body functions", IsCorrect = true },
                new Answer { Id = 44, QuestionId = 15, Description = "Transports nutrients", IsCorrect = false },
                new Answer { Id = 45, QuestionId = 15, Description = "Provides energy", IsCorrect = false },

                // Answers for Test-related Questions
                new Answer { Id = 46, QuestionId = 16, Description = "To carry oxygen", IsCorrect = true },
                new Answer { Id = 47, QuestionId = 16, Description = "To fight infections", IsCorrect = false },
                new Answer { Id = 48, QuestionId = 16, Description = "To clot blood", IsCorrect = false },

                new Answer { Id = 49, QuestionId = 17, Description = "By recognizing pathogens", IsCorrect = true },
                new Answer { Id = 50, QuestionId = 17, Description = "By producing energy", IsCorrect = false },
                new Answer { Id = 51, QuestionId = 17, Description = "By storing nutrients", IsCorrect = false },

                new Answer { Id = 52, QuestionId = 18, Description = "Interphase, mitosis, cytokinesis", IsCorrect = true },
                new Answer { Id = 53, QuestionId = 18, Description = "Prophase, metaphase, anaphase", IsCorrect = false },
                new Answer { Id = 54, QuestionId = 18, Description = "Meiosis only", IsCorrect = false },

                new Answer { Id = 55, QuestionId = 19, Description = "Programmed cell death", IsCorrect = true },
                new Answer { Id = 56, QuestionId = 19, Description = "Cell growth", IsCorrect = false },
                new Answer { Id = 57, QuestionId = 19, Description = "Cell division", IsCorrect = false },

                new Answer { Id = 58, QuestionId = 20, Description = "Carries genetic information", IsCorrect = true },
                new Answer { Id = 59, QuestionId = 20, Description = "Produces energy", IsCorrect = false },
                new Answer { Id = 60, QuestionId = 20, Description = "Fights diseases", IsCorrect = false }
            );
        }
    }
}
