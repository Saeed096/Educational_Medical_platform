using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // Seed user-role relationships
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1a111a11-1111-1111-1111-111111111111", // Ehab
                    RoleId = "952625cb-623b-4f8e-a426-c9e14ffe41bc" // Admin Role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "2b222b22-2222-2222-2222-222222222222", // Mohamed Galal
                    RoleId = "ea3206f7-8571-4e45-b209-e593236f3420" // User Role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "3c333c33-3333-3333-3333-333333333333", // Alaa
                    RoleId = "ea3206f7-8571-4e45-b209-e593236f3420" // User Role ID
                }
            );
        }
    }
}