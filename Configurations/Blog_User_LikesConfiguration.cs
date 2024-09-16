using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class Blog_User_LikesConfiguration : IEntityTypeConfiguration<Blog_User_Likes>
    {
        public void Configure(EntityTypeBuilder<Blog_User_Likes> modelBuilder)
        {
            modelBuilder.HasKey(b => new { b.UserId, b.BlogId });
        }
    }
}