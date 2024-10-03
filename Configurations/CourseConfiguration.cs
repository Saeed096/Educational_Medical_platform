using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Educational_Medical_platform.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "physiology",
                    DurationInhours = 10,
                    SubCategoryId = 1,
                    Price = 1500,
                    InstructorId = "2b222b22-2222-2222-2222-222222222222",
                    Type = CourseType.Free,
                },
                new Course
                {
                    Id = 2,
                    Title = "anatomy",
                    DurationInhours = 20,
                    SubCategoryId = 3,
                    Price = 1000,
                    InstructorId = "2b222b22-2222-2222-2222-222222222222",
                    Type = CourseType.Paid,
                },
                new Course
                {
                    Id = 3,
                    Title = "histology",
                    DurationInhours = 30,
                    SubCategoryId = 5,
                    Price = 2500,
                    InstructorId = "3c333c33-3333-3333-3333-333333333333",
                    Type = CourseType.Paid,
                }
                );

            // Instructor-Course one-to-many relationship
            builder
                .HasOne(c => c.Instructor)
                .WithMany(u => u.CoursesCreated)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
