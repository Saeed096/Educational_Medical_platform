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
                    LikesNumber = 7,
                    ImageURL = "/Images/Blogs/blog1.jpg",
                    CategoryId = 4,
                    SubCategoryId = 7
                }
                );
        }
    }
}