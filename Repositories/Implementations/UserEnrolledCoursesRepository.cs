using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class UserEnrolledCoursesRepository : GenericRepository<User_Enrolled_Courses>, IUserEnrolledCoursesRepository
    {
        public UserEnrolledCoursesRepository(ApplicationDBContext Context) : base(Context)
        {
        }

        public bool IsUserHasEnrolledInAnyCourse(string userID)
        {
            return base.context.UserEnrolledCourses.Any(uc => uc.StudentId == userID);
        }
    }
}
