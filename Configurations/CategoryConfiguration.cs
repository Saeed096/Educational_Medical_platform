using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Seed Initial data for Category
            builder.HasData(

                // Courses
                new Category { Id = 1, Name = "Anatomy Course", Type = Helpers.CategoryType.Courses },
                new Category { Id = 2, Name = "Physiology Course", Type = Helpers.CategoryType.Courses },
                new Category { Id = 3, Name = "Pharmacology Course", Type = Helpers.CategoryType.Courses },
                new Category { Id = 4, Name = "Pathology Course", Type = Helpers.CategoryType.Courses },

                // Books
                new Category { Id = 5, Name = "Anatomy Book", Type = Helpers.CategoryType.Books },
                new Category { Id = 6, Name = "Physiology Book", Type = Helpers.CategoryType.Books },
                new Category { Id = 7, Name = "Pharmacology Book", Type = Helpers.CategoryType.Books },
                new Category { Id = 8, Name = "Pathology Book", Type = Helpers.CategoryType.Books },

                // Blogs
                new Category { Id = 9, Name = "Anatomy Blog", Type = Helpers.CategoryType.Blogs },
                new Category { Id = 10, Name = "Physiology Blog", Type = Helpers.CategoryType.Blogs },
                new Category { Id = 11, Name = "Pharmacology Blog", Type = Helpers.CategoryType.Blogs },
                new Category { Id = 12, Name = "Pathology Blog", Type = Helpers.CategoryType.Blogs },

                // Exams
                new Category { Id = 13, Name = "Anatomy Exam", Type = Helpers.CategoryType.Exams },
                new Category { Id = 14, Name = "Physiology Exam", Type = Helpers.CategoryType.Exams },
                new Category { Id = 15, Name = "Pharmacology Exam", Type = Helpers.CategoryType.Exams },
                new Category { Id = 16, Name = "Pathology Exam", Type = Helpers.CategoryType.Exams }
            );
        }
    }
}