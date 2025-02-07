using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            // Seed Initial data for SubCategory
            builder.HasData(

                // Courses
                new SubCategory { Id = 1, Name = "Human Anatomy", CategoryId = 1, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 2, Name = "Comparative Anatomy", CategoryId = 1, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 3, Name = "Cell Physiology", CategoryId = 2, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 4, Name = "Systemic Physiology", CategoryId = 2, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 5, Name = "Clinical Pharmacology", CategoryId = 3, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 6, Name = "Pharmacokinetics", CategoryId = 3, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 7, Name = "General Pathology", CategoryId = 4, Type = Helpers.SubCategoryType.Courses },
                new SubCategory { Id = 8, Name = "Systemic Pathology", CategoryId = 4, Type = Helpers.SubCategoryType.Courses }

        ,         // Books
                new SubCategory { Id = 9, Name = "Human Anatomy Book", CategoryId = 5, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 10, Name = "Comparative Anatomy Book", CategoryId = 5, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 11, Name = "Cell Physiology Book", CategoryId = 6, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 12, Name = "Systemic Physiology Book", CategoryId = 6, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 13, Name = "Clinical Pharmacology Book", CategoryId = 7, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 14, Name = "Pharmacokinetics Book", CategoryId = 7, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 15, Name = "General Pathology Book", CategoryId = 8, Type = Helpers.SubCategoryType.Books },
                new SubCategory { Id = 16, Name = "Systemic Pathology Book", CategoryId = 8, Type = Helpers.SubCategoryType.Books },

                // Blogs
                new SubCategory { Id = 17, Name = "Human Anatomy Blog", CategoryId = 9, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 18, Name = "Comparative Anatomy Blog", CategoryId = 9, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 19, Name = "Cell Physiology Blog", CategoryId = 10, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 20, Name = "Systemic Physiology Blog", CategoryId = 10, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 21, Name = "Clinical Pharmacology Blog", CategoryId = 11, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 22, Name = "Pharmacokinetics Blog", CategoryId = 11, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 23, Name = "General Pathology Blog", CategoryId = 12, Type = Helpers.SubCategoryType.Blogs },
                new SubCategory { Id = 24, Name = "Systemic Pathology Blog", CategoryId = 12, Type = Helpers.SubCategoryType.Blogs },

                // Exams
                new SubCategory { Id = 25, Name = "Human Anatomy Exam", CategoryId = 13, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 26, Name = "Comparative Anatomy Exam", CategoryId = 13, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 27, Name = "Cell Physiology Exam", CategoryId = 14, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 28, Name = "Systemic Physiology Exam", CategoryId = 14, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 29, Name = "Clinical Pharmacology Exam", CategoryId = 15, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 30, Name = "Pharmacokinetics Exam", CategoryId = 15, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 31, Name = "General Pathology Exam", CategoryId = 16, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 32, Name = "Systemic Pathology Exam", CategoryId = 16, Type = Helpers.SubCategoryType.Exams },

                // real data 
                new SubCategory { Id = 33, Name = "Surgery", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 34, Name = "Burns", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 35, Name = "Surgery & Burns", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 36, Name = "Cardiology & Chest", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 37, Name = "Cancer", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 38, Name = "Dermatology", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 39, Name = "Other systems", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 40, Name = "Basic science", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 41, Name = "Gynecology", CategoryId = 17, Type = Helpers.SubCategoryType.Exams },
                new SubCategory { Id = 42, Name = "Neurology", CategoryId = 17, Type = Helpers.SubCategoryType.Exams }


                );
        }
    }
}