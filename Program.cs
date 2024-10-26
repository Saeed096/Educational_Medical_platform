using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shoghlana.Core.Models;
using Shoghlana.EF;
using System.Text;


namespace Educational_Medical_platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://localhost:5173") // Add multiple origins
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });


            #region Registering Services
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>(); 
            builder.Services.AddScoped<IBookRepository,BookRepository>();
            builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IBlog_User_LikesRepository, Blog_User_LikeRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
            builder.Services.AddScoped<IStandardTestRepository, StandardTestRepository>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseRequirementsRepository, CourseRequirementsRepository>();
            builder.Services.AddScoped<ICourseObjectiveRepository, CourseObjectiveRepository>();
            builder.Services.AddScoped<IVideoRepository, VideoRepository>();
            builder.Services.AddScoped<IUserEnrolledCoursesRepository, UserEnrolledCoursesRepository>();
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            builder.Services.AddScoped<IUserSubscribtionRipository, UserSubscribtionRipository>();
            builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
            builder.Services.AddScoped<IUserLocalSubscribtionRepository, UserLocalSubscribtionRepository>();

            #endregion

            //************************************************************************

            #region JWT


            // Registering Identiny
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // you can remove some validations for easier testing
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireLowercase = false;
                //options.Password.RequireUppercase = false;
                //options.Password.RequireDigit = false;
                //options.SignIn.RequireConfirmedAccount = true;        // maybe later

                options.SignIn.RequireConfirmedEmail = true; // You can adjust this based on your requirements

            })
            .AddEntityFrameworkStores<ApplicationDBContext>()
            .AddDefaultTokenProviders(); // This line registers the default token providers

            //ibrahim:this line for forget password configrations for ==>link time epirtations
            //builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(10));

            builder.Services.AddAuthentication(options =>
            {
                // adjusting the authorize attr to look for JWT Bearer tokens not schema
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                // in case of failer(challenge) => see the JWT default behaviour which is returing UnAuthorized res
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                // see the other schemas and change them with the JWT default schema
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                // the token must be saved not written
                options.SaveToken = true;

                // validate the token itself
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    // check that the issuer is this wep API
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIss"],

                    // check that the audience is target React App
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAud"],// note : don't write any sapces

                    // check the signature resulting from : key + payload 
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"])),
                };
            });


            /// <summary>
            /// disapling checking for authorize by default because of the [Api Controller] attribute
            /// if the model state was Invalid => the default was not to enter the action nad return directly Badrequest with arr of Errors
            /// So I disaple this default so it enters the action and returns my customized response
            /// </summary>
            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            //-----------------------------------------------------

            /// <summary>
            /// swager configuration to deal with register and login tokens
            /// <summary>
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET Core 8 Web API",
                    Description = "MedLearn Hub"
                });

                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6 IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                      {
                      new OpenApiSecurityScheme
                      {
                  Reference = new OpenApiReference
                  {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                      }
                  },
                      new string[] {}
                      }
                  });
            });

            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromHours(3)); // Example: 3 hours

            builder.WebHost.ConfigureKestrel(options =>
            {
                // Set the maximum request body size to 1 GB
                options.Limits.MaxRequestBodySize = 1 * 1024 * 1024 * 1024 ; // 1 GB in bytes
            });

            // Configure form options to handle large file uploads
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 1 * 1024 * 1024 * 1024; // 1 GB in bytes
            });

            #endregion

            //*************************************************************************
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("DefaultPolicy");

            app.UseAuthentication(); // Ensure this is called before authorization

            app.UseAuthorization();

            app.UseStaticFiles(); // Serves files from wwwroot

            app.MapControllers();

            app.Run();
        }
    }
}