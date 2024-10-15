using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;
using System.Security.Claims;

namespace Educational_Medical_platform.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUserEnrolledCoursesRepository _userEnrolledCoursesRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IStandardTestRepository _standardTestRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(
            IUserEnrolledCoursesRepository userEnrolledCoursesRepository,
            ICourseRepository courseRepository,
            IBookRepository bookRepository,
            IBlogRepository blogRepository,
            IStandardTestRepository standardTestRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _userEnrolledCoursesRepository = userEnrolledCoursesRepository;
            _courseRepository = courseRepository;
            _bookRepository = bookRepository;
            _blogRepository = blogRepository;
            _standardTestRepository = standardTestRepository;
            _userManager = userManager;
        }

        //**************************************************************************

        [HttpGet("GetCourseEnrollersCount/{courseId:int}")]
        public ActionResult<GeneralResponse> GetCourseEnrollersCount(int courseId)
        {
            if (!_courseRepository.Exists(courseId))
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"No Course Found with this ID : {courseId}"
                };
            }

            int EnrollersCount = _userEnrolledCoursesRepository.FindAll(criteria: uc => uc.CourseId == courseId).ToList().Count();

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = EnrollersCount,
            };
        }

        [HttpGet("GetAllstatistics")]
        public ActionResult<GeneralResponse> GetAllstatistics()
        {
            int totalCoursesCount = _courseRepository.GetCount();

            int totalBooksCount = _bookRepository.GetCount();

            int totalBlogsCount = _blogRepository.GetCount();

            int totalExamsCount = _standardTestRepository.GetCount();

            int totalUsersCount = _userManager.Users.Count();

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = new
                {
                    totalCoursesCount,
                    totalBooksCount,
                    totalBlogsCount,
                    totalExamsCount,
                    totalUsersCount,
                }
            };
        }

        [HttpGet("GetAlUsersInfo")]
        public ActionResult<GeneralResponse> GetAlUsersInfo()
        {
            var users = _userManager.Users.Select(
                u =>
                new
                {
                    u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    u.Email,
                    u.PhoneNumber,
                    u.ImageUrl
                }
                ).ToList();

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = users
            };
        }

        [HttpGet("GetUserDetails/{userId}")]
        public async Task<ActionResult<GeneralResponse>> GetUserDetails(string userId)
        {
            ApplicationUser? user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"No User Found with this ID : {userId}"
                };
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);

            var userDTO = new
            {
                ID = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = roles,
                IsSubscribedToPlatform = user.IsSubscribedToPlatform,
                ImageUrl = user.ImageUrl,
            };

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = userDTO
            };
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<ActionResult<GeneralResponse>> DeleteUser(string userId)
        {
            ApplicationUser? user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"No User Found with this ID : {userId}"
                };
            }

            // Check if the user is enrolled in any courses
            bool isEnrolledInCourses = _userEnrolledCoursesRepository.IsUserHasEnrolledInAnyCourse(userId);

            if (isEnrolledInCourses)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Cannot delete user. The user is already enrolled in courses.You Have To Remove the Enrollment First"
                };
            }

            int numOfOwnedCourses = _courseRepository.GetCount(c => c.InstructorId == user.Id);
            if (numOfOwnedCourses > 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Cannot delete user. The user is the owner of courses, and students may be enrolled in these courses. You need to delete the courses before deleting the user."
                };
            }

            int numOfPublishedBooks = _bookRepository.GetCount(c => c.UserId == user.Id);
            if (numOfPublishedBooks > 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Cannot delete user. The user is the publisher of Existed Books, You have to delete those Books First ."
                };
            }

            int numOfPublishedBlogs = _blogRepository.GetCount(c => c.AuthorId == user.Id);
            if (numOfPublishedBlogs > 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Cannot delete user. The user is the Author of Existed Blogs, You have to delete those Blogs First ."
                };
            }

            // If no related entities, proceed to delete the user

            try
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Any())
                {
                    var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!result.Succeeded)
                    {
                        return new GeneralResponse
                        {
                            IsSuccess = false,
                            Message = "Error happened while removing user roles. Please try again."
                        };
                    }
                }

                var deleteResult = await _userManager.DeleteAsync(user);
                if (!deleteResult.Succeeded)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Error happened while deleting the user. Make sure this user has no relations with existing entities and try again."
                    };
                }

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "User deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An unexpected error occurred while deleting the user: {ex.Message}"
                };
            }
        }

    }
}
