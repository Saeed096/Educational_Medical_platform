using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Org.BouncyCastle.Utilities.Bzip2;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        public CourseRepository(ApplicationDBContext Context) : base(Context)
        {
            
        }
    }
}
