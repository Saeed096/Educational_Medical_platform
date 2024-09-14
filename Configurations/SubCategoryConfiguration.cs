using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            // Seed Initial data for SubCategory
            builder.HasData(
                new SubCategory { Id = 1, Name = "Human Anatomy", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Comparative Anatomy", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "Cell Physiology", CategoryId = 2 },
                new SubCategory { Id = 4, Name = "Systemic Physiology", CategoryId = 2 },
                new SubCategory { Id = 5, Name = "Clinical Pharmacology", CategoryId = 3 },
                new SubCategory { Id = 6, Name = "Pharmacokinetics", CategoryId = 3 },
                new SubCategory { Id = 7, Name = "General Pathology", CategoryId = 4 },
                new SubCategory { Id = 8, Name = "Systemic Pathology", CategoryId = 4 }
            );
        }
    }
}