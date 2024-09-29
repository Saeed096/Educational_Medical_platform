using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Shoghlana.EF.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.UserName)
                        .HasColumnType("nvarchar(50)");

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                     new ApplicationUser
                     {
                         Id = "1a111a11-1111-1111-1111-111111111111", 
                         UserName = "Ehab_Naser",
                         FirstName ="Ehab",
                         LastName = "Naser",
                         NormalizedUserName = "EHAB_NASER",
                         Email = "Ehab_Naser@example.com",
                         NormalizedEmail = "EHAB_NASER@EXAMPLE.COM",
                         EmailConfirmed = true,
                         PasswordHash = hasher.HashPassword(null, "Test@123"),
                         SecurityStamp = Guid.NewGuid().ToString("D")
                     },
                    new ApplicationUser
                    {
                        Id = "2b222b22-2222-2222-2222-222222222222",
                        UserName = "Mohamed_Galal",
                        FirstName = "Mohamed",
                        LastName = "Galal",
                        NormalizedUserName = "MOHAMED_GALAL",
                        Email = "Mohamed_Galal@example.com",
                        NormalizedEmail = "MOHAMED_GALAL@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Test@123"),
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    },
                    new ApplicationUser
                    {
                        Id = "3c333c33-3333-3333-3333-333333333333",
                        UserName = "Alaa_Test",
                        FirstName = "Alaa",
                        LastName = "Test",
                        NormalizedUserName = "ALAA_TEST",
                        Email = "Alaa_Test@example.com",
                        NormalizedEmail = "ALAA_TEST@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Test@123"),
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    }
                );
        }
    }
}