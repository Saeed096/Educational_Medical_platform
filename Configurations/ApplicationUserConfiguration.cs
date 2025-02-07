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
                           Id = "2b22343b22-2222h-2222-2222-222435342222",
                           UserName = "Saeed_Saudie",
                           FirstName = "Saeed",
                           LastName = "Saudie",
                           NormalizedUserName = "SAEED_SAUDIE",
                           Email = "Saeed_Saudie@personal.example.com",
                           NormalizedEmail = "SAEED_SAUDIE@PERSONAL.EXAMPLE.COM",
                           EmailConfirmed = true,
                           PasswordHash = hasher.HashPassword(null, "Test@123"),
                           SecurityStamp = "9f9eD741-d631-42d2-99ee-93v2420d8a23432",
                           PhoneNumber = "01054871577",
                       },
                          new ApplicationUser
                          {
                              Id = "2b223432b22-2222h-2222-2222-2224353421234123",
                              UserName = "Omar_Saudie",
                              FirstName = "Omar",
                              LastName = "Saudie",
                              NormalizedUserName = "OMAR_SAUDIE",
                              Email = "Omar_Saudie@personal.example.com",
                              NormalizedEmail = "OMAR_SAUDIE@PERSONAL.EXAMPLE.COM",
                              EmailConfirmed = true,
                              PasswordHash = hasher.HashPassword(null, "Test@123"),
                              SecurityStamp = "9f9eD741-d631-42d2-995e-93v2420d8a2335",
                              PhoneNumber = "01054844512",
                          },

                             //------------------------

                             new ApplicationUser
                             {
                                 Id = "2b22343b22-2222h-2222-2222-2225425235",
                                 UserName = "Yasser_Saudie",
                                 FirstName = "Yassser",
                                 LastName = "Saudie",
                                 NormalizedUserName = "YASSER_SAUDIE",
                                 Email = "Yasser_Saudie@business.example.com",
                                 NormalizedEmail = "YASSER_SAUDIE@BUSINESS.EXAMPLE.COM",
                                 EmailConfirmed = true,
                                 PasswordHash = hasher.HashPassword(null, "Test@123"),
                                 SecurityStamp = "9f9eD741-d631-42d2-99ee-93v2420d8a20000",
                                 PhoneNumber = "010548715000",
                             },
                          new ApplicationUser
                          {
                              Id = "2b223432b22-2222h-2222-2222-2224353125214532",
                              UserName = "Raghad_Saudie",
                              FirstName = "Raghad",
                              LastName = "Saudie",
                              NormalizedUserName = "RAGHAD_SAUDIE",
                              Email = "Raghad_Saudie@business.example.com",
                              NormalizedEmail = "RAGHAD_SAUDIE@BUSINESS.EXAMPLE.COM",
                              EmailConfirmed = true,
                              PasswordHash = hasher.HashPassword(null, "Test@123"),
                              SecurityStamp = "9f9eD741-d631-42d2-995e-93v2420d8a5555",
                              PhoneNumber = "010548443455435",
                          },

                    //------------------------
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