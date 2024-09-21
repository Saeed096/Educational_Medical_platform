using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    SubCategoryId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "anatomy",
                    DurationInhours = 20,
                    SubCategoryId = 1
                },
                new Course
                {
                    Id = 3,
                    Title = "histology",
                    DurationInhours = 30,
                    SubCategoryId = 1
                }
                );
        }
    }
}
