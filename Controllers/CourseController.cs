using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVideoRepository _videoRepository;
        private readonly ICourseRequirementsRepository _courseRequirementsRepository;
        private readonly ICourseObjectiveRepository _courseObjectiveRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserEnrolledCoursesRepository _userEnrolledCoursesRepository;
        private readonly string _imagesPath;
        private readonly string _videosPath;
        private readonly long _maxImageSize;
        private readonly long _maxVideoSize;

        public CourseController(ICourseRepository courseRepository,
            UserManager<ApplicationUser> userManager,
            IVideoRepository videoRepository,
            ICourseRequirementsRepository courseRequirementsRepository,
            ICourseObjectiveRepository courseObjectiveRepository,
            ISubCategoryRepository subCategoryRepository , 
            ICategoryRepository categoryRepository ,
            IUserEnrolledCoursesRepository userEnrolledCoursesRepository)
        {
            _courseRepository = courseRepository;
            _userManager = userManager;
            _videoRepository = videoRepository;
            _courseRequirementsRepository = courseRequirementsRepository;
            _courseObjectiveRepository = courseObjectiveRepository;
            _subCategoryRepository = subCategoryRepository;
            this._categoryRepository = categoryRepository;
            this._userEnrolledCoursesRepository = userEnrolledCoursesRepository;
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Courses");
            _videosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Videos", "Courses");

            _maxImageSize = 2 * 1024 * 1024;  // 2 MB
            _maxVideoSize = 500 * 1024 * 1024; // 500 MB
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Course> courses = _courseRepository.FindAll(includes: new[] { "Requirements", "Objectives", "Videos", "SubCategory" , "Instructor" }).ToList();

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

        [HttpGet("{courseId:int}")]
        public ActionResult<GeneralResponse> GetByCourseId(int courseId)
        {
            Course? course = _courseRepository.Find(criteria: c => c.Id == courseId, includes: new[] { "Requirements", "Objectives", "Videos", "SubCategory" , "Instructor" });

            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no course with this ID : {courseId} ",
                    Status = 404
                };
            }

            GetCourseDTO courseDTO = new GetCourseDTO()
            {
                Id = course.Id,

                Preview = course.Preview,
                Title = course.Title,
                DurationInhours = course.DurationInhours,
                Price = course.Price,
                Type = course.Type,

                InstructorId = course.InstructorId,
                InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                SubCategoryId = course.SubCategoryId,
                SubCategoryName = course.SubCategory.Name,

                CategoryId = course.SubCategory.CategoryId,
                CategoryName = _categoryRepository.GetById(course.SubCategory.CategoryId).Name ?? "NA",

                ThumbnailURL = course.ThumbnailURL ?? "NA",

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

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Course retrieved with it's requirments , Objectives and Videos successfully.",
                Data = courseDTO
            };
        }

        [HttpGet("Instructor/{instructorId}")]
        public async Task<ActionResult<GeneralResponse>> GetByInstructorId(string instructorId)
        {
            var instructor = await _userManager.FindByIdAsync(instructorId);

            if (instructor == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no user Found with this ID : {instructorId}",
                    Status = 406,
                };
            }

            List<Course> courses = _courseRepository.FindAll(criteria: c => c.InstructorId == instructorId, includes: new[] { "Requirements", "Objectives", "SubCategory" , "Instructor" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There are no courses available for this User ID : {instructorId}",
                    Status = 407
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Preview = course.Preview,
                    Price = course.Price,
                    Type = course.Type,

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
                Message = "Courses retrieved with Requirments and objectives and vidoes successfully.",
                Data = courseDTOs
            };
        }

        [HttpGet("Student/{studentId}")]
        public async Task<ActionResult<GeneralResponse>> GetByStudentId(string studentId)
        {
            var student = await _userManager.FindByIdAsync(studentId);

            if (student == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no user Found with this ID : {studentId}",
                    Status = 406,
                };
            }

            List<User_Enrolled_Courses> User_Enrolled_Courses = _userEnrolledCoursesRepository.FindAll(criteria: uc => uc.StudentId == studentId ).ToList();

            if (User_Enrolled_Courses == null || !User_Enrolled_Courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There are no Enrolled courses available for this User ID : {studentId}",
                    Status = 407
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var User_Enrolled_Course in User_Enrolled_Courses)
            {
                var course = _courseRepository.Find(c => c.Id == User_Enrolled_Course.CourseId, ["Instructor"]);


                var subCategory = _subCategoryRepository.Find(s => s.Id == course.SubCategoryId, ["Category"]);

                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = User_Enrolled_Course.Course.Id,

                    Title = User_Enrolled_Course.Course.Title,
                    DurationInhours = User_Enrolled_Course.Course.DurationInhours,
                    Preview = User_Enrolled_Course.Course.Preview,
                    Price = User_Enrolled_Course.Course.Price,
                    Type = User_Enrolled_Course.Course.Type,

                    InstructorId = course.InstructorId,
                    InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                    SubCategoryId = course.SubCategoryId,
                    SubCategoryName = subCategory.Name,

                    CategoryId = subCategory.CategoryId,
                    CategoryName = subCategory.Category.Name,

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
                Message = "Courses retrieved with Requirments and objectives and vidoes successfully.",
                Data = courseDTOs
            };
        }

        [HttpPost("Enroll")]
        public async Task<ActionResult<GeneralResponse>> EnrollStudentInCourse(string studentId, int courseId)
        {
            // Check if student exists
            var student = await _userManager.FindByIdAsync(studentId);
            if (student == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no user found with this ID: {studentId}",
                    Status = 406,
                };
            }

            // Check if course exists
            var course = _courseRepository.Find(c => c.Id == courseId);
            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no course found with this ID: {courseId}",
                    Status = 407,
                };
            }

            // Check if the student is already enrolled in the course
            var enrollmentExists = _userEnrolledCoursesRepository.Find(c => c.StudentId == studentId && c.CourseId == courseId);
            if (enrollmentExists != null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Student is already enrolled in this course.",
                    Status = 409 // Conflict
                };
            }


            if (course.InstructorId == studentId)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "The Instructor Can't Enroll in his Course !",
                    Status = 406
                };
            }

            // Create a new record in the User_Enrolled_Courses table
            var newEnrollment = new User_Enrolled_Courses()
            {
                StudentId = studentId,
                CourseId = courseId,
                Degree = 0, 
                CurrentVideoNumber = 0, 
                StartDate = DateTime.Now
            };

            // Save the new enrollment record
            await _userEnrolledCoursesRepository.AddAsync(newEnrollment);
            await _userEnrolledCoursesRepository.SaveAsync(); // Save changes to the database

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Student enrolled in course successfully.",
                Status = 200
            };
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddCourse([FromForm] AddCourseDTO courseDTO)
        {
            // Check if the instructor exists
            var instructor = await _userManager.FindByIdAsync(courseDTO.InstructorID);
            if (instructor == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no user found with this ID: {courseDTO.InstructorID}",
                    Status = 406,
                };
            }

            bool foundSubCategory = _subCategoryRepository.Exists(courseDTO.SubCategoryId);

            var subCategory = _subCategoryRepository.Find(s => s.Id == courseDTO.SubCategoryId , ["Category"]);

            if (!foundSubCategory)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No SubCategory found with ID: {courseDTO.SubCategoryId}",
                    Status = 407,
                };
            }

            string fileName = "";

            if (courseDTO.Thumbnail != null)
            {
                // Validate that the file is an image by checking the MIME type
                if (!courseDTO.Thumbnail.ContentType.StartsWith("image/"))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "The uploaded file is not a valid image.",
                        Status = 409
                    };
                }

                // Validate image size (e.g., max 2MB)
                if (courseDTO.Thumbnail.Length > _maxImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB.",
                        Status = 410
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(courseDTO.Thumbnail.FileName)}_{Guid.NewGuid()}{Path.GetExtension(courseDTO.Thumbnail.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await courseDTO.Thumbnail.CopyToAsync(stream);
                }

                courseDTO.Thumbnail = null; // Remove the image from DTO after saving
            }


            // Map the DTO to the Course entity
            var newCourse = new Course
            {
                Title = courseDTO.Title,
                DurationInhours = courseDTO.DurationInhours,
                Preview = courseDTO.Preview,
                InstructorId = courseDTO.InstructorID,
                SubCategoryId = courseDTO.SubCategoryId,
                ThumbnailURL = $"/Images/Courses/{fileName}",
                Price = courseDTO.Price,
                Type = courseDTO.Type,

                //ThumbnailURL = courseDTO.ThumbnailURL,
                Requirements = courseDTO.Requirements?.Select(req => new Requirement
                {
                    Description = req.Description
                }).ToList(),
                Objectives = courseDTO.Objectives?.Select(obj => new Objective
                {
                    Description = obj.Description
                }).ToList()
            };

            var categoryId = _subCategoryRepository.Find(criteria: s => s.Id == newCourse.SubCategoryId, includes: ["Category"]).CategoryId;

            // Add the course to the repository
            _courseRepository.Add(newCourse);
            await _courseRepository.SaveAsync();

            GetCourseDTO getCourseDTO = new GetCourseDTO
            {
                Id = newCourse.Id,
                Title = courseDTO.Title,
                DurationInhours = courseDTO.DurationInhours,
                Preview = courseDTO.Preview,

                InstructorId = courseDTO.InstructorID,
                InstructorFullName = $"{instructor.FirstName} {instructor.LastName}",

                SubCategoryId = courseDTO.SubCategoryId,
                SubCategoryName = subCategory.Name,

                CategoryId = categoryId,
                CategoryName = subCategory.Category.Name,

                ThumbnailURL = $"/Images/Courses/{fileName}",
                Price = courseDTO.Price,
                Type = courseDTO.Type,

                Requirements = courseDTO.Requirements?.Select(req => new GetCourseRequirmentsDTO
                {
                    Description = req.Description
                }).ToList(),

                Objectives = courseDTO.Objectives?.Select(obj => new GetCourseObjectiveDTO
                {
                    Description = obj.Description
                }).ToList(),
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Course created successfully.",
                Data = getCourseDTO
            };
        }

        //----------------------------------------------------------------------------------------------------------

        [HttpPost("AddVideo")]
        public async Task<ActionResult<GeneralResponse>> AddCourseVideos([FromForm] AddCourseVideosDTO courseDTO)
        {
            Course? course = _courseRepository.GetById(courseDTO.CourseId);

            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Course Found with this ID : {courseDTO.CourseId}",
                    Status = 404
                };
            }

            string fileName = "";

            if (courseDTO.video != null)
            {
                // Validate that the file is a video by checking the MIME type
                if (!courseDTO.video.ContentType.StartsWith("video/"))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "The uploaded file is not a valid video.",
                        Status = 411
                    };
                }

                if (courseDTO.video.Length > _maxVideoSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Video size exceeds the maximum allowed size of 500MB.",
                        Status = 412
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(courseDTO.video.FileName)}_{Guid.NewGuid()}{Path.GetExtension(courseDTO.video.FileName)}";
                var filePath = Path.Combine(_videosPath, fileName);

                // Save the video
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await courseDTO.video.CopyToAsync(stream);
                }

                courseDTO.video = null; // Clear the video object after saving
            }

            Video video = new Video
            {
                Title = courseDTO.Title,
                Number = courseDTO.Number,
                Description = courseDTO.Description,
                CourseId = courseDTO.CourseId,
                videoURL = $"/Videos/Courses/{fileName}"
            };

            _videoRepository.Add(video);
            await _videoRepository.SaveAsync();

            GetVideoDTO getVideoDTO = new GetVideoDTO
            {
                Id = video.Id,
                Title = courseDTO.Title,
                Number = courseDTO.Number,
                Description = courseDTO.Description,
                CourseId = courseDTO.CourseId,
                videoURL = $"/Videos/Courses/{fileName}"
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Video has been added successfully.",
                Data = getVideoDTO
            };
        }

        [HttpPut("EditVideo")]
        public async Task<ActionResult<GeneralResponse>> EditCourseVideo([FromForm] EditCourseVideoDTO courseDTO)
        {
            // Retrieve the video from the repository
            Video? video = _videoRepository.GetById(courseDTO.VideoId);

            if (video == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Video Found with this ID : {courseDTO.VideoId}",
                    Status = 405
                };
            }

            string fileName = video.videoURL; // Keep the original video file name if no new file is uploaded

            if (courseDTO.video != null)
            {
                // Validate that the file is a video
                if (!courseDTO.video.ContentType.StartsWith("video/"))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "The uploaded file is not a valid video.",
                        Status = 411
                    };
                }

                // Validate video size
                if (courseDTO.video.Length > _maxVideoSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Video size exceeds the maximum allowed size of 500MB.",
                        Status = 412
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(courseDTO.video.FileName)}_{Guid.NewGuid()}{Path.GetExtension(courseDTO.video.FileName)}";
                var filePath = Path.Combine(_videosPath, fileName);

                // Save the new video file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await courseDTO.video.CopyToAsync(stream);
                }

                // delete the old video file from the server
                var oldFileName = Path.GetFileName(video.videoURL);

                // Construct the full file system path using the _videosPath and the extracted file name
                var oldFilePath = Path.Combine(_videosPath, oldFileName);

                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            // Update the video properties
            video.Title = courseDTO.Title;
            video.Number = courseDTO.Number;
            video.Description = courseDTO.Description;
            video.videoURL = $"/Videos/Courses/{fileName}";

            _videoRepository.Update(video);
            await _videoRepository.SaveAsync();

            GetVideoDTO getVideoDTO = new GetVideoDTO
            {
                Id = video.Id,
                Title = video.Title,
                Number = video.Number,
                Description = video.Description,
                videoURL = video.videoURL,
                CourseId = video.CourseId
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Video has been updated successfully.",
                Data = getVideoDTO
            };
        }

        [HttpDelete("DeleteVideo/{videoId:int}")]
        public async Task<ActionResult<GeneralResponse>> DeleteCourseVideo(int videoId)
        {
            // Retrieve the video from the repository
            Video? video = _videoRepository.GetById(videoId);

            if (video == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Video Found with this ID : {videoId}",
                    Status = 405

                };
            }

            // delete the old video file from the server
            var oldFileName = Path.GetFileName(video.videoURL);

            // Construct the full file system path using the _videosPath and the extracted file name
            var oldFilePath = Path.Combine(_videosPath, oldFileName);

            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            // Remove the video record from the repository
            _videoRepository.Delete(video);
            await _videoRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Video has been deleted successfully."
            };
        }

        //----------------------------------------------------------------------------------------------------------

        [HttpPut]
        public async Task<ActionResult<GeneralResponse>> EditCourse([FromForm] EditCourseDTO courseDTO)
        {
            // Check if the course exists
            Course? course = _courseRepository.Find(criteria: c => c.Id == courseDTO.CourseID, includes: ["Requirements", "Objectives" , "Instructor"]);
            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No course found with ID: {courseDTO.CourseID}",
                    Status = 404,
                };
            }

            bool foundSubCategory = _subCategoryRepository.Exists(courseDTO.SubCategoryId);

            if (!foundSubCategory)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No SubCategory found with ID: {courseDTO.SubCategoryId}",
                    Status = 407,
                };
            }

            var subCategory = _subCategoryRepository.Find(s => courseDTO.SubCategoryId == s.Id, ["Category"]);

            string fileName = course.ThumbnailURL; // Keep the existing thumbnail URL

            if (courseDTO.Thumbnail != null)
            {
                // Validate that the file is an image by checking the MIME type
                if (!courseDTO.Thumbnail.ContentType.StartsWith("image/"))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "The uploaded file is not a valid image.",
                        Status = 409
                    };
                }

                // Validate image size (e.g., max 2MB)
                if (courseDTO.Thumbnail.Length > _maxImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB.",
                        Status = 410
                    };
                }

                // Generate a new unique filename for the thumbnail
                fileName = $"{Path.GetFileNameWithoutExtension(courseDTO.Thumbnail.FileName)}_{Guid.NewGuid()}{Path.GetExtension(courseDTO.Thumbnail.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the new thumbnail
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await courseDTO.Thumbnail.CopyToAsync(stream);
                }

                // Delete the old thumbnail if it exists and is different from the new one
                if (!string.IsNullOrEmpty(course.ThumbnailURL))
                {
                    // delete the old Thumbnail file from the server
                    var oldFilePath = Path.Combine(_imagesPath, Path.GetFileName(course.ThumbnailURL)); // Extract file name from old URL
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
            }

            // Update course details
            course.Title = courseDTO.Title;
            course.DurationInhours = courseDTO.DurationInhours;
            course.Preview = courseDTO.Preview;
            course.SubCategoryId = courseDTO.SubCategoryId;
            course.ThumbnailURL = $"/Images/Courses/{fileName}"; // Update thumbnail URL
            course.Price = courseDTO.Price;
            course.Type = courseDTO.Type;

            if (course?.Requirements != null || course?.Requirements?.Count() == 0)
            {
                _courseRequirementsRepository.DeleteRange(course.Requirements);
                _courseRequirementsRepository.save();
            }

            if (course?.Objectives != null || course?.Objectives?.Count() == 0)
            {
                _courseObjectiveRepository.DeleteRange(course.Objectives);
                _courseObjectiveRepository.save();
            }

            // Update requirements and objectives
            course.Requirements = courseDTO.Requirements?.Select(req => new Requirement
            {
                Description = req.Description
            }).ToList();

            course.Objectives = courseDTO.Objectives?.Select(obj => new Objective
            {
                Description = obj.Description
            }).ToList();

            // Save the updated course
            _courseRepository.Update(course);
            await _courseRepository.SaveAsync();

            GetCourseDTO getCourseDTO = new GetCourseDTO
            {
                Title = courseDTO.Title,
                DurationInhours = courseDTO.DurationInhours,
                Preview = courseDTO.Preview,

                InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                SubCategoryId = courseDTO.SubCategoryId,
                SubCategoryName = subCategory.Name,

                CategoryId = subCategory.CategoryId,
                CategoryName = subCategory.Category.Name,

                ThumbnailURL = $"/Images/Courses/{fileName}", // Update thumbnail URL
                Price = courseDTO.Price,
                Type = courseDTO.Type,

                Requirements = courseDTO.Requirements != null && courseDTO.Requirements.Any()
                    ? courseDTO.Requirements.Select(req => new GetCourseRequirmentsDTO()
                    {
                        Description = req.Description,
                    }).ToList()
                    : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                Objectives = courseDTO.Objectives != null && courseDTO.Objectives.Any()
                    ? courseDTO.Objectives.Select(req => new GetCourseObjectiveDTO()
                    {
                        Description = req.Description,
                    }).ToList()
                    : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Course updated successfully.",
                Data = getCourseDTO
            };
        }

        [HttpDelete("{courseId:int}")]
        public async Task<ActionResult<GeneralResponse>> DeleteCourse(int courseId)
        {
            // Check if the course exists
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
                _courseRequirementsRepository.save();
            }

            if (course?.Objectives != null || course?.Objectives?.Count() == 0)
            {
                _courseObjectiveRepository.DeleteRange(course.Objectives);
                _courseObjectiveRepository.save();
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
            _videoRepository.save();

            // Delete the course
            _courseRepository.Delete(course);
            await _courseRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = $"Course with ID ({courseId}) deleted with it's requirments , objectives and videos successfully."
            };
        }

    }
}