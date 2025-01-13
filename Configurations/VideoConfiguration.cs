using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            //builder.HasData(
            //    new Video
            //    {
            //        Id = 1,
            //        Number = 1,
            //        Title = "new video",
            //        videoURL = "https://www.youtube.com/watch?v=4oThHBo2-Gs",
            //        CourseId = 1
            //    },
            //      new Video
            //      {
            //          Id = 2,
            //          Number = 1,
            //          Title = "old video",
            //          videoURL = "https://www.youtube.com/watch?v=mgEAimOoyHk",
            //          CourseId = 2
            //      },
            //        new Video
            //        {
            //            Id = 3,
            //            Number = 1,
            //            Title = "funny video",
            //            videoURL = "https://www.youtube.com/watch?v=zhCKr62s12w",
            //            CourseId = 3
            //        }
            //    );
        }

    }
}
