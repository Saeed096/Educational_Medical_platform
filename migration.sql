Build started...
Build succeeded.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'38fa01ed-610f-4c55-ac53-3069e8281c8d', [PasswordHash] = N'AQAAAAIAAYagAAAAEAfx/X4E5M1hol1gTWLIuIk19MdG5eDbKRcqc8kI4OmJLjsdd/BDfv3NsNBV9vYWUA=='
WHERE [Id] = N'1a111a11-1111-1111-1111-111111111111';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'13735001-5a68-4bf2-9570-3e7d74402b64', [PasswordHash] = N'AQAAAAIAAYagAAAAEOopC71RhZx4M0hfITQC7PPEi1XS7k/6CQr+rbc2n1WNRN2uWI8N+Iy7MPOJL6tlLg=='
WHERE [Id] = N'2b222b22-2222-2222-2222-222222222222';
SELECT @@ROWCOUNT;

GO

UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'2c8643f1-7910-49e5-ac5d-d159f66724c4', [PasswordHash] = N'AQAAAAIAAYagAAAAEEjiaPlH7woEgksl+EuxOaSY0lBN4703yeoY6jwzbYoxvjfSBmfysqXjZoC1Jy7GdA=='
WHERE [Id] = N'3c333c33-3333-3333-3333-333333333333';
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241208202726_publish', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [IsSubscribedToPlatform] bit NOT NULL,
    [SubscriptionMethod] int NULL,
    [UserName] nvarchar(50) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [platformData] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] nvarchar(max) NULL,
    [ProductName] nvarchar(max) NULL,
    [ProductDescribtion] nvarchar(max) NULL,
    [PlanId] nvarchar(max) NULL,
    [PlanName] nvarchar(max) NULL,
    [PlanDescription] nvarchar(max) NULL,
    [PlanFixedPricePerMonth] decimal(10,2) NULL,
    [PlanSetupFee] decimal(10,2) NULL,
    [PlanTaxesPercentage] decimal(10,2) NULL,
    CONSTRAINT [PK_platformData] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id])
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [UserLocalSubscribtions] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [TransactionImageURL] nvarchar(max) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_UserLocalSubscribtions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserLocalSubscribtions_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [UserSubscriptions] (
    [Id] int NOT NULL IDENTITY,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [UserId] nvarchar(450) NOT NULL,
    [SubscriptionPlanId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_UserSubscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserSubscriptions_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [SubCategories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [CategoryId] int NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_SubCategories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id])
);
GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [LikesNumber] int NOT NULL,
    [ImageURL] nvarchar(max) NULL,
    [Title] nvarchar(50) NOT NULL,
    [Intro] nvarchar(2000) NULL,
    [Content] nvarchar(max) NOT NULL,
    [Conclusion] nvarchar(2000) NULL,
    [AuthorId] nvarchar(450) NOT NULL,
    [SubCategoryId] int NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Blogs_AspNetUsers_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Blogs_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]),
    CONSTRAINT [FK_Blogs_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategories] ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [PublisherName] nvarchar(max) NULL,
    [PublisherRole] nvarchar(max) NULL,
    [PublishDate] datetime2 NULL,
    [ThumbnailURL] nvarchar(max) NULL,
    [Url] nvarchar(max) NOT NULL,
    [SubCategoryId] int NULL,
    [CategoryId] int NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]),
    CONSTRAINT [FK_Books_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategories] ([Id])
);
GO

CREATE TABLE [Courses] (
    [Id] int NOT NULL IDENTITY,
    [PaypalProductId] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Price] decimal(10,2) NOT NULL,
    [ThumbnailURL] nvarchar(max) NULL,
    [DurationInhours] real NOT NULL,
    [Preview] nvarchar(max) NULL,
    [Type] int NOT NULL,
    [Status] int NOT NULL,
    [RejectedReason] nvarchar(max) NULL,
    [InstructorId] nvarchar(450) NOT NULL,
    [SubCategoryId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Courses_AspNetUsers_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Courses_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]),
    CONSTRAINT [FK_Courses_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategories] ([Id])
);
GO

CREATE TABLE [StandardTests] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Fullmark] int NOT NULL,
    [Price] int NOT NULL,
    [Type] int NOT NULL,
    [Difficulty] int NOT NULL,
    [DurationInMinutes] int NOT NULL,
    [SubCategoryId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_StandardTests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_StandardTests_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]),
    CONSTRAINT [FK_StandardTests_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategories] ([Id])
);
GO

CREATE TABLE [Blog_User_Likes] (
    [UserId] nvarchar(450) NOT NULL,
    [BlogId] int NOT NULL,
    CONSTRAINT [PK_Blog_User_Likes] PRIMARY KEY ([UserId], [BlogId]),
    CONSTRAINT [FK_Blog_User_Likes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Blog_User_Likes_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id])
);
GO

CREATE TABLE [Objectives] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [CourseId] int NOT NULL,
    CONSTRAINT [PK_Objectives] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Objectives_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id])
);
GO

CREATE TABLE [Requirements] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [CourseId] int NOT NULL,
    CONSTRAINT [PK_Requirements] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Requirements_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id])
);
GO

CREATE TABLE [UserEnrolledCourses] (
    [StudentId] nvarchar(450) NOT NULL,
    [CourseId] int NOT NULL,
    [Degree] real NULL,
    [CurrentVideoNumber] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [TransactionImageURL] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_UserEnrolledCourses] PRIMARY KEY ([StudentId], [CourseId]),
    CONSTRAINT [FK_UserEnrolledCourses_AspNetUsers_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_UserEnrolledCourses_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id])
);
GO

CREATE TABLE [Videos] (
    [Id] int NOT NULL IDENTITY,
    [Number] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [videoURL] nvarchar(max) NULL,
    [CourseId] int NOT NULL,
    CONSTRAINT [PK_Videos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Videos_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id])
);
GO

CREATE TABLE [Questions] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(800) NOT NULL,
    [TestId] int NULL,
    [SubCategoryId] int NULL,
    [CourseId] int NULL,
    [BlogId] int NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Questions_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]),
    CONSTRAINT [FK_Questions_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]),
    CONSTRAINT [FK_Questions_StandardTests_TestId] FOREIGN KEY ([TestId]) REFERENCES [StandardTests] ([Id]),
    CONSTRAINT [FK_Questions_SubCategories_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategories] ([Id])
);
GO

CREATE TABLE [Answers] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Reason] nvarchar(max) NOT NULL,
    [IsCorrect] bit NOT NULL,
    [QuestionId] int NOT NULL,
    CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'952625cb-623b-4f8e-a426-c9e14ffe41bc', N'9e9ef764-d672-42d8-99ee-93c2410d8ae0', N'Admin', N'ADMIN'),
(N'ea3206f7-8571-4e45-b209-e593236f3420', N'df2d8409-cg61-4aac-ae65-b26fbbab77f2', N'User', N'USER');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'ImageUrl', N'IsSubscribedToPlatform', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'SubscriptionMethod', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [FirstName], [ImageUrl], [IsSubscribedToPlatform], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [SubscriptionMethod], [TwoFactorEnabled], [UserName])
VALUES (N'1a111a11-1111-1111-1111-111111111111', 0, N'300dd0c4-8158-4690-b8d2-e55214c20e9e', N'Ehab_Naser@example.com', CAST(1 AS bit), N'Ehab', NULL, CAST(0 AS bit), N'Naser', CAST(0 AS bit), NULL, N'EHAB_NASER@EXAMPLE.COM', N'EHAB_NASER', N'AQAAAAIAAYagAAAAEHttV3DqoWV4hHUMKu4JERP7lS7Vqc3G7JPMP25CQNHnv58VDZX2PRdaLm5yZx8P4w==', N'011548726155', CAST(0 AS bit), N'9f9ef764-d632-42d2-99ee-93v2410d8ae0', NULL, CAST(0 AS bit), N'Ehab_Naser'),
(N'2b222b22-2222-2222-2222-222222222222', 0, N'402b359a-b5c7-4ce2-847b-80ccc4b63879', N'Abdallah_Saudie@business.example.com', CAST(1 AS bit), N'Abdallah', NULL, CAST(0 AS bit), N'Saudie', CAST(0 AS bit), NULL, N'ABDALLAH_SAUDIE@BUSINESS.EXAMPLE.COM', N'ABDALLAH_SAUDIE', N'AQAAAAIAAYagAAAAEJtthbABaALVDFS5sRhTMNsG/oif/LXMK7HgQYc8Q8G1PSXxSYjTpTFJkEPpM5x6iQ==', N'01054871566', CAST(0 AS bit), N'9f9ed761-d631-42d2-99ee-93v2420d8ae0', NULL, CAST(0 AS bit), N'Abdallah_Saudie'),
(N'3c333c33-3333-3333-3333-333333333333', 0, N'a3727d04-de66-4b1b-9d28-ad8997b9fe03', N'Alaa_Test@example.com', CAST(1 AS bit), N'Alaa', NULL, CAST(0 AS bit), N'Ahmed', CAST(0 AS bit), NULL, N'ALAA_AHMED@EXAMPLE.COM', N'ALAA_AHMED', N'AQAAAAIAAYagAAAAECs4ucO8QIWZbfOBpswu/lg/OjA/RXhbk3qSs2ZWXLeBPD4OQPuoEc3o6QUoAblmdw==', N'01225193482', CAST(0 AS bit), N'9f1ed761-a631-42dq-99ee-93z2420d8aeq', NULL, CAST(0 AS bit), N'Alaa_Ahmed');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'FirstName', N'ImageUrl', N'IsSubscribedToPlatform', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'SubscriptionMethod', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([Id], [Name], [Type])
VALUES (1, N'Anatomy Course', 0),
(2, N'Physiology Course', 0),
(3, N'Pharmacology Course', 0),
(4, N'Pathology Course', 0),
(5, N'Anatomy Book', 1),
(6, N'Physiology Book', 1),
(7, N'Pharmacology Book', 1),
(8, N'Pathology Book', 1),
(9, N'Anatomy Blog', 2),
(10, N'Physiology Blog', 2),
(11, N'Pharmacology Blog', 2),
(12, N'Pathology Blog', 2),
(13, N'Anatomy Exam', 3),
(14, N'Physiology Exam', 3),
(15, N'Pharmacology Exam', 3),
(16, N'Pathology Exam', 3),
(17, N'American physical therapy equation', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'CourseId', N'Description', N'SubCategoryId', N'TestId') AND [object_id] = OBJECT_ID(N'[Questions]'))
    SET IDENTITY_INSERT [Questions] ON;
INSERT INTO [Questions] ([Id], [BlogId], [CourseId], [Description], [SubCategoryId], [TestId])
VALUES (11, NULL, NULL, N'What are the key structures of the human body?', NULL, NULL),
(12, NULL, NULL, N'How does the muscular system work?', NULL, NULL),
(13, NULL, NULL, N'What is the importance of studying anatomy?', NULL, NULL),
(14, NULL, NULL, N'What are the different systems of the human body?', NULL, NULL),
(15, NULL, NULL, N'What role does the nervous system play in body functions?', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'CourseId', N'Description', N'SubCategoryId', N'TestId') AND [object_id] = OBJECT_ID(N'[Questions]'))
    SET IDENTITY_INSERT [Questions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'PlanDescription', N'PlanFixedPricePerMonth', N'PlanId', N'PlanName', N'PlanSetupFee', N'PlanTaxesPercentage', N'ProductDescribtion', N'ProductId', N'ProductName') AND [object_id] = OBJECT_ID(N'[platformData]'))
    SET IDENTITY_INSERT [platformData] ON;
