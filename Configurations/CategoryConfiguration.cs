using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Seed Initial data for Category
            builder.HasData(
                new Category { Id = 1, Name = "Anatomy" },
                new Category { Id = 2, Name = "Physiology" },
                new Category { Id = 3, Name = "Pharmacology" },
                new Category { Id = 4, Name = "Pathology" }
            );
        }
    }
}