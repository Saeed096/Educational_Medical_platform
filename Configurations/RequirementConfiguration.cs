using Educational_Medical_platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.HasData(

                new Models.Requirement
                {
                    Id = 1,
                    Description = "being medical student",
                    CourseId = 1
                },
                new Models.Requirement
                {
                    Id = 2,
                    Description = "having laptop",
                    CourseId = 1
                },
                new Models.Requirement
                {
                    Id = 3,
                    Description = "buying premium package",
                    CourseId = 2
                }
);
        }
    }
}
