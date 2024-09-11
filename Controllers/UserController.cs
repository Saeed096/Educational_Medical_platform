using Educational_Medical_platform.DTO.User;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IAdminRepository _adminRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IConfiguration _configuration;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IEmailService emailService,
            IAdminRepository adminRepository,
            IInstructorRepository instructorRepository,
            IStudentRepository studentRepository,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _adminRepository = adminRepository;
            _instructorRepository = instructorRepository;
            _studentRepository = studentRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<GeneralResponse>> Register(RegisterDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State"
                };
            }

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(userDTO.Email);
            if (existingUser != null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Email is already in use."
                };
            }

            ApplicationUser applicationUser = new ApplicationUser()
            {
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                UserName = $"{userDTO.FirstName}_{userDTO.LastName}",
            };

            IdentityResult createAccResult = await _userManager.CreateAsync(applicationUser, userDTO.Password);

            if (!createAccResult.Succeeded)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = createAccResult.Errors,
                    Message = "Couldn't create Account due to Model State Errors"
                };
            }

            IdentityResult addRoleResult = new IdentityResult();

            if (userDTO.Role == Role.Student)
            {
                addRoleResult = await _userManager.AddToRoleAsync(applicationUser, "Student");
            }
            else if (userDTO.Role == Role.Instructor)
            {
                addRoleResult = await _userManager.AddToRoleAsync(applicationUser, "Instructor");
            }
            else if (userDTO.Role == Role.Admin)
            {
                addRoleResult = await _userManager.AddToRoleAsync(applicationUser, "Admin");
            }

            if (!addRoleResult.Succeeded)
            {
                _userManager.DeleteAsync(applicationUser);

                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Error Happened While Adding Roles to this User .",
                    Data = addRoleResult.Errors
                };
            }

            // Generate email confirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);

            var confirmationLink = Url.Action("ConfirmEmail", "User", new { userId = applicationUser.Id, token }, Request.Scheme);

            string mailBody = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <title>Email Confirmation</title>\r\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n  <style>\r\n    body {{\r\n      background: #f9f9f9;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n    .container {{\r\n      max-width: 640px;\r\n      margin: 0 auto;\r\n      background: #ffffff;\r\n      box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);\r\n      border-radius: 4px;\r\n      overflow: hidden;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <div style=\"background-color: #7289da; padding: 57px; text-align: center;\">\r\n      <div style=\"cursor: auto; color: white; font-family: Arial, sans-serif; font-size: 36px; font-weight: 600;\">\r\n        Welcome to MedLearn Hub!\r\n      </div>\r\n    </div>\r\n    \r\n    <div style=\"padding: 40px 70px;\">\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <h2 style=\"font-weight: 500; font-size: 20px; color: #4f545c;\">Hey {applicationUser.UserName},</h2>\r\n        <p>\r\n          Welcome aboard MedLearn Hub! 🚀 Thanks for signing up! We're thrilled to have you join our community.\r\n        </p>\r\n        <p>\r\n          To get started, we just need to confirm your email address to ensure everything runs smoothly.\r\n        </p>\r\n        <p>\r\n          Click the button below to verify your email and unlock all the amazing features MedLearn Hub has to offer:\r\n        </p>\r\n      </div>\r\n      <div style=\"text-align: center; padding: 20px;\">\r\n        <a href=\"{confirmationLink}\" style=\"display: inline-block; background-color: #7289da; color: white; text-decoration: none; padding: 15px 30px; border-radius: 3px;\">Verify Email</a>\r\n      </div>\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <p>If you have any questions or need assistance, feel free to reach out to our support team.</p>\r\n        <p>Emad<br>MedLearn Hub Team</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n";

            // Send email confirmation link
            _emailService.SendEmailAsync(userDTO.Email, "Email Confiramtion", mailBody);


            if (userDTO.Role == Role.Student)
            {
                Student student = new Student()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    User = applicationUser,
                    IsSubscribed = false
                };

                _studentRepository.Add(student);

                _studentRepository.save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = student.Id,
                    Message = "Student Account Created and Confiramtion mail has been sent successfully"
                };
            }
            else if (userDTO.Role == Role.Instructor)
            {
                Instructor instructor = new Instructor()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    User = applicationUser
                };

                _instructorRepository.Add(instructor);

                _instructorRepository.save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = instructor.Id,
                    Message = "instructor Account Created and Confiramtion mail has been sent successfully"
                };
            }
            else if (userDTO.Role == Role.Admin)
            {
                Admin admin = new Admin()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    User = applicationUser
                };

                var s = _adminRepository.Add(admin);

                _adminRepository.save();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = admin.Id,
                    Message = "admin Account Created and Confiramtion mail has been sent successfully"
                };
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = userDTO.Role,
                    Message = "Invalid Role !"
                };
            }
        }


        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            int maxRetryAttempts = 3;
            int retryAttempt = 0;

            while (retryAttempt < maxRetryAttempts)
            {
                try
                {
                    if (userId is null || token is null)
                    {
                        return Content("<html><body><h1>Error</h1><p>User ID or token is null.</p></body></html>", "text/html");
                    }

                    var user = await _userManager.FindByIdAsync(userId);

                    if (user is null)
                    {
                        return Content("<html><body><h1>Error</h1><p>Unable to load user.</p></body></html>", "text/html");
                    }

                    // Validates that an email confirmation token matches the specified user.
                    var result = await _userManager.ConfirmEmailAsync(user, token);

                    if (result.Succeeded)
                    {
                        //string loginUrl = Url.Action("Login", "User", null, Request.Scheme);
                        string loginUrl = "http://localhost:3000/Put the login URL in React here";

                        string htmlContent = $@"
                        <!DOCTYPE html>
                        <html>
                        <head>
                            <title>Email Verified</title>
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                                    text-align: center;
                                    margin-top: 50px;
                                    background-color: #f4f4f4;
                                }}
                                .container {{
                                    max-width: 500px;
                                    margin: 0 auto;
                                    padding: 20px;
                                    background: #fff;
                                    border-radius: 5px;
                                    box-shadow: 0 0 10px rgba(0,0,0,0.1);
                                }}
                                .button {{
                                    display: inline-block;
                                    padding: 10px 20px;
                                    font-size: 16px;
                                    color: #fff;
                                    background-color: #7289da;
                                    text-decoration: none;
                                    border-radius: 5px;
                                }}
                            </style>
                        </head>
                        <body>
                            <div class='container'>
                                <h1>Email Verified Successfully</h1>
                                <p>Your email address has been verified. You can now log in to your account.</p>
                                <a href='{loginUrl}' class='button'>Go to Login</a>
                            </div>
                        </body>
                        </html>";

                        return Content(htmlContent, "text/html");
                    }
                    else
                    {
                        return Content("<html><body><h1>Error</h1><p>Error confirming email.</p></body></html>", "text/html");
                    }
                }
                catch (Exception ex)
                {
                    // wait for a short duration before retrying
                    await Task.Delay(TimeSpan.FromSeconds(1)); // Wait for 1 second before retrying
                    retryAttempt++;
                }
            }

            return Content("<html><body><h1>Error</h1><p>Error confirming email after multiple retries.</p></body></html>", "text/html");
        }


        [HttpPost("login")]
        public async Task<ActionResult<GeneralResponse>> Login(LoginDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? userFromDB = await _userManager.FindByEmailAsync(userDTO.Email);

                if (userFromDB is null)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "can't find this user name"
                    };
                }
                else if (!userFromDB.EmailConfirmed)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "this user Email is not confirmed"
                    };
                }

                bool IsPasswordMatched = await _userManager.CheckPasswordAsync(userFromDB, userDTO.Password);

                if (IsPasswordMatched)
                {
                    // create token steps : 
                    List<Claim> myClaims = new List<Claim>();
                    myClaims.Add(new Claim(ClaimTypes.Name, userFromDB.UserName ?? "Not Available"));
                    myClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDB.Id));
                    //myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // if u want for the same user => his token be unique for each login => uncomment this

                    // claim roles
                    IList<string> roles = await _userManager.GetRolesAsync(userFromDB);

                    foreach (string role in roles)
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    //  security key 
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    // in the JWT header =>  credentials : key + ALgorithm
                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    // in the JWT payload => JwtSecurityToken is a class that design the token
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                        (
                        issuer: _configuration["JWT:ValidIss"], // the povider API who is responsible for creating the token
                        audience: _configuration["JWT:ValidAud"],  // the consumer (React domain)
                        expires: DateTime.Now.AddHours(1),
                        claims: myClaims,
                        signingCredentials: signingCredentials
                        );

                    //return the token
                    return new GeneralResponse()
                    {
                        IsSuccess = true,
                        Data = null,
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Expired = jwtSecurityToken.ValidTo,
                        Message = "Token Created Successfully"
                    };
                }
                else
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Wrong Password"
                    };
                }
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State"
                };
            }
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<GeneralResponse>> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State"
                };
            }

            var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);

            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "User with the provided email does not exist or is not confirmed."
                };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = HttpUtility.UrlEncode(token);
            var resetLink = Url.Action("ResetPassword", "User", new { token = encodedToken, email = user.Email }, Request.Scheme);

            string mailBody = $@"
                            <!DOCTYPE html>
                            <html>
                            <head>
                                <title>Reset Your Password</title>
                            </head>
                            <body>
                                <h1>Reset Your Password</h1>
                                <p>We received a request to reset your password. Click the link below to reset it:</p>
                                <a href='{resetLink}'>Reset Password</a>
                                <p>If you did not request this password reset, please ignore this email.</p>
                            </body>
                            </html>";

            await _emailService.SendEmailAsync(forgotPasswordDTO.Email, "Password Reset Request", mailBody);

            return new GeneralResponse
            {
                IsSuccess = true,
                Message = "Password reset email has been sent."
            };
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<GeneralResponse>> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State"
                };
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);

            if (user == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "User with the provided email does not exist."
                };
            }

            // Decode the token twice if it was double-encoded in the URL
            var decodedToken = HttpUtility.UrlDecode(HttpUtility.UrlDecode(resetPasswordDTO.Token));

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, resetPasswordDTO.NewPassword);

            if (result.Succeeded)
            {
                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Password has been reset successfully."
                };
            }
            else
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = result.Errors,
                    Message = "Error resetting password."
                };
            }
        }

    }
}