using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class User_Enrolled_CoursesConfiguration : IEntityTypeConfiguration<User_Enrolled_Courses>
    {
        public void Configure(EntityTypeBuilder<User_Enrolled_Courses> builder)
        {
            // Configure the composite primary key
            builder.HasKey(uec => new { uec.StudentId, uec.CourseId });

            // Configure relationships
            builder
                .HasOne(uec => uec.Student)
                .WithMany(u => u.EnrolledCourses) // Navigation property in ApplicationUser
                .HasForeignKey(uec => uec.StudentId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder
                .HasOne(uec => uec.Course)
                .WithMany(c => c.EnrolledUsers) // Navigation property in Course
                .HasForeignKey(uec => uec.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}