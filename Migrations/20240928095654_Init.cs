using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    CategoryId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id");
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
                    ThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { "1a111a11-1111-1111-1111-111111111111", 0, "a46769b7-e8ff-490a-b2e3-3e57776ec8f3", "Ehab_Naser@example.com", true, "Ehab", null, "Naser", false, null, "EHAB_NASER@EXAMPLE.COM", "EHAB_NASER", "AQAAAAIAAYagAAAAEElQrDPcq62rZhb8krXBamMVEFPCxh/k4RNlDfvDnNFfiCGcddlRW8TP+wext3CwCg==", null, false, "44b862f5-266f-4ca9-b816-d42abadcfc1c", false, "Ehab_Naser" },
                    { "2b222b22-2222-2222-2222-222222222222", 0, "d818d7bf-2f6f-42e7-9098-ead33c150677", "Mohamed_Galal@example.com", true, "Mohamed", null, "Galal", false, null, "MOHAMED_GALAL@EXAMPLE.COM", "MOHAMED_GALAL", "AQAAAAIAAYagAAAAECu2SV7nnxK04xmwRnwHJ2TGYyj6NHCrSgHqBWOtvDKOkvH/BLT1dtvydGnjRkEl3g==", null, false, "6282b736-4934-4fef-bd6a-de3a6ff04505", false, "Mohamed_Galal" },
                    { "3c333c33-3333-3333-3333-333333333333", 0, "c26304ef-3740-4c4a-8b9f-3176a2e0bf0d", "Alaa_Test@example.com", true, "Alaa", null, "Test", false, null, "ALAA_TEST@EXAMPLE.COM", "ALAA_TEST", "AQAAAAIAAYagAAAAEPU8yXGq3w2BRi7FgK8UazCSTS9uY4U4DWIaEZxkjO4hzZoXVjN1nSy6sDTX7R6BqA==", null, false, "e13a7907-0329-40f1-a490-1fc0b38dc390", false, "Alaa_Test" }
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
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 46, "To carry oxygen", true, 16 },
                    { 47, "To fight infections", false, 16 },
                    { 48, "To clot blood", false, 16 },
                    { 49, "By recognizing pathogens", true, 17 },
                    { 50, "By producing energy", false, 17 },
                    { 51, "By storing nutrients", false, 17 },
                    { 52, "Interphase, mitosis, cytokinesis", true, 18 },
                    { 53, "Prophase, metaphase, anaphase", false, 18 },
                    { 54, "Meiosis only", false, 18 },
                    { 55, "Programmed cell death", true, 19 },
                    { 56, "Cell growth", false, 19 },
                    { 57, "Cell division", false, 19 },
                    { 58, "Carries genetic information", true, 20 },
                    { 59, "Produces energy", false, 20 },
                    { 60, "Fights diseases", false, 20 }
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
                columns: new[] { "Id", "DurationInhours", "InstructorId", "Preview", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, 10f, "2b222b22-2222-2222-2222-222222222222", null, 1, "physiology" },
                    { 2, 20f, "2b222b22-2222-2222-2222-222222222222", null, 1, "anatomy" },
                    { 3, 30f, "3c333c33-3333-3333-3333-333333333333", null, 1, "histology" }
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
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 16, "Breaks down food", true, 6 },
                    { 17, "Circulates blood", false, 6 },
                    { 18, "Transports oxygen", false, 6 },
                    { 19, "Through the walls of the intestines", true, 7 },
                    { 20, "Via the bloodstream", false, 7 },
                    { 21, "By chewing", false, 7 },
                    { 22, "Mouth, esophagus, stomach", true, 8 },
                    { 23, "Brain, heart, lungs", false, 8 },
                    { 24, "Skin, muscles, bones", false, 8 },
                    { 25, "They speed up chemical reactions", true, 9 },
                    { 26, "They are absorbed", false, 9 },
                    { 27, "They break down food", false, 9 },
                    { 28, "The wave-like motion that moves food", true, 10 },
                    { 29, "The absorption of nutrients", false, 10 },
                    { 30, "The secretion of enzymes", false, 10 },
                    { 31, "Organs and systems", true, 11 },
                    { 32, "Cells only", false, 11 },
                    { 33, "Muscles only", false, 11 },
                    { 34, "By contracting and relaxing", true, 12 },
                    { 35, "By sending signals", false, 12 },
                    { 36, "By absorbing nutrients", false, 12 },
                    { 37, "To understand the human body", true, 13 },
                    { 38, "To pass exams", false, 13 },
                    { 39, "To perform surgeries", false, 13 },
                    { 40, "Nervous, muscular, skeletal", true, 14 },
                    { 41, "Respiratory, circulatory", false, 14 },
                    { 42, "Digestive, excretory", false, 14 },
                    { 43, "Controls body functions", true, 15 },
                    { 44, "Transports nutrients", false, 15 },
                    { 45, "Provides energy", false, 15 }
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
                columns: new[] { "Id", "CourseId", "Description", "Number", "ThumbnailURL", "Title", "videoURL" },
                values: new object[,]
                {
                    { 1, 1, null, 1, null, "new video", "https://www.youtube.com/watch?v=4oThHBo2-Gs" },
                    { 2, 2, null, 1, null, "old video", "https://www.youtube.com/watch?v=mgEAimOoyHk" },
                    { 3, 3, null, 1, null, "funny video", "https://www.youtube.com/watch?v=zhCKr62s12w" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Description", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Cell", true, 1 },
                    { 2, "Tissue", false, 1 },
                    { 3, "Organ", false, 1 },
                    { 4, "Mitochondria", true, 2 },
                    { 5, "Nucleus", false, 2 },
                    { 6, "Ribosome", false, 2 },
                    { 7, "Protein synthesis", true, 3 },
                    { 8, "Energy production", false, 3 },
                    { 9, "DNA replication", false, 3 },
                    { 10, "Protects the cell", true, 4 },
                    { 11, "Stores DNA", false, 4 },
                    { 12, "Produces energy", false, 4 },
                    { 13, "Movement of water", true, 5 },
                    { 14, "Transport of nutrients", false, 5 },
                    { 15, "Protein synthesis", false, 5 }
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