INSERT INTO [platformData] ([Id], [PlanDescription], [PlanFixedPricePerMonth], [PlanId], [PlanName], [PlanSetupFee], [PlanTaxesPercentage], [ProductDescribtion], [ProductId], [ProductName])
VALUES (1, NULL, 20.0, NULL, NULL, 2.0, 10.0, NULL, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'PlanDescription', N'PlanFixedPricePerMonth', N'PlanId', N'PlanName', N'PlanSetupFee', N'PlanTaxesPercentage', N'ProductDescribtion', N'ProductId', N'ProductName') AND [object_id] = OBJECT_ID(N'[platformData]'))
    SET IDENTITY_INSERT [platformData] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsCorrect', N'QuestionId', N'Reason') AND [object_id] = OBJECT_ID(N'[Answers]'))
    SET IDENTITY_INSERT [Answers] ON;
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (31, N'Organs and systems', CAST(1 AS bit), 11, N'These are the correct components when discussing body structures.'),
(32, N'Cells only', CAST(0 AS bit), 11, N'Cells are part of organs and systems, not the only component.'),
(33, N'Muscles only', CAST(0 AS bit), 11, N'Muscles are just one type of tissue, which is part of organs and systems.'),
(34, N'By contracting and relaxing', CAST(1 AS bit), 12, N'Muscles work by contracting and relaxing to produce movement.'),
(35, N'By sending signals', CAST(0 AS bit), 12, N'While signaling is important, it does not describe how muscles function directly.'),
(36, N'By absorbing nutrients', CAST(0 AS bit), 12, N'Muscles do not absorb nutrients; this is a function of the digestive system.'),
(37, N'To understand the human body', CAST(1 AS bit), 13, N'Anatomy is studied to understand the structure and function of the body.'),
(38, N'To pass exams', CAST(0 AS bit), 13, N'While exams may test knowledge, they are not the purpose of studying anatomy.'),
(39, N'To perform surgeries', CAST(0 AS bit), 13, N'While anatomy knowledge is important for surgeries, it is not the sole purpose of the study.'),
(40, N'Nervous, muscular, skeletal', CAST(1 AS bit), 14, N'These are major body systems.'),
(41, N'Respiratory, circulatory', CAST(0 AS bit), 14, N'While important, they do not encompass all major systems.'),
(42, N'Digestive, excretory', CAST(0 AS bit), 14, N'These systems are essential but are not all-inclusive of body systems.'),
(43, N'Controls body functions', CAST(1 AS bit), 15, N'The nervous system regulates bodily functions.'),
(44, N'Transports nutrients', CAST(0 AS bit), 15, N'Nutrient transport is handled by the circulatory system.'),
(45, N'Provides energy', CAST(0 AS bit), 15, N'Energy provision is not a primary role of the nervous system.');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsCorrect', N'QuestionId', N'Reason') AND [object_id] = OBJECT_ID(N'[Answers]'))
    SET IDENTITY_INSERT [Answers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
VALUES (N'952625cb-623b-4f8e-a426-c9e14ffe41bc', N'1a111a11-1111-1111-1111-111111111111'),
(N'ea3206f7-8571-4e45-b209-e593236f3420', N'2b222b22-2222-2222-2222-222222222222'),
(N'ea3206f7-8571-4e45-b209-e593236f3420', N'3c333c33-3333-3333-3333-333333333333');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[SubCategories]'))
    SET IDENTITY_INSERT [SubCategories] ON;
INSERT INTO [SubCategories] ([Id], [CategoryId], [Name], [Type])
VALUES (1, 1, N'Human Anatomy', 0),
(2, 1, N'Comparative Anatomy', 0),
(3, 2, N'Cell Physiology', 0),
(4, 2, N'Systemic Physiology', 0),
(5, 3, N'Clinical Pharmacology', 0),
(6, 3, N'Pharmacokinetics', 0),
(7, 4, N'General Pathology', 0),
(8, 4, N'Systemic Pathology', 0),
(9, 5, N'Human Anatomy Book', 1),
(10, 5, N'Comparative Anatomy Book', 1),
(11, 6, N'Cell Physiology Book', 1),
(12, 6, N'Systemic Physiology Book', 1),
(13, 7, N'Clinical Pharmacology Book', 1),
(14, 7, N'Pharmacokinetics Book', 1),
(15, 8, N'General Pathology Book', 1),
(16, 8, N'Systemic Pathology Book', 1),
(17, 9, N'Human Anatomy Blog', 2),
(18, 9, N'Comparative Anatomy Blog', 2),
(19, 10, N'Cell Physiology Blog', 2),
(20, 10, N'Systemic Physiology Blog', 2),
(21, 11, N'Clinical Pharmacology Blog', 2),
(22, 11, N'Pharmacokinetics Blog', 2),
(23, 12, N'General Pathology Blog', 2),
(24, 12, N'Systemic Pathology Blog', 2),
(25, 13, N'Human Anatomy Exam', 3),
(26, 13, N'Comparative Anatomy Exam', 3),
(27, 14, N'Cell Physiology Exam', 3),
(28, 14, N'Systemic Physiology Exam', 3),
(29, 15, N'Clinical Pharmacology Exam', 3),
(30, 15, N'Pharmacokinetics Exam', 3),
(31, 16, N'General Pathology Exam', 3),
(32, 16, N'Systemic Pathology Exam', 3),
(33, 17, N'Surgery', 3),
(34, 17, N'Burns', 3),
(35, 17, N'Surgery & Burns', 3),
(36, 17, N'Cardiology & Chest', 3),
(37, 17, N'Cancer', 3),
(38, 17, N'Dermatology', 3),
(39, 17, N'Other systems', 3),
(40, 17, N'Basic science', 3),
(41, 17, N'Gynecology', 3),
(42, 17, N'Neurology', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[SubCategories]'))
    SET IDENTITY_INSERT [SubCategories] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'CourseId', N'Description', N'SubCategoryId', N'TestId') AND [object_id] = OBJECT_ID(N'[Questions]'))
    SET IDENTITY_INSERT [Questions] ON;
INSERT INTO [Questions] ([Id], [BlogId], [CourseId], [Description], [SubCategoryId], [TestId])
VALUES (6, NULL, NULL, N'What is the primary function of the digestive system?', 1, NULL),
(7, NULL, NULL, N'How does the body absorb nutrients?', 1, NULL),
(8, NULL, NULL, N'What are the main components of the digestive system?', 2, NULL),
(9, NULL, NULL, N'What is the role of enzymes in digestion?', 2, NULL),
(10, NULL, NULL, N'What is the process of peristalsis?', 3, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'CourseId', N'Description', N'SubCategoryId', N'TestId') AND [object_id] = OBJECT_ID(N'[Questions]'))
    SET IDENTITY_INSERT [Questions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'Difficulty', N'DurationInMinutes', N'Fullmark', N'Price', N'SubCategoryId', N'Title', N'Type') AND [object_id] = OBJECT_ID(N'[StandardTests]'))
    SET IDENTITY_INSERT [StandardTests] ON;
INSERT INTO [StandardTests] ([Id], [CategoryId], [Difficulty], [DurationInMinutes], [Fullmark], [Price], [SubCategoryId], [Title], [Type])
VALUES (1, 13, 0, 60, 100, 0, 25, N'Test1', 0),
(2, 14, 1, 100, 150, 100, 27, N'Test2', 1),
(3, 15, 2, 200, 300, 150, 29, N'Test3', 1),
(4, 17, 1, 30, 20, 150, 36, N'Cardiology & Chest 1', 0),
(5, 17, 1, 30, 20, 150, 36, N'Cardiology & Chest 2', 1),
(6, 17, 1, 30, 20, 150, 36, N'Cardiology & Chest 3', 1),
(7, 17, 1, 30, 20, 150, 36, N'Cardiology & Chest 4', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'Difficulty', N'DurationInMinutes', N'Fullmark', N'Price', N'SubCategoryId', N'Title', N'Type') AND [object_id] = OBJECT_ID(N'[StandardTests]'))
    SET IDENTITY_INSERT [StandardTests] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsCorrect', N'QuestionId', N'Reason') AND [object_id] = OBJECT_ID(N'[Answers]'))
    SET IDENTITY_INSERT [Answers] ON;
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (16, N'Breaks down food', CAST(1 AS bit), 6, N'The digestive system''s primary role is to break down food.'),
(17, N'Circulates blood', CAST(0 AS bit), 6, N'Blood circulation is the role of the circulatory system.'),
(18, N'Transports oxygen', CAST(0 AS bit), 6, N'Oxygen transport is handled by the respiratory system.'),
(19, N'Through the walls of the intestines', CAST(1 AS bit), 7, N'Nutrients are absorbed through the intestinal walls into the bloodstream.'),
(20, N'Via the bloodstream', CAST(0 AS bit), 7, N'The bloodstream transports nutrients after they are absorbed.'),
(21, N'By chewing', CAST(0 AS bit), 7, N'Chewing is part of the mechanical digestion process, not nutrient absorption.'),
(22, N'Mouth, esophagus, stomach', CAST(1 AS bit), 8, N'These are the primary organs involved in the digestive process.'),
(23, N'Brain, heart, lungs', CAST(0 AS bit), 8, N'These organs are not directly involved in digestion.'),
(24, N'Skin, muscles, bones', CAST(0 AS bit), 8, N'These are not part of the digestive system.'),
(25, N'They speed up chemical reactions', CAST(1 AS bit), 9, N'Enzymes are biological catalysts that accelerate chemical reactions.'),
(26, N'They are absorbed', CAST(0 AS bit), 9, N'Enzymes are not absorbed; they assist in reactions.'),
(27, N'They break down food', CAST(0 AS bit), 9, N'While enzymes help in breaking down food, they do not do so independently.'),
(28, N'The wave-like motion that moves food', CAST(1 AS bit), 10, N'Peristalsis is the wave-like motion that moves food through the digestive tract.'),
(29, N'The absorption of nutrients', CAST(0 AS bit), 10, N'Nutrient absorption occurs after food is moved through the digestive tract.'),
(30, N'The secretion of enzymes', CAST(0 AS bit), 10, N'Enzyme secretion assists in digestion but is not the motion that moves food.');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsCorrect', N'QuestionId', N'Reason') AND [object_id] = OBJECT_ID(N'[Answers]'))
    SET IDENTITY_INSERT [Answers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'CourseId', N'Description', N'SubCategoryId', N'TestId') AND [object_id] = OBJECT_ID(N'[Questions]'))
    SET IDENTITY_INSERT [Questions] ON;
