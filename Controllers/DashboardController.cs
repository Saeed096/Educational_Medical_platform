using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.DTO.User;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUserEnrolledCoursesRepository _userEnrolledCoursesRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IStandardTestRepository _standardTestRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICourseObjectiveRepository _courseObjectiveRepository;
        private readonly ICourseRequirementsRepository _courseRequirementsRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IUserLocalSubscribtionRepository _userLocalSubscribtionRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly string _imagesPath;
        private readonly string _videosPath;

        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(
            IUserEnrolledCoursesRepository userEnrolledCoursesRepository,
            ICourseRepository courseRepository,
            IBookRepository bookRepository,
            IBlogRepository blogRepository,
            IStandardTestRepository standardTestRepository,
            IAnswerRepository answerRepository,
            ICategoryRepository categoryRepository,
            ICourseObjectiveRepository courseObjectiveRepository,
            ICourseRequirementsRepository courseRequirementsRepository,
            IQuestionRepository questionRepository,
            IVideoRepository videoRepository,
            IUserLocalSubscribtionRepository userLocalSubscribtionRepository,
            IApplicationUserRepository applicationUserRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _userEnrolledCoursesRepository = userEnrolledCoursesRepository;
            _courseRepository = courseRepository;
            _bookRepository = bookRepository;
            _blogRepository = blogRepository;
            _standardTestRepository = standardTestRepository;
            _answerRepository = answerRepository;
            _categoryRepository = categoryRepository;
            _courseObjectiveRepository = courseObjectiveRepository;
            _courseRequirementsRepository = courseRequirementsRepository;
            _questionRepository = questionRepository;
            _videoRepository = videoRepository;
            _userLocalSubscribtionRepository = userLocalSubscribtionRepository;
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;

            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Courses");
            _videosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Videos", "Courses");
        }

        //******************************************  General Statistics  *****************************************************

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

        //********************************************  Users Actions *********************************************************

        [HttpGet("GetApprovedCourseEnrollersCount/{courseId:int}")]
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

            int EnrollersCount = _userEnrolledCoursesRepository
                .FindAll(criteria: uc => uc.CourseId == courseId && uc.Status == EnrollRequestStatus.Approved)
                .ToList().Count();

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = EnrollersCount,
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

        [HttpGet("GetAllUsersPaginated")]
        public ActionResult<GeneralResponse> GetAllUsersPaginated(int page = 1, int pageSize = 10)
        {
            var usersPaginationList = _applicationUserRepository.FindPaginatedUsers(page: page, pageSize: pageSize);

            if (usersPaginationList == null || !usersPaginationList.Items.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "No users available."
                };
            }

            var userDTOs = usersPaginationList.Items.Select(user => new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsSubscribedToPlatform = user.IsSubscribedToPlatform,
                ImageUrl = user.ImageUrl
            }).ToList();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Users retrieved successfully.",
                Data = new
                {
                    CurrentPage = usersPaginationList.CurrentPage,
                    TotalPages = usersPaginationList.TotalPages,
                    TotalItems = usersPaginationList.TotalItems,
                    Users = userDTOs
                }
            };
        }


        //********************************************  Course Actions *********************************************************

        [HttpGet("PendingApproval")]
        public ActionResult<GeneralResponse> GetPendingApprovalCourses()
        {
            List<Course> courses = _courseRepository.FindAll(criteria: c => c.Status == CourseStatus.PendingApproval, includes: new[] { "Requirements", "Objectives", "Videos", "SubCategory", "Instructor" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "There are no courses available"
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Preview = course.Preview,
                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Price = course.Price,

                    Type = course.Type,
                    TypeName = course.Type.GetDisplayName(),

                    Status = course.Status,
                    StatusName = course.Status.GetDisplayName(),

                    InstructorId = course.InstructorId,
                    InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                    SubCategoryId = course.SubCategoryId,
                    SubCategoryName = course.SubCategory.Name,

                    CategoryId = course.SubCategory.CategoryId,
                    CategoryName = _categoryRepository.GetById(course.SubCategory.CategoryId).Name ?? "NA",

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(),

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(),

                    Videos = course.Videos != null && course.Videos.Any()
                    ? course.Videos.Select(video => new GetVideoDTO()
                    {
                        Id = video.Id,
                        CourseId = video.CourseId,
                        Description = video.Description,
                        Number = video.Number,
                        Title = video.Title,
                        videoURL = video.videoURL
                    }).ToList()
                    : new List<GetVideoDTO>(),
                };

                courseDTOs.Add(courseDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Courses retrieved with Requirments and objectives and VideosURLs successfully.",
                Data = courseDTOs
            };
        }

        [HttpGet("PendingDeletion")]
        public ActionResult<GeneralResponse> GetPendingDeletionCourses()
        {
            List<Course> courses = _courseRepository.FindAll(criteria: c => c.Status == CourseStatus.PendingDeletion, includes: new[] { "Requirements", "Objectives", "Videos", "SubCategory", "Instructor" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "There are no courses available"
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Preview = course.Preview,
                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Price = course.Price,
                    Type = course.Type,
                    TypeName = course.Type.GetDisplayName(),

                    Status = course.Status,
                    StatusName = course.Status.GetDisplayName(),


                    InstructorId = course.InstructorId,
                    InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                    SubCategoryId = course.SubCategoryId,
                    SubCategoryName = course.SubCategory.Name,

                    CategoryId = course.SubCategory.CategoryId,
                    CategoryName = _categoryRepository.GetById(course.SubCategory.CategoryId).Name ?? "NA",

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives

                    Videos = course.Videos != null && course.Videos.Any()
                    ? course.Videos.Select(video => new GetVideoDTO()
                    {
                        Id = video.Id,
                        CourseId = video.CourseId,
                        Description = video.Description,
                        Number = video.Number,
                        Title = video.Title,
                        videoURL = video.videoURL
                    }).ToList()
                    : new List<GetVideoDTO>(),
                };

                courseDTOs.Add(courseDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Courses retrieved with Requirments and objectives and VideosURLs successfully.",
                Data = courseDTOs
            };
        }

        [HttpGet("Approved")]
        public ActionResult<GeneralResponse> GetApprovedCourses()
        {
            List<Course> courses = _courseRepository.FindAll(criteria: c => c.Status == CourseStatus.Approved, includes: new[] { "Requirements", "Objectives", "Videos", "SubCategory", "Instructor" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "There are no courses available"
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Preview = course.Preview,
                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Price = course.Price,
                    Type = course.Type,
                    TypeName = course.Type.GetDisplayName(),

                    Status = course.Status,
                    StatusName = course.Status.GetDisplayName(),


                    InstructorId = course.InstructorId,
                    InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                    SubCategoryId = course.SubCategoryId,
                    SubCategoryName = course.SubCategory.Name,

                    CategoryId = course.SubCategory.CategoryId,
                    CategoryName = _categoryRepository.GetById(course.SubCategory.CategoryId).Name ?? "NA",

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives

                    Videos = course.Videos != null && course.Videos.Any()
                    ? course.Videos.Select(video => new GetVideoDTO()
                    {
                        Id = video.Id,
                        CourseId = video.CourseId,
                        Description = video.Description,
                        Number = video.Number,
                        Title = video.Title,
                        videoURL = video.videoURL
                    }).ToList()
                    : new List<GetVideoDTO>(),
                };

                courseDTOs.Add(courseDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Courses retrieved with Requirments and objectives and VideosURLs successfully.",
                Data = courseDTOs
            };
        }

        [HttpGet("Rejected")]
        public ActionResult<GeneralResponse> GetRejectedCourses()
        {
            List<Course> courses = _courseRepository.FindAll(criteria: c => c.Status == CourseStatus.Rejected, includes: new[] { "Requirements", "Objectives", "Videos", "SubCategory", "Instructor" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "There are no courses available"
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Preview = course.Preview,
                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Price = course.Price,
                    Type = course.Type,
                    TypeName = course.Type.GetDisplayName(),

                    Status = course.Status,
                    StatusName = course.Status.GetDisplayName(),
                    RejectionReason = course.RejectedReason,

                    InstructorId = course.InstructorId,
                    InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                    SubCategoryId = course.SubCategoryId,
                    SubCategoryName = course.SubCategory.Name,

                    CategoryId = course.SubCategory.CategoryId,
                    CategoryName = _categoryRepository.GetById(course.SubCategory.CategoryId).Name ?? "NA",

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives

                    Videos = course.Videos != null && course.Videos.Any()
                    ? course.Videos.Select(video => new GetVideoDTO()
                    {
                        Id = video.Id,
                        CourseId = video.CourseId,
                        Description = video.Description,
                        Number = video.Number,
                        Title = video.Title,
                        videoURL = video.videoURL
                    }).ToList()
                    : new List<GetVideoDTO>(),
                };

                courseDTOs.Add(courseDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Courses retrieved with Requirments and objectives and VideosURLs successfully.",
                Data = courseDTOs
            };
        }

        [HttpPost("ApproveAddingCourse/{courseId:int}")]
        public ActionResult<GeneralResponse> ApproveAddingCourse(int courseId)
        {
            var course = _courseRepository.Find(c => c.Id == courseId);

            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Course found with this ID {courseId}"
                };
            }

            course.Status = CourseStatus.Approved;

            _courseRepository.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = $"Course With ID {courseId} approved Successfully"
            };
        }

        [HttpPost("RejectAddingCourse/{courseId:int}")]
        public ActionResult<GeneralResponse> RejectAddingCourse(int courseId, string? rejectionReason)
        {
            var course = _courseRepository.Find(c => c.Id == courseId);

            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Course found with this ID {courseId}"
                };
            }

            course.Status = CourseStatus.Rejected;
            course.RejectedReason = rejectionReason;

            _courseRepository.Save();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = $"Course With ID {courseId} Rejected Successfully"
            };
        }

        [HttpDelete("{courseId:int}")]
        public async Task<ActionResult<GeneralResponse>> DeleteCourse(int courseId)
        {
            var course = _courseRepository.Find(criteria: c => c.Id == courseId, includes: ["Objectives", "Requirements", "Videos"]);
            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No course found with ID: {courseId}",
                    Status = 404,
                };
            }

            // Delete related records in the join table (User_Enrolled_Courses)
            var enrollments = _userEnrolledCoursesRepository.FindAll(criteria: c => c.CourseId == courseId).ToList();
            if (enrollments.Any())
            {
                _userEnrolledCoursesRepository.DeleteRange(enrollments);
                await _userEnrolledCoursesRepository.SaveAsync();
            }


            if (course?.Requirements != null || course?.Requirements?.Count() == 0)
            {
                _courseRequirementsRepository.DeleteRange(course.Requirements);
                _courseRequirementsRepository.Save();
            }

            if (course?.Objectives != null || course?.Objectives?.Count() == 0)
            {
                _courseObjectiveRepository.DeleteRange(course.Objectives);
                _courseObjectiveRepository.Save();
            }


            //  delete the associated image file
            if (!string.IsNullOrEmpty(course.ThumbnailURL))
            {
                var filePath = Path.Combine(_imagesPath, Path.GetFileName(course.ThumbnailURL));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            foreach (Video video in course.Videos)
            {
                // delete the old video file from the server
                var oldFileName = Path.GetFileName(video.videoURL);

                // Construct the full file system path using the _videosPath and the extracted file name
                var oldFilePath = Path.Combine(_videosPath, oldFileName);

                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            _videoRepository.DeleteRange(course.Videos);
            _videoRepository.Save();

            var questions = _questionRepository.FindAll(criteria: q => q.CourseId == course.Id, includes: ["Answers"]);

            foreach (var question in questions)
            {
                _answerRepository.DeleteRange(question.Answers);
            }
            _questionRepository.DeleteRange(questions);

            _courseRepository.Delete(course);

            await _courseRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = $"Course with ID ({courseId}) deleted with it's requirments , objectives and videos successfully."
            };
        }

        [HttpGet("GetPendingApprovalEnrollRequests")]
        public async Task<ActionResult<GeneralResponse>> GetPendingApprovalEnrollRequests()
        {
            List<User_Enrolled_Courses> enrollRequests = _userEnrolledCoursesRepository
                                   .FindAll(criteria: uc => uc.Status == EnrollRequestStatus.PendingApproval,
                                            includes: ["Course", "Student"])
                                   .ToList();

            List<GetRequestUserEnrollDTO> enrollRequestsDTO = new List<GetRequestUserEnrollDTO>();

            foreach (var enrollRequest in enrollRequests)
            {
                var instructor = await _userManager.FindByIdAsync(enrollRequest.Course.InstructorId);

                enrollRequestsDTO.Add(new GetRequestUserEnrollDTO
                {
                    CourseId = enrollRequest.CourseId,
                    CourseName = enrollRequest.Course.Title,

                    InstructorId = enrollRequest.Course.InstructorId,
                    InstructorName = $"{instructor?.FirstName ?? "NA"} {instructor?.LastName ?? "NA"}",

                    StudentId = enrollRequest.StudentId,
                    StudentName = $"{enrollRequest?.Student?.FirstName ?? "NA"} {enrollRequest?.Student?.LastName ?? "NA"}",

                    StartDate = enrollRequest.StartDate,

                    Status = enrollRequest.Status,
                    StatusName = enrollRequest.Status.GetDisplayName(),

                    TransactionImageURL = enrollRequest.TransactionImageURL,
                });
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = enrollRequestsDTO.OrderByDescending(r => r.StartDate).ToList(),
            };
        }

        [HttpGet("GetAllEnrollRequests")]
        public  async Task<ActionResult<GeneralResponse>> GetAllEnrollRequests()
        {
            List<User_Enrolled_Courses> enrollRequests = _userEnrolledCoursesRepository
                               .FindAll(includes: ["Course" , "Student"]).ToList();

            List<GetRequestUserEnrollDTO> enrollRequestsDTO = new List<GetRequestUserEnrollDTO>();

            foreach (var enrollRequest in enrollRequests)
            {
                var instructor = await _userManager.FindByIdAsync(enrollRequest.Course.InstructorId);

                enrollRequestsDTO.Add(new GetRequestUserEnrollDTO
                {
                    CourseId = enrollRequest.CourseId,
                    CourseName = enrollRequest.Course.Title,

                    InstructorId = enrollRequest.Course.InstructorId,
                    InstructorName = $"{instructor?.FirstName ?? "NA"} {instructor?.LastName ?? "NA"}",

                    StudentId = enrollRequest.StudentId,
                    StudentName = $"{enrollRequest?.Student?.FirstName ?? "NA"} {enrollRequest?.Student?.LastName ?? "NA"}",

                    StartDate = enrollRequest.StartDate,

                    Status = enrollRequest.Status,
                    StatusName = enrollRequest.Status.GetDisplayName(),

                    TransactionImageURL = enrollRequest.TransactionImageURL,
                });
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = enrollRequestsDTO.OrderByDescending(r => r.StartDate).ToList(),
            };
        }

        [HttpPost("ApprovePendingApprovalEnrollRequests")]
        public async Task<ActionResult<GeneralResponse>> ApprovePendingApprovalEnrollRequests(ApproveEnrollCourseRequest approveEnrollRequest)
        {
            var instructor = await _userManager.FindByIdAsync(approveEnrollRequest.InstructorId);
            if (instructor == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no User found with this ID: {approveEnrollRequest.InstructorId}",
                    Status = 406,
                };
            }

            var student = await _userManager.FindByIdAsync(approveEnrollRequest.StudentId);
            if (student == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no User found with this ID: {approveEnrollRequest.StudentId}",
                    Status = 406,
                };
            }

            var course = _courseRepository.Find(c => c.Id == approveEnrollRequest.CourseId);
            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no course found with this ID: {approveEnrollRequest.CourseId}",
                    Status = 407,
                };
            }

            if (course.InstructorId != approveEnrollRequest.InstructorId)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "The Given Instructor ID is not the instructor who owns this course",
                    Status = 406
                };
            }

            if (course.InstructorId == approveEnrollRequest.StudentId)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "The Instructor Can't Enroll in his Course !",
                    Status = 406
                };
            }

            User_Enrolled_Courses? enrollRequest = _userEnrolledCoursesRepository
                               .Find(criteria:
                               uc => uc.CourseId == approveEnrollRequest.CourseId &&
                               uc.StudentId == approveEnrollRequest.StudentId);

            if (enrollRequest == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"This request is not found"
                };
            }

            if (enrollRequest.Status != EnrollRequestStatus.PendingApproval)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"This request status is not pending Approval ," +
                    $" current status is : {enrollRequest.Status.GetDisplayName()}"
                };
            }

            enrollRequest.Status = EnrollRequestStatus.Approved;
            await _userEnrolledCoursesRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Request Approved Successfully"
            };
        }

        [HttpPost("RejectPendingApprovalEnrollRequests")]
        public async Task<ActionResult<GeneralResponse>> RejectPendingApprovalEnrollRequests(ApproveEnrollCourseRequest approveEnrollRequest)
        {
            var instructor = await _userManager.FindByIdAsync(approveEnrollRequest.InstructorId);
            if (instructor == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no User found with this ID: {approveEnrollRequest.InstructorId}",
                    Status = 406,
                };
            }

            var student = await _userManager.FindByIdAsync(approveEnrollRequest.StudentId);
            if (student == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no User found with this ID: {approveEnrollRequest.StudentId}",
                    Status = 406,
                };
            }

            var course = _courseRepository.Find(c => c.Id == approveEnrollRequest.CourseId);
            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no course found with this ID: {approveEnrollRequest.CourseId}",
                    Status = 407,
                };
            }

            if (course.InstructorId != approveEnrollRequest.InstructorId)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "The Given Instructor ID is not the instructor who owns this course",
                    Status = 406
                };
            }

            if (course.InstructorId == approveEnrollRequest.StudentId)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "The Instructor Can't Enroll in his Course !",
                    Status = 406
                };
            }

            User_Enrolled_Courses? enrollRequest = _userEnrolledCoursesRepository
                               .Find(criteria:
                               uc => uc.CourseId == approveEnrollRequest.CourseId &&
                               uc.StudentId == approveEnrollRequest.StudentId);

            if (enrollRequest == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"This request is not found"
                };
            }

            if (enrollRequest.Status != EnrollRequestStatus.PendingApproval)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"This request status is not pending Approval ," +
                    $" current status is : {enrollRequest.Status.GetDisplayName()}"
                };
            }

            enrollRequest.Status = EnrollRequestStatus.Rejected;
            await _userEnrolledCoursesRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Request Rejected Successfully"
            };
        }

        //******************************************** Local Subscribtions Actions *********************************************************

        [HttpGet("GetPendingApprovalLocalSubscriptions")]
        public ActionResult<GeneralResponse> GetPendingApprovalLocalSubscriptions()
        {
            List<UserLocalSubscribtion> UserLocalSubscribtions = _userLocalSubscribtionRepository
                               .FindAll(criteria: us => us.Status == LocalSubscribtionStatus.PendingApproval,
                                         includes: ["User"])
                               .ToList();

            List<GetUserLocalSubscribtionDTO> subscriptionsRequestsDTO = UserLocalSubscribtions.Select(
                subscribtionRequest => new GetUserLocalSubscribtionDTO
                {
                    Id = subscribtionRequest.Id,
                    UserId = subscribtionRequest.UserId,
                    UserFullName = $"{subscribtionRequest.User.FirstName} {subscribtionRequest.User.LastName}",

                    Status = subscribtionRequest.Status,
                    StatusName = subscribtionRequest.Status.GetDisplayName(),

                    TransactionImageURL = subscribtionRequest.TransactionImageURL,
                })
            .OrderByDescending(req => req.Id)
            .ToList();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = subscriptionsRequestsDTO
            };
        }

        [HttpGet("GetAllLocalSubscriptionsRequests")]
        public ActionResult<GeneralResponse> GetAllLocalSubscriptionsRequests()
        {
            List<UserLocalSubscribtion> UserLocalSubscribtions = _userLocalSubscribtionRepository
                                                                  .FindAll(includes: ["User"])
                                                                  .ToList();

            List<GetUserLocalSubscribtionDTO> subscriptionsRequestsDTO = UserLocalSubscribtions.Select(
                subscribtionRequest => new GetUserLocalSubscribtionDTO
                {
                    Id = subscribtionRequest.Id,
                    UserId = subscribtionRequest.UserId,
                    UserFullName = $"{subscribtionRequest.User.FirstName} {subscribtionRequest.User.LastName}",

                    Status = subscribtionRequest.Status,
                    StatusName = subscribtionRequest.Status.GetDisplayName(),

                    TransactionImageURL = subscribtionRequest.TransactionImageURL,
                })
            .OrderByDescending(req => req.Id)
            .ToList();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = subscriptionsRequestsDTO
            };
        }

        [HttpPost("ApproveLocalSubscriptionRequest")]
        public async Task<ActionResult<GeneralResponse>> ApproveLocalSubscriptionRequest(int localSubscriptionId)
        {
            UserLocalSubscribtion? UserLocalSubscribtion = _userLocalSubscribtionRepository
                                .Find(criteria: us => us.Id == localSubscriptionId,
                                includes: ["User"]);

            if (UserLocalSubscribtion == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"There is no Subscription Request found with this Id : {localSubscriptionId}"
                };
            }

            if (UserLocalSubscribtion.Status != LocalSubscribtionStatus.PendingApproval)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"This request status is not pending Approval , his current status is : {UserLocalSubscribtion.Status.GetDisplayName()}"
                };
            }

            UserLocalSubscribtion.Status = LocalSubscribtionStatus.Approved;
            UserLocalSubscribtion.User.IsSubscribedToPlatform = true;
            UserLocalSubscribtion.User.SubscriptionMethod = SubscriptionMethod.Local;

            await _userEnrolledCoursesRepository.SaveAsync(); // will also save the user data because it has nav prop to him :D

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Subscription Request Approved Succssfully"
            };
        }

        [HttpPost("RejectLocalSubscriptionRequest")]
        public async Task<ActionResult<GeneralResponse>> RejectLocalSubscriptionRequest(int localSubscriptionId)
        {
            UserLocalSubscribtion? UserLocalSubscribtion = _userLocalSubscribtionRepository
                                .Find(criteria: us => us.Id == localSubscriptionId,
                                includes: ["User"]);

            if (UserLocalSubscribtion == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"There is no Subscription Request found with this Id : {localSubscriptionId}"
                };
            }

            if (UserLocalSubscribtion.Status != LocalSubscribtionStatus.PendingApproval)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"This request status is not pending Approval , his current status is : {UserLocalSubscribtion.Status.GetDisplayName()}"
                };
            }

            UserLocalSubscribtion.Status = LocalSubscribtionStatus.Rejected;
            UserLocalSubscribtion.User.IsSubscribedToPlatform = true;
            UserLocalSubscribtion.User.SubscriptionMethod = SubscriptionMethod.Local;

            await _userEnrolledCoursesRepository.SaveAsync(); // will also save the user data because it has nav prop to him :D

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Subscription Request Rejected Succssfully"
            };
        }
    }
}