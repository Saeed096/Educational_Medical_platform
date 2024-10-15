using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Introduction to Medical Studies",
                    Description = "A comprehensive guide for first-year medical students.",
                    PublisherName = "Mohamed Galal",
                    PublisherRole = "User",
                    PublishDate = new DateTime(2021, 4, 15),
                    ThumbnailURL = "https://example.com/thumbnails/book1.jpg",
                    Url = "https://example.com/books/intro-medical-studies",
                    SubCategoryId = 9,
                    CategoryId = 5,
                    UserId = "2b222b22-2222-2222-2222-222222222222"
                },
                new Book
                {
                    Id = 2,
                    Title = "Advanced Human Anatomy",
                    Description = "In-depth study of human anatomy for advanced medical students.",
                    PublisherName = "Mohamed Galal",
                    PublisherRole = "User",
                    PublishDate = new DateTime(2020, 11, 20),
                    ThumbnailURL = "https://example.com/thumbnails/book2.jpg",
                    Url = "https://example.com/books/advanced-anatomy",
                    SubCategoryId = 9,
                    CategoryId = 5,
                    UserId = "2b222b22-2222-2222-2222-222222222222"

                },
                new Book
                {
                    Id = 3,
                    Title = "Clinical Diagnosis Techniques",
                    Description = "A practical guide to clinical diagnostic methods.",
                    PublisherName = "Alaa Ahmed",
                    PublisherRole = "User",
                    PublishDate = new DateTime(2019, 7, 10),
                    ThumbnailURL = "https://example.com/thumbnails/book3.jpg",
                    Url = "https://example.com/books/clinical-diagnosis",
                    SubCategoryId = 10,
                    CategoryId = 5,
                    UserId = "3c333c33-3333-3333-3333-333333333333"
                },
                new Book
                {
                    Id = 4,
                    Title = "Pharmacology Basics",
                    Description = "Essential pharmacology concepts for healthcare professionals.",
                    PublisherName = "Alaa Ahmed",
                    PublisherRole = "User",
                    PublishDate = new DateTime(2022, 3, 5),
                    ThumbnailURL = "https://example.com/thumbnails/book4.jpg",
                    Url = "https://example.com/books/pharmacology-basics",
                    SubCategoryId = 11,
                    CategoryId = 6,
                    UserId = "3c333c33-3333-3333-3333-333333333333"

                },
                new Book
                {
                    Id = 5,
                    Title = "Pathology Essentials",
                    Description = "Key topics in pathology explained in a clear and concise manner.",
                    PublisherName = "Alaa Ahmed",
                    PublisherRole = "User",
                    PublishDate = new DateTime(2021, 1, 18),
                    ThumbnailURL = "https://example.com/thumbnails/book5.jpg",
                    Url = "https://example.com/books/pathology-essentials",
                    SubCategoryId = 12,
                    CategoryId = 6,
                    UserId = "3c333c33-3333-3333-3333-333333333333"

                },
                new Book
                {
                    Id = 6,
                    Title = "Microbiology Fundamentals",
                    Description = "Basic microbiology concepts for beginners.",
                    PublisherName = "Ehab Naser",
                    PublisherRole = "Admin",
                    PublishDate = new DateTime(2020, 6, 22),
                    ThumbnailURL = "https://example.com/thumbnails/book6.jpg",
                    Url = "https://example.com/books/microbiology-fundamentals",
                    SubCategoryId = 13,
                    CategoryId = 7,
                    UserId = "1a111a11-1111-1111-1111-111111111111"
                },
                new Book
                {
                    Id = 7,
                    Title = "Surgical Procedures Handbook",
                    Description = "A handbook on modern surgical techniques.",
                    PublisherName = "Ehab Naser",
                    PublisherRole = "Admin",
                    PublishDate = new DateTime(2023, 8, 13),
                    ThumbnailURL = "https://example.com/thumbnails/book7.jpg",
                    Url = "https://example.com/books/surgical-procedures",
                    SubCategoryId = 13,
                    CategoryId = 7,
                    UserId = "1a111a11-1111-1111-1111-111111111111"
                }
                );
        }
    }
}