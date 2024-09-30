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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullmark = table.Column<int>(type: "int", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTests", x => x.Id);
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
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInhours = table.Column<float>(type: "real", nullable: false),
                    Preview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Courses_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
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
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    VideoNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertifiedHours = table.Column<int>(type: "int", nullable: false)
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
                    { "23978a1d-7823-4030-bd5d-ef7a0e6412a2", "df2d8409-ce61-4dac-ae75-b26fbbab27f2", "Student", "STUDENT" },
                    { "952625cb-623b-4f8e-a426-c9e14ffe41bc", "9e9ef764-d672-42d8-99ee-93c2410d8ae0", "Admin", "ADMIN" },
                    { "ea3203f7-8571-4e45-b109-e593235f3420", "df2d8409-ce61-4dac-ae75-b26fbbab27f2", "Instructor", "INSTRUCTOR" },
                    { "ea3206f7-8571-4e45-b209-e593236f3420", "df2d8409-cg61-4aac-ae65-b26fbbab77f2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a111a11-1111-1111-1111-111111111111", 0, "37c672cb-422e-499f-8d27-42299cf70286", "Ehab_Naser@example.com", true, "Ehab", null, "Naser", false, null, "EHAB_NASER@EXAMPLE.COM", "EHAB_NASER", "AQAAAAIAAYagAAAAENwuzliBQZa1AnhQXwkTz9IlgxRMXzHy0+Zhg4bMRrDuY90lFLr83TJXqrbInKZ+3g==", null, false, "208c8c86-25c9-405c-b67c-841dfe68bf7c", false, "Ehab_Naser" },
                    { "2b222b22-2222-2222-2222-222222222222", 0, "79cd15bc-43ac-459d-a853-24fdf90f5bc7", "Mohamed_Galal@example.com", true, "Mohamed", null, "Galal", false, null, "MOHAMED_GALAL@EXAMPLE.COM", "MOHAMED_GALAL", "AQAAAAIAAYagAAAAEBnHad0KD0ISI7O64Q6c3byUryTu7FJMQvQFxf8iFsZS4TSSIVv7WKIbiVjsWP28hA==", null, false, "84b5016e-cee7-4f64-a44a-c1e81cb51d86", false, "Mohamed_Galal" },
                    { "3c333c33-3333-3333-3333-333333333333", 0, "1af6c7c3-7718-4b28-962c-4647b391dca7", "Alaa_Test@example.com", true, "Alaa", null, "Test", false, null, "ALAA_TEST@EXAMPLE.COM", "ALAA_TEST", "AQAAAAIAAYagAAAAENO7qJBz6qTPw97dXZLAvRDR7gxHOs60ylV5aN/4SlUfC3YVdwbghmeWu+CoTUtzSw==", null, false, "d7421cae-4eb5-419c-b01a-012dca93760e", false, "Alaa_Test" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Anatomy" },
                    { 2, "Physiology" },
                    { 3, "Pharmacology" },
                    { 4, "Pathology" }
                });

            migrationBuilder.InsertData(
                table: "StandardTests",
                columns: new[] { "Id", "DurationInMinutes", "Fullmark", "Title" },
                values: new object[,]
                {
                    { 1, 60, 100, "Test1" },
                    { 2, 100, 150, "Test2" },
                    { 3, 200, 300, "Test3" }
                });

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
                table: "Questions",
                columns: new[] { "Id", "BlogId", "CourseId", "Description", "SubCategoryId", "TestId" },
                values: new object[,]
                {
                    { 16, null, null, "What is the primary function of red blood cells?", null, 1 },
                    { 17, null, null, "How does the immune system protect the body?", null, 1 },
                    { 18, null, null, "What are the stages of the cell cycle?", null, 2 },
                    { 19, null, null, "What is apoptosis?", null, 2 },
                    { 20, null, null, "What role does DNA play in inheritance?", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Human Anatomy" },
                    { 2, 1, "Comparative Anatomy" },
                    { 3, 2, "Cell Physiology" },
                    { 4, 2, "Systemic Physiology" },
                    { 5, 3, "Clinical Pharmacology" },
                    { 6, 3, "Pharmacokinetics" },
                    { 7, 4, "General Pathology" },
                    { 8, 4, "Systemic Pathology" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId", "Reason" },
                values: new object[,]
                {
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
                    { 60, "Fights diseases", false, 20, "DNA does not directly fight diseases; it contains the instructions for making proteins." }
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
                table: "Courses",
                columns: new[] { "Id", "DurationInhours", "InstructorId", "Preview", "Price", "SubCategoryId", "ThumbnailURL", "Title" },
                values: new object[,]
                {
                    { 1, 10f, "2b222b22-2222-2222-2222-222222222222", null, 1500m, 1, null, "physiology" },
                    { 2, 20f, "2b222b22-2222-2222-2222-222222222222", null, 1000m, 1, null, "anatomy" },
                    { 3, 30f, "3c333c33-3333-3333-3333-333333333333", null, 2500m, 1, null, "histology" }
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
                    { 5, null, 2, "What is osmosis?", null, null }
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
                    { 15, "Protein synthesis", false, 5, "Protein synthesis involves ribosomes, not the movement of water." }
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
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEnrolledCourses_CourseId",
                table: "UserEnrolledCourses",
                column: "CourseId");

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
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "UserEnrolledCourses");

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
