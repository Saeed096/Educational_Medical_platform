using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class Student_CoursesConfiguration : IEntityTypeConfiguration<Student_Courses>
    {
        public void Configure(EntityTypeBuilder<Student_Courses> modelBuilder)
        {
            modelBuilder.HasKey(s => new { s.StudentId, s.CourseId });
        }
    }
}