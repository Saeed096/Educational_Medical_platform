using Educational_Medical_platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class ObjectiveConfiguration : IEntityTypeConfiguration<Objective>
    {
        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.HasData(

                new Objective
                {
                    Id = 1,
                   Description = "Enhancing medical skills",
                   CourseId = 1
                },
                new Objective
                {
                    Id = 2,
                    Description = "Enhancing physiology knowledge",
                    CourseId = 1
                },
                new Objective
                {
                    Id = 3,
                    Description = "increasing job opportunities",
                    CourseId = 1
                }
);
        }
    }
    }
