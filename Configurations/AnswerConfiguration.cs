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
                new Answer { Id = 1, QuestionId = 1, Description = "Cell", IsCorrect = true, Reason = "Cells are the basic building blocks of life." },
                new Answer { Id = 2, QuestionId = 1, Description = "Tissue", IsCorrect = false, Reason = "Tissues are made up of cells, but they are not the smallest unit of life." },
                new Answer { Id = 3, QuestionId = 1, Description = "Organ", IsCorrect = false, Reason = "Organs are composed of tissues, which consist of cells." },

                new Answer { Id = 4, QuestionId = 2, Description = "Mitochondria", IsCorrect = true, Reason = "Mitochondria are known as the powerhouse of the cell." },
                new Answer { Id = 5, QuestionId = 2, Description = "Nucleus", IsCorrect = false, Reason = "The nucleus contains the cell's genetic material, but does not produce energy." },
                new Answer { Id = 6, QuestionId = 2, Description = "Ribosome", IsCorrect = false, Reason = "Ribosomes are responsible for protein synthesis, not energy production." },

                new Answer { Id = 7, QuestionId = 3, Description = "Protein synthesis", IsCorrect = true, Reason = "This is the primary function of ribosomes in the cell." },
                new Answer { Id = 8, QuestionId = 3, Description = "Energy production", IsCorrect = false, Reason = "Energy production occurs in the mitochondria, not during protein synthesis." },
                new Answer { Id = 9, QuestionId = 3, Description = "DNA replication", IsCorrect = false, Reason = "DNA replication is a separate process from protein synthesis." },

                new Answer { Id = 10, QuestionId = 4, Description = "Protects the cell", IsCorrect = true, Reason = "The cell membrane protects the cell from its environment." },
                new Answer { Id = 11, QuestionId = 4, Description = "Stores DNA", IsCorrect = false, Reason = "DNA is stored in the nucleus, not the cell membrane." },
                new Answer { Id = 12, QuestionId = 4, Description = "Produces energy", IsCorrect = false, Reason = "Energy production occurs in mitochondria, not the cell membrane." },

                new Answer { Id = 13, QuestionId = 5, Description = "Movement of water", IsCorrect = true, Reason = "Osmosis is the movement of water across a membrane." },
                new Answer { Id = 14, QuestionId = 5, Description = "Transport of nutrients", IsCorrect = false, Reason = "Nutrient transport occurs via active and passive transport mechanisms, not osmosis." },
                new Answer { Id = 15, QuestionId = 5, Description = "Protein synthesis", IsCorrect = false, Reason = "Protein synthesis involves ribosomes, not the movement of water." },

                // Answers for SubCategory-related Questions
                new Answer { Id = 16, QuestionId = 6, Description = "Breaks down food", IsCorrect = true, Reason = "The digestive system's primary role is to break down food." },
                new Answer { Id = 17, QuestionId = 6, Description = "Circulates blood", IsCorrect = false, Reason = "Blood circulation is the role of the circulatory system." },
                new Answer { Id = 18, QuestionId = 6, Description = "Transports oxygen", IsCorrect = false, Reason = "Oxygen transport is handled by the respiratory system." },

                new Answer { Id = 19, QuestionId = 7, Description = "Through the walls of the intestines", IsCorrect = true, Reason = "Nutrients are absorbed through the intestinal walls into the bloodstream." },
                new Answer { Id = 20, QuestionId = 7, Description = "Via the bloodstream", IsCorrect = false, Reason = "The bloodstream transports nutrients after they are absorbed." },
                new Answer { Id = 21, QuestionId = 7, Description = "By chewing", IsCorrect = false, Reason = "Chewing is part of the mechanical digestion process, not nutrient absorption." },

                new Answer { Id = 22, QuestionId = 8, Description = "Mouth, esophagus, stomach", IsCorrect = true, Reason = "These are the primary organs involved in the digestive process." },
                new Answer { Id = 23, QuestionId = 8, Description = "Brain, heart, lungs", IsCorrect = false, Reason = "These organs are not directly involved in digestion." },
                new Answer { Id = 24, QuestionId = 8, Description = "Skin, muscles, bones", IsCorrect = false, Reason = "These are not part of the digestive system." },

                new Answer { Id = 25, QuestionId = 9, Description = "They speed up chemical reactions", IsCorrect = true, Reason = "Enzymes are biological catalysts that accelerate chemical reactions." },
                new Answer { Id = 26, QuestionId = 9, Description = "They are absorbed", IsCorrect = false, Reason = "Enzymes are not absorbed; they assist in reactions." },
                new Answer { Id = 27, QuestionId = 9, Description = "They break down food", IsCorrect = false, Reason = "While enzymes help in breaking down food, they do not do so independently." },

                new Answer { Id = 28, QuestionId = 10, Description = "The wave-like motion that moves food", IsCorrect = true, Reason = "Peristalsis is the wave-like motion that moves food through the digestive tract." },
                new Answer { Id = 29, QuestionId = 10, Description = "The absorption of nutrients", IsCorrect = false, Reason = "Nutrient absorption occurs after food is moved through the digestive tract." },
                new Answer { Id = 30, QuestionId = 10, Description = "The secretion of enzymes", IsCorrect = false, Reason = "Enzyme secretion assists in digestion but is not the motion that moves food." },

                // Answers for Blog-related Questions
                new Answer { Id = 31, QuestionId = 11, Description = "Organs and systems", IsCorrect = true, Reason = "These are the correct components when discussing body structures." },
                new Answer { Id = 32, QuestionId = 11, Description = "Cells only", IsCorrect = false, Reason = "Cells are part of organs and systems, not the only component." },
                new Answer { Id = 33, QuestionId = 11, Description = "Muscles only", IsCorrect = false, Reason = "Muscles are just one type of tissue, which is part of organs and systems." },

                new Answer { Id = 34, QuestionId = 12, Description = "By contracting and relaxing", IsCorrect = true, Reason = "Muscles work by contracting and relaxing to produce movement." },
                new Answer { Id = 35, QuestionId = 12, Description = "By sending signals", IsCorrect = false, Reason = "While signaling is important, it does not describe how muscles function directly." },
                new Answer { Id = 36, QuestionId = 12, Description = "By absorbing nutrients", IsCorrect = false, Reason = "Muscles do not absorb nutrients; this is a function of the digestive system." },

                new Answer { Id = 37, QuestionId = 13, Description = "To understand the human body", IsCorrect = true, Reason = "Anatomy is studied to understand the structure and function of the body." },
                new Answer { Id = 38, QuestionId = 13, Description = "To pass exams", IsCorrect = false, Reason = "While exams may test knowledge, they are not the purpose of studying anatomy." },
                new Answer { Id = 39, QuestionId = 13, Description = "To perform surgeries", IsCorrect = false, Reason = "While anatomy knowledge is important for surgeries, it is not the sole purpose of the study." },

                new Answer { Id = 40, QuestionId = 14, Description = "Nervous, muscular, skeletal", IsCorrect = true, Reason = "These are major body systems." },
                new Answer { Id = 41, QuestionId = 14, Description = "Respiratory, circulatory", IsCorrect = false, Reason = "While important, they do not encompass all major systems." },
                new Answer { Id = 42, QuestionId = 14, Description = "Digestive, excretory", IsCorrect = false, Reason = "These systems are essential but are not all-inclusive of body systems." },

                new Answer { Id = 43, QuestionId = 15, Description = "Controls body functions", IsCorrect = true, Reason = "The nervous system regulates bodily functions." },
                new Answer { Id = 44, QuestionId = 15, Description = "Transports nutrients", IsCorrect = false, Reason = "Nutrient transport is handled by the circulatory system." },
                new Answer { Id = 45, QuestionId = 15, Description = "Provides energy", IsCorrect = false, Reason = "Energy provision is not a primary role of the nervous system." },

                // Answers for Test-related Questions
                new Answer { Id = 46, QuestionId = 16, Description = "To carry oxygen", IsCorrect = true, Reason = "Hemoglobin in red blood cells carries oxygen." },
                new Answer { Id = 47, QuestionId = 16, Description = "To fight infections", IsCorrect = false, Reason = "Fighting infections is primarily the role of the immune system." },
                new Answer { Id = 48, QuestionId = 16, Description = "To clot blood", IsCorrect = false, Reason = "Blood clotting is done by platelets and certain plasma proteins." },

                new Answer { Id = 49, QuestionId = 17, Description = "By recognizing pathogens", IsCorrect = true, Reason = "The immune system identifies and targets pathogens." },
                new Answer { Id = 50, QuestionId = 17, Description = "By producing energy", IsCorrect = false, Reason = "Energy production is not a function of the immune system." },
                new Answer { Id = 51, QuestionId = 17, Description = "By storing nutrients", IsCorrect = false, Reason = "Nutrient storage is a function of the liver and other organs." },

                new Answer { Id = 52, QuestionId = 18, Description = "Interphase, mitosis, cytokinesis", IsCorrect = true, Reason = "These are the stages of the cell cycle." },
                new Answer { Id = 53, QuestionId = 18, Description = "Prophase, metaphase, anaphase", IsCorrect = false, Reason = "These terms refer to stages of mitosis, not the entire cell cycle." },
                new Answer { Id = 54, QuestionId = 18, Description = "Meiosis only", IsCorrect = false, Reason = "Meiosis is a specific type of cell division, separate from the cell cycle." },

                new Answer { Id = 55, QuestionId = 19, Description = "Programmed cell death", IsCorrect = true, Reason = "Apoptosis is the process of programmed cell death." },
                new Answer { Id = 56, QuestionId = 19, Description = "Cell growth", IsCorrect = false, Reason = "Cell growth is a separate process from apoptosis." },
                new Answer { Id = 57, QuestionId = 19, Description = "Cell division", IsCorrect = false, Reason = "Cell division is the process of replicating cells, distinct from programmed cell death." },

                new Answer { Id = 58, QuestionId = 20, Description = "Carries genetic information", IsCorrect = true, Reason = "DNA is the molecule that carries genetic information." },
                new Answer { Id = 59, QuestionId = 20, Description = "Produces energy", IsCorrect = false, Reason = "Energy production is not a role of DNA." },
                new Answer { Id = 60, QuestionId = 20, Description = "Fights diseases", IsCorrect = false, Reason = "DNA does not directly fight diseases; it contains the instructions for making proteins." }
            );
        }
    }
}