INSERT INTO [Questions] ([Id], [BlogId], [CourseId], [Description], [SubCategoryId], [TestId])
VALUES (1, NULL, NULL, N'What is the basic unit of life?', NULL, 1),
(2, NULL, NULL, N'Which organelle is known as the powerhouse of the cell?', NULL, 1),
(3, NULL, NULL, N'What is the function of ribosomes?', NULL, 1),
(4, NULL, NULL, N'What is the role of the cell membrane?', NULL, 1),
(5, NULL, NULL, N'What is osmosis?', NULL, 1),
(16, NULL, NULL, N'What is the primary function of red blood cells?', NULL, 1),
(17, NULL, NULL, N'How does the immune system protect the body?', NULL, 1),
(18, NULL, NULL, N'What are the stages of the cell cycle?', NULL, 2),
(19, NULL, NULL, N'What is apoptosis?', NULL, 2),
(20, NULL, NULL, N'What role does DNA play in inheritance?', NULL, 2),
(21, NULL, NULL, N'To manually assess a patient''s lower extremity circulation, a physical therapist should palpate the patient''s peripheral pulse at which of the following locations?', 36, 4),
(22, NULL, NULL, N'A patient has difficulty palpating the carotid pulse during exercise. The patient should be instructed in alternate methods of self-monitoring, because repeated palpation is likely to result in:', 36, 4),
(23, NULL, NULL, N'A physical therapist is walking down an isolated hospital staircase. The therapist sees a middle-aged adult lying on the landing and determines that the adult is unresponsive. What should the therapist do NEXT?', 36, 4),
(24, NULL, NULL, N'A patient reports a 2-week history of left upper abdominal quadrant pain, left flank pain, and mid-back pain as a result of a motor vehicle accident. The patient also reports being fatigued and generally not feeling well. Which of the following differential diagnoses would MOST likely account for the patient''s symptoms?', 36, 4),
(25, NULL, NULL, N'Clubbing of the fingers is MOST associated with which of the following conditions?', 36, 4),
(26, NULL, NULL, N'During initial examination of a patient, a physical therapist notices severe clubbing of the patient''s fingernails. The therapist should further investigate for the presence of signs and symptoms associated with which of the following conditions?', 36, 4),
(27, NULL, NULL, N'What precautions should a physical therapist observe when working with a patient infected with methicillin-resistant Staphylococcus aureus?', 36, 4),
(28, NULL, NULL, N'When examining a patient with a history of alcohol abuse, a physical therapist notes that the patient demonstrates fine resting tremors and hyperactive reflexes. The patient reports frequent right upper quadrant pain. Which of the following additional signs is MOST likely to be present?', 36, 4),
(29, NULL, NULL, N'Which of the following signs and symptoms are MOST characteristic of a patient with metabolic syndrome?', 36, 4),
(30, NULL, NULL, N'During an examination, a physical therapist finds that a patient with chronic obstructive pulmonary disease has a weak wet cough. Which of the following techniques is MOST appropriate to help this patient clear secretions?', 36, 4),
(31, NULL, NULL, N'Increased residual volume is LEAST likely to be a finding in pulmonary function testing of a patient with which of the following conditions?', 36, 4),
(32, NULL, NULL, N'Which of the following combinations of measures is the MOST useful for determining changes in status in a patient who has chronic obstructive pulmonary disease and emphysema?', 36, 4),
(33, NULL, NULL, N'A patient with a recent total knee arthroplasty and a new diagnosis of hiatal hernia is concerned about the exercise program. Which of the following responses by the physical therapist would be MOST appropriate?', 36, 4),
(34, NULL, NULL, N'Which of the following hernias is MOST likely to cause shoulder pain?', 36, 4),
(35, NULL, NULL, N'A patient who has a hiatal hernia is receiving physical therapy. Which of the following exercises would MOST likely worsen the symptoms related to the hernia?', 36, 4),
(36, NULL, NULL, N'A patient reports multiple myalgias, fatigue, weight gain despite decreased food intake, and frequently feeling cold. The physical therapist should expect information from which of the following tests to be MOST helpful in managing the patient''s care?', 36, 4),
(37, NULL, NULL, N'Which of the following factors is considered to be a primary risk factor for atherosclerosis?', 36, 4),
(38, NULL, NULL, N'Which of the following endocrine glands regulates sexual development?', 36, 4),
(39, NULL, NULL, N'Which of the following is the MOST likely hormonal response in reaction to a stressful stimulus?', 36, 4),
(40, NULL, NULL, N'A patient with syndrome of inappropriate antidiuretic hormone secretion (SIADH) would MOST likely have complications involving which of the following systems?', 36, 4),
(41, NULL, NULL, N'A patient has aspiration precautions. Which of the following factors is MOST likely to affect the patient''s condition?', 36, 5),
(42, NULL, NULL, N'A physical therapist examines the output from a single lead electrocardiogram of a patient with atrioventricular heart block. The defining characteristic of first-degree atrioventricular heart block is:', 36, 5),
(43, NULL, NULL, N'A patient''s electrocardiogram shows a new ST-segment displacement from baseline and a sinus rhythm of 70 bpm. What is the MOST likely diagnosis?', 36, 5),
(44, NULL, NULL, N'A patient who is transported to the physical therapy department in a wheelchair reports severe, bilateral lower extremity pain. A purple discoloration of both feet is observed. The pain is relieved when the patient''s feet are raised just above the horizontal plane. These signs are MOST indicative of:', 36, 5),
(45, NULL, NULL, N'A patient with peripheral vascular disease comes to physical therapy for evaluation of leg pain that gets worse when walking. The patient will MOST likely also have:', 36, 5),
(46, NULL, NULL, N'A physical therapist reviews the medical record of a patient diagnosed with peripheral vascular disease prior to initiating treatment. Which objective finding would most severely limit the patient''s ability to participate in an exercise program?', 36, 5),
(47, NULL, NULL, N'A patient with the ulcer shown in the photograph is unable to perceive a 5.07-gauge (10-g) monofilament applied to the sole of the foot. Which of the following ulcer types is MOST likely present?', 36, 5),
(49, NULL, NULL, N'A patient who has lower extremity claudication is exercising to the point of symptom production. The skin on the distal aspect of the patient''s lower extremity is MOST likely to display which of the following findings?', 36, 5),
(50, NULL, NULL, N'A patient has an aching, cramping sensation in the posterior lower legs bilaterally that occurs during walking and is relieved by rest. The patient''s feet are pale and cool to the touch. The popliteal and pedal pulses are absent. The patient has full range of motion of the ankles and knee, and Normal (5/5) strength in the tibialis anterior and Good (4/5) strength in the gastrocnemius and soleus bilaterally. The MOST likely cause of this patient''s pain is:', 36, 5),
(51, NULL, NULL, N'A patient is in good health except for hypertension that is controlled with a beta-blocker. What is the BEST means of monitoring the patient''s cardiovascular tolerance?', 36, 5),
(52, NULL, NULL, N'A physical therapist working with a patient who is borderline hypotensive can minimize orthostatic hypotension by:', 36, 5),
(53, NULL, NULL, N'A physical therapist plans to use a tilt table for a patient who is having difficulty tolerating upright sitting position. The therapist should stop inclining the tilt table if the patient experiences which of the following signs and symptoms?', 36, 5);
INSERT INTO [Questions] ([Id], [BlogId], [CourseId], [Description], [SubCategoryId], [TestId])
VALUES (54, NULL, NULL, N'Which of the following signs is MOST likely to be present in a patient who has been experiencing chronic diarrhea?', 36, 5),
(55, NULL, NULL, N'A physical therapist is examining the feet of a patient with type 2 diabetes. Which of the following tests is BEST to determine the patient''s risk for developing foot ulceration?', 36, 5),
(56, NULL, NULL, N'A patient suspected of having hypoglycemia is MOST likely to show which of the following signs?', 36, 5),
(57, NULL, NULL, N'A physical therapist is monitoring the exercise of a patient who has type 1 diabetes. The patient''s blood glucose level would be BEST for safe exercise at which of the following values?', 36, 5),
(58, NULL, NULL, N'A physical therapist has been asked to speak to a group of senior citizens regarding the benefits of exercise. The therapist should instruct the group that exercise has the greatest effect on which of the following endocrine disorders?', 36, 5),
(59, NULL, NULL, N'A patient who has type 2 diabetes mellitus is starting an aerobic exercise program. Which of the following effects is MOST expected with continued adherence to the exercise program?', 36, 5),
(60, NULL, NULL, N'During an initial evaluation, which of the following tests is MOST likely to identify an abnormal finding for a patient who has acute right-sided heart failure?', 36, 5),
(61, NULL, NULL, N'An inpatient is referred to physical therapy after undergoing coronary artery bypass surgery 5 days ago. The patient''s medical history includes hypertension, hypercholesterolemia, and type 2 diabetes. Which of the following sets of factors should a physical therapist consider when developing a plan of care?', 36, 6),
(62, NULL, NULL, N'A woman has been walking on a treadmill for 10 minutes at 3.5 miles (5.6 km) per hour and 0آ° elevation when she reports a new onset of midthoracic back pain, aching in the right biceps muscle, fatigue, weakness, and nausea. Which system is MOST likely implicated?', 36, 6),
(63, NULL, NULL, N'Which of the following descriptions BEST characterizes stable angina?', 36, 6),
(64, NULL, NULL, N'A patient with chest pain from myocardial ischemia will MOST likely exhibit:', 36, 6),
(65, NULL, NULL, N'Prior to starting an exercise training program, a patient with cardiac problems who is taking beta-blocking medication should receive an explanation of the:', 36, 6),
(66, NULL, NULL, N'A patient with idiopathic pulmonary fibrosis completed a 6-minute walk test and demonstrates the following results: total walking distance of 1200 ft (366 m) in 6 minutes, heart rate of 82 to 110 bpm (pretest to posttest), blood pressure of 125/80 to 145/85 mm Hg (pretest to posttest), respiratory rate of 18 to 40 breaths/minute (pretest to posttest), and oxygen saturation of 98% to 92% (pretest to posttest); an electrocardiogram showed normal sinus rhythm throughout the test. Based on these results, the physical therapist should determine that the patient has impaired:', 36, 6),
(67, NULL, NULL, N'A 22-year-old patient is hospitalized awaiting a lung transplant due to cystic fibrosis. The patient''s physician is interested in an objective measure of the patient''s preoperative endurance. Which of the following tests is MOST appropriate for the physical therapist to administer to this patient?', 36, 6),
(68, NULL, NULL, N'A physical therapist is setting up an exercise program for a patient who is interested in improving cardiovascular fitness. When performing a submaximal cycle ergometer test the therapist should expect a relatively constant value for:', 36, 6),
(69, NULL, NULL, N'A patient, who has many risk factors for coronary artery disease and is presently not taking any cardiac medications, is interested in beginning an exercise program at a gym to improve cardiac health. The BEST self-assessment of exercise intensity during the exercise sessions of this patient is:', 36, 6),
(70, NULL, NULL, N'An important change in gastrointestinal function that occurs with aging is a(n):', 36, 6),
(71, NULL, NULL, N'An important change in gastrointestinal function that occurs with aging is a(n):', 36, 6),
(72, NULL, NULL, N'An active 75-year-old patient is admitted to the hospital following a fall at home. All workup is negative and comorbidities are limited to osteoarthritis, cataracts, and hypertension. Which of the following statements is the MOST accurate prognosis?', 36, 6),
(73, NULL, NULL, N'A 21-year-old female ballet dancer who has had an insidious onset of pelvic and hip pain is referred to physical therapy. During the history the patient reports relief of symptoms after passing gas. The patient exhibits full, pain-free hip and lumbar range of motion and normal lower extremity strength. The patient''s pain is unchanged by walking or lying supine. Which of the following causes of the pain is MOST likely?', 36, 6),
(74, NULL, NULL, N'The medical record indicates that a patient has a deficiency of vitamin D. The patient is MOST at risk for developing which of the following conditions?', 36, 6),
(75, NULL, NULL, N'A patient with a chronic skin ulcer displays decreased blood pressure and skin turgor, as well as a weak, rapid pulse. A physical therapist should suspect a decreased dietary intake of:', 36, 6),
(76, NULL, NULL, N'Which of the following terms BEST describes a patient who has a body mass of 27 kg/mآ²?', 36, 6),
(77, NULL, NULL, N'Treatment of a patient with hemophilia who has a subacute hemarthrosis of the knee should INITIALLY include:', 36, 6),
(78, NULL, NULL, N'Rate pressure product is MOST indicative of which of the following cardiac factors?', 36, 6),
(79, NULL, NULL, N'While walking on a treadmill during Phase II cardiac rehabilitation following coronary artery bypass surgery, a patient reports the new onset of chest pain and dyspnea. The physical therapist should instruct the patient to:', 36, 6),
(80, NULL, NULL, N'A home health patient who recently had a three-vessel coronary artery bypass graft describes experiencing bilateral lower extremity swelling, leg pain, and shortness of breath, especially when lying down. The patient MOST likely has which of the following diagnoses?', 36, 6),
(81, NULL, NULL, N'While walking on a treadmill during Phase II cardiac rehabilitation following coronary artery bypass surgery, a patient reports the new onset of chest pain and dyspnea. The physical therapist should instruct the patient to:', 36, 7),
(82, NULL, NULL, N'When providing patient education in cardiac rehabilitation, which of the following signs and symptoms of exertional intolerance should the physical therapist emphasize?', 36, 7),
(83, NULL, NULL, N'Which of the following findings are associated with the LOWEST risk for a subsequent cardiac event?', 36, 7),
(84, NULL, NULL, N'A patient is referred to physical therapy with thoracic spine pain. Which of the following data obtained from the patient''s history is MOST likely indicative of the presence of an underlying cardiac condition?', 36, 7),
(85, NULL, NULL, N'A physical therapist observes a bluish discoloration of the nail beds of the toes on the operative extremity. This finding is MOST often associated with which of the following conditions?', 36, 7),
(86, NULL, NULL, N'A nonathletic male patient reports occasional brief palpitations without pain, dizziness, or light-headedness. The MOST likely source of the palpitations is:', 36, 7),
(87, NULL, NULL, N'To manually assess a patient''s lower extremity circulation, a physical therapist should palpate the patient''s peripheral pulse at which of the following locations?', 36, 7),
(88, NULL, NULL, N'The resting heart rate of a 32-year-old runner is measured at 46 bpm. Which of the following explanations for this heart rate is MOST likely?', 36, 7),
(89, NULL, NULL, N'A patient has difficulty palpating the carotid pulse during exercise. The patient should be instructed in alternate methods of self-monitoring, because repeated palpation is likely to result in:', 36, 7),
(90, NULL, NULL, N'A physical therapist is walking down an isolated hospital staircase. The therapist sees a middle-aged adult lying on the landing and determines that the adult is unresponsive. What should the therapist do NEXT?', 36, 7),
(91, NULL, NULL, N'A patient reports a 2-week history of left upper abdominal quadrant pain, left flank pain, and mid-back pain as a result of a motor vehicle accident. The patient also reports being fatigued and generally not feeling well. Which of the following differential diagnoses would MOST likely account for the patient''s symptoms?', 36, 7),
(92, NULL, NULL, N'Clubbing of the fingers is MOST associated with which of the following conditions?', 36, 7),
(93, NULL, NULL, N'During initial examination of a patient, a physical therapist notices severe clubbing of the patient''s fingernails. The therapist should further investigate for the presence of signs and symptoms associated with which of the following conditions?', 36, 7),
(94, NULL, NULL, N'A physical therapist is providing supervised exercise to a patient who has been restricted to extended bed rest. After 2 weeks of intervention, which of the following measures would BEST reflect cardiopulmonary system improvement?', 36, 7),
(95, NULL, NULL, N'A physical therapist is administering a graded exercise test. Which of the following patient responses is an ABSOLUTE indication for terminating the exercise test?', 36, 7);
INSERT INTO [Questions] ([Id], [BlogId], [CourseId], [Description], [SubCategoryId], [TestId])
VALUES (96, NULL, NULL, N'A patient who had a myocardial infarction 5 days ago is referred for a low-level treadmill test. The patient reports having had several episodes of mild angina at rest, after meals, and during the night since being hospitalized. Which of the following actions is MOST appropriate for the physical therapist?', 36, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BlogId', N'CourseId', N'Description', N'SubCategoryId', N'TestId') AND [object_id] = OBJECT_ID(N'[Questions]'))
    SET IDENTITY_INSERT [Questions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsCorrect', N'QuestionId', N'Reason') AND [object_id] = OBJECT_ID(N'[Answers]'))
    SET IDENTITY_INSERT [Answers] ON;
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (1, N'Cell', CAST(1 AS bit), 1, N'Cells are the basic building blocks of life.'),
(2, N'Tissue', CAST(0 AS bit), 1, N'Tissues are made up of cells, but they are not the smallest unit of life.'),
(3, N'Organ', CAST(0 AS bit), 1, N'Organs are composed of tissues, which consist of cells.'),
(4, N'Mitochondria', CAST(1 AS bit), 2, N'Mitochondria are known as the powerhouse of the cell.'),
(5, N'Nucleus', CAST(0 AS bit), 2, N'The nucleus contains the cell''s genetic material, but does not produce energy.'),
(6, N'Ribosome', CAST(0 AS bit), 2, N'Ribosomes are responsible for protein synthesis, not energy production.'),
(7, N'Protein synthesis', CAST(1 AS bit), 3, N'This is the primary function of ribosomes in the cell.'),
(8, N'Energy production', CAST(0 AS bit), 3, N'Energy production occurs in the mitochondria, not during protein synthesis.'),
(9, N'DNA replication', CAST(0 AS bit), 3, N'DNA replication is a separate process from protein synthesis.'),
(10, N'Protects the cell', CAST(1 AS bit), 4, N'The cell membrane protects the cell from its environment.'),
(11, N'Stores DNA', CAST(0 AS bit), 4, N'DNA is stored in the nucleus, not the cell membrane.'),
(12, N'Produces energy', CAST(0 AS bit), 4, N'Energy production occurs in mitochondria, not the cell membrane.'),
(13, N'Movement of water', CAST(1 AS bit), 5, N'Osmosis is the movement of water across a membrane.'),
(14, N'Transport of nutrients', CAST(0 AS bit), 5, N'Nutrient transport occurs via active and passive transport mechanisms, not osmosis.'),
(15, N'Protein synthesis', CAST(0 AS bit), 5, N'Protein synthesis involves ribosomes, not the movement of water.'),
(46, N'To carry oxygen', CAST(1 AS bit), 16, N'Hemoglobin in red blood cells carries oxygen.'),
(47, N'To fight infections', CAST(0 AS bit), 16, N'Fighting infections is primarily the role of the immune system.'),
(48, N'To clot blood', CAST(0 AS bit), 16, N'Blood clotting is done by platelets and certain plasma proteins.'),
(49, N'By recognizing pathogens', CAST(1 AS bit), 17, N'The immune system identifies and targets pathogens.'),
(50, N'By producing energy', CAST(0 AS bit), 17, N'Energy production is not a function of the immune system.'),
(51, N'By storing nutrients', CAST(0 AS bit), 17, N'Nutrient storage is a function of the liver and other organs.'),
(52, N'Interphase, mitosis, cytokinesis', CAST(1 AS bit), 18, N'These are the stages of the cell cycle.'),
(53, N'Prophase, metaphase, anaphase', CAST(0 AS bit), 18, N'These terms refer to stages of mitosis, not the entire cell cycle.'),
(54, N'Meiosis only', CAST(0 AS bit), 18, N'Meiosis is a specific type of cell division, separate from the cell cycle.'),
(55, N'Programmed cell death', CAST(1 AS bit), 19, N'Apoptosis is the process of programmed cell death.'),
(56, N'Cell growth', CAST(0 AS bit), 19, N'Cell growth is a separate process from apoptosis.'),
(57, N'Cell division', CAST(0 AS bit), 19, N'Cell division is the process of replicating cells, distinct from programmed cell death.'),
(58, N'Carries genetic information', CAST(1 AS bit), 20, N'DNA is the molecule that carries genetic information.'),
(59, N'Produces energy', CAST(0 AS bit), 20, N'Energy production is not a role of DNA.'),
(60, N'Fights diseases', CAST(0 AS bit), 20, N'DNA does not directly fight diseases; it contains the instructions for making proteins.'),
(61, N'Dorsal foot, near the base of the first metatarsal', CAST(1 AS bit), 21, N'. The therapist should palpate the dorsal pedal pulse, which is found on the dorsal aspect of the foot near the base of the first metatarsal. The dorsalis pedis pulse is often used to assess a patient''s circulation because of its distal location on the lower extremity. (pp. 1101-1102)'),
(62, N'Lateral lower leg, just posterior to the fibular head', CAST(0 AS bit), 21, N'The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The popliteal pulse may also be palpated, but it is located posterior to the knee, not in the lateral leg. (p. 979)'),
(63, N'Lateral ankle, just inferior to the lateral malleolus', CAST(0 AS bit), 21, N'The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The posterior tibial pulse may also be palpated, but it is located at the medial ankle just posterior to the medial malleolus, not the lateral ankle. (p. 1102)'),
(64, N'Plantar foot, just medial to the medial calcaneal tuberosity', CAST(0 AS bit), 21, N'The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The pulse would be palpated on the dorsal surface of the foot, not the plantar surface. The plantar foot does not possess a pulse site used in lower extremity circulation assessment. (p. 1102)'),
(65, N'an increase in the heart rate.', CAST(0 AS bit), 22, N'Heart rate is expected to decrease, not increase when the carotid sinus is overstimulated.'),
(66, N'a decrease in the heart rate.', CAST(1 AS bit), 22, N'Manual pressure on the carotid sinus can cause a reflexive drop in heart rate, blood pressure, or both.'),
(67, N'an irregular heart rhythm.', CAST(0 AS bit), 22, N'Heart rate, not rhythm, is expected to change due to manual pressure on the carotid sinus.'),
(68, N'an increase in blood pressure.', CAST(0 AS bit), 22, N'Blood pressure is expected to decrease, not increase, due to pressure on the carotid sinus.'),
(69, N'Initiate chest compressions.', CAST(0 AS bit), 23, N'When an adult is found unresponsive, the first step is to activate emergency medical services and then begin chest compressions.'),
(70, N'Find the nearest defibrillator.', CAST(0 AS bit), 23, N'In the adult population, the most important factor for survival typically is time to defibrillation; therefore, it is most important to activate the emergency response system first. The proper sequence after that is to initiate chest compressions and then rescue breaths.'),
(71, N'Initiate rescue breathing.', CAST(0 AS bit), 23, N'Emergency medical services should be activated first. Then chest compressions should be initiated followed by rescue breaths.'),
(72, N'Activate the emergency response system', CAST(1 AS bit), 23, N'Emergency medical services should be activated first, due to the need (typically) for defibrillation in the adult.');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (73, N'Chronic fatigue syndrome', CAST(0 AS bit), 24, N'The diagnostic criteria for chronic fatigue syndrome are similar to those for fibromyalgia syndrome (FMS) with the hallmark feature being fatigue (versus pain in FMS). This option does not address specifically the left upper abdominal quadrant pain, left flank pain, and mid-back pain. (p. 460)'),
(74, N'Referred pain from the spleen', CAST(1 AS bit), 24, N'The spleen is located in the upper left abdominal quadrant. Enlargement of the spleen may be associated with the etiology and symptoms noted in the stem. (pp. 214-215)'),
(75, N'Conversion disorder from emotional distress', CAST(0 AS bit), 24, N'A conversion disorder is defined as a condition that presents as an alteration or loss of a physical function suggestive of a physical disorder, with often an underlying psychological conflict or need. The stem does not describe a loss of function. (p. 145)'),
(76, N'Acute onset of bladder infection', CAST(0 AS bit), 24, N'Lower abdominal pain and a strong urge to urinate are characteristics of a bladder infection. These symptoms are not described in the stem. (p. 628)'),
(77, N'Lymphedema', CAST(0 AS bit), 25, N'Lymphedema is not commonly associated with digital clubbing. While lymphedema is associated with chronic swelling of the extremities, chronic hypoxia is not commonly observed.'),
(78, N'Chronic obstructive pulmonary disease', CAST(1 AS bit), 25, N'Conditions that chronically interfere with tissue perfusion and nutrition may cause clubbing. Pulmonary disease is the most predominant cause of digital clubbing and is present in 75% to 85% of the cases in which clubbing is noted.'),
(79, N'Chronic venous insufficiency', CAST(0 AS bit), 25, N'Chronic venous insufficiency is not commonly associated with digital clubbing. Hemosiderin staining, lower extremity swelling, and stasis ulcers are more characteristic of venous insufficiency.'),
(80, N'Complex regional pain syndrome', CAST(0 AS bit), 25, N'Digital clubbing is not commonly associated with complex regional pain syndrome. Abnormal pain and trophic changes are characteristic of complex regional pain syndrome.'),
(81, N'Skin cancer', CAST(0 AS bit), 26, N'Nail clubbing is not associated with skin cancer.'),
(82, N'Renal failure', CAST(0 AS bit), 26, N'The nails of patients who have renal failure may appear to have short transverse lines across the nail (Mees lines) or a brownish distal one-third end of the nail (half-and-half nails), but not clubbing.'),
(83, N'Lung cancer', CAST(1 AS bit), 26, N'Severe clubbing of the nails is an abnormality associated with lung cancer and chronic hypoxia.'),
(84, N'Liver dysfunction', CAST(0 AS bit), 26, N'Liver dysfunction may result in nails with transverse depressions (Beau lines) or a nail bed that is white and extends two-thirds of the length of the nail (Terry nails).'),
(85, N'Airborne', CAST(0 AS bit), 27, N'Methicillin-resistant Staphylococcus aureus is not spread through the air; it is spread by contact.'),
(86, N'Sterile', CAST(0 AS bit), 27, N'Sterile precautions or techniques are not necessary for the physical therapist to use with a patient infected with methicillin-resistant Staphylococcus aureus.'),
(87, N'Droplet', CAST(0 AS bit), 27, N'Methicillin-resistant Staphylococcus aureus is not spread through droplets; it is spread by contact.'),
(88, N'Contact', CAST(1 AS bit), 27, N'Methicillin-resistant Staphylococcus aureus is spread by contact.'),
(89, N'Jaundice', CAST(1 AS bit), 28, N'With a history of alcohol abuse and the presence of fine resting tremors and right upper quadrant pain, the patient is presenting a history and signs and symptoms consistent with liver disease. Jaundice is a skin change associated with disease of the hepatic system. (Goodman, p. 363)'),
(90, N'Hyperhidrosis', CAST(0 AS bit), 28, N'Hyperhidrosis, or excessive sweating, can be present with several conditions, such as endocrine disorders, but is not associated with liver disease (Taber''s, p. 1164).'),
(91, N'Hypotension', CAST(0 AS bit), 28, N'Hypotension is not listed as a sign of liver disorders (Goodman, p. 363).'),
(92, N'Nocturnal cough', CAST(0 AS bit), 28, N'A nocturnal cough can be associated with rheumatic fever, but is not characteristic of liver disease (Goodman, p. 260).'),
(93, N'Confused mental state, muscular weakness, and presence of nausea', CAST(0 AS bit), 29, N'Confused mental state, weakness, and nausea are signs and symptoms of metabolic alkalosis (p. 435).'),
(94, N'Large waist circumference, high triglyceride values, and high blood pressure', CAST(1 AS bit), 29, N'Metabolic syndrome consists of signs and symptoms that are actually risk factors and are strongly linked to type 2 diabetes, cardiovascular disease, and stroke. Metabolic syndrome is characterized by abdominal obesity (waist size > 40 in (101.6 cm), high triglycerides levels, high low-density lipids and low high-density lipids cholesterol values, and elevated blood pressure (> 130/85 mm Hg). (p. 435)'),
(95, N'Headache, fatigue, and muscular twitching', CAST(0 AS bit), 29, N'Headache, fatigue, and muscular twitching are signs and symptoms of metabolic acidosis (p. 436).'),
(96, N'Respiratory rate of 15 breaths/minute, pulse rate of 60 bpm, and body temperature of 96.5آ°F (35.9آ°C)', CAST(0 AS bit), 29, N'A respiratory rate of 15 breaths/min, a heart rate of 60 bpm, and body temperature of 96.5آ°F (35.9آ°C) are considered normal for older adults (pp. 161, 163, 170).'),
(97, N'Abdominal thrusts', CAST(0 AS bit), 30, N'Abdominal thrusts or Heimlich-type assistance is primarily used in patients with low neuromuscular tone or flaccid abdominal muscles (Frownfelter, p. 343).'),
(98, N'Postural drainage', CAST(0 AS bit), 30, N'Postural drainage facilitates drainage of secretions to the level of the segmental bronchus only. In addition, a cough is needed to clear secretions. (Hillegass, p. 541)'),
(99, N'Huffing', CAST(1 AS bit), 30, N'Huffing helps stabilize collapsible airways present with chronic obstructive pulmonary disease (Hillegass, p. 545; Frownfelter, p. 321).'),
(100, N'Manual or mechanical percussion', CAST(0 AS bit), 30, N'Percussion helps mobilize secretions from the periphery of the lungs; however, it does not improve the strength of the patient''s cough (Hillegass, pp. 543-544).'),
(101, N'Atelectasis', CAST(1 AS bit), 31, N'Atelectasis is more of a restrictive issue and would not lead to an increase in residual volume. Restrictive lung disease is associated with a decreased residual volume.'),
(102, N'Bronchiectasis', CAST(0 AS bit), 31, N'Bronchiectasis is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume.'),
(103, N'Chronic bronchitis', CAST(0 AS bit), 31, N'Chronic bronchitis is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume.'),
(104, N'Emphysema', CAST(0 AS bit), 31, N'Emphysema is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume.'),
(105, N'Vital capacity, functional residual capacity, and total lung capacity', CAST(0 AS bit), 32, N'Vital capacity, functional residual capacity, and total lung capacity are important measurements in the diagnosis of pulmonary disease but have minimal value for the staging of obstructive pulmonary disease (p. 196).'),
(106, N'Forced inspiratory volume in 1 second and the ratio of forced inspiratory volume in 1 second to forced vital capacity', CAST(0 AS bit), 32, N'Forced inspiratory volume in 1 second is not a test performed during pulmonary function tests. The main issue in chronic obstructive pulmonary disease is forced expiration, and this would not be a useful measure in assessing disease progression. (pp. 196, 350)'),
(107, N'Tidal volume and the ratio of tidal volume to total lung capacity', CAST(0 AS bit), 32, N'The tidal volume and the tidal volume/total lung capacity ratio are important in the determination of a patient''s current ventilation capacity but do not factor into the staging of chronic obstructive pulmonary disease (p. 196).'),
(108, N'Forced expiratory volume in 1 second and the ratio of forced expiratory volume in 1 second to forced vital capacity', CAST(1 AS bit), 32, N'Forced expiratory volume in 1 second and the ratio of forced expiratory volume in 1 second to forced vital capacity ratio are the most useful measurements in determining the progression of obstructive pulmonary disease and are part of the Global Initiative for Chronic Obstructive Lung Disease (GOLD) classification system (p. 196).'),
(109, N'Supine exercises are best for patients with a hiatal hernia.', CAST(0 AS bit), 33, N'Supine position can cause the lower esophagus and stomach to be pulled into the thorax, thus increasing symptoms or discomfort. Although not contraindicated, these exercises would not be best. (p. 1429)'),
(110, N'Exercise is contraindicated for patients with a hiatal hernia.', CAST(0 AS bit), 33, N'Exercise can help with some of the risk factors for hernia, including obesity/weight control (p. 1430).'),
(111, N'There are no restrictions on exercise for patients with a hiatal hernia.', CAST(0 AS bit), 33, N'The physical therapist should educate the patient on the challenges of supine exercise, recumbent exercises, exercises that involve bending, and exercises that increase abdominal pressure, exacerbating symptoms (pp. 1429-1430).'),
(112, N'The Valsalva maneuver should be avoided during exercise.', CAST(1 AS bit), 33, N'Patients who have a hiatal hernia should avoid the Valsalva maneuver. The Valsalva maneuver increases intraabdominal pressure, which can worsen the hernia (pp. 1429-1430).'),
(113, N'Femoral', CAST(0 AS bit), 34, N'A hiatal hernia would most likely be associated with shoulder pain. A femoral hernia will cause pain in the lateral pelvic wall (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616).'),
(114, N'Hiatal', CAST(1 AS bit), 34, N'A hiatal hernia would most likely be associated with shoulder pain. An inguinal hernia will cause groin pain, and an umbilical hernia would most likely cause pain around the umbilical ring in the mid to lower abdomen (Goodman, Pathology, pp. 868, 898-900; Goodman, Differential Diagnosis, pp. 615-616).');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (115, N'Inguinal', CAST(0 AS bit), 34, N'A hiatal hernia would most likely be associated with shoulder pain. An inguinal hernia will cause groin pain (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616).'),
(116, N'Umbilical', CAST(0 AS bit), 34, N'A hiatal hernia would most likely be associated with shoulder pain. An umbilical hernia would most likely cause pain around the umbilical ring in the mid to lower abdomen. (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616).'),
(117, N'Wall sits', CAST(0 AS bit), 35, N'Wall sits are performed in an upright position and would not exacerbate a hiatal hernia.'),
(118, N'Overhead press', CAST(0 AS bit), 35, N'An overhead press is typically performed in seated, semireclined, or standing position and would not exacerbate a hiatal hernia.'),
(119, N'Bilateral leg lifts', CAST(1 AS bit), 35, N'Individuals who have a hiatal hernia should avoid supine position and avoid the Valsalva maneuver. Bilateral leg lifts must be performed in supine position and require strong contractions of the stomach muscles, encouraging the Valsalva maneuver, which would worsen the hiatal hernia.'),
(120, N'Hamstring stretch', CAST(0 AS bit), 35, N'Hamstring stretching can be modified to be done in a position other than supine to avoid exacerbating a hiatal hernia.'),
(121, N'Rheumatoid factor', CAST(0 AS bit), 36, N'Rheumatoid factor is appropriate for determining the presence of rheumatoid arthritis or other inflammatory conditions. A patient who has rheumatoid arthritis would be more likely to report arthralgias than myalgias. (p. 452)'),
(122, N'C-reactive protein', CAST(0 AS bit), 36, N'The patient is describing symptoms of hypothyroidism. C-reactive protein is a nonspecific indicator of inflammation or infection. It wouldn''t provide the most pertinent information with this diagnosis. (pp. 248, 465)'),
(123, N'Fasting blood glucose level', CAST(0 AS bit), 36, N'Fasting blood glucose levels determine the amount of sugar (glucose) in the blood. This is an appropriate test for diabetes. Fatigue and weight loss are associated with diabetes; however, polyuria and polydipsia are often reported. The patient''s report of myalgias and impaired thermoregulation is more consistent with hypothyroidism. (pp. 425-426)'),
(124, N'Thyroid stimulating hormone level', CAST(1 AS bit), 36, N'The patient is describing symptoms of hypothyroidism. When hypothyroidism is present, the blood levels of thyroid hormones can be measured directly and are decreased. The main tool for the detection of thyroid disease is the measurement of thyroid stimulating hormone. (pp. 417, 420)'),
(125, N'Stress', CAST(0 AS bit), 37, N'Stress is a secondary risk factor.'),
(126, N'Obesity', CAST(0 AS bit), 37, N'Obesity is a secondary risk factor.'),
(127, N'Cigarette smoking', CAST(1 AS bit), 37, N'High blood pressure, cigarette smoking, and hyperlipidemia are direct or primary risk factors for atherosclerosis.'),
(128, N'Sedentary lifestyle', CAST(0 AS bit), 37, N'Activity level is a secondary risk factor.'),
(129, N'Parathyroid', CAST(0 AS bit), 38, N'The parathyroid gland is responsible for calcium and phosphorus metabolism and bone calcification. It does not play a role in sexual development.'),
(130, N'Thyroid', CAST(0 AS bit), 38, N'Secretion of hormones via the thyroid gland is regulated by the pituitary gland. The thyroid secretes hormones that control metabolism and protein synthesis. It also influences calcium and phosphorus metabolism. The thyroid gland does not play a role in sexual development.'),
(131, N'Adrenal', CAST(0 AS bit), 38, N'Hormone secretion by the adrenal glands is regulated by the pituitary gland. The adrenal gland does secrete hormones responsible for secondary sexual characteristics. However, it is primarily involved in fluid/electrolyte balance and metabolism.'),
(132, N'Pituitary', CAST(1 AS bit), 38, N'The pituitary gland serves as a master gland and regulates the secretion of many hormones. The anterior pituitary glands regulate sexual development via release of gonadotropins. Gonadotropins regulate secretion of male and female hormones.'),
(133, N'Release of epinephrine by the adrenal gland', CAST(1 AS bit), 39, N'The sympathetic system is aroused during the stress response and causes the medulla of the adrenal gland to release catecholamines, such as epinephrine, norepinephrine, and dopamine, into the bloodstream. (p. 475)'),
(134, N'Suppression of cortisol by the adrenal gland', CAST(0 AS bit), 39, N'Cortisol is a catecholamine that is increased during stress. (p. 475)'),
(135, N'Release of adrenalin by the hypothalamus', CAST(0 AS bit), 39, N'Adrenalin is increased with stress, but it is produced by the adrenal medulla. (p. 475)'),
(136, N'Suppression of growth hormone by the pituitary', CAST(0 AS bit), 39, N'Growth hormone may be increased as a response to stress. (p. 476)'),
(137, N'Neuromuscular', CAST(0 AS bit), 40, N'Syndrome of inappropriate antidiuretic hormone secretion results in fluid volume excess. Fluid loss would be more likely to result in neuromuscular symptoms, such as tetany or tingling. (p. 211)'),
(138, N'Integumentary', CAST(0 AS bit), 40, N'The skin may be warm or cool if edema is present, but there should be no concern with skin integrity in this condition (p. 211).'),
(139, N'Cardiovascular', CAST(1 AS bit), 40, N'Syndrome of inappropriate antidiuretic hormone results in fluid volume excess, so it may cause hypertension and arrhythmias, which require monitoring as activity levels change. Also, the physical therapist may observe distended neck veins or a visible jugular pulse. (pp. 211, 482-483)'),
(140, N'Musculoskeletal', CAST(0 AS bit), 40, N'Syndrome of inappropriate antidiuretic hormone secretion results in fluid volume excess. Fluid loss would be more likely to result in musculoskeletal symptoms, such as weakness. (p. 211)'),
(141, N'Liquids are aspirated more easily than solids.', CAST(1 AS bit), 41, N'Dysphagia can lead to aspiration. Dysphagia can be assessed at bedside. Aspiration is more likely to occur with thin liquids. Therefore, treatment is to thicken the liquids or use thicker solutions and then progress to thinner liquids as the patient''s swallowing function improves. (McCance, p. 1428)'),
(142, N'Solids are aspirated more easily than liquids.', CAST(0 AS bit), 41, N'Aspiration is more likely to occur with thin liquids (McCance, p. 1428).'),
(143, N'Cold food is easier to swallow than warm food.', CAST(0 AS bit), 41, N'Moist, warm food is more easily swallowed (McCance, p. 1428).'),
(144, N'Hyperextension of the neck facilitates swallowing.', CAST(0 AS bit), 41, N'To facilitate swallowing, posture should be aligned with the chin tucked (Cifu, p. 66).'),
(145, N'Heightened T wave', CAST(0 AS bit), 42, N''),
(146, N'Prolonged PR interval', CAST(1 AS bit), 42, N'Atrioventricular blocks are caused by an abnormal delay or failure of conduction through the AV node or the atrioventricular bundle. The defining characteristic of first-degree atrioventricular heart block is a prolonged PR interval. (Brannon 212)'),
(147, N'Bizarre QRS complex', CAST(0 AS bit), 42, N''),
(148, N'Shortened ST segment', CAST(0 AS bit), 42, N''),
(149, N'Bradycardia', CAST(0 AS bit), 43, N'Bradycardia is defined as a heart rate below 60 bpm (pp. 314-315).'),
(150, N'Anxiety reaction', CAST(0 AS bit), 43, N'Anxiety reactions typically present with an increased heart rate (pp. 315-316).'),
(151, N'Acute myocardial infarction', CAST(1 AS bit), 43, N'Acute myocardial infarction is associated with either ST elevation or ST depression (pp. 285, 331).'),
(152, N'Congestive heart failure', CAST(0 AS bit), 43, N'Congestive heart failure is not usually associated with ST elevation.'),
(153, N'arterial insufficiency.', CAST(0 AS bit), 44, N'With arterial insufficiency, elevation increases ischemia and, therefore, pain.'),
(154, N'intermittent claudication.', CAST(0 AS bit), 44, N'Intermittent claudication is associated with metabolic demands exceeding the capability of the vascular system to supply adequate blood flow and manifests as pain during lower extremity exercise.'),
(155, N'venous insufficiency.', CAST(1 AS bit), 44, N'With venous insufficiency, placing the limb in a dependent position increases swelling and, therefore, possibly, pain.'),
(156, N'a psychosomatic episode.', CAST(0 AS bit), 44, N'An objective sign, such as purple discoloration, rules out a psychosomatic episode.');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (157, N'relief of pain with the legs elevated.', CAST(0 AS bit), 45, N'The patient most likely has intermittent claudication caused by arterial insufficiency. Elevating the legs in the presence of arterial insufficiency decreases blood flow, which increases pain.'),
(158, N'purple or brown pigmentation of the skin on the legs.', CAST(0 AS bit), 45, N'Purple or brown pigmentation of the skin on the legs is associated with venous insufficiency, not arterial insufficiency.'),
(159, N'relief of pain with the legs in the dependent position.', CAST(1 AS bit), 45, N'Placing the patient''s legs in the dependent position facilitates blood flow and reduces pain.'),
(160, N'a positive Homans sign.', CAST(0 AS bit), 45, N'Pain with exercise is indicative of intermittent claudication, not deep vein thrombosis, which is associated with a positive Homans sign.'),
(161, N'signs of resting claudication', CAST(1 AS bit), 46, N'Peripheral vascular disease refers to a condition involving the arterial, venous, or lymphatic system that results in compromised circulation to the extremities. Resting claudication is typically considered a contraindication to active exercise in patients with peripheral vascular disease. (Kisner 631)'),
(162, N'decreased peripheral pulses', CAST(0 AS bit), 46, N''),
(163, N'cool skin', CAST(0 AS bit), 46, N''),
(164, N'blood pressure: 165/90 mm Hg', CAST(0 AS bit), 46, N''),
(165, N'Pressure', CAST(0 AS bit), 47, N'A pressure ulcer is caused by unrelieved external pressure against the skin over a bony prominence. The wound in the picture is not a pressure injury.'),
(166, N'Neuropathic', CAST(1 AS bit), 47, N'The ulcer is located on the plantar surface of the foot with decreased protective sensation, which is associated with peripheral neuropathies. Therefore, it is a neuropathic ulcer.'),
(167, N'Arterial insufficiency', CAST(0 AS bit), 47, N'Ischemic ulcers have sharply demarcated borders and are usually located over the toes or dorsum of the foot. The ulcer in question is inconsistent with arterial wounds.'),
(168, N'Venous insufficiency', CAST(0 AS bit), 47, N'Venous insufficiency ulcers are typically located proximal to the medial malleolus and do not present with decreased protective sensation.'),
(170, N'Edema', CAST(0 AS bit), 49, N'Edema would be expected for a patient who has venous insufficiency, not intermittent claudication associated with arterial insufficiency.'),
(171, N'Hyperhidrosis', CAST(0 AS bit), 49, N'Hyperhidrosis is not expected in the lower extremities of a patient experiencing intermittent claudication.'),
(172, N'Hyperemia', CAST(0 AS bit), 49, N'Pallor, not hyperemia, would be expected due to arterial insufficiency, which shunts blood away from the area.'),
(173, N'Pallor', CAST(1 AS bit), 49, N'Pallor is caused by shunting of blood to the exercising muscle and away from the distal aspect of the extremity.'),
(174, N'lower extremity venous stasis.', CAST(0 AS bit), 50, N'Venous insufficiency does not result in pale or cool skin and absent pulses.'),
(175, N'deep-vein thrombosis.', CAST(0 AS bit), 50, N'Deep vein thrombosis is generally painful but does not present with intermittent claudication symptoms.'),
(176, N'chronic arterial occlusion.', CAST(1 AS bit), 50, N'The scenario describes intermittent claudication characteristic of arterial occlusion, with pale, cool skin and absent pulses.'),
(177, N'weakness of the plantar flexors.', CAST(0 AS bit), 50, N'Weakness of the plantar flexors does not cause the pain or associated changes in skin temperature and pulse.'),
(178, N'Electrocardiogram', CAST(0 AS bit), 51, N'Beta-blockers decrease both resting and exercise heart rates, making an electrocardiogram unreliable. Although it can detect arrhythmias, it is not the best option for assessing tolerance.'),
(179, N'Rating of perceived exertion', CAST(1 AS bit), 51, N'Due to the blunted heart rate response from beta-blockers, using the rating of perceived exertion scale is recommended as it provides a better assessment of cardiovascular tolerance.'),
(180, N'Pulse oximetry', CAST(0 AS bit), 51, N'While pulse oximetry monitors oxygen saturation, the rating of perceived exertion scale is preferred over pulse oximetry for assessing cardiovascular tolerance in patients on beta-blockers.'),
(181, N'Heart rate', CAST(0 AS bit), 51, N'Beta-blockers lower both resting and exercise heart rates, making heart rate monitoring unreliable.'),
(182, N'loosening tight legwear and footwear before gait training.', CAST(0 AS bit), 52, N'Tight stockings are actually recommended to reduce orthostatic hypotension, rather than loosening legwear.'),
(183, N'elevating the head during a hypotensive episode.', CAST(0 AS bit), 52, N'The head of the bed should be lowered during a hypotensive episode to help improve blood pressure.'),
(184, N'instructing the patient to perform ankle pumps before standing.', CAST(1 AS bit), 52, N'Ankle pumps help reduce symptoms of orthostatic hypotension by promoting circulation before standing.'),
(185, N'encouraging the patient to consume meals prior to therapy.', CAST(0 AS bit), 52, N'Consuming meals before therapy does not significantly affect orthostatic hypotension.'),
(186, N'Decrease in diastolic blood pressure of 15 mm Hg', CAST(1 AS bit), 53, N'An excessive drop in blood pressure suggests the patient is not tolerating the upright position well, indicating the need to stop inclining.'),
(187, N'Increase in systolic blood pressure of 10 mm Hg', CAST(0 AS bit), 53, N'A slight increase in systolic blood pressure is normal and does not indicate intolerance to the upright position.'),
(188, N'Increase in heart rate of 15 bpm', CAST(0 AS bit), 53, N'An increase in heart rate is expected and does not signify intolerance to the upright position.'),
(189, N'Decrease in oxygen saturation to 93%', CAST(0 AS bit), 53, N'An oxygen saturation of 93% is still within the acceptable range and does not indicate intolerance to upright posture.'),
(190, N'Postural hypotension', CAST(1 AS bit), 54, N'Chronic diarrhea causes fluid loss and electrolyte imbalance, often resulting in postural hypotension.'),
(191, N'Hypertension', CAST(0 AS bit), 54, N'Due to the fluid loss from chronic diarrhea, hypertension is unlikely; hypotension is more common.'),
(192, N'Bradycardia', CAST(0 AS bit), 54, N'Typically, the heart rate increases to compensate for fluid loss, making bradycardia unlikely.'),
(193, N'Hypercapnia', CAST(0 AS bit), 54, N'Chronic diarrhea does not generally impact respiratory function, so hypercapnia is unlikely.'),
(194, N'Pain sensation', CAST(0 AS bit), 55, N'Pain sensation is not as predictive of ulceration risk as pressure threshold.'),
(195, N'Pressure threshold', CAST(1 AS bit), 55, N'Pressure thresholds using nylon filaments are highly predictive of ulceration risk. The 10-gram (Semmes-Weinstein 5.07) filament is commonly used for assessing protective sensation.'),
(196, N'Two-point discrimination', CAST(0 AS bit), 55, N'Two-point discrimination is less predictive of ulceration risk compared to pressure threshold.'),
(197, N'Temperature awareness', CAST(0 AS bit), 55, N'Temperature awareness is not as predictive of ulceration risk as pressure threshold.'),
(198, N'Fruity smelling breath', CAST(0 AS bit), 56, N'Fruity smelling breath is a sign of hyperglycemia, not hypoglycemia.'),
(199, N'Thirst, nausea, and vomiting', CAST(0 AS bit), 56, N'These are signs of hyperglycemia, not hypoglycemia.');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (200, N'Dry, crusty mucous membranes', CAST(0 AS bit), 56, N'Dry, crusty mucous membranes are a sign of hyperglycemia.'),
(201, N'Difficulty speaking and concentrating', CAST(1 AS bit), 56, N'Mental state changes, including difficulty speaking and concentrating, are common with hypoglycemia.'),
(202, N'60 mg/dL (3.3 mmol/L)', CAST(0 AS bit), 57, N'A blood glucose level of 60 mg/dL is hypoglycemic and unsafe for exercise.'),
(203, N'175 mg/dL (9.7 mmol/L)', CAST(1 AS bit), 57, N'For safe exercise, blood glucose levels should be between 100 and 250 mg/dL.'),
(204, N'260 mg/dL (14.4 mmol/L)', CAST(0 AS bit), 57, N'260 mg/dL is hyperglycemic and unsafe for exercise.'),
(205, N'345 mg/dL (19.1 mmol/L)', CAST(0 AS bit), 57, N'345 mg/dL is hyperglycemic and unsafe for exercise.'),
(206, N'Type 1 diabetes mellitus', CAST(0 AS bit), 58, N'Type 1 diabetes cannot be prevented with exercise, though it is a beneficial intervention.'),
(207, N'Type 2 diabetes mellitus', CAST(1 AS bit), 58, N'Exercise improves glucose tolerance and reduces obesity, greatly benefiting individuals with type 2 diabetes.'),
(208, N'Cushing syndrome', CAST(0 AS bit), 58, N'While exercise may help delay symptoms, patients with Cushing syndrome often have muscle wasting and limited tolerance for exercise.'),
(209, N'Graves disease', CAST(0 AS bit), 58, N'Exercise does not prevent Graves disease, which is associated with hyperthyroidism.'),
(210, N'No change in glucose tolerance or risk for cardiovascular disease', CAST(0 AS bit), 59, N'Exercise is expected to improve glucose tolerance and reduce cardiovascular disease risk.'),
(211, N'No change in glucose tolerance, but a reduction in risk for cardiovascular disease', CAST(0 AS bit), 59, N'Improved glucose tolerance is also expected with exercise.'),
(212, N'Improved glucose tolerance, but no change in risk for cardiovascular disease', CAST(0 AS bit), 59, N'A decrease in cardiovascular disease risk is also expected.'),
(213, N'Improved glucose tolerance and a reduction in risk for cardiovascular disease', CAST(1 AS bit), 59, N'Aerobic exercise is shown to improve glucose tolerance and reduce cardiovascular risk in patients with type 2 diabetes.'),
(214, N'Sensory testing of the upper extremities', CAST(0 AS bit), 60, N'Although sensory testing is important in an initial examination, impaired sensation is less likely to occur in a patient with right-sided heart failure.'),
(215, N'Circumferential girth measurement of the lower extremities', CAST(1 AS bit), 60, N'Right-sided heart failure results in dependent edema. Circumferential girth measurements of the lower extremities are appropriate to monitor the severity of edema and aid in treatment planning.'),
(216, N'Resisted manual muscle testing of all extremities', CAST(0 AS bit), 60, N'In cases of acute right-sided heart failure, resisted manual muscle testing is generally avoided until the heart failure is more stable.'),
(217, N'Peripheral pulse testing of the lower extremities', CAST(0 AS bit), 60, N'Peripheral pulse testing is important in an initial examination, but with right-sided heart failure, edema in the lower extremities is more likely to be noted.'),
(218, N'History of smoking, electrocardiographic changes, and parental/family history', CAST(0 AS bit), 61, N'Genetic factors and family history are not modifiable factors and cannot be addressed by the physical therapist''s treatment plan. Electrocardiographic changes are also not addressable by the physical therapist.'),
(219, N'Premorbid physical activity level, current physical condition, and motivation to exercise', CAST(1 AS bit), 61, N'Physical activity level, current physical condition, and motivation to exercise are modifiable factors. These factors can be addressed in the plan of care.'),
(220, N'Lower extremity muscle strength, waist-to-chest ratio measurement, and endurance on treadmill test', CAST(0 AS bit), 61, N'Lower extremity muscle strength, waist-to-chest ratio measurement, and endurance on treadmill test are not relevant to progression of coronary artery disease and do not need to be included specifically in the plan of care.'),
(221, N'Exercise history, daily caloric intake and dietary habits, and job responsibilities', CAST(0 AS bit), 61, N'Exercise history, daily caloric intake, and dietary habits are not addressable by a physical therapist''s plan of care. It is more important to focus on factors within the therapist''s scope, such as physical condition and motivation.'),
(222, N'Cardiovascular', CAST(1 AS bit), 62, N'Midthoracic pain and upper extremity pain can be signs of angina in women. The undue weakness, fatigue, and nausea are concerning for a systemic origin of pain, particularly the cardiovascular system.'),
(223, N'Gastrointestinal', CAST(0 AS bit), 62, N'Gastrointestinal-related pain would be more likely to refer to the abdomen and pelvis.'),
(224, N'Musculoskeletal', CAST(0 AS bit), 62, N'Musculoskeletal pain is more likely to be associated with an activity that specifically engages that muscle or joint. Nausea is more indicative of a systemic source of pain.'),
(225, N'Neuromuscular', CAST(0 AS bit), 62, N'Neuromuscular pain is more likely to be described as shooting and burning, than as aching.'),
(226, N'Episodes of nonradiating chest pain each lasting 5-15 minutes', CAST(1 AS bit), 63, N'Stable angina generally occurs during physical effort and is characterized by substernal, usually nonradiating pain lasting between 5 and 15 minutes.'),
(227, N'Episodes of severe chest pain each lasting longer than 15 minutes', CAST(0 AS bit), 63, N'In unstable angina, the episodes occur during physical exertion or psychological stress and are more frequent, the pain may be severe, and the duration of each event is usually greater than 15 minutes.'),
(228, N'Chest pain occurring at rest and unaffected by exertion', CAST(0 AS bit), 63, N'Variant angina occurs while the individual is at rest, usually during waking and at the same hour of the day.'),
(229, N'Chest pain accompanied by dysrhythmias', CAST(0 AS bit), 63, N'Dysrhythmias occur more commonly in individuals who have variant angina than in those with exertional angina (either stable or unstable).'),
(230, N'Increased pain upon chest-wall palpation.', CAST(0 AS bit), 64, N'Increased pain with chest-wall palpation is more indicative of a musculoskeletal origin of pain.'),
(231, N'Increased pain with deep breathing.', CAST(0 AS bit), 64, N'Increased pain with deep breathing is more indicative of a pulmonary origin of pain.'),
(232, N'Relief with nitroglycerin (Nitrostat).', CAST(1 AS bit), 64, N'Nitroglycerin (Nitrostat) is a common vasodilator that is prescribed for patients who have angina. A vasodilator will improve myocardial blood flow and help relieve ischemia and its manifestations.'),
(233, N'Relief with antacid.', CAST(0 AS bit), 64, N'Relief of pain with antacid ingestion is more indicative of referred pain from peptic ulcer disease.'),
(234, N'Greater benefits from cardiovascular exercise to be achieved at lower rather than at higher metabolic levels.', CAST(0 AS bit), 65, N'Even though heart rate and blood pressure would be lower due to the beta-blocker, the patient actually achieves the same metabolic levels during exercise. The patient will not achieve greater benefits from exercise at lower metabolic levels due to taking the medication.'),
(235, N'Need to use measures other than heart rate to determine intensity of exercise.', CAST(1 AS bit), 65, N'A patient taking beta-blocking medication will experience a lower heart rate and blood pressure response during exercise, compared to a patient who is not taking this type of medication. Heart rate is lower than anticipated in patients taking beta-blockers, and using heart rate to monitor exercise intensity may not give an accurate indication of intensity. Another measure, such as the Borg scale (rating of perceived exertion), would be more beneficial.'),
(236, N'Need for exercise training sessions to be more frequent but of shorter duration.', CAST(0 AS bit), 65, N'Even though heart rate and blood pressure would be lower due to the beta-blocker, the patient actually achieves the same metabolic levels during exercise. Therefore, altering the frequency or duration of exercise is unnecessary.'),
(237, N'Need for longer warm-up periods and cool-down periods during exercise sessions.', CAST(0 AS bit), 65, N'The time for warm-up and cool-down exercises does not need to be altered.'),
(238, N'Aerobic capacity and endurance associated with cardiovascular pump dysfunction.', CAST(0 AS bit), 66, N'Based on the walk test results, the heart rate and blood pressure have normal physiologic rise in response to exercise and would not indicate cardiovascular pump dysfunction.'),
(239, N'Ventilation, respiration, and aerobic capacity associated with airway clearance dysfunction.', CAST(0 AS bit), 66, N'Although the walk test results do indicate impaired ventilation and respiration, there is no indication of airway clearance issues in the question.'),
(240, N'Ventilation, respiration, aerobic capacity, and gas exchange associated with ventilatory pump dysfunction.', CAST(1 AS bit), 66, N'In general, a patient who has pulmonary fibrosis will have an impaired ventilatory pump. This is further evidenced by the exaggerated respiratory rate response and desaturation in the 6-minute walk test results.'),
(241, N'Aerobic capacity and endurance associated with myocardial ischemia.', CAST(0 AS bit), 66, N'The normal electrocardiogram does not suggest myocardial ischemia.');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (242, N'VO2 max treadmill test.', CAST(0 AS bit), 67, N'The VO2 max treadmill test examines functional cardiovascular capacity, not necessarily endurance.'),
(243, N'Two-step exercise test.', CAST(0 AS bit), 67, N'The two-step exercise test is the clinical standard for assessing exercise-induced ischemia. This test can reach VO2 max, which is not appropriate for the patient described.'),
(244, N'Submaximal exercise test on a cycle ergometer.', CAST(0 AS bit), 67, N'The submaximal exercise test is used to estimate VO2 max and assesses aerobic power, not endurance.'),
(245, N'6-minute walk test.', CAST(1 AS bit), 67, N'The 6-minute walk test is designed to measure endurance for acutely ill individuals with cardiovascular and pulmonary dysfunction.'),
(246, N'Oxygen consumption.', CAST(0 AS bit), 68, N'An increase in oxygen uptake occurs in response to increased workload.'),
(247, N'Heart rate.', CAST(0 AS bit), 68, N'Heart rate increases gradually in response to increased workload.'),
(248, N'Systolic blood pressure.', CAST(0 AS bit), 68, N'Systolic blood pressure should increase with increasing workload by approximately 10 mm Hg per 1 metabolic equivalent (MET) increase.'),
(249, N'Diastolic blood pressure.', CAST(1 AS bit), 68, N'Diastolic blood pressure should remain relatively constant during exercise, remaining within 10 mm Hg of the starting point.'),
(250, N'Change in systolic blood pressure.', CAST(0 AS bit), 69, N'Systolic blood pressure is a useful measure of exercise intensity, but it is not easily assessed by the patient.'),
(251, N'MET (metabolic equivalent) level.', CAST(0 AS bit), 69, N'A MET is a metabolic equivalent of an individual''s resting metabolic rate. It varies based on individual factors and is generally too complex for patient self-assessment.'),
(252, N'Rating of perceived exertion.', CAST(1 AS bit), 69, N'The rating of perceived exertion scale is subjective and fairly accurate for assessing ventilatory threshold.'),
(253, N'Respiratory rate.', CAST(0 AS bit), 69, N'Respiratory rate is a useful measure of exercise intensity, but it is not easily assessed by the patient.'),
(254, N'increase in gastric motility', CAST(0 AS bit), 70, N'Gastric motility decreases with aging.'),
(255, N'increase in salivary secretion', CAST(0 AS bit), 70, N'Salivary secretion decreases with aging.'),
(256, N'decrease in tooth decay', CAST(0 AS bit), 70, N'Tooth decay increases due to enamel and dentin wear and decreased saliva.'),
(257, N'decrease in nutrient absorption', CAST(1 AS bit), 70, N'Aging includes a decrease in nutrient absorption.'),
(258, N'increase in gastric motility', CAST(0 AS bit), 71, N'Gastric motility decreases with aging.'),
(259, N'increase in salivary secretion', CAST(0 AS bit), 71, N'Salivary secretion decreases with aging.'),
(260, N'decrease in tooth decay', CAST(0 AS bit), 71, N'Tooth decay increases due to enamel and dentin wear and decreased saliva.'),
(261, N'decrease in nutrient absorption', CAST(1 AS bit), 71, N'Aging includes a decrease in nutrient absorption.'),
(262, N'Patient should return to the previous level of function within 1 week.', CAST(1 AS bit), 72, N'A prognosis is the predicted optimal level of improvement in function reached in a certain time period. The patient''s comorbidities are common in older adults, and with gait and balance training, the patient is expected to return to normal activities.'),
(263, N'Patient will be independent with a walker on all surfaces in 3 weeks.', CAST(0 AS bit), 72, N'There is no mention of gait dysfunction in the question; assuming the patient needs a walker is inappropriate.'),
(264, N'Patient will need to use a wheelchair at home to avoid falls.', CAST(0 AS bit), 72, N'The patient should be given an opportunity to ambulate safely before being considered for a wheelchair.'),
(265, N'Patient should be transferred to a skilled nursing facility for safety.', CAST(0 AS bit), 72, N'The patient''s workup is negative, and with gait and balance retraining, the patient should be able to resume normal activity at home.'),
(266, N'Pancreatitis', CAST(0 AS bit), 73, N'Pancreatitis will typically be made worse by walking or lying in supine position.'),
(267, N'Lumbar herniated nucleus pulposus', CAST(0 AS bit), 73, N'A herniated nucleus pulposus typically causes loss of lumbar motion, and the symptoms are relieved with lying supine.'),
(268, N'Sacroiliac dysfunction', CAST(0 AS bit), 73, N'Sacroiliac dysfunction typically causes decreased hip or lumbar range of motion and is not affected by passing gas.'),
(269, N'Crohn disease', CAST(1 AS bit), 73, N'Crohn disease can refer pain to the pelvic area and hip that is relieved by passing gas.'),
(270, N'Fragile skin', CAST(0 AS bit), 74, N'Vitamin D is not primarily involved in maintaining skin integrity.'),
(271, N'Excessive bleeding', CAST(0 AS bit), 74, N'Bleeding disorders are related to hematological disorders, not vitamin D deficiency.'),
(272, N'Bone decalcification', CAST(1 AS bit), 74, N'Vitamin D is important for calcium absorption, synthesis, and transport, and bone decalcification can result from a deficiency.'),
(273, N'Poor vision', CAST(0 AS bit), 74, N'Vitamin D is not primarily involved in maintaining proper vision.'),
(274, N'Protein', CAST(0 AS bit), 75, N'Too much protein may lead to greater water needs; too little will prevent the development of a wound bed. Protein level does not have a direct effect on heart rate or blood pressure.'),
(275, N'Water', CAST(1 AS bit), 75, N'Water aids in hydration of the wound site, and dehydration will result in elevated heart rate and decreased blood pressure.'),
(276, N'Vitamin B', CAST(0 AS bit), 75, N'Vitamin B is critical in the rebuilding/remodeling stage, but it does not affect heart rate or blood pressure.'),
(277, N'Carbohydrates', CAST(0 AS bit), 75, N'Carbohydrates are important for overall energy needs but do not directly affect heart rate or blood pressure.'),
(278, N'Normal weight', CAST(0 AS bit), 76, N'Body mass index (BMI) for normal weight is 18.5-24.9.'),
(279, N'Underweight', CAST(0 AS bit), 76, N'BMI for underweight is less than 18.5.'),
(280, N'Overweight', CAST(1 AS bit), 76, N'The correct answer according to the BMI rating scale is overweight, which is indicated by a BMI of 25-29.9.'),
(281, N'Obese', CAST(0 AS bit), 76, N'BMI for obese is more than 30.'),
(282, N'active assistive range-of-motion exercise to the knee', CAST(1 AS bit), 77, N'In this stage of hemarthrosis, there is still some bleeding into the joint space, but it is not as extensive as during the acute phase. Therefore, the patient will benefit from range-of-motion exercise to prevent contracture. The patient may need active-assistive exercises, because there may still be pain or edema in the joint that prevents independent performance of range of motion.'),
(283, N'instruction of the patient for weight-bearing to tolerance', CAST(0 AS bit), 77, N'The mechanical trauma of weight-bearing to tolerance at this stage may impinge on and damage the pathologic synovium within the joint.');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (284, N'gentle resistive range-of-motion exercise to the knee', CAST(0 AS bit), 77, N'Resistive range of motion is more appropriate when pain and swelling have subsided and bleeding is not occurring.'),
(285, N'continuous immobilization of the knee in an extension splint', CAST(0 AS bit), 77, N'Continuous immobilization in the extended position will promote contracture in the edematous knee.'),
(286, N'Stroke volume', CAST(0 AS bit), 78, N'Stroke volume is the amount of blood ejected from the left ventricle during each heartbeat and is not directly related to rate pressure product.'),
(287, N'Cardiac output', CAST(0 AS bit), 78, N'Cardiac output is calculated by multiplying stroke volume by heart rate, but rate pressure product specifically relates to myocardial oxygen demand.'),
(288, N'Pulse amplitude', CAST(0 AS bit), 78, N'Pulse amplitude refers to the quality of the pulse and is unrelated to rate pressure product.'),
(289, N'Myocardial oxygen demand', CAST(1 AS bit), 78, N'Rate pressure product is calculated by multiplying heart rate by systolic blood pressure and is an indication of myocardial oxygen demand.'),
(290, N'continue walking while the therapist monitors the patient''s vital signs', CAST(0 AS bit), 79, N'Continuing to walk is inappropriate. Angina during exercise should result in termination of the activity.'),
(291, N'continue walking at 50% slower speed while the therapist calls the physician', CAST(0 AS bit), 79, N'These are indications to terminate exercise and reassess vital signs. Continuing to walk at a lower intensity is inappropriate.'),
(292, N'cease walking while the therapist reassesses the patient''s vital signs', CAST(1 AS bit), 79, N'An episode of stable angina is an indication to terminate exercise testing and reassess vital signs.'),
(293, N'cease walking while the therapist activates the emergency medical system', CAST(0 AS bit), 79, N'These symptoms do not constitute a medical emergency. It is more appropriate to reassess vitals and ask the patient to take nitroglycerin, if prescribed.'),
(294, N'Deep vein thrombosis', CAST(0 AS bit), 80, N'A deep vein thrombosis typically causes unilateral leg swelling and pain, not bilateral.'),
(295, N'Myocardial infarction', CAST(0 AS bit), 80, N'While myocardial infarction may cause shortness of breath, it does not typically cause bilateral swelling. Heart failure could result from a myocardial infarction.'),
(296, N'Pulmonary embolism', CAST(0 AS bit), 80, N'A pulmonary embolism causes shortness of breath but is not typically associated with bilateral lower extremity swelling or pain.'),
(297, N'Heart failure', CAST(1 AS bit), 80, N'Heart failure is characterized by symptoms like dyspnea, orthopnea, paroxysmal nocturnal dyspnea, and peripheral edema, all of which are present in this patient.'),
(298, N'continue walking while the therapist monitors the patient''s vital signs', CAST(0 AS bit), 81, N'Continuing to walk is inappropriate. Angina during exercise should result in termination of the activity.'),
(299, N'continue walking at 50% slower speed while the therapist calls the physician', CAST(0 AS bit), 81, N'These are indications to terminate exercise and reassess vital signs. Continuing to walk at a lower intensity is inappropriate.'),
(300, N'cease walking while the therapist reassesses the patient''s vital signs', CAST(1 AS bit), 81, N'An episode of stable angina is an indication to terminate exercise testing and reassess vital signs.'),
(301, N'cease walking while the therapist activates the emergency medical system', CAST(0 AS bit), 81, N'These symptoms do not constitute a medical emergency. It is more appropriate to reassess vitals and ask the patient to take nitroglycerin, if prescribed.'),
(302, N'Anginal pain, insomnia, sudden weight gain, leg stiffness', CAST(0 AS bit), 82, N'Leg stiffness is not typically associated with exertional intolerance among patients undergoing cardiac rehabilitation.'),
(303, N'Persistent dyspnea, dizziness, anginal pain, sudden weight gain', CAST(1 AS bit), 82, N'These are classic signs of exertional intolerance that should be emphasized during cardiac rehabilitation.'),
(304, N'Persistent dyspnea, anginal pain, insomnia, weight loss', CAST(0 AS bit), 82, N'Weight loss is not a typical symptom of exertional intolerance. Angina and dyspnea are more critical signs.'),
(305, N'Anginal pain, confusion, leg numbness, weight loss', CAST(0 AS bit), 82, N'Leg numbness, confusion, and weight loss are not signs associated with exertional intolerance.'),
(306, N'Left ventricular ejection fraction of 55% and functional capacity of 3 metabolic equivalents (METs)', CAST(0 AS bit), 83, N'A functional capacity below 5-6 METs places a patient at moderate risk for morbidity and mortality.'),
(307, N'Occasional premature ventricular contractions and functional capacity of 6 metabolic equivalents (METs)', CAST(1 AS bit), 83, N'A functional capacity of 6 METs or greater and occasional PVCs are associated with low risk for morbidity and mortality.'),
(308, N'Exercise-induced ST segment depression of less than 2 mm and sustained supraventricular tachycardia', CAST(0 AS bit), 83, N'ST segment depression and SVT indicate ischemia and an arrhythmia, suggesting higher risk for cardiac events.'),
(309, N'Exercise-induced ST segment depression of greater than 2 mm and left ventricular ejection fraction of 45%', CAST(0 AS bit), 83, N'An ejection fraction below 55% and ST depression >2mm indicate high risk for future cardiac events.'),
(310, N'Sharp mid back pain that increases with lifting of heavy objects', CAST(0 AS bit), 84, N'This type of pain is typically related to musculoskeletal or nerve issues, not cardiac.'),
(311, N'Increased pain with deep breathing', CAST(0 AS bit), 84, N'Pain with breathing is often associated with pulmonary or rib movement, not cardiac.'),
(312, N'Feeling of heaviness in the chest', CAST(1 AS bit), 84, N'Heaviness in the chest may indicate a cardiovascular issue, warranting physician referral.'),
(313, N'Persistent night pain', CAST(0 AS bit), 84, N'Night pain often suggests a musculoskeletal issue or potentially cancer, not primarily cardiac.'),
(314, N'Decreased peripheral blood flow', CAST(1 AS bit), 85, N'Peripheral cyanosis is typically linked to decreased peripheral blood flow.'),
(315, N'Deep vein thrombosis', CAST(0 AS bit), 85, N'DVT is usually accompanied by swelling and tenderness, not cyanosis alone.'),
(316, N'Lymphedema', CAST(0 AS bit), 85, N'Lymphedema typically results in swelling rather than cyanosis.'),
(317, N'Aneurysm', CAST(0 AS bit), 85, N'An aneurysm often presents as a pulsing mass, not peripheral cyanosis.'),
(318, N'Gender', CAST(0 AS bit), 86, N'Gender-related hormonal changes are unlikely in a healthy male without cardiovascular symptoms.'),
(319, N'Sedentary activity level', CAST(0 AS bit), 86, N'Sedentary lifestyle is not a primary cause of palpitations without other symptoms.'),
(320, N'Excess caffeine intake', CAST(1 AS bit), 86, N'Excessive caffeine is a common, non-cardiac cause of palpitations in healthy individuals.'),
(321, N'Cardiac abnormality', CAST(0 AS bit), 86, N'Cardiac-origin palpitations usually come with symptoms like dyspnea or light-headedness.'),
(322, N'Dorsal foot, near the base of the first metatarsal', CAST(1 AS bit), 87, N'The dorsal pedal pulse, found near the base of the first metatarsal, is commonly used to assess circulation due to its distal location.'),
(323, N'Lateral lower leg, just posterior to the fibular head', CAST(0 AS bit), 87, N'The popliteal pulse, not located in the lateral lower leg, is an alternative but less distal location.'),
(324, N'Lateral ankle, just inferior to the lateral malleolus', CAST(0 AS bit), 87, N'The posterior tibial pulse is located at the medial, not lateral, ankle.'),
(325, N'Plantar foot, just medial to the medial calcaneal tuberosity', CAST(0 AS bit), 87, N'The plantar surface does not have a pulse point typically used for assessing circulation in the lower extremity.');
INSERT INTO [Answers] ([Id], [Description], [IsCorrect], [QuestionId], [Reason])
VALUES (326, N'The individual has a hypotensive disorder.', CAST(0 AS bit), 88, N'Bradycardia in this case is more likely due to a training effect rather than hypotension.'),
(327, N'The rate is secondary to an increased stroke volume.', CAST(1 AS bit), 88, N'Endurance training increases stroke volume, leading to a compensatory decrease in resting heart rate to maintain cardiac output.'),
(328, N'The individual has an atrioventricular block.', CAST(0 AS bit), 88, N'The low heart rate is more consistent with a training effect, not a conduction block.'),
(329, N'Endurance training has stimulated the sympathetic nervous system.', CAST(0 AS bit), 88, N'Endurance training actually increases parasympathetic activity and reduces sympathetic discharge, lowering the resting heart rate.'),
(330, N'an increase in the heart rate.', CAST(0 AS bit), 89, N'Overstimulation of the carotid sinus decreases heart rate, not increases it.'),
(331, N'a decrease in the heart rate.', CAST(1 AS bit), 89, N'Manual pressure on the carotid sinus can trigger a reflexive drop in heart rate and blood pressure.'),
(332, N'an irregular heart rhythm.', CAST(0 AS bit), 89, N'The heart rate, not the rhythm, changes due to carotid sinus pressure.'),
(333, N'an increase in blood pressure.', CAST(0 AS bit), 89, N'Carotid sinus stimulation decreases, not increases, blood pressure.'),
(334, N'Initiate chest compressions.', CAST(0 AS bit), 90, N'While chest compressions are important, the first action is to activate the emergency response system before beginning compressions.'),
(335, N'Find the nearest defibrillator.', CAST(0 AS bit), 90, N'Time to defibrillation is critical, but activating the emergency response system is the first priority to ensure help is on the way.'),
(336, N'Initiate rescue breathing.', CAST(0 AS bit), 90, N'Rescue breathing is part of the CPR process, but activating the emergency response system is the necessary first step.'),
(337, N'Activate the emergency response system', CAST(1 AS bit), 90, N'The first action is to activate emergency medical services to ensure timely defibrillation and additional support, then proceed with CPR as needed.'),
(338, N'Chronic fatigue syndrome', CAST(0 AS bit), 91, N'Chronic fatigue syndrome is mainly characterized by fatigue rather than pain localized to the left upper quadrant, flank, and mid-back, which points to a different etiology.'),
(339, N'Referred pain from the spleen', CAST(1 AS bit), 91, N'The spleen is located in the left upper abdominal quadrant, and its enlargement or trauma could cause referred pain in this region and explain the patient''s symptoms.'),
(340, N'Conversion disorder from emotional distress', CAST(0 AS bit), 91, N'Conversion disorder involves loss of function often linked to psychological conflict; however, this case does not involve any described functional loss.'),
(341, N'Acute onset of bladder infection', CAST(0 AS bit), 91, N'Bladder infections typically present with lower abdominal pain and urinary symptoms, not pain localized to the left upper quadrant, flank, and mid-back.'),
(342, N'Lymphedema', CAST(0 AS bit), 92, N'Lymphedema is associated with swelling but not typically with digital clubbing, which is more common in chronic hypoxic conditions.'),
(343, N'Chronic obstructive pulmonary disease', CAST(1 AS bit), 92, N'Pulmonary diseases that affect oxygenation can cause digital clubbing; COPD is a predominant cause.'),
(344, N'Chronic venous insufficiency', CAST(0 AS bit), 92, N'Chronic venous insufficiency is more often associated with leg swelling and stasis ulcers rather than digital clubbing.'),
(345, N'Complex regional pain syndrome', CAST(0 AS bit), 92, N'CRPS is characterized by pain and trophic changes but does not typically include clubbing of the fingers.'),
(346, N'Skin cancer', CAST(0 AS bit), 93, N'Skin cancer is not associated with nail clubbing.'),
(347, N'Renal failure', CAST(0 AS bit), 93, N'Renal failure may cause specific nail changes but not clubbing, which is more indicative of pulmonary issues like lung cancer.'),
(348, N'Lung cancer', CAST(1 AS bit), 93, N'Lung cancer and other conditions causing chronic hypoxia are strongly associated with severe clubbing of the nails.'),
(349, N'Liver dysfunction', CAST(0 AS bit), 93, N'Liver dysfunction can cause specific nail changes (e.g., Beau lines, Terry nails) but is not associated with clubbing.'),
(350, N'Delayed cardiovascular response upon rising from supine position', CAST(0 AS bit), 94, N'Early mobilization improves venous return and adaptation to positional changes, which should enhance rather than delay cardiovascular response.'),
(351, N'Decreased heart rate response to exercise', CAST(1 AS bit), 94, N'With conditioning, the heart rate response to exercise is reduced as stroke volume and myocardial contractility increase.'),
(352, N'Decreased respiratory rate in response to exercise', CAST(0 AS bit), 94, N'Early mobilization will improve respiratory function, but a reduction in heart rate response is more specific to cardiopulmonary conditioning.'),
(353, N'Increased cardiovascular peripheral resistance', CAST(0 AS bit), 94, N'Cardiovascular resistance tends to decrease with training, improving blood vessel responsiveness and vascular reflexes.'),
(354, N'Fatigue, shortness of breath, or wheezing', CAST(0 AS bit), 95, N'These are relative indications to stop a test, but they are not absolute contraindications.'),
(355, N'A drop in systolic blood pressure of 10 mm Hg in the absence of ischemic changes', CAST(0 AS bit), 95, N'A drop in systolic blood pressure without ischemia is a relative indication, not an absolute indication, to stop the test.'),
(356, N'A request to stop the test', CAST(1 AS bit), 95, N'The test should be immediately terminated if the patient requests it to be stopped.'),
(357, N'A rise in diastolic blood pressure to 90 mm Hg', CAST(0 AS bit), 95, N'While elevated blood pressure is a concern, a rise to 90 mm Hg is not an absolute indication to stop the test.'),
(358, N'Proceed with the usual low-level protocol, because mild angina is common this soon after a myocardial infarction.', CAST(0 AS bit), 96, N'Unstable angina warrants immediate medical attention rather than proceeding with exercise testing.'),
(359, N'Defer testing the patient, because the symptoms suggest unstable angina after a myocardial infarction.', CAST(1 AS bit), 96, N'Unstable angina following a myocardial infarction requires immediate medical attention and testing should be deferred.'),
(360, N'Perform the test at a lower-than-usual workload, because the symptoms suggest unstable angina after a myocardial infarction.', CAST(0 AS bit), 96, N'Any exercise with unstable angina is contraindicated and the patient should be evaluated immediately.'),
(361, N'Defer testing the patient, because 5 days after a myocardial infarction is too soon to begin physical exertion.', CAST(0 AS bit), 96, N'Exercise testing is typically done before discharge after a myocardial infarction, provided there are no unstable symptoms.');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IsCorrect', N'QuestionId', N'Reason') AND [object_id] = OBJECT_ID(N'[Answers]'))
    SET IDENTITY_INSERT [Answers] OFF;
GO

CREATE INDEX [IX_Answers_QuestionId] ON [Answers] ([QuestionId]);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Blog_User_Likes_BlogId] ON [Blog_User_Likes] ([BlogId]);
GO

CREATE INDEX [IX_Blogs_AuthorId] ON [Blogs] ([AuthorId]);
GO

CREATE INDEX [IX_Blogs_CategoryId] ON [Blogs] ([CategoryId]);
GO

CREATE INDEX [IX_Blogs_SubCategoryId] ON [Blogs] ([SubCategoryId]);
GO

CREATE INDEX [IX_Books_CategoryId] ON [Books] ([CategoryId]);
GO

CREATE INDEX [IX_Books_SubCategoryId] ON [Books] ([SubCategoryId]);
GO

CREATE INDEX [IX_Books_UserId] ON [Books] ([UserId]);
GO

CREATE INDEX [IX_Courses_CategoryId] ON [Courses] ([CategoryId]);
GO

CREATE INDEX [IX_Courses_InstructorId] ON [Courses] ([InstructorId]);
GO

CREATE INDEX [IX_Courses_SubCategoryId] ON [Courses] ([SubCategoryId]);
GO

CREATE INDEX [IX_Objectives_CourseId] ON [Objectives] ([CourseId]);
GO

CREATE INDEX [IX_Questions_BlogId] ON [Questions] ([BlogId]);
GO

CREATE INDEX [IX_Questions_CourseId] ON [Questions] ([CourseId]);
GO

CREATE INDEX [IX_Questions_SubCategoryId] ON [Questions] ([SubCategoryId]);
GO

CREATE INDEX [IX_Questions_TestId] ON [Questions] ([TestId]);
GO

CREATE INDEX [IX_Requirements_CourseId] ON [Requirements] ([CourseId]);
GO

CREATE INDEX [IX_StandardTests_CategoryId] ON [StandardTests] ([CategoryId]);
GO

CREATE INDEX [IX_StandardTests_SubCategoryId] ON [StandardTests] ([SubCategoryId]);
GO

CREATE INDEX [IX_SubCategories_CategoryId] ON [SubCategories] ([CategoryId]);
GO

CREATE INDEX [IX_UserEnrolledCourses_CourseId] ON [UserEnrolledCourses] ([CourseId]);
GO

CREATE INDEX [IX_UserLocalSubscribtions_UserId] ON [UserLocalSubscribtions] ([UserId]);
GO

CREATE INDEX [IX_UserSubscriptions_UserId] ON [UserSubscriptions] ([UserId]);
GO

CREATE INDEX [IX_Videos_CourseId] ON [Videos] ([CourseId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250113164010_Init', N'8.0.8');
GO

COMMIT;
GO


