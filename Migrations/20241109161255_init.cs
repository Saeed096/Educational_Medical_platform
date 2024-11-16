using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubscribedToPlatform = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionMethod = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "platformData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescribtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanFixedPricePerMonth = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PlanSetupFee = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PlanTaxesPercentage = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platformData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserLocalSubscribtions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocalSubscribtions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLocalSubscribtions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscriptionPlanId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikesNumber = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Blogs_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaypalProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInhours = table.Column<float>(type: "real", nullable: false),
                    Preview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Courses_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StandardTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullmark = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardTests_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StandardTests_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Blog_User_Likes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_User_Likes", x => new { x.UserId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_Blog_User_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Blog_User_Likes_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserEnrolledCourses",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<float>(type: "real", nullable: true),
                    CurrentVideoNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransactionImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEnrolledCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserEnrolledCourses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEnrolledCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    videoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_StandardTests_TestId",
                        column: x => x.TestId,
                        principalTable: "StandardTests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "952625cb-623b-4f8e-a426-c9e14ffe41bc", "9e9ef764-d672-42d8-99ee-93c2410d8ae0", "Admin", "ADMIN" },
                    { "ea3206f7-8571-4e45-b209-e593236f3420", "df2d8409-cg61-4aac-ae65-b26fbbab77f2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsSubscribedToPlatform", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionMethod", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a111a11-1111-1111-1111-111111111111", 0, "cffb14a3-4614-48c2-b6a5-3f755019f233", "Ehab_Naser@example.com", true, "Ehab", null, false, "Naser", false, null, "EHAB_NASER@EXAMPLE.COM", "EHAB_NASER", "AQAAAAIAAYagAAAAEBsxX7ZE7gD1it/Cm/JzVVh4zG9e2jH/xWy8Gje2OqpO8Jtb5TPbLgCVrJoC8F7htA==", "011548726155", false, "9f9ef764-d632-42d2-99ee-93v2410d8ae0", null, false, "Ehab_Naser" },
                    { "2b222b22-2222-2222-2222-222222222222", 0, "8155b9e3-9ea4-4771-bee2-b868e8677373", "Abdallah_Saudie@business.example.com", true, "Abdallah", null, false, "Saudie", false, null, "ABDALLAH_SAUDIE@BUSINESS.EXAMPLE.COM", "ABDALLAH_SAUDIE", "AQAAAAIAAYagAAAAEASqXeM56z9WBKczXoC3Nwux+7V6rYYellXGFO1vrasSz8bTh/2SuVNFOJ8x0VnVHQ==", "01054871566", false, "9f9ed761-d631-42d2-99ee-93v2420d8ae0", null, false, "Abdallah_Saudie" },
                    { "3c333c33-3333-3333-3333-333333333333", 0, "89e9ea2f-d88f-4fcf-b20d-ecb876028af5", "Alaa_Test@example.com", true, "Alaa", null, false, "Ahmed", false, null, "ALAA_AHMED@EXAMPLE.COM", "ALAA_AHMED", "AQAAAAIAAYagAAAAEBh16Wrw5SjkLFEAUxlEFKO/MKIhLBX4PattvOipJ7MECv62suvuaIesmc5l+9ifcA==", "01225193482", false, "9f1ed761-a631-42dq-99ee-93z2420d8aeq", null, false, "Alaa_Ahmed" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Anatomy Course", 0 },
                    { 2, "Physiology Course", 0 },
                    { 3, "Pharmacology Course", 0 },
                    { 4, "Pathology Course", 0 },
                    { 5, "Anatomy Book", 1 },
                    { 6, "Physiology Book", 1 },
                    { 7, "Pharmacology Book", 1 },
                    { 8, "Pathology Book", 1 },
                    { 9, "Anatomy Blog", 2 },
                    { 10, "Physiology Blog", 2 },
                    { 11, "Pharmacology Blog", 2 },
                    { 12, "Pathology Blog", 2 },
                    { 13, "Anatomy Exam", 3 },
                    { 14, "Physiology Exam", 3 },
                    { 15, "Pharmacology Exam", 3 },
                    { 16, "Pathology Exam", 3 },
                    { 17, "American physical therapy equation", 3 }
                });

            migrationBuilder.InsertData(
                table: "platformData",
                columns: new[] { "Id", "PlanDescription", "PlanFixedPricePerMonth", "PlanId", "PlanName", "PlanSetupFee", "PlanTaxesPercentage", "ProductDescribtion", "ProductId", "ProductName" },
                values: new object[] { 1, null, 20m, null, null, 2m, 10m, null, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "952625cb-623b-4f8e-a426-c9e14ffe41bc", "1a111a11-1111-1111-1111-111111111111" },
                    { "ea3206f7-8571-4e45-b209-e593236f3420", "2b222b22-2222-2222-2222-222222222222" },
                    { "ea3206f7-8571-4e45-b209-e593236f3420", "3c333c33-3333-3333-3333-333333333333" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Conclusion", "Content", "ImageURL", "Intro", "LikesNumber", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, "2b222b22-2222-2222-2222-222222222222", 1, "Understanding human anatomy is essential for medical professionals and enthusiasts alike.", "This blog covers the basics of human anatomy...", "/Images/Blogs/blog1.jpg", "Anatomy is the branch of biology concerned with the study of the structure of organisms and their parts.", 10, null, "Introduction to Human Anatomy" },
                    { 2, "2b222b22-2222-2222-2222-222222222222", 1, "The study of comparative anatomy is crucial for evolutionary biology and understanding the functional adaptations of organisms.", "This blog explores comparative anatomy across species...", "/Images/Blogs/blog1.jpg", "Comparative anatomy allows us to understand the similarities and differences between different organisms.", 15, null, "Advanced Comparative Anatomy" },
                    { 3, "2b222b22-2222-2222-2222-222222222222", 2, "A deep understanding of cell physiology is vital for advancements in medical science.", "Understanding the basics of cell physiology...", "/Images/Blogs/blog1.jpg", "Cell physiology is the study of the functions of cells and their components.", 20, null, "Fundamentals of Cell Physiology" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Human Anatomy", 0 },
                    { 2, 1, "Comparative Anatomy", 0 },
                    { 3, 2, "Cell Physiology", 0 },
                    { 4, 2, "Systemic Physiology", 0 },
                    { 5, 3, "Clinical Pharmacology", 0 },
                    { 6, 3, "Pharmacokinetics", 0 },
                    { 7, 4, "General Pathology", 0 },
                    { 8, 4, "Systemic Pathology", 0 },
                    { 9, 5, "Human Anatomy Book", 1 },
                    { 10, 5, "Comparative Anatomy Book", 1 },
                    { 11, 6, "Cell Physiology Book", 1 },
                    { 12, 6, "Systemic Physiology Book", 1 },
                    { 13, 7, "Clinical Pharmacology Book", 1 },
                    { 14, 7, "Pharmacokinetics Book", 1 },
                    { 15, 8, "General Pathology Book", 1 },
                    { 16, 8, "Systemic Pathology Book", 1 },
                    { 17, 9, "Human Anatomy Blog", 2 },
                    { 18, 9, "Comparative Anatomy Blog", 2 },
                    { 19, 10, "Cell Physiology Blog", 2 },
                    { 20, 10, "Systemic Physiology Blog", 2 },
                    { 21, 11, "Clinical Pharmacology Blog", 2 },
                    { 22, 11, "Pharmacokinetics Blog", 2 },
                    { 23, 12, "General Pathology Blog", 2 },
                    { 24, 12, "Systemic Pathology Blog", 2 },
                    { 25, 13, "Human Anatomy Exam", 3 },
                    { 26, 13, "Comparative Anatomy Exam", 3 },
                    { 27, 14, "Cell Physiology Exam", 3 },
                    { 28, 14, "Systemic Physiology Exam", 3 },
                    { 29, 15, "Clinical Pharmacology Exam", 3 },
                    { 30, 15, "Pharmacokinetics Exam", 3 },
                    { 31, 16, "General Pathology Exam", 3 },
                    { 32, 16, "Systemic Pathology Exam", 3 },
                    { 33, 17, "Surgery", 3 },
                    { 34, 17, "Burns", 3 },
                    { 35, 17, "Surgery & Burns", 3 },
                    { 36, 17, "Cardiology & Chest", 3 },
                    { 37, 17, "Cancer", 3 },
                    { 38, 17, "Dermatology", 3 },
                    { 39, 17, "Other systems", 3 },
                    { 40, 17, "Basic science", 3 },
                    { 41, 17, "Gynecology", 3 },
                    { 42, 17, "Neurology", 3 }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Conclusion", "Content", "ImageURL", "Intro", "LikesNumber", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 4, "2b222b22-2222-2222-2222-222222222222", 1, "This overview serves as a foundational step towards more detailed studies of specific systems.", "This blog provides an overview of human anatomy...", "/Images/Blogs/blog1.jpg", "An overview of human anatomy highlights the complexity and organization of the human body.", 5, 1, "Human Anatomy Overview" },
                    { 5, "3c333c33-3333-3333-3333-333333333333", 2, "Grasping systemic physiology is crucial for understanding how the body maintains homeostasis.", "An introductory blog on systemic physiology...", "/Images/Blogs/blog1.jpg", "Systemic physiology studies the functions of various systems within the body.", 8, 4, "Systemic Physiology Basics" },
                    { 6, "3c333c33-3333-3333-3333-333333333333", 3, "Understanding these applications is essential for safe and effective patient care.", "Exploring clinical applications in pharmacology...", "/Images/Blogs/blog1.jpg", "Pharmacology focuses on the interactions between drugs and living organisms.", 12, 5, "Clinical Applications of Pharmacology" },
                    { 7, "3c333c33-3333-3333-3333-333333333333", 4, "A solid grasp of pathology is necessary for any healthcare professional.", "A comprehensive overview of pathology...", "/Images/Blogs/blog1.jpg", "Pathology is the study of disease, its causes, and effects on the body.", 7, 7, "Pathology: An Overview" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Description", "PublishDate", "PublisherName", "PublisherRole", "SubCategoryId", "ThumbnailURL", "Title", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 5, "A comprehensive guide for first-year medical students.", new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed Galal", "User", 9, "https://example.com/thumbnails/book1.jpg", "Introduction to Medical Studies", "https://example.com/books/intro-medical-studies", "2b222b22-2222-2222-2222-222222222222" },
                    { 2, 5, "In-depth study of human anatomy for advanced medical students.", new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed Galal", "User", 9, "https://example.com/thumbnails/book2.jpg", "Advanced Human Anatomy", "https://example.com/books/advanced-anatomy", "2b222b22-2222-2222-2222-222222222222" },
                    { 3, 5, "A practical guide to clinical diagnostic methods.", new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alaa Ahmed", "User", 10, "https://example.com/thumbnails/book3.jpg", "Clinical Diagnosis Techniques", "https://example.com/books/clinical-diagnosis", "3c333c33-3333-3333-3333-333333333333" },
                    { 4, 6, "Essential pharmacology concepts for healthcare professionals.", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alaa Ahmed", "User", 11, "https://example.com/thumbnails/book4.jpg", "Pharmacology Basics", "https://example.com/books/pharmacology-basics", "3c333c33-3333-3333-3333-333333333333" },
                    { 5, 6, "Key topics in pathology explained in a clear and concise manner.", new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alaa Ahmed", "User", 12, "https://example.com/thumbnails/book5.jpg", "Pathology Essentials", "https://example.com/books/pathology-essentials", "3c333c33-3333-3333-3333-333333333333" },
                    { 6, 7, "Basic microbiology concepts for beginners.", new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ehab Naser", "Admin", 13, "https://example.com/thumbnails/book6.jpg", "Microbiology Fundamentals", "https://example.com/books/microbiology-fundamentals", "1a111a11-1111-1111-1111-111111111111" },
                    { 7, 7, "A handbook on modern surgical techniques.", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ehab Naser", "Admin", 13, "https://example.com/thumbnails/book7.jpg", "Surgical Procedures Handbook", "https://example.com/books/surgical-procedures", "1a111a11-1111-1111-1111-111111111111" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "DurationInhours", "InstructorId", "PaypalProductId", "Preview", "Price", "RejectedReason", "Status", "SubCategoryId", "ThumbnailURL", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, 10f, "2b222b22-2222-2222-2222-222222222222", "", null, 1500m, null, 1, 1, null, "physiology", 0 },
                    { 2, 2, 20f, "2b222b22-2222-2222-2222-222222222222", "", null, 1000m, null, 0, 3, null, "anatomy", 1 },
                    { 3, 3, 30f, "3c333c33-3333-3333-3333-333333333333", "", null, 2500m, null, 2, 5, null, "histology", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "BlogId", "CourseId", "Description", "SubCategoryId", "TestId" },
                values: new object[,]
                {
                    { 6, null, null, "What is the primary function of the digestive system?", 1, null },
                    { 7, null, null, "How does the body absorb nutrients?", 1, null },
                    { 8, null, null, "What are the main components of the digestive system?", 2, null },
                    { 9, null, null, "What is the role of enzymes in digestion?", 2, null },
                    { 10, null, null, "What is the process of peristalsis?", 3, null },
                    { 11, 1, null, "What are the key structures of the human body?", null, null },
                    { 12, 1, null, "How does the muscular system work?", null, null },
                    { 13, 2, null, "What is the importance of studying anatomy?", null, null },
                    { 14, 2, null, "What are the different systems of the human body?", null, null },
                    { 15, 3, null, "What role does the nervous system play in body functions?", null, null }
                });

            migrationBuilder.InsertData(
                table: "StandardTests",
                columns: new[] { "Id", "CategoryId", "Difficulty", "DurationInMinutes", "Fullmark", "Price", "SubCategoryId", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 13, 0, 60, 100, 0, 25, "Test1", 0 },
                    { 2, 14, 1, 100, 150, 100, 27, "Test2", 1 },
                    { 3, 15, 2, 200, 300, 150, 29, "Test3", 1 },
                    { 4, 17, 1, 30, 20, 150, 36, "Cardiology & Chest 1", 0 },
                    { 5, 17, 1, 30, 20, 150, 36, "Cardiology & Chest 2", 1 },
                    { 6, 17, 1, 30, 20, 150, 36, "Cardiology & Chest 3", 1 },
                    { 7, 17, 1, 30, 20, 150, 36, "Cardiology & Chest 4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId", "Reason" },
                values: new object[,]
                {
                    { 16, "Breaks down food", true, 6, "The digestive system's primary role is to break down food." },
                    { 17, "Circulates blood", false, 6, "Blood circulation is the role of the circulatory system." },
                    { 18, "Transports oxygen", false, 6, "Oxygen transport is handled by the respiratory system." },
                    { 19, "Through the walls of the intestines", true, 7, "Nutrients are absorbed through the intestinal walls into the bloodstream." },
                    { 20, "Via the bloodstream", false, 7, "The bloodstream transports nutrients after they are absorbed." },
                    { 21, "By chewing", false, 7, "Chewing is part of the mechanical digestion process, not nutrient absorption." },
                    { 22, "Mouth, esophagus, stomach", true, 8, "These are the primary organs involved in the digestive process." },
                    { 23, "Brain, heart, lungs", false, 8, "These organs are not directly involved in digestion." },
                    { 24, "Skin, muscles, bones", false, 8, "These are not part of the digestive system." },
                    { 25, "They speed up chemical reactions", true, 9, "Enzymes are biological catalysts that accelerate chemical reactions." },
                    { 26, "They are absorbed", false, 9, "Enzymes are not absorbed; they assist in reactions." },
                    { 27, "They break down food", false, 9, "While enzymes help in breaking down food, they do not do so independently." },
                    { 28, "The wave-like motion that moves food", true, 10, "Peristalsis is the wave-like motion that moves food through the digestive tract." },
                    { 29, "The absorption of nutrients", false, 10, "Nutrient absorption occurs after food is moved through the digestive tract." },
                    { 30, "The secretion of enzymes", false, 10, "Enzyme secretion assists in digestion but is not the motion that moves food." },
                    { 31, "Organs and systems", true, 11, "These are the correct components when discussing body structures." },
                    { 32, "Cells only", false, 11, "Cells are part of organs and systems, not the only component." },
                    { 33, "Muscles only", false, 11, "Muscles are just one type of tissue, which is part of organs and systems." },
                    { 34, "By contracting and relaxing", true, 12, "Muscles work by contracting and relaxing to produce movement." },
                    { 35, "By sending signals", false, 12, "While signaling is important, it does not describe how muscles function directly." },
                    { 36, "By absorbing nutrients", false, 12, "Muscles do not absorb nutrients; this is a function of the digestive system." },
                    { 37, "To understand the human body", true, 13, "Anatomy is studied to understand the structure and function of the body." },
                    { 38, "To pass exams", false, 13, "While exams may test knowledge, they are not the purpose of studying anatomy." },
                    { 39, "To perform surgeries", false, 13, "While anatomy knowledge is important for surgeries, it is not the sole purpose of the study." },
                    { 40, "Nervous, muscular, skeletal", true, 14, "These are major body systems." },
                    { 41, "Respiratory, circulatory", false, 14, "While important, they do not encompass all major systems." },
                    { 42, "Digestive, excretory", false, 14, "These systems are essential but are not all-inclusive of body systems." },
                    { 43, "Controls body functions", true, 15, "The nervous system regulates bodily functions." },
                    { 44, "Transports nutrients", false, 15, "Nutrient transport is handled by the circulatory system." },
                    { 45, "Provides energy", false, 15, "Energy provision is not a primary role of the nervous system." }
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "CourseId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Enhancing medical skills" },
                    { 2, 1, "Enhancing physiology knowledge" },
                    { 3, 1, "increasing job opportunities" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "BlogId", "CourseId", "Description", "SubCategoryId", "TestId" },
                values: new object[,]
                {
                    { 1, null, 1, "What is the basic unit of life?", null, null },
                    { 2, null, 1, "Which organelle is known as the powerhouse of the cell?", null, null },
                    { 3, null, 2, "What is the function of ribosomes?", null, null },
                    { 4, null, 2, "What is the role of the cell membrane?", null, null },
                    { 5, null, 2, "What is osmosis?", null, null },
                    { 16, null, null, "What is the primary function of red blood cells?", null, 1 },
                    { 17, null, null, "How does the immune system protect the body?", null, 1 },
                    { 18, null, null, "What are the stages of the cell cycle?", null, 2 },
                    { 19, null, null, "What is apoptosis?", null, 2 },
                    { 20, null, null, "What role does DNA play in inheritance?", null, 2 },
                    { 21, null, null, "To manually assess a patient's lower extremity circulation, a physical therapist should palpate the patient's peripheral pulse at which of the following locations?", 36, 4 },
                    { 22, null, null, "A patient has difficulty palpating the carotid pulse during exercise. The patient should be instructed in alternate methods of self-monitoring, because repeated palpation is likely to result in:", 36, 4 },
                    { 23, null, null, "A physical therapist is walking down an isolated hospital staircase. The therapist sees a middle-aged adult lying on the landing and determines that the adult is unresponsive. What should the therapist do NEXT?", 36, 4 },
                    { 24, null, null, "A patient reports a 2-week history of left upper abdominal quadrant pain, left flank pain, and mid-back pain as a result of a motor vehicle accident. The patient also reports being fatigued and generally not feeling well. Which of the following differential diagnoses would MOST likely account for the patient's symptoms?", 36, 4 },
                    { 25, null, null, "Clubbing of the fingers is MOST associated with which of the following conditions?", 36, 4 },
                    { 26, null, null, "During initial examination of a patient, a physical therapist notices severe clubbing of the patient's fingernails. The therapist should further investigate for the presence of signs and symptoms associated with which of the following conditions?", 36, 4 },
                    { 27, null, null, "What precautions should a physical therapist observe when working with a patient infected with methicillin-resistant Staphylococcus aureus?", 36, 4 },
                    { 28, null, null, "When examining a patient with a history of alcohol abuse, a physical therapist notes that the patient demonstrates fine resting tremors and hyperactive reflexes. The patient reports frequent right upper quadrant pain. Which of the following additional signs is MOST likely to be present?", 36, 4 },
                    { 29, null, null, "Which of the following signs and symptoms are MOST characteristic of a patient with metabolic syndrome?", 36, 4 },
                    { 30, null, null, "During an examination, a physical therapist finds that a patient with chronic obstructive pulmonary disease has a weak wet cough. Which of the following techniques is MOST appropriate to help this patient clear secretions?", 36, 4 },
                    { 31, null, null, "Increased residual volume is LEAST likely to be a finding in pulmonary function testing of a patient with which of the following conditions?", 36, 4 },
                    { 32, null, null, "Which of the following combinations of measures is the MOST useful for determining changes in status in a patient who has chronic obstructive pulmonary disease and emphysema?", 36, 4 },
                    { 33, null, null, "A patient with a recent total knee arthroplasty and a new diagnosis of hiatal hernia is concerned about the exercise program. Which of the following responses by the physical therapist would be MOST appropriate?", 36, 4 },
                    { 34, null, null, "Which of the following hernias is MOST likely to cause shoulder pain?", 36, 4 },
                    { 35, null, null, "A patient who has a hiatal hernia is receiving physical therapy. Which of the following exercises would MOST likely worsen the symptoms related to the hernia?", 36, 4 },
                    { 36, null, null, "A patient reports multiple myalgias, fatigue, weight gain despite decreased food intake, and frequently feeling cold. The physical therapist should expect information from which of the following tests to be MOST helpful in managing the patient's care?", 36, 4 },
                    { 37, null, null, "Which of the following factors is considered to be a primary risk factor for atherosclerosis?", 36, 4 },
                    { 38, null, null, "Which of the following endocrine glands regulates sexual development?", 36, 4 },
                    { 39, null, null, "Which of the following is the MOST likely hormonal response in reaction to a stressful stimulus?", 36, 4 },
                    { 40, null, null, "A patient with syndrome of inappropriate antidiuretic hormone secretion (SIADH) would MOST likely have complications involving which of the following systems?", 36, 4 },
                    { 41, null, null, "A patient has aspiration precautions. Which of the following factors is MOST likely to affect the patient's condition?", 36, 5 },
                    { 42, null, null, "A physical therapist examines the output from a single lead electrocardiogram of a patient with atrioventricular heart block. The defining characteristic of first-degree atrioventricular heart block is:", 36, 5 },
                    { 43, null, null, "A patient's electrocardiogram shows a new ST-segment displacement from baseline and a sinus rhythm of 70 bpm. What is the MOST likely diagnosis?", 36, 5 },
                    { 44, null, null, "A patient who is transported to the physical therapy department in a wheelchair reports severe, bilateral lower extremity pain. A purple discoloration of both feet is observed. The pain is relieved when the patient's feet are raised just above the horizontal plane. These signs are MOST indicative of:", 36, 5 },
                    { 45, null, null, "A patient with peripheral vascular disease comes to physical therapy for evaluation of leg pain that gets worse when walking. The patient will MOST likely also have:", 36, 5 },
                    { 46, null, null, "A physical therapist reviews the medical record of a patient diagnosed with peripheral vascular disease prior to initiating treatment. Which objective finding would most severely limit the patient's ability to participate in an exercise program?", 36, 5 },
                    { 47, null, null, "A patient with the ulcer shown in the photograph is unable to perceive a 5.07-gauge (10-g) monofilament applied to the sole of the foot. Which of the following ulcer types is MOST likely present?", 36, 5 },
                    { 49, null, null, "A patient who has lower extremity claudication is exercising to the point of symptom production. The skin on the distal aspect of the patient's lower extremity is MOST likely to display which of the following findings?", 36, 5 },
                    { 50, null, null, "A patient has an aching, cramping sensation in the posterior lower legs bilaterally that occurs during walking and is relieved by rest. The patient's feet are pale and cool to the touch. The popliteal and pedal pulses are absent. The patient has full range of motion of the ankles and knee, and Normal (5/5) strength in the tibialis anterior and Good (4/5) strength in the gastrocnemius and soleus bilaterally. The MOST likely cause of this patient's pain is:", 36, 5 },
                    { 51, null, null, "A patient is in good health except for hypertension that is controlled with a beta-blocker. What is the BEST means of monitoring the patient's cardiovascular tolerance?", 36, 5 },
                    { 52, null, null, "A physical therapist working with a patient who is borderline hypotensive can minimize orthostatic hypotension by:", 36, 5 },
                    { 53, null, null, "A physical therapist plans to use a tilt table for a patient who is having difficulty tolerating upright sitting position. The therapist should stop inclining the tilt table if the patient experiences which of the following signs and symptoms?", 36, 5 },
                    { 54, null, null, "Which of the following signs is MOST likely to be present in a patient who has been experiencing chronic diarrhea?", 36, 5 },
                    { 55, null, null, "A physical therapist is examining the feet of a patient with type 2 diabetes. Which of the following tests is BEST to determine the patient's risk for developing foot ulceration?", 36, 5 },
                    { 56, null, null, "A patient suspected of having hypoglycemia is MOST likely to show which of the following signs?", 36, 5 },
                    { 57, null, null, "A physical therapist is monitoring the exercise of a patient who has type 1 diabetes. The patient's blood glucose level would be BEST for safe exercise at which of the following values?", 36, 5 },
                    { 58, null, null, "A physical therapist has been asked to speak to a group of senior citizens regarding the benefits of exercise. The therapist should instruct the group that exercise has the greatest effect on which of the following endocrine disorders?", 36, 5 },
                    { 59, null, null, "A patient who has type 2 diabetes mellitus is starting an aerobic exercise program. Which of the following effects is MOST expected with continued adherence to the exercise program?", 36, 5 },
                    { 60, null, null, "During an initial evaluation, which of the following tests is MOST likely to identify an abnormal finding for a patient who has acute right-sided heart failure?", 36, 5 },
                    { 61, null, null, "An inpatient is referred to physical therapy after undergoing coronary artery bypass surgery 5 days ago. The patient's medical history includes hypertension, hypercholesterolemia, and type 2 diabetes. Which of the following sets of factors should a physical therapist consider when developing a plan of care?", 36, 6 },
                    { 62, null, null, "A woman has been walking on a treadmill for 10 minutes at 3.5 miles (5.6 km) per hour and 0° elevation when she reports a new onset of midthoracic back pain, aching in the right biceps muscle, fatigue, weakness, and nausea. Which system is MOST likely implicated?", 36, 6 },
                    { 63, null, null, "Which of the following descriptions BEST characterizes stable angina?", 36, 6 },
                    { 64, null, null, "A patient with chest pain from myocardial ischemia will MOST likely exhibit:", 36, 6 },
                    { 65, null, null, "Prior to starting an exercise training program, a patient with cardiac problems who is taking beta-blocking medication should receive an explanation of the:", 36, 6 },
                    { 66, null, null, "A patient with idiopathic pulmonary fibrosis completed a 6-minute walk test and demonstrates the following results: total walking distance of 1200 ft (366 m) in 6 minutes, heart rate of 82 to 110 bpm (pretest to posttest), blood pressure of 125/80 to 145/85 mm Hg (pretest to posttest), respiratory rate of 18 to 40 breaths/minute (pretest to posttest), and oxygen saturation of 98% to 92% (pretest to posttest); an electrocardiogram showed normal sinus rhythm throughout the test. Based on these results, the physical therapist should determine that the patient has impaired:", 36, 6 },
                    { 67, null, null, "A 22-year-old patient is hospitalized awaiting a lung transplant due to cystic fibrosis. The patient's physician is interested in an objective measure of the patient's preoperative endurance. Which of the following tests is MOST appropriate for the physical therapist to administer to this patient?", 36, 6 },
                    { 68, null, null, "A physical therapist is setting up an exercise program for a patient who is interested in improving cardiovascular fitness. When performing a submaximal cycle ergometer test the therapist should expect a relatively constant value for:", 36, 6 },
                    { 69, null, null, "A patient, who has many risk factors for coronary artery disease and is presently not taking any cardiac medications, is interested in beginning an exercise program at a gym to improve cardiac health. The BEST self-assessment of exercise intensity during the exercise sessions of this patient is:", 36, 6 },
                    { 70, null, null, "An important change in gastrointestinal function that occurs with aging is a(n):", 36, 6 },
                    { 71, null, null, "An important change in gastrointestinal function that occurs with aging is a(n):", 36, 6 },
                    { 72, null, null, "An active 75-year-old patient is admitted to the hospital following a fall at home. All workup is negative and comorbidities are limited to osteoarthritis, cataracts, and hypertension. Which of the following statements is the MOST accurate prognosis?", 36, 6 },
                    { 73, null, null, "A 21-year-old female ballet dancer who has had an insidious onset of pelvic and hip pain is referred to physical therapy. During the history the patient reports relief of symptoms after passing gas. The patient exhibits full, pain-free hip and lumbar range of motion and normal lower extremity strength. The patient's pain is unchanged by walking or lying supine. Which of the following causes of the pain is MOST likely?", 36, 6 },
                    { 74, null, null, "The medical record indicates that a patient has a deficiency of vitamin D. The patient is MOST at risk for developing which of the following conditions?", 36, 6 },
                    { 75, null, null, "A patient with a chronic skin ulcer displays decreased blood pressure and skin turgor, as well as a weak, rapid pulse. A physical therapist should suspect a decreased dietary intake of:", 36, 6 },
                    { 76, null, null, "Which of the following terms BEST describes a patient who has a body mass of 27 kg/m²?", 36, 6 },
                    { 77, null, null, "Treatment of a patient with hemophilia who has a subacute hemarthrosis of the knee should INITIALLY include:", 36, 6 },
                    { 78, null, null, "Rate pressure product is MOST indicative of which of the following cardiac factors?", 36, 6 },
                    { 79, null, null, "While walking on a treadmill during Phase II cardiac rehabilitation following coronary artery bypass surgery, a patient reports the new onset of chest pain and dyspnea. The physical therapist should instruct the patient to:", 36, 6 },
                    { 80, null, null, "A home health patient who recently had a three-vessel coronary artery bypass graft describes experiencing bilateral lower extremity swelling, leg pain, and shortness of breath, especially when lying down. The patient MOST likely has which of the following diagnoses?", 36, 6 },
                    { 81, null, null, "While walking on a treadmill during Phase II cardiac rehabilitation following coronary artery bypass surgery, a patient reports the new onset of chest pain and dyspnea. The physical therapist should instruct the patient to:", 36, 7 },
                    { 82, null, null, "When providing patient education in cardiac rehabilitation, which of the following signs and symptoms of exertional intolerance should the physical therapist emphasize?", 36, 7 },
                    { 83, null, null, "Which of the following findings are associated with the LOWEST risk for a subsequent cardiac event?", 36, 7 },
                    { 84, null, null, "A patient is referred to physical therapy with thoracic spine pain. Which of the following data obtained from the patient's history is MOST likely indicative of the presence of an underlying cardiac condition?", 36, 7 },
                    { 85, null, null, "A physical therapist observes a bluish discoloration of the nail beds of the toes on the operative extremity. This finding is MOST often associated with which of the following conditions?", 36, 7 },
                    { 86, null, null, "A nonathletic male patient reports occasional brief palpitations without pain, dizziness, or light-headedness. The MOST likely source of the palpitations is:", 36, 7 },
                    { 87, null, null, "To manually assess a patient's lower extremity circulation, a physical therapist should palpate the patient's peripheral pulse at which of the following locations?", 36, 7 },
                    { 88, null, null, "The resting heart rate of a 32-year-old runner is measured at 46 bpm. Which of the following explanations for this heart rate is MOST likely?", 36, 7 },
                    { 89, null, null, "A patient has difficulty palpating the carotid pulse during exercise. The patient should be instructed in alternate methods of self-monitoring, because repeated palpation is likely to result in:", 36, 7 },
                    { 90, null, null, "A physical therapist is walking down an isolated hospital staircase. The therapist sees a middle-aged adult lying on the landing and determines that the adult is unresponsive. What should the therapist do NEXT?", 36, 7 },
                    { 91, null, null, "A patient reports a 2-week history of left upper abdominal quadrant pain, left flank pain, and mid-back pain as a result of a motor vehicle accident. The patient also reports being fatigued and generally not feeling well. Which of the following differential diagnoses would MOST likely account for the patient's symptoms?", 36, 7 },
                    { 92, null, null, "Clubbing of the fingers is MOST associated with which of the following conditions?", 36, 7 },
                    { 93, null, null, "During initial examination of a patient, a physical therapist notices severe clubbing of the patient's fingernails. The therapist should further investigate for the presence of signs and symptoms associated with which of the following conditions?", 36, 7 },
                    { 94, null, null, "A physical therapist is providing supervised exercise to a patient who has been restricted to extended bed rest. After 2 weeks of intervention, which of the following measures would BEST reflect cardiopulmonary system improvement?", 36, 7 },
                    { 95, null, null, "A physical therapist is administering a graded exercise test. Which of the following patient responses is an ABSOLUTE indication for terminating the exercise test?", 36, 7 },
                    { 96, null, null, "A patient who had a myocardial infarction 5 days ago is referred for a low-level treadmill test. The patient reports having had several episodes of mild angina at rest, after meals, and during the night since being hospitalized. Which of the following actions is MOST appropriate for the physical therapist?", 36, 7 }
                });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "Id", "CourseId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "being medical student" },
                    { 2, 1, "having laptop" },
                    { 3, 2, "buying premium package" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CourseId", "Description", "Number", "Title", "videoURL" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "new video", "https://www.youtube.com/watch?v=4oThHBo2-Gs" },
                    { 2, 2, null, 1, "old video", "https://www.youtube.com/watch?v=mgEAimOoyHk" },
                    { 3, 3, null, 1, "funny video", "https://www.youtube.com/watch?v=zhCKr62s12w" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId", "Reason" },
                values: new object[,]
                {
                    { 1, "Cell", true, 1, "Cells are the basic building blocks of life." },
                    { 2, "Tissue", false, 1, "Tissues are made up of cells, but they are not the smallest unit of life." },
                    { 3, "Organ", false, 1, "Organs are composed of tissues, which consist of cells." },
                    { 4, "Mitochondria", true, 2, "Mitochondria are known as the powerhouse of the cell." },
                    { 5, "Nucleus", false, 2, "The nucleus contains the cell's genetic material, but does not produce energy." },
                    { 6, "Ribosome", false, 2, "Ribosomes are responsible for protein synthesis, not energy production." },
                    { 7, "Protein synthesis", true, 3, "This is the primary function of ribosomes in the cell." },
                    { 8, "Energy production", false, 3, "Energy production occurs in the mitochondria, not during protein synthesis." },
                    { 9, "DNA replication", false, 3, "DNA replication is a separate process from protein synthesis." },
                    { 10, "Protects the cell", true, 4, "The cell membrane protects the cell from its environment." },
                    { 11, "Stores DNA", false, 4, "DNA is stored in the nucleus, not the cell membrane." },
                    { 12, "Produces energy", false, 4, "Energy production occurs in mitochondria, not the cell membrane." },
                    { 13, "Movement of water", true, 5, "Osmosis is the movement of water across a membrane." },
                    { 14, "Transport of nutrients", false, 5, "Nutrient transport occurs via active and passive transport mechanisms, not osmosis." },
                    { 15, "Protein synthesis", false, 5, "Protein synthesis involves ribosomes, not the movement of water." },
                    { 46, "To carry oxygen", true, 16, "Hemoglobin in red blood cells carries oxygen." },
                    { 47, "To fight infections", false, 16, "Fighting infections is primarily the role of the immune system." },
                    { 48, "To clot blood", false, 16, "Blood clotting is done by platelets and certain plasma proteins." },
                    { 49, "By recognizing pathogens", true, 17, "The immune system identifies and targets pathogens." },
                    { 50, "By producing energy", false, 17, "Energy production is not a function of the immune system." },
                    { 51, "By storing nutrients", false, 17, "Nutrient storage is a function of the liver and other organs." },
                    { 52, "Interphase, mitosis, cytokinesis", true, 18, "These are the stages of the cell cycle." },
                    { 53, "Prophase, metaphase, anaphase", false, 18, "These terms refer to stages of mitosis, not the entire cell cycle." },
                    { 54, "Meiosis only", false, 18, "Meiosis is a specific type of cell division, separate from the cell cycle." },
                    { 55, "Programmed cell death", true, 19, "Apoptosis is the process of programmed cell death." },
                    { 56, "Cell growth", false, 19, "Cell growth is a separate process from apoptosis." },
                    { 57, "Cell division", false, 19, "Cell division is the process of replicating cells, distinct from programmed cell death." },
                    { 58, "Carries genetic information", true, 20, "DNA is the molecule that carries genetic information." },
                    { 59, "Produces energy", false, 20, "Energy production is not a role of DNA." },
                    { 60, "Fights diseases", false, 20, "DNA does not directly fight diseases; it contains the instructions for making proteins." },
                    { 61, "Dorsal foot, near the base of the first metatarsal", true, 21, ". The therapist should palpate the dorsal pedal pulse, which is found on the dorsal aspect of the foot near the base of the first metatarsal. The dorsalis pedis pulse is often used to assess a patient's circulation because of its distal location on the lower extremity. (pp. 1101-1102)" },
                    { 62, "Lateral lower leg, just posterior to the fibular head", false, 21, "The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The popliteal pulse may also be palpated, but it is located posterior to the knee, not in the lateral leg. (p. 979)" },
                    { 63, "Lateral ankle, just inferior to the lateral malleolus", false, 21, "The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The posterior tibial pulse may also be palpated, but it is located at the medial ankle just posterior to the medial malleolus, not the lateral ankle. (p. 1102)" },
                    { 64, "Plantar foot, just medial to the medial calcaneal tuberosity", false, 21, "The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The pulse would be palpated on the dorsal surface of the foot, not the plantar surface. The plantar foot does not possess a pulse site used in lower extremity circulation assessment. (p. 1102)" },
                    { 65, "an increase in the heart rate.", false, 22, "Heart rate is expected to decrease, not increase when the carotid sinus is overstimulated." },
                    { 66, "a decrease in the heart rate.", true, 22, "Manual pressure on the carotid sinus can cause a reflexive drop in heart rate, blood pressure, or both." },
                    { 67, "an irregular heart rhythm.", false, 22, "Heart rate, not rhythm, is expected to change due to manual pressure on the carotid sinus." },
                    { 68, "an increase in blood pressure.", false, 22, "Blood pressure is expected to decrease, not increase, due to pressure on the carotid sinus." },
                    { 69, "Initiate chest compressions.", false, 23, "When an adult is found unresponsive, the first step is to activate emergency medical services and then begin chest compressions." },
                    { 70, "Find the nearest defibrillator.", false, 23, "In the adult population, the most important factor for survival typically is time to defibrillation; therefore, it is most important to activate the emergency response system first. The proper sequence after that is to initiate chest compressions and then rescue breaths." },
                    { 71, "Initiate rescue breathing.", false, 23, "Emergency medical services should be activated first. Then chest compressions should be initiated followed by rescue breaths." },
                    { 72, "Activate the emergency response system", true, 23, "Emergency medical services should be activated first, due to the need (typically) for defibrillation in the adult." },
                    { 73, "Chronic fatigue syndrome", false, 24, "The diagnostic criteria for chronic fatigue syndrome are similar to those for fibromyalgia syndrome (FMS) with the hallmark feature being fatigue (versus pain in FMS). This option does not address specifically the left upper abdominal quadrant pain, left flank pain, and mid-back pain. (p. 460)" },
                    { 74, "Referred pain from the spleen", true, 24, "The spleen is located in the upper left abdominal quadrant. Enlargement of the spleen may be associated with the etiology and symptoms noted in the stem. (pp. 214-215)" },
                    { 75, "Conversion disorder from emotional distress", false, 24, "A conversion disorder is defined as a condition that presents as an alteration or loss of a physical function suggestive of a physical disorder, with often an underlying psychological conflict or need. The stem does not describe a loss of function. (p. 145)" },
                    { 76, "Acute onset of bladder infection", false, 24, "Lower abdominal pain and a strong urge to urinate are characteristics of a bladder infection. These symptoms are not described in the stem. (p. 628)" },
                    { 77, "Lymphedema", false, 25, "Lymphedema is not commonly associated with digital clubbing. While lymphedema is associated with chronic swelling of the extremities, chronic hypoxia is not commonly observed." },
                    { 78, "Chronic obstructive pulmonary disease", true, 25, "Conditions that chronically interfere with tissue perfusion and nutrition may cause clubbing. Pulmonary disease is the most predominant cause of digital clubbing and is present in 75% to 85% of the cases in which clubbing is noted." },
                    { 79, "Chronic venous insufficiency", false, 25, "Chronic venous insufficiency is not commonly associated with digital clubbing. Hemosiderin staining, lower extremity swelling, and stasis ulcers are more characteristic of venous insufficiency." },
                    { 80, "Complex regional pain syndrome", false, 25, "Digital clubbing is not commonly associated with complex regional pain syndrome. Abnormal pain and trophic changes are characteristic of complex regional pain syndrome." },
                    { 81, "Skin cancer", false, 26, "Nail clubbing is not associated with skin cancer." },
                    { 82, "Renal failure", false, 26, "The nails of patients who have renal failure may appear to have short transverse lines across the nail (Mees lines) or a brownish distal one-third end of the nail (half-and-half nails), but not clubbing." },
                    { 83, "Lung cancer", true, 26, "Severe clubbing of the nails is an abnormality associated with lung cancer and chronic hypoxia." },
                    { 84, "Liver dysfunction", false, 26, "Liver dysfunction may result in nails with transverse depressions (Beau lines) or a nail bed that is white and extends two-thirds of the length of the nail (Terry nails)." },
                    { 85, "Airborne", false, 27, "Methicillin-resistant Staphylococcus aureus is not spread through the air; it is spread by contact." },
                    { 86, "Sterile", false, 27, "Sterile precautions or techniques are not necessary for the physical therapist to use with a patient infected with methicillin-resistant Staphylococcus aureus." },
                    { 87, "Droplet", false, 27, "Methicillin-resistant Staphylococcus aureus is not spread through droplets; it is spread by contact." },
                    { 88, "Contact", true, 27, "Methicillin-resistant Staphylococcus aureus is spread by contact." },
                    { 89, "Jaundice", true, 28, "With a history of alcohol abuse and the presence of fine resting tremors and right upper quadrant pain, the patient is presenting a history and signs and symptoms consistent with liver disease. Jaundice is a skin change associated with disease of the hepatic system. (Goodman, p. 363)" },
                    { 90, "Hyperhidrosis", false, 28, "Hyperhidrosis, or excessive sweating, can be present with several conditions, such as endocrine disorders, but is not associated with liver disease (Taber's, p. 1164)." },
                    { 91, "Hypotension", false, 28, "Hypotension is not listed as a sign of liver disorders (Goodman, p. 363)." },
                    { 92, "Nocturnal cough", false, 28, "A nocturnal cough can be associated with rheumatic fever, but is not characteristic of liver disease (Goodman, p. 260)." },
                    { 93, "Confused mental state, muscular weakness, and presence of nausea", false, 29, "Confused mental state, weakness, and nausea are signs and symptoms of metabolic alkalosis (p. 435)." },
                    { 94, "Large waist circumference, high triglyceride values, and high blood pressure", true, 29, "Metabolic syndrome consists of signs and symptoms that are actually risk factors and are strongly linked to type 2 diabetes, cardiovascular disease, and stroke. Metabolic syndrome is characterized by abdominal obesity (waist size > 40 in (101.6 cm), high triglycerides levels, high low-density lipids and low high-density lipids cholesterol values, and elevated blood pressure (> 130/85 mm Hg). (p. 435)" },
                    { 95, "Headache, fatigue, and muscular twitching", false, 29, "Headache, fatigue, and muscular twitching are signs and symptoms of metabolic acidosis (p. 436)." },
                    { 96, "Respiratory rate of 15 breaths/minute, pulse rate of 60 bpm, and body temperature of 96.5°F (35.9°C)", false, 29, "A respiratory rate of 15 breaths/min, a heart rate of 60 bpm, and body temperature of 96.5°F (35.9°C) are considered normal for older adults (pp. 161, 163, 170)." },
                    { 97, "Abdominal thrusts", false, 30, "Abdominal thrusts or Heimlich-type assistance is primarily used in patients with low neuromuscular tone or flaccid abdominal muscles (Frownfelter, p. 343)." },
                    { 98, "Postural drainage", false, 30, "Postural drainage facilitates drainage of secretions to the level of the segmental bronchus only. In addition, a cough is needed to clear secretions. (Hillegass, p. 541)" },
                    { 99, "Huffing", true, 30, "Huffing helps stabilize collapsible airways present with chronic obstructive pulmonary disease (Hillegass, p. 545; Frownfelter, p. 321)." },
                    { 100, "Manual or mechanical percussion", false, 30, "Percussion helps mobilize secretions from the periphery of the lungs; however, it does not improve the strength of the patient's cough (Hillegass, pp. 543-544)." },
                    { 101, "Atelectasis", true, 31, "Atelectasis is more of a restrictive issue and would not lead to an increase in residual volume. Restrictive lung disease is associated with a decreased residual volume." },
                    { 102, "Bronchiectasis", false, 31, "Bronchiectasis is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume." },
                    { 103, "Chronic bronchitis", false, 31, "Chronic bronchitis is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume." },
                    { 104, "Emphysema", false, 31, "Emphysema is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume." },
                    { 105, "Vital capacity, functional residual capacity, and total lung capacity", false, 32, "Vital capacity, functional residual capacity, and total lung capacity are important measurements in the diagnosis of pulmonary disease but have minimal value for the staging of obstructive pulmonary disease (p. 196)." },
                    { 106, "Forced inspiratory volume in 1 second and the ratio of forced inspiratory volume in 1 second to forced vital capacity", false, 32, "Forced inspiratory volume in 1 second is not a test performed during pulmonary function tests. The main issue in chronic obstructive pulmonary disease is forced expiration, and this would not be a useful measure in assessing disease progression. (pp. 196, 350)" },
                    { 107, "Tidal volume and the ratio of tidal volume to total lung capacity", false, 32, "The tidal volume and the tidal volume/total lung capacity ratio are important in the determination of a patient's current ventilation capacity but do not factor into the staging of chronic obstructive pulmonary disease (p. 196)." },
                    { 108, "Forced expiratory volume in 1 second and the ratio of forced expiratory volume in 1 second to forced vital capacity", true, 32, "Forced expiratory volume in 1 second and the ratio of forced expiratory volume in 1 second to forced vital capacity ratio are the most useful measurements in determining the progression of obstructive pulmonary disease and are part of the Global Initiative for Chronic Obstructive Lung Disease (GOLD) classification system (p. 196)." },
                    { 109, "Supine exercises are best for patients with a hiatal hernia.", false, 33, "Supine position can cause the lower esophagus and stomach to be pulled into the thorax, thus increasing symptoms or discomfort. Although not contraindicated, these exercises would not be best. (p. 1429)" },
                    { 110, "Exercise is contraindicated for patients with a hiatal hernia.", false, 33, "Exercise can help with some of the risk factors for hernia, including obesity/weight control (p. 1430)." },
                    { 111, "There are no restrictions on exercise for patients with a hiatal hernia.", false, 33, "The physical therapist should educate the patient on the challenges of supine exercise, recumbent exercises, exercises that involve bending, and exercises that increase abdominal pressure, exacerbating symptoms (pp. 1429-1430)." },
                    { 112, "The Valsalva maneuver should be avoided during exercise.", true, 33, "Patients who have a hiatal hernia should avoid the Valsalva maneuver. The Valsalva maneuver increases intraabdominal pressure, which can worsen the hernia (pp. 1429-1430)." },
                    { 113, "Femoral", false, 34, "A hiatal hernia would most likely be associated with shoulder pain. A femoral hernia will cause pain in the lateral pelvic wall (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616)." },
                    { 114, "Hiatal", true, 34, "A hiatal hernia would most likely be associated with shoulder pain. An inguinal hernia will cause groin pain, and an umbilical hernia would most likely cause pain around the umbilical ring in the mid to lower abdomen (Goodman, Pathology, pp. 868, 898-900; Goodman, Differential Diagnosis, pp. 615-616)." },
                    { 115, "Inguinal", false, 34, "A hiatal hernia would most likely be associated with shoulder pain. An inguinal hernia will cause groin pain (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616)." },
                    { 116, "Umbilical", false, 34, "A hiatal hernia would most likely be associated with shoulder pain. An umbilical hernia would most likely cause pain around the umbilical ring in the mid to lower abdomen. (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616)." },
                    { 117, "Wall sits", false, 35, "Wall sits are performed in an upright position and would not exacerbate a hiatal hernia." },
                    { 118, "Overhead press", false, 35, "An overhead press is typically performed in seated, semireclined, or standing position and would not exacerbate a hiatal hernia." },
                    { 119, "Bilateral leg lifts", true, 35, "Individuals who have a hiatal hernia should avoid supine position and avoid the Valsalva maneuver. Bilateral leg lifts must be performed in supine position and require strong contractions of the stomach muscles, encouraging the Valsalva maneuver, which would worsen the hiatal hernia." },
                    { 120, "Hamstring stretch", false, 35, "Hamstring stretching can be modified to be done in a position other than supine to avoid exacerbating a hiatal hernia." },
                    { 121, "Rheumatoid factor", false, 36, "Rheumatoid factor is appropriate for determining the presence of rheumatoid arthritis or other inflammatory conditions. A patient who has rheumatoid arthritis would be more likely to report arthralgias than myalgias. (p. 452)" },
                    { 122, "C-reactive protein", false, 36, "The patient is describing symptoms of hypothyroidism. C-reactive protein is a nonspecific indicator of inflammation or infection. It wouldn't provide the most pertinent information with this diagnosis. (pp. 248, 465)" },
                    { 123, "Fasting blood glucose level", false, 36, "Fasting blood glucose levels determine the amount of sugar (glucose) in the blood. This is an appropriate test for diabetes. Fatigue and weight loss are associated with diabetes; however, polyuria and polydipsia are often reported. The patient's report of myalgias and impaired thermoregulation is more consistent with hypothyroidism. (pp. 425-426)" },
                    { 124, "Thyroid stimulating hormone level", true, 36, "The patient is describing symptoms of hypothyroidism. When hypothyroidism is present, the blood levels of thyroid hormones can be measured directly and are decreased. The main tool for the detection of thyroid disease is the measurement of thyroid stimulating hormone. (pp. 417, 420)" },
                    { 125, "Stress", false, 37, "Stress is a secondary risk factor." },
                    { 126, "Obesity", false, 37, "Obesity is a secondary risk factor." },
                    { 127, "Cigarette smoking", true, 37, "High blood pressure, cigarette smoking, and hyperlipidemia are direct or primary risk factors for atherosclerosis." },
                    { 128, "Sedentary lifestyle", false, 37, "Activity level is a secondary risk factor." },
                    { 129, "Parathyroid", false, 38, "The parathyroid gland is responsible for calcium and phosphorus metabolism and bone calcification. It does not play a role in sexual development." },
                    { 130, "Thyroid", false, 38, "Secretion of hormones via the thyroid gland is regulated by the pituitary gland. The thyroid secretes hormones that control metabolism and protein synthesis. It also influences calcium and phosphorus metabolism. The thyroid gland does not play a role in sexual development." },
                    { 131, "Adrenal", false, 38, "Hormone secretion by the adrenal glands is regulated by the pituitary gland. The adrenal gland does secrete hormones responsible for secondary sexual characteristics. However, it is primarily involved in fluid/electrolyte balance and metabolism." },
                    { 132, "Pituitary", true, 38, "The pituitary gland serves as a master gland and regulates the secretion of many hormones. The anterior pituitary glands regulate sexual development via release of gonadotropins. Gonadotropins regulate secretion of male and female hormones." },
                    { 133, "Release of epinephrine by the adrenal gland", true, 39, "The sympathetic system is aroused during the stress response and causes the medulla of the adrenal gland to release catecholamines, such as epinephrine, norepinephrine, and dopamine, into the bloodstream. (p. 475)" },
                    { 134, "Suppression of cortisol by the adrenal gland", false, 39, "Cortisol is a catecholamine that is increased during stress. (p. 475)" },
                    { 135, "Release of adrenalin by the hypothalamus", false, 39, "Adrenalin is increased with stress, but it is produced by the adrenal medulla. (p. 475)" },
                    { 136, "Suppression of growth hormone by the pituitary", false, 39, "Growth hormone may be increased as a response to stress. (p. 476)" },
                    { 137, "Neuromuscular", false, 40, "Syndrome of inappropriate antidiuretic hormone secretion results in fluid volume excess. Fluid loss would be more likely to result in neuromuscular symptoms, such as tetany or tingling. (p. 211)" },
                    { 138, "Integumentary", false, 40, "The skin may be warm or cool if edema is present, but there should be no concern with skin integrity in this condition (p. 211)." },
                    { 139, "Cardiovascular", true, 40, "Syndrome of inappropriate antidiuretic hormone results in fluid volume excess, so it may cause hypertension and arrhythmias, which require monitoring as activity levels change. Also, the physical therapist may observe distended neck veins or a visible jugular pulse. (pp. 211, 482-483)" },
                    { 140, "Musculoskeletal", false, 40, "Syndrome of inappropriate antidiuretic hormone secretion results in fluid volume excess. Fluid loss would be more likely to result in musculoskeletal symptoms, such as weakness. (p. 211)" },
                    { 141, "Liquids are aspirated more easily than solids.", true, 41, "Dysphagia can lead to aspiration. Dysphagia can be assessed at bedside. Aspiration is more likely to occur with thin liquids. Therefore, treatment is to thicken the liquids or use thicker solutions and then progress to thinner liquids as the patient's swallowing function improves. (McCance, p. 1428)" },
                    { 142, "Solids are aspirated more easily than liquids.", false, 41, "Aspiration is more likely to occur with thin liquids (McCance, p. 1428)." },
                    { 143, "Cold food is easier to swallow than warm food.", false, 41, "Moist, warm food is more easily swallowed (McCance, p. 1428)." },
                    { 144, "Hyperextension of the neck facilitates swallowing.", false, 41, "To facilitate swallowing, posture should be aligned with the chin tucked (Cifu, p. 66)." },
                    { 145, "Heightened T wave", false, 42, "" },
                    { 146, "Prolonged PR interval", true, 42, "Atrioventricular blocks are caused by an abnormal delay or failure of conduction through the AV node or the atrioventricular bundle. The defining characteristic of first-degree atrioventricular heart block is a prolonged PR interval. (Brannon 212)" },
                    { 147, "Bizarre QRS complex", false, 42, "" },
                    { 148, "Shortened ST segment", false, 42, "" },
                    { 149, "Bradycardia", false, 43, "Bradycardia is defined as a heart rate below 60 bpm (pp. 314-315)." },
                    { 150, "Anxiety reaction", false, 43, "Anxiety reactions typically present with an increased heart rate (pp. 315-316)." },
                    { 151, "Acute myocardial infarction", true, 43, "Acute myocardial infarction is associated with either ST elevation or ST depression (pp. 285, 331)." },
                    { 152, "Congestive heart failure", false, 43, "Congestive heart failure is not usually associated with ST elevation." },
                    { 153, "arterial insufficiency.", false, 44, "With arterial insufficiency, elevation increases ischemia and, therefore, pain." },
                    { 154, "intermittent claudication.", false, 44, "Intermittent claudication is associated with metabolic demands exceeding the capability of the vascular system to supply adequate blood flow and manifests as pain during lower extremity exercise." },
                    { 155, "venous insufficiency.", true, 44, "With venous insufficiency, placing the limb in a dependent position increases swelling and, therefore, possibly, pain." },
                    { 156, "a psychosomatic episode.", false, 44, "An objective sign, such as purple discoloration, rules out a psychosomatic episode." },
                    { 157, "relief of pain with the legs elevated.", false, 45, "The patient most likely has intermittent claudication caused by arterial insufficiency. Elevating the legs in the presence of arterial insufficiency decreases blood flow, which increases pain." },
                    { 158, "purple or brown pigmentation of the skin on the legs.", false, 45, "Purple or brown pigmentation of the skin on the legs is associated with venous insufficiency, not arterial insufficiency." },
                    { 159, "relief of pain with the legs in the dependent position.", true, 45, "Placing the patient's legs in the dependent position facilitates blood flow and reduces pain." },
                    { 160, "a positive Homans sign.", false, 45, "Pain with exercise is indicative of intermittent claudication, not deep vein thrombosis, which is associated with a positive Homans sign." },
                    { 161, "signs of resting claudication", true, 46, "Peripheral vascular disease refers to a condition involving the arterial, venous, or lymphatic system that results in compromised circulation to the extremities. Resting claudication is typically considered a contraindication to active exercise in patients with peripheral vascular disease. (Kisner 631)" },
                    { 162, "decreased peripheral pulses", false, 46, "" },
                    { 163, "cool skin", false, 46, "" },
                    { 164, "blood pressure: 165/90 mm Hg", false, 46, "" },
                    { 165, "Pressure", false, 47, "A pressure ulcer is caused by unrelieved external pressure against the skin over a bony prominence. The wound in the picture is not a pressure injury." },
                    { 166, "Neuropathic", true, 47, "The ulcer is located on the plantar surface of the foot with decreased protective sensation, which is associated with peripheral neuropathies. Therefore, it is a neuropathic ulcer." },
                    { 167, "Arterial insufficiency", false, 47, "Ischemic ulcers have sharply demarcated borders and are usually located over the toes or dorsum of the foot. The ulcer in question is inconsistent with arterial wounds." },
                    { 168, "Venous insufficiency", false, 47, "Venous insufficiency ulcers are typically located proximal to the medial malleolus and do not present with decreased protective sensation." },
                    { 170, "Edema", false, 49, "Edema would be expected for a patient who has venous insufficiency, not intermittent claudication associated with arterial insufficiency." },
                    { 171, "Hyperhidrosis", false, 49, "Hyperhidrosis is not expected in the lower extremities of a patient experiencing intermittent claudication." },
                    { 172, "Hyperemia", false, 49, "Pallor, not hyperemia, would be expected due to arterial insufficiency, which shunts blood away from the area." },
                    { 173, "Pallor", true, 49, "Pallor is caused by shunting of blood to the exercising muscle and away from the distal aspect of the extremity." },
                    { 174, "lower extremity venous stasis.", false, 50, "Venous insufficiency does not result in pale or cool skin and absent pulses." },
                    { 175, "deep-vein thrombosis.", false, 50, "Deep vein thrombosis is generally painful but does not present with intermittent claudication symptoms." },
                    { 176, "chronic arterial occlusion.", true, 50, "The scenario describes intermittent claudication characteristic of arterial occlusion, with pale, cool skin and absent pulses." },
                    { 177, "weakness of the plantar flexors.", false, 50, "Weakness of the plantar flexors does not cause the pain or associated changes in skin temperature and pulse." },
                    { 178, "Electrocardiogram", false, 51, "Beta-blockers decrease both resting and exercise heart rates, making an electrocardiogram unreliable. Although it can detect arrhythmias, it is not the best option for assessing tolerance." },
                    { 179, "Rating of perceived exertion", true, 51, "Due to the blunted heart rate response from beta-blockers, using the rating of perceived exertion scale is recommended as it provides a better assessment of cardiovascular tolerance." },
                    { 180, "Pulse oximetry", false, 51, "While pulse oximetry monitors oxygen saturation, the rating of perceived exertion scale is preferred over pulse oximetry for assessing cardiovascular tolerance in patients on beta-blockers." },
                    { 181, "Heart rate", false, 51, "Beta-blockers lower both resting and exercise heart rates, making heart rate monitoring unreliable." },
                    { 182, "loosening tight legwear and footwear before gait training.", false, 52, "Tight stockings are actually recommended to reduce orthostatic hypotension, rather than loosening legwear." },
                    { 183, "elevating the head during a hypotensive episode.", false, 52, "The head of the bed should be lowered during a hypotensive episode to help improve blood pressure." },
                    { 184, "instructing the patient to perform ankle pumps before standing.", true, 52, "Ankle pumps help reduce symptoms of orthostatic hypotension by promoting circulation before standing." },
                    { 185, "encouraging the patient to consume meals prior to therapy.", false, 52, "Consuming meals before therapy does not significantly affect orthostatic hypotension." },
                    { 186, "Decrease in diastolic blood pressure of 15 mm Hg", true, 53, "An excessive drop in blood pressure suggests the patient is not tolerating the upright position well, indicating the need to stop inclining." },
                    { 187, "Increase in systolic blood pressure of 10 mm Hg", false, 53, "A slight increase in systolic blood pressure is normal and does not indicate intolerance to the upright position." },
                    { 188, "Increase in heart rate of 15 bpm", false, 53, "An increase in heart rate is expected and does not signify intolerance to the upright position." },
                    { 189, "Decrease in oxygen saturation to 93%", false, 53, "An oxygen saturation of 93% is still within the acceptable range and does not indicate intolerance to upright posture." },
                    { 190, "Postural hypotension", true, 54, "Chronic diarrhea causes fluid loss and electrolyte imbalance, often resulting in postural hypotension." },
                    { 191, "Hypertension", false, 54, "Due to the fluid loss from chronic diarrhea, hypertension is unlikely; hypotension is more common." },
                    { 192, "Bradycardia", false, 54, "Typically, the heart rate increases to compensate for fluid loss, making bradycardia unlikely." },
                    { 193, "Hypercapnia", false, 54, "Chronic diarrhea does not generally impact respiratory function, so hypercapnia is unlikely." },
                    { 194, "Pain sensation", false, 55, "Pain sensation is not as predictive of ulceration risk as pressure threshold." },
                    { 195, "Pressure threshold", true, 55, "Pressure thresholds using nylon filaments are highly predictive of ulceration risk. The 10-gram (Semmes-Weinstein 5.07) filament is commonly used for assessing protective sensation." },
                    { 196, "Two-point discrimination", false, 55, "Two-point discrimination is less predictive of ulceration risk compared to pressure threshold." },
                    { 197, "Temperature awareness", false, 55, "Temperature awareness is not as predictive of ulceration risk as pressure threshold." },
                    { 198, "Fruity smelling breath", false, 56, "Fruity smelling breath is a sign of hyperglycemia, not hypoglycemia." },
                    { 199, "Thirst, nausea, and vomiting", false, 56, "These are signs of hyperglycemia, not hypoglycemia." },
                    { 200, "Dry, crusty mucous membranes", false, 56, "Dry, crusty mucous membranes are a sign of hyperglycemia." },
                    { 201, "Difficulty speaking and concentrating", true, 56, "Mental state changes, including difficulty speaking and concentrating, are common with hypoglycemia." },
                    { 202, "60 mg/dL (3.3 mmol/L)", false, 57, "A blood glucose level of 60 mg/dL is hypoglycemic and unsafe for exercise." },
                    { 203, "175 mg/dL (9.7 mmol/L)", true, 57, "For safe exercise, blood glucose levels should be between 100 and 250 mg/dL." },
                    { 204, "260 mg/dL (14.4 mmol/L)", false, 57, "260 mg/dL is hyperglycemic and unsafe for exercise." },
                    { 205, "345 mg/dL (19.1 mmol/L)", false, 57, "345 mg/dL is hyperglycemic and unsafe for exercise." },
                    { 206, "Type 1 diabetes mellitus", false, 58, "Type 1 diabetes cannot be prevented with exercise, though it is a beneficial intervention." },
                    { 207, "Type 2 diabetes mellitus", true, 58, "Exercise improves glucose tolerance and reduces obesity, greatly benefiting individuals with type 2 diabetes." },
                    { 208, "Cushing syndrome", false, 58, "While exercise may help delay symptoms, patients with Cushing syndrome often have muscle wasting and limited tolerance for exercise." },
                    { 209, "Graves disease", false, 58, "Exercise does not prevent Graves disease, which is associated with hyperthyroidism." },
                    { 210, "No change in glucose tolerance or risk for cardiovascular disease", false, 59, "Exercise is expected to improve glucose tolerance and reduce cardiovascular disease risk." },
                    { 211, "No change in glucose tolerance, but a reduction in risk for cardiovascular disease", false, 59, "Improved glucose tolerance is also expected with exercise." },
                    { 212, "Improved glucose tolerance, but no change in risk for cardiovascular disease", false, 59, "A decrease in cardiovascular disease risk is also expected." },
                    { 213, "Improved glucose tolerance and a reduction in risk for cardiovascular disease", true, 59, "Aerobic exercise is shown to improve glucose tolerance and reduce cardiovascular risk in patients with type 2 diabetes." },
                    { 214, "Sensory testing of the upper extremities", false, 60, "Although sensory testing is important in an initial examination, impaired sensation is less likely to occur in a patient with right-sided heart failure." },
                    { 215, "Circumferential girth measurement of the lower extremities", true, 60, "Right-sided heart failure results in dependent edema. Circumferential girth measurements of the lower extremities are appropriate to monitor the severity of edema and aid in treatment planning." },
                    { 216, "Resisted manual muscle testing of all extremities", false, 60, "In cases of acute right-sided heart failure, resisted manual muscle testing is generally avoided until the heart failure is more stable." },
                    { 217, "Peripheral pulse testing of the lower extremities", false, 60, "Peripheral pulse testing is important in an initial examination, but with right-sided heart failure, edema in the lower extremities is more likely to be noted." },
                    { 218, "History of smoking, electrocardiographic changes, and parental/family history", false, 61, "Genetic factors and family history are not modifiable factors and cannot be addressed by the physical therapist's treatment plan. Electrocardiographic changes are also not addressable by the physical therapist." },
                    { 219, "Premorbid physical activity level, current physical condition, and motivation to exercise", true, 61, "Physical activity level, current physical condition, and motivation to exercise are modifiable factors. These factors can be addressed in the plan of care." },
                    { 220, "Lower extremity muscle strength, waist-to-chest ratio measurement, and endurance on treadmill test", false, 61, "Lower extremity muscle strength, waist-to-chest ratio measurement, and endurance on treadmill test are not relevant to progression of coronary artery disease and do not need to be included specifically in the plan of care." },
                    { 221, "Exercise history, daily caloric intake and dietary habits, and job responsibilities", false, 61, "Exercise history, daily caloric intake, and dietary habits are not addressable by a physical therapist's plan of care. It is more important to focus on factors within the therapist's scope, such as physical condition and motivation." },
                    { 222, "Cardiovascular", true, 62, "Midthoracic pain and upper extremity pain can be signs of angina in women. The undue weakness, fatigue, and nausea are concerning for a systemic origin of pain, particularly the cardiovascular system." },
                    { 223, "Gastrointestinal", false, 62, "Gastrointestinal-related pain would be more likely to refer to the abdomen and pelvis." },
                    { 224, "Musculoskeletal", false, 62, "Musculoskeletal pain is more likely to be associated with an activity that specifically engages that muscle or joint. Nausea is more indicative of a systemic source of pain." },
                    { 225, "Neuromuscular", false, 62, "Neuromuscular pain is more likely to be described as shooting and burning, than as aching." },
                    { 226, "Episodes of nonradiating chest pain each lasting 5-15 minutes", true, 63, "Stable angina generally occurs during physical effort and is characterized by substernal, usually nonradiating pain lasting between 5 and 15 minutes." },
                    { 227, "Episodes of severe chest pain each lasting longer than 15 minutes", false, 63, "In unstable angina, the episodes occur during physical exertion or psychological stress and are more frequent, the pain may be severe, and the duration of each event is usually greater than 15 minutes." },
                    { 228, "Chest pain occurring at rest and unaffected by exertion", false, 63, "Variant angina occurs while the individual is at rest, usually during waking and at the same hour of the day." },
                    { 229, "Chest pain accompanied by dysrhythmias", false, 63, "Dysrhythmias occur more commonly in individuals who have variant angina than in those with exertional angina (either stable or unstable)." },
                    { 230, "Increased pain upon chest-wall palpation.", false, 64, "Increased pain with chest-wall palpation is more indicative of a musculoskeletal origin of pain." },
                    { 231, "Increased pain with deep breathing.", false, 64, "Increased pain with deep breathing is more indicative of a pulmonary origin of pain." },
                    { 232, "Relief with nitroglycerin (Nitrostat).", true, 64, "Nitroglycerin (Nitrostat) is a common vasodilator that is prescribed for patients who have angina. A vasodilator will improve myocardial blood flow and help relieve ischemia and its manifestations." },
                    { 233, "Relief with antacid.", false, 64, "Relief of pain with antacid ingestion is more indicative of referred pain from peptic ulcer disease." },
                    { 234, "Greater benefits from cardiovascular exercise to be achieved at lower rather than at higher metabolic levels.", false, 65, "Even though heart rate and blood pressure would be lower due to the beta-blocker, the patient actually achieves the same metabolic levels during exercise. The patient will not achieve greater benefits from exercise at lower metabolic levels due to taking the medication." },
                    { 235, "Need to use measures other than heart rate to determine intensity of exercise.", true, 65, "A patient taking beta-blocking medication will experience a lower heart rate and blood pressure response during exercise, compared to a patient who is not taking this type of medication. Heart rate is lower than anticipated in patients taking beta-blockers, and using heart rate to monitor exercise intensity may not give an accurate indication of intensity. Another measure, such as the Borg scale (rating of perceived exertion), would be more beneficial." },
                    { 236, "Need for exercise training sessions to be more frequent but of shorter duration.", false, 65, "Even though heart rate and blood pressure would be lower due to the beta-blocker, the patient actually achieves the same metabolic levels during exercise. Therefore, altering the frequency or duration of exercise is unnecessary." },
                    { 237, "Need for longer warm-up periods and cool-down periods during exercise sessions.", false, 65, "The time for warm-up and cool-down exercises does not need to be altered." },
                    { 238, "Aerobic capacity and endurance associated with cardiovascular pump dysfunction.", false, 66, "Based on the walk test results, the heart rate and blood pressure have normal physiologic rise in response to exercise and would not indicate cardiovascular pump dysfunction." },
                    { 239, "Ventilation, respiration, and aerobic capacity associated with airway clearance dysfunction.", false, 66, "Although the walk test results do indicate impaired ventilation and respiration, there is no indication of airway clearance issues in the question." },
                    { 240, "Ventilation, respiration, aerobic capacity, and gas exchange associated with ventilatory pump dysfunction.", true, 66, "In general, a patient who has pulmonary fibrosis will have an impaired ventilatory pump. This is further evidenced by the exaggerated respiratory rate response and desaturation in the 6-minute walk test results." },
                    { 241, "Aerobic capacity and endurance associated with myocardial ischemia.", false, 66, "The normal electrocardiogram does not suggest myocardial ischemia." },
                    { 242, "VO2 max treadmill test.", false, 67, "The VO2 max treadmill test examines functional cardiovascular capacity, not necessarily endurance." },
                    { 243, "Two-step exercise test.", false, 67, "The two-step exercise test is the clinical standard for assessing exercise-induced ischemia. This test can reach VO2 max, which is not appropriate for the patient described." },
                    { 244, "Submaximal exercise test on a cycle ergometer.", false, 67, "The submaximal exercise test is used to estimate VO2 max and assesses aerobic power, not endurance." },
                    { 245, "6-minute walk test.", true, 67, "The 6-minute walk test is designed to measure endurance for acutely ill individuals with cardiovascular and pulmonary dysfunction." },
                    { 246, "Oxygen consumption.", false, 68, "An increase in oxygen uptake occurs in response to increased workload." },
                    { 247, "Heart rate.", false, 68, "Heart rate increases gradually in response to increased workload." },
                    { 248, "Systolic blood pressure.", false, 68, "Systolic blood pressure should increase with increasing workload by approximately 10 mm Hg per 1 metabolic equivalent (MET) increase." },
                    { 249, "Diastolic blood pressure.", true, 68, "Diastolic blood pressure should remain relatively constant during exercise, remaining within 10 mm Hg of the starting point." },
                    { 250, "Change in systolic blood pressure.", false, 69, "Systolic blood pressure is a useful measure of exercise intensity, but it is not easily assessed by the patient." },
                    { 251, "MET (metabolic equivalent) level.", false, 69, "A MET is a metabolic equivalent of an individual's resting metabolic rate. It varies based on individual factors and is generally too complex for patient self-assessment." },
                    { 252, "Rating of perceived exertion.", true, 69, "The rating of perceived exertion scale is subjective and fairly accurate for assessing ventilatory threshold." },
                    { 253, "Respiratory rate.", false, 69, "Respiratory rate is a useful measure of exercise intensity, but it is not easily assessed by the patient." },
                    { 254, "increase in gastric motility", false, 70, "Gastric motility decreases with aging." },
                    { 255, "increase in salivary secretion", false, 70, "Salivary secretion decreases with aging." },
                    { 256, "decrease in tooth decay", false, 70, "Tooth decay increases due to enamel and dentin wear and decreased saliva." },
                    { 257, "decrease in nutrient absorption", true, 70, "Aging includes a decrease in nutrient absorption." },
                    { 258, "increase in gastric motility", false, 71, "Gastric motility decreases with aging." },
                    { 259, "increase in salivary secretion", false, 71, "Salivary secretion decreases with aging." },
                    { 260, "decrease in tooth decay", false, 71, "Tooth decay increases due to enamel and dentin wear and decreased saliva." },
                    { 261, "decrease in nutrient absorption", true, 71, "Aging includes a decrease in nutrient absorption." },
                    { 262, "Patient should return to the previous level of function within 1 week.", true, 72, "A prognosis is the predicted optimal level of improvement in function reached in a certain time period. The patient's comorbidities are common in older adults, and with gait and balance training, the patient is expected to return to normal activities." },
                    { 263, "Patient will be independent with a walker on all surfaces in 3 weeks.", false, 72, "There is no mention of gait dysfunction in the question; assuming the patient needs a walker is inappropriate." },
                    { 264, "Patient will need to use a wheelchair at home to avoid falls.", false, 72, "The patient should be given an opportunity to ambulate safely before being considered for a wheelchair." },
                    { 265, "Patient should be transferred to a skilled nursing facility for safety.", false, 72, "The patient's workup is negative, and with gait and balance retraining, the patient should be able to resume normal activity at home." },
                    { 266, "Pancreatitis", false, 73, "Pancreatitis will typically be made worse by walking or lying in supine position." },
                    { 267, "Lumbar herniated nucleus pulposus", false, 73, "A herniated nucleus pulposus typically causes loss of lumbar motion, and the symptoms are relieved with lying supine." },
                    { 268, "Sacroiliac dysfunction", false, 73, "Sacroiliac dysfunction typically causes decreased hip or lumbar range of motion and is not affected by passing gas." },
                    { 269, "Crohn disease", true, 73, "Crohn disease can refer pain to the pelvic area and hip that is relieved by passing gas." },
                    { 270, "Fragile skin", false, 74, "Vitamin D is not primarily involved in maintaining skin integrity." },
                    { 271, "Excessive bleeding", false, 74, "Bleeding disorders are related to hematological disorders, not vitamin D deficiency." },
                    { 272, "Bone decalcification", true, 74, "Vitamin D is important for calcium absorption, synthesis, and transport, and bone decalcification can result from a deficiency." },
                    { 273, "Poor vision", false, 74, "Vitamin D is not primarily involved in maintaining proper vision." },
                    { 274, "Protein", false, 75, "Too much protein may lead to greater water needs; too little will prevent the development of a wound bed. Protein level does not have a direct effect on heart rate or blood pressure." },
                    { 275, "Water", true, 75, "Water aids in hydration of the wound site, and dehydration will result in elevated heart rate and decreased blood pressure." },
                    { 276, "Vitamin B", false, 75, "Vitamin B is critical in the rebuilding/remodeling stage, but it does not affect heart rate or blood pressure." },
                    { 277, "Carbohydrates", false, 75, "Carbohydrates are important for overall energy needs but do not directly affect heart rate or blood pressure." },
                    { 278, "Normal weight", false, 76, "Body mass index (BMI) for normal weight is 18.5-24.9." },
                    { 279, "Underweight", false, 76, "BMI for underweight is less than 18.5." },
                    { 280, "Overweight", true, 76, "The correct answer according to the BMI rating scale is overweight, which is indicated by a BMI of 25-29.9." },
                    { 281, "Obese", false, 76, "BMI for obese is more than 30." },
                    { 282, "active assistive range-of-motion exercise to the knee", true, 77, "In this stage of hemarthrosis, there is still some bleeding into the joint space, but it is not as extensive as during the acute phase. Therefore, the patient will benefit from range-of-motion exercise to prevent contracture. The patient may need active-assistive exercises, because there may still be pain or edema in the joint that prevents independent performance of range of motion." },
                    { 283, "instruction of the patient for weight-bearing to tolerance", false, 77, "The mechanical trauma of weight-bearing to tolerance at this stage may impinge on and damage the pathologic synovium within the joint." },
                    { 284, "gentle resistive range-of-motion exercise to the knee", false, 77, "Resistive range of motion is more appropriate when pain and swelling have subsided and bleeding is not occurring." },
                    { 285, "continuous immobilization of the knee in an extension splint", false, 77, "Continuous immobilization in the extended position will promote contracture in the edematous knee." },
                    { 286, "Stroke volume", false, 78, "Stroke volume is the amount of blood ejected from the left ventricle during each heartbeat and is not directly related to rate pressure product." },
                    { 287, "Cardiac output", false, 78, "Cardiac output is calculated by multiplying stroke volume by heart rate, but rate pressure product specifically relates to myocardial oxygen demand." },
                    { 288, "Pulse amplitude", false, 78, "Pulse amplitude refers to the quality of the pulse and is unrelated to rate pressure product." },
                    { 289, "Myocardial oxygen demand", true, 78, "Rate pressure product is calculated by multiplying heart rate by systolic blood pressure and is an indication of myocardial oxygen demand." },
                    { 290, "continue walking while the therapist monitors the patient's vital signs", false, 79, "Continuing to walk is inappropriate. Angina during exercise should result in termination of the activity." },
                    { 291, "continue walking at 50% slower speed while the therapist calls the physician", false, 79, "These are indications to terminate exercise and reassess vital signs. Continuing to walk at a lower intensity is inappropriate." },
                    { 292, "cease walking while the therapist reassesses the patient's vital signs", true, 79, "An episode of stable angina is an indication to terminate exercise testing and reassess vital signs." },
                    { 293, "cease walking while the therapist activates the emergency medical system", false, 79, "These symptoms do not constitute a medical emergency. It is more appropriate to reassess vitals and ask the patient to take nitroglycerin, if prescribed." },
                    { 294, "Deep vein thrombosis", false, 80, "A deep vein thrombosis typically causes unilateral leg swelling and pain, not bilateral." },
                    { 295, "Myocardial infarction", false, 80, "While myocardial infarction may cause shortness of breath, it does not typically cause bilateral swelling. Heart failure could result from a myocardial infarction." },
                    { 296, "Pulmonary embolism", false, 80, "A pulmonary embolism causes shortness of breath but is not typically associated with bilateral lower extremity swelling or pain." },
                    { 297, "Heart failure", true, 80, "Heart failure is characterized by symptoms like dyspnea, orthopnea, paroxysmal nocturnal dyspnea, and peripheral edema, all of which are present in this patient." },
                    { 298, "continue walking while the therapist monitors the patient's vital signs", false, 81, "Continuing to walk is inappropriate. Angina during exercise should result in termination of the activity." },
                    { 299, "continue walking at 50% slower speed while the therapist calls the physician", false, 81, "These are indications to terminate exercise and reassess vital signs. Continuing to walk at a lower intensity is inappropriate." },
                    { 300, "cease walking while the therapist reassesses the patient's vital signs", true, 81, "An episode of stable angina is an indication to terminate exercise testing and reassess vital signs." },
                    { 301, "cease walking while the therapist activates the emergency medical system", false, 81, "These symptoms do not constitute a medical emergency. It is more appropriate to reassess vitals and ask the patient to take nitroglycerin, if prescribed." },
                    { 302, "Anginal pain, insomnia, sudden weight gain, leg stiffness", false, 82, "Leg stiffness is not typically associated with exertional intolerance among patients undergoing cardiac rehabilitation." },
                    { 303, "Persistent dyspnea, dizziness, anginal pain, sudden weight gain", true, 82, "These are classic signs of exertional intolerance that should be emphasized during cardiac rehabilitation." },
                    { 304, "Persistent dyspnea, anginal pain, insomnia, weight loss", false, 82, "Weight loss is not a typical symptom of exertional intolerance. Angina and dyspnea are more critical signs." },
                    { 305, "Anginal pain, confusion, leg numbness, weight loss", false, 82, "Leg numbness, confusion, and weight loss are not signs associated with exertional intolerance." },
                    { 306, "Left ventricular ejection fraction of 55% and functional capacity of 3 metabolic equivalents (METs)", false, 83, "A functional capacity below 5-6 METs places a patient at moderate risk for morbidity and mortality." },
                    { 307, "Occasional premature ventricular contractions and functional capacity of 6 metabolic equivalents (METs)", true, 83, "A functional capacity of 6 METs or greater and occasional PVCs are associated with low risk for morbidity and mortality." },
                    { 308, "Exercise-induced ST segment depression of less than 2 mm and sustained supraventricular tachycardia", false, 83, "ST segment depression and SVT indicate ischemia and an arrhythmia, suggesting higher risk for cardiac events." },
                    { 309, "Exercise-induced ST segment depression of greater than 2 mm and left ventricular ejection fraction of 45%", false, 83, "An ejection fraction below 55% and ST depression >2mm indicate high risk for future cardiac events." },
                    { 310, "Sharp mid back pain that increases with lifting of heavy objects", false, 84, "This type of pain is typically related to musculoskeletal or nerve issues, not cardiac." },
                    { 311, "Increased pain with deep breathing", false, 84, "Pain with breathing is often associated with pulmonary or rib movement, not cardiac." },
                    { 312, "Feeling of heaviness in the chest", true, 84, "Heaviness in the chest may indicate a cardiovascular issue, warranting physician referral." },
                    { 313, "Persistent night pain", false, 84, "Night pain often suggests a musculoskeletal issue or potentially cancer, not primarily cardiac." },
                    { 314, "Decreased peripheral blood flow", true, 85, "Peripheral cyanosis is typically linked to decreased peripheral blood flow." },
                    { 315, "Deep vein thrombosis", false, 85, "DVT is usually accompanied by swelling and tenderness, not cyanosis alone." },
                    { 316, "Lymphedema", false, 85, "Lymphedema typically results in swelling rather than cyanosis." },
                    { 317, "Aneurysm", false, 85, "An aneurysm often presents as a pulsing mass, not peripheral cyanosis." },
                    { 318, "Gender", false, 86, "Gender-related hormonal changes are unlikely in a healthy male without cardiovascular symptoms." },
                    { 319, "Sedentary activity level", false, 86, "Sedentary lifestyle is not a primary cause of palpitations without other symptoms." },
                    { 320, "Excess caffeine intake", true, 86, "Excessive caffeine is a common, non-cardiac cause of palpitations in healthy individuals." },
                    { 321, "Cardiac abnormality", false, 86, "Cardiac-origin palpitations usually come with symptoms like dyspnea or light-headedness." },
                    { 322, "Dorsal foot, near the base of the first metatarsal", true, 87, "The dorsal pedal pulse, found near the base of the first metatarsal, is commonly used to assess circulation due to its distal location." },
                    { 323, "Lateral lower leg, just posterior to the fibular head", false, 87, "The popliteal pulse, not located in the lateral lower leg, is an alternative but less distal location." },
                    { 324, "Lateral ankle, just inferior to the lateral malleolus", false, 87, "The posterior tibial pulse is located at the medial, not lateral, ankle." },
                    { 325, "Plantar foot, just medial to the medial calcaneal tuberosity", false, 87, "The plantar surface does not have a pulse point typically used for assessing circulation in the lower extremity." },
                    { 326, "The individual has a hypotensive disorder.", false, 88, "Bradycardia in this case is more likely due to a training effect rather than hypotension." },
                    { 327, "The rate is secondary to an increased stroke volume.", true, 88, "Endurance training increases stroke volume, leading to a compensatory decrease in resting heart rate to maintain cardiac output." },
                    { 328, "The individual has an atrioventricular block.", false, 88, "The low heart rate is more consistent with a training effect, not a conduction block." },
                    { 329, "Endurance training has stimulated the sympathetic nervous system.", false, 88, "Endurance training actually increases parasympathetic activity and reduces sympathetic discharge, lowering the resting heart rate." },
                    { 330, "an increase in the heart rate.", false, 89, "Overstimulation of the carotid sinus decreases heart rate, not increases it." },
                    { 331, "a decrease in the heart rate.", true, 89, "Manual pressure on the carotid sinus can trigger a reflexive drop in heart rate and blood pressure." },
                    { 332, "an irregular heart rhythm.", false, 89, "The heart rate, not the rhythm, changes due to carotid sinus pressure." },
                    { 333, "an increase in blood pressure.", false, 89, "Carotid sinus stimulation decreases, not increases, blood pressure." },
                    { 334, "Initiate chest compressions.", false, 90, "While chest compressions are important, the first action is to activate the emergency response system before beginning compressions." },
                    { 335, "Find the nearest defibrillator.", false, 90, "Time to defibrillation is critical, but activating the emergency response system is the first priority to ensure help is on the way." },
                    { 336, "Initiate rescue breathing.", false, 90, "Rescue breathing is part of the CPR process, but activating the emergency response system is the necessary first step." },
                    { 337, "Activate the emergency response system", true, 90, "The first action is to activate emergency medical services to ensure timely defibrillation and additional support, then proceed with CPR as needed." },
                    { 338, "Chronic fatigue syndrome", false, 91, "Chronic fatigue syndrome is mainly characterized by fatigue rather than pain localized to the left upper quadrant, flank, and mid-back, which points to a different etiology." },
                    { 339, "Referred pain from the spleen", true, 91, "The spleen is located in the left upper abdominal quadrant, and its enlargement or trauma could cause referred pain in this region and explain the patient's symptoms." },
                    { 340, "Conversion disorder from emotional distress", false, 91, "Conversion disorder involves loss of function often linked to psychological conflict; however, this case does not involve any described functional loss." },
                    { 341, "Acute onset of bladder infection", false, 91, "Bladder infections typically present with lower abdominal pain and urinary symptoms, not pain localized to the left upper quadrant, flank, and mid-back." },
                    { 342, "Lymphedema", false, 92, "Lymphedema is associated with swelling but not typically with digital clubbing, which is more common in chronic hypoxic conditions." },
                    { 343, "Chronic obstructive pulmonary disease", true, 92, "Pulmonary diseases that affect oxygenation can cause digital clubbing; COPD is a predominant cause." },
                    { 344, "Chronic venous insufficiency", false, 92, "Chronic venous insufficiency is more often associated with leg swelling and stasis ulcers rather than digital clubbing." },
                    { 345, "Complex regional pain syndrome", false, 92, "CRPS is characterized by pain and trophic changes but does not typically include clubbing of the fingers." },
                    { 346, "Skin cancer", false, 93, "Skin cancer is not associated with nail clubbing." },
                    { 347, "Renal failure", false, 93, "Renal failure may cause specific nail changes but not clubbing, which is more indicative of pulmonary issues like lung cancer." },
                    { 348, "Lung cancer", true, 93, "Lung cancer and other conditions causing chronic hypoxia are strongly associated with severe clubbing of the nails." },
                    { 349, "Liver dysfunction", false, 93, "Liver dysfunction can cause specific nail changes (e.g., Beau lines, Terry nails) but is not associated with clubbing." },
                    { 350, "Delayed cardiovascular response upon rising from supine position", false, 94, "Early mobilization improves venous return and adaptation to positional changes, which should enhance rather than delay cardiovascular response." },
                    { 351, "Decreased heart rate response to exercise", true, 94, "With conditioning, the heart rate response to exercise is reduced as stroke volume and myocardial contractility increase." },
                    { 352, "Decreased respiratory rate in response to exercise", false, 94, "Early mobilization will improve respiratory function, but a reduction in heart rate response is more specific to cardiopulmonary conditioning." },
                    { 353, "Increased cardiovascular peripheral resistance", false, 94, "Cardiovascular resistance tends to decrease with training, improving blood vessel responsiveness and vascular reflexes." },
                    { 354, "Fatigue, shortness of breath, or wheezing", false, 95, "These are relative indications to stop a test, but they are not absolute contraindications." },
                    { 355, "A drop in systolic blood pressure of 10 mm Hg in the absence of ischemic changes", false, 95, "A drop in systolic blood pressure without ischemia is a relative indication, not an absolute indication, to stop the test." },
                    { 356, "A request to stop the test", true, 95, "The test should be immediately terminated if the patient requests it to be stopped." },
                    { 357, "A rise in diastolic blood pressure to 90 mm Hg", false, 95, "While elevated blood pressure is a concern, a rise to 90 mm Hg is not an absolute indication to stop the test." },
                    { 358, "Proceed with the usual low-level protocol, because mild angina is common this soon after a myocardial infarction.", false, 96, "Unstable angina warrants immediate medical attention rather than proceeding with exercise testing." },
                    { 359, "Defer testing the patient, because the symptoms suggest unstable angina after a myocardial infarction.", true, 96, "Unstable angina following a myocardial infarction requires immediate medical attention and testing should be deferred." },
                    { 360, "Perform the test at a lower-than-usual workload, because the symptoms suggest unstable angina after a myocardial infarction.", false, 96, "Any exercise with unstable angina is contraindicated and the patient should be evaluated immediately." },
                    { 361, "Defer testing the patient, because 5 days after a myocardial infarction is too soon to begin physical exertion.", false, 96, "Exercise testing is typically done before discharge after a myocardial infarction, provided there are no unstable symptoms." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_User_Likes_BlogId",
                table: "Blog_User_Likes",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_SubCategoryId",
                table: "Blogs",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubCategoryId",
                table: "Books",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubCategoryId",
                table: "Courses",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_CourseId",
                table: "Objectives",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_BlogId",
                table: "Questions",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubCategoryId",
                table: "Questions",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_CourseId",
                table: "Requirements",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTests_CategoryId",
                table: "StandardTests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTests_SubCategoryId",
                table: "StandardTests",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEnrolledCourses_CourseId",
                table: "UserEnrolledCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocalSubscribtions_UserId",
                table: "UserLocalSubscribtions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_UserId",
                table: "UserSubscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseId",
                table: "Videos",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Blog_User_Likes");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "platformData");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "UserEnrolledCourses");

            migrationBuilder.DropTable(
                name: "UserLocalSubscribtions");

            migrationBuilder.DropTable(
                name: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StandardTests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
