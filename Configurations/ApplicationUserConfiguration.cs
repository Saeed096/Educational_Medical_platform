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
                         FirstName = "Ehab",
                         LastName = "Naser",
                         NormalizedUserName = "EHAB_NASER",
                         Email = "Ehab_Naser@example.com",
                         NormalizedEmail = "EHAB_NASER@EXAMPLE.COM",
                         EmailConfirmed = true,
                         PasswordHash = hasher.HashPassword(null, "Test@123"),
                         SecurityStamp = "9f9ef764-d632-42d2-99ee-93v2410d8ae0",
                         PhoneNumber = "011548726155",
                     },
                      new ApplicationUser
                      {
                          Id = "2b222b22-2222-2222-2222-222222222222",
                          UserName = "Abdallah_Saudie", 
                          FirstName = "Abdallah",
                          LastName = "Saudie", 
                          NormalizedUserName = "ABDALLAH_SAUDIE", 
                          Email = "Abdallah_Saudie@business.example.com", 
                          NormalizedEmail = "ABDALLAH_SAUDIE@BUSINESS.EXAMPLE.COM", 
                          EmailConfirmed = true,
                          PasswordHash = hasher.HashPassword(null, "Test@123"),
                          SecurityStamp = "9f9ed761-d631-42d2-99ee-93v2420d8ae0",
                          PhoneNumber = "01054871566",
                      },
                    new ApplicationUser
                    {
                        Id = "3c333c33-3333-3333-3333-333333333333",
                        UserName = "Alaa_Ahmed",
                        FirstName = "Alaa",
                        LastName = "Ahmed",
                        NormalizedUserName = "ALAA_AHMED",
                        Email = "Alaa_Test@example.com",
                        NormalizedEmail = "ALAA_AHMED@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Test@123"),
                        SecurityStamp = "9f1ed761-a631-42dq-99ee-93z2420d8aeq",
                        PhoneNumber = "01225193482",
                    }
                );
        }
    }
}