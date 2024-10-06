using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "952625cb-623b-4f8e-a426-c9e14ffe41bc", 
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9e9ef764-d672-42d8-99ee-93c2410d8ae0"
            },
            new IdentityRole
            {
                Id = "ea3206f7-8571-4e45-b209-e593236f3420",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "df2d8409-cg61-4aac-ae65-b26fbbab77f2"
            }
        );
    }
}
