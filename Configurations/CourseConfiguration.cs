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
            //builder.HasData(
            //    new Course
            //    {
            //        Id = 1,
            //        Title = "physiology",
            //        DurationInhours = 10,
            //        Price = 1500,
            //        InstructorId = "2b222b22-2222-2222-2222-222222222222",
            //        Type = CourseType.Free,
            //        Status = CourseStatus.Approved,
            //        CategoryId = 1,
            //        SubCategoryId = 1,
            //    },
            //    new Course
            //    {
            //        Id = 2,
            //        Title = "anatomy",
            //        DurationInhours = 20,
            //        Price = 1000,
            //        InstructorId = "2b222b22-2222-2222-2222-222222222222",
            //        Type = CourseType.Paid,
            //        Status = CourseStatus.PendingApproval,
            //        CategoryId = 2,
            //        SubCategoryId = 3,
            //    },
            //    new Course
            //    {
            //        Id = 3,
            //        Title = "histology",
            //        DurationInhours = 30,
            //        Price = 2500,
            //        InstructorId = "3c333c33-3333-3333-3333-333333333333",
            //        Type = CourseType.Paid,
            //        Status = CourseStatus.PendingDeletion,
            //        CategoryId = 3,
            //        SubCategoryId = 5,
            //    }
            //    );

            // Instructor-Course one-to-many relationship
            builder
                .HasOne(c => c.Instructor)
                .WithMany(u => u.CoursesCreated)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
