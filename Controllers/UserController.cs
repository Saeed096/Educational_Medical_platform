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
        private readonly IConfiguration _configuration;
        private readonly string _imagesPath;


        public UserController(
            UserManager<ApplicationUser> userManager,
            IEmailService emailService,
            IInstructorRepository instructorRepository,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Users");
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
                    Message = "Invalid Model State",
                    Status = 106
                };
            }

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(userDTO.Email);
            if (existingUser != null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Email is already in use.",
                    Status = 100
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
                    Message = "Couldn't create Account due to Model State Errors",
                    Status = 101
                };
            }

            IdentityResult addRoleResult = new IdentityResult();

            addRoleResult = await _userManager.AddToRoleAsync(applicationUser , "USER");

            if (!addRoleResult.Succeeded)
            {
                _userManager.DeleteAsync(applicationUser);

                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Error Happened While Adding Roles to this User .",
                    Data = addRoleResult.Errors,
                    Status = 102
                };
            }

            // Generate email confirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);

            var confirmationLink = Url.Action("ConfirmEmail", "User", new { userId = applicationUser.Id, token }, Request.Scheme);

            string mailBody = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <title>Email Confirmation</title>\r\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n  <style>\r\n    body {{\r\n      background: #f9f9f9;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n    .container {{\r\n      max-width: 640px;\r\n      margin: 0 auto;\r\n      background: #ffffff;\r\n      box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);\r\n      border-radius: 4px;\r\n      overflow: hidden;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <div style=\"background-color: #7289da; padding: 57px; text-align: center;\">\r\n      <div style=\"cursor: auto; color: white; font-family: Arial, sans-serif; font-size: 36px; font-weight: 600;\">\r\n        Welcome to MedLearn Hub!\r\n      </div>\r\n    </div>\r\n    \r\n    <div style=\"padding: 40px 70px;\">\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <h2 style=\"font-weight: 500; font-size: 20px; color: #4f545c;\">Hey {applicationUser.UserName},</h2>\r\n        <p>\r\n          Welcome aboard MedLearn Hub! 🚀 Thanks for signing up! We're thrilled to have you join our community.\r\n        </p>\r\n        <p>\r\n          To get started, we just need to confirm your email address to ensure everything runs smoothly.\r\n        </p>\r\n        <p>\r\n          Click the button below to verify your email and unlock all the amazing features MedLearn Hub has to offer:\r\n        </p>\r\n      </div>\r\n      <div style=\"text-align: center; padding: 20px;\">\r\n        <a href=\"{confirmationLink}\" style=\"display: inline-block; background-color: #7289da; color: white; text-decoration: none; padding: 15px 30px; border-radius: 3px;\">Verify Email</a>\r\n      </div>\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <p>If you have any questions or need assistance, feel free to reach out to our support team.</p>\r\n        <p>Emad<br>MedLearn Hub Team</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n";

            // Send email confirmation link
            _emailService.SendEmailAsync(userDTO.Email, "Email Confiramtion", mailBody);


            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = applicationUser.Id,
                Message = "User Account Created and Confiramtion mail has been sent successfully"
            };
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
                        string loginUrl = "http://localhost:3000/sign-in";

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
                        Message = "Can't find this username",
                        Status = 104
                    };
                }
                else if (!userFromDB.EmailConfirmed)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "This user email is not confirmed",
                        Status = 105
                    };
                }

                bool IsPasswordMatched = await _userManager.CheckPasswordAsync(userFromDB, userDTO.Password);

                if (IsPasswordMatched)
                {
                    // Create token steps
                    List<Claim> myClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userFromDB.UserName ?? "Not Available"),
                        new Claim(ClaimTypes.NameIdentifier, userFromDB.Id)
                    };

                    // Claim roles
                    IList<string> roles = await _userManager.GetRolesAsync(userFromDB);
                    foreach (string role in roles)
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    // Security key
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                    // JWT header
                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    // JWT payload
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                    (
                        issuer: _configuration["JWT:ValidIss"],
                        audience: _configuration["JWT:ValidAud"],
                        expires: DateTime.Now.AddHours(1),
                        claims: myClaims,
                        signingCredentials: signingCredentials
                    );

                    // Prepare user data to return
                    var userData = new
                    {
                        userFromDB.Id,
                        userFromDB.FirstName,
                        userFromDB.LastName,
                        userFromDB.UserName,
                        userFromDB.PhoneNumber,
                        userFromDB.Email,
                        userFromDB.ImageUrl
                    };

                    // Return the token and user data
                    return new GeneralResponse()
                    {
                        IsSuccess = true,
                        Data = userData, // Include user data in response
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
                        Message = "Wrong Password",
                        Status = 105
                    };
                }
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State",
                    Status = 106
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
                    Message = "Invalid Model State",
                    Status = 106
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

            // Construct the reset link pointing to your frontend
            var resetLink = $"http://localhost:3000/Rest-pass?token={encodedToken}&email={forgotPasswordDTO.Email}";

            string mailBody = $@"
                                <!DOCTYPE html>
                                <html lang='en'>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>Reset Your Password</title>
                                    <link href='https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css' rel='stylesheet'>
                                    <style>
                                        body {{
                                            background-color: #f7f7f7;
                                            font-family: Arial, sans-serif;
                                        }}
                                        .container {{
                                            max-width: 600px;
                                            padding: 20px;
                                            margin: 50px auto;
                                            background-color: white;
                                            border-radius: 10px;
                                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                                        }}
                                        .btn-reset {{
                                            background-color: #007bff;
                                            color: white;
                                            padding: 10px 20px;
                                            border-radius: 5px;
                                            text-decoration: none;
                                        }}
                                        .btn-reset:hover {{
                                            background-color: #0056b3;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    <div class='container'>
                                        <h2>Password Reset Request</h2>
                                        <p>Hello,</p>
                                        <p>We received a request to reset the password for your account associated with this email address.</p>
                                        <p>Click the button below to reset your password:</p>
                                        <div style='text-align: center; margin: 20px 0;'>
                                            <a href='{resetLink}' class='btn btn-reset'>Reset Password</a>
                                        </div>
                                        <p>If you didn't request this, you can ignore this email.</p>
                                        <p>Best regards,</p>
                                        <p>Your Team</p>
                                    </div>
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
                    Message = "Invalid Model State",
                    Status = 106
                };
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);

            if (user == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "User with the provided email does not exist.",
                    Status = 107
                };
            }

            // Decode the token twice if it was double-encoded in the URL
            //var decodedToken = HttpUtility.UrlDecode(HttpUtility.UrlDecode(resetPasswordDTO.Token));
            var decodedToken = HttpUtility.UrlDecode(resetPasswordDTO.Token);

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
                    Message = "Error resetting password.",
                    Status = 108
                };
            }
        }

        [HttpPut("update/{userId}")]
        public async Task<ActionResult<GeneralResponse>> UpdateUser(string userId, [FromForm] UpdateUserDTO updateUserDTO)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "User not found.",
                    Status = 109
                };
            }

            // Update user properties
            user.FirstName = updateUserDTO.FirstName;
            user.LastName = updateUserDTO.LastName;
            user.PhoneNumber = updateUserDTO.PhoneNumber;

            if (!string.IsNullOrWhiteSpace(updateUserDTO.UserName))
            {
                user.UserName = updateUserDTO.UserName; // Update username
            }

            if (!string.IsNullOrWhiteSpace(updateUserDTO.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, updateUserDTO.NewPassword);

                if (!result.Succeeded)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = result.Errors,
                        Message = "Couldn't update password.",
                        Status = 110
                    };
                }
            }

            string fileName = "";

            if (updateUserDTO.Image != null)
            {
                // Validate image size (e.g., max 2MB)
                if (updateUserDTO.Image.Length > 2 * 1024 * 1024)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB."
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(updateUserDTO.Image.FileName)}_{Guid.NewGuid()}{Path.GetExtension(updateUserDTO.Image.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateUserDTO.Image.CopyToAsync(stream);
                }

                user.ImageUrl = $"/Images/Users/{fileName}"; // Assuming you have an ImageURL property in ApplicationUser
            }

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = updateResult.Errors,
                    Message = "Couldn't update user information.",
                    Status = 111
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = user,
                Message = "User information updated successfully."
            };
        }
    }
}