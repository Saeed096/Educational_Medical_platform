using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                // Blogs related to Categories
                new Blog
                {
                    Id = 1,
                    Title = "Introduction to Human Anatomy",
                    Content = "This blog covers the basics of human anatomy...",
                    Intro = "Anatomy is the branch of biology concerned with the study of the structure of organisms and their parts.",
                    Conclusion = "Understanding human anatomy is essential for medical professionals and enthusiasts alike.",
                    LikesNumber = 10,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 1,
                    SubCategoryId = null
                },
                new Blog
                {
                    Id = 2,
                    Title = "Advanced Comparative Anatomy",
                    Content = "This blog explores comparative anatomy across species...",
                    Intro = "Comparative anatomy allows us to understand the similarities and differences between different organisms.",
                    Conclusion = "The study of comparative anatomy is crucial for evolutionary biology and understanding the functional adaptations of organisms.",
                    LikesNumber = 15,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 1,
                    SubCategoryId = null
                },
                new Blog
                {
                    Id = 3,
                    Title = "Fundamentals of Cell Physiology",
                    Content = "Understanding the basics of cell physiology...",
                    Intro = "Cell physiology is the study of the functions of cells and their components.",
                    Conclusion = "A deep understanding of cell physiology is vital for advancements in medical science.",
                    LikesNumber = 20,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 2,
                    SubCategoryId = null
                },

                // Blogs related to SubCategories
                new Blog
                {
                    Id = 4,
                    Title = "Human Anatomy Overview",
                    Content = "This blog provides an overview of human anatomy...",
                    Intro = "An overview of human anatomy highlights the complexity and organization of the human body.",
                    Conclusion = "This overview serves as a foundational step towards more detailed studies of specific systems.",
                    LikesNumber = 5,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 1,
                    SubCategoryId = 1
                },
                new Blog
                {
                    Id = 5,
                    Title = "Systemic Physiology Basics",
                    Content = "An introductory blog on systemic physiology...",
                    Intro = "Systemic physiology studies the functions of various systems within the body.",
                    Conclusion = "Grasping systemic physiology is crucial for understanding how the body maintains homeostasis.",
                    LikesNumber = 8,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 2,
                    SubCategoryId = 4
                },
                new Blog
                {
                    Id = 6,
                    Title = "Clinical Applications of Pharmacology",
                    Content = "Exploring clinical applications in pharmacology...",
                    Intro = "Pharmacology focuses on the interactions between drugs and living organisms.",
                    Conclusion = "Understanding these applications is essential for safe and effective patient care.",
                    LikesNumber = 12,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 3,
                    SubCategoryId = 5
                },
                new Blog
                {
                    Id = 7,
                    Title = "Pathology: An Overview",
                    Content = "A comprehensive overview of pathology...",
                    Intro = "Pathology is the study of disease, its causes, and effects on the body.",
                    Conclusion = "A solid grasp of pathology is necessary for any healthcare professional.",
                    LikesNumber = 7,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 4,
                    SubCategoryId = 7
                }
            );
        }
    }
}
