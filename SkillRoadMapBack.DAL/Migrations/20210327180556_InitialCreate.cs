using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillRoadMapBack.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKCategory", x => x.Id_Category);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id_Company = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmployeesCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Specialization = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKCompany", x => x.Id_Company);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id_Employer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKEmployer", x => x.Id_Employer);
                    table.ForeignKey(
                        name: "R_16",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "Id_Company",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id_Employee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DevLevel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Experience = table.Column<double>(type: "float", nullable: false),
                    IdMentor = table.Column<int>(type: "int", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKEmployee", x => x.Id_Employee);
                    table.ForeignKey(
                        name: "R_15",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "Id_Company",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_9",
                        column: x => x.IdMentor,
                        principalTable: "Employers",
                        principalColumn: "Id_Employer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id_Training = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingLevel = table.Column<int>(type: "int", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false),
                    IdCoach = table.Column<int>(type: "int", nullable: true),
                    IdCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTraining", x => x.Id_Training);
                    table.ForeignKey(
                        name: "R_25",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id_Category",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_26",
                        column: x => x.IdCoach,
                        principalTable: "Employers",
                        principalColumn: "Id_Employer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statisticses",
                columns: table => new
                {
                    Id_Statistics = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    StatYear = table.Column<int>(type: "int", nullable: false),
                    NewSkillCount = table.Column<int>(type: "int", nullable: false),
                    StudyingTime = table.Column<long>(type: "bigint", nullable: false),
                    AverageSkillLevel = table.Column<double>(type: "float", nullable: false),
                    BetterThanPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKStatistics", x => x.Id_Statistics);
                    table.ForeignKey(
                        name: "R_24",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id_Employee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id_UserSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skillname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUserSkill", x => x.Id_UserSkill);
                    table.ForeignKey(
                        name: "R_1",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id_Employee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_10",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id_Category",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id_Recommendation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    Invitation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IdTraining = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKRecommendation", x => x.Id_Recommendation);
                    table.ForeignKey(
                        name: "R_22",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id_Employee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_29",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "Id_Training",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingMembers",
                columns: table => new
                {
                    Id_TrainingMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTraining = table.Column<int>(type: "int", nullable: true),
                    IdMember = table.Column<int>(type: "int", nullable: true),
                    IsEnded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTrainingMember", x => x.Id_TrainingMember);
                    table.ForeignKey(
                        name: "R_27",
                        column: x => x.IdMember,
                        principalTable: "Employees",
                        principalColumn: "Id_Employee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_28",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "Id_Training",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id_Certificate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUserSkill = table.Column<int>(type: "int", nullable: true),
                    CertificateTitle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdRecipient = table.Column<int>(type: "int", nullable: true),
                    IdPublisher = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKCertificate", x => x.Id_Certificate);
                    table.ForeignKey(
                        name: "R_17",
                        column: x => x.IdPublisher,
                        principalTable: "Employers",
                        principalColumn: "Id_Employer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_18",
                        column: x => x.IdRecipient,
                        principalTable: "Employees",
                        principalColumn: "Id_Employee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_19",
                        column: x => x.IdUserSkill,
                        principalTable: "UserSkills",
                        principalColumn: "Id_UserSkill",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id_Comment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdEmployer = table.Column<int>(type: "int", nullable: true),
                    IdUserSkill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKComment", x => x.Id_Comment);
                    table.ForeignKey(
                        name: "R_2",
                        column: x => x.IdEmployer,
                        principalTable: "Employers",
                        principalColumn: "Id_Employer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_3",
                        column: x => x.IdUserSkill,
                        principalTable: "UserSkills",
                        principalColumn: "Id_UserSkill",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id_Notification = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationText = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    IdEmployer = table.Column<int>(type: "int", nullable: true),
                    IdUserSkill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKNotification", x => x.Id_Notification);
                    table.ForeignKey(
                        name: "R_4",
                        column: x => x.IdEmployer,
                        principalTable: "Employers",
                        principalColumn: "Id_Employer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_5",
                        column: x => x.IdUserSkill,
                        principalTable: "UserSkills",
                        principalColumn: "Id_UserSkill",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_6",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id_Employee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillMetrics",
                columns: table => new
                {
                    Id_SkillMetric = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetricName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MetricValue = table.Column<int>(type: "int", nullable: false),
                    MetricInfluence = table.Column<double>(type: "float", nullable: false),
                    IdUserSkill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKSkillMetric", x => x.Id_SkillMetric);
                    table.ForeignKey(
                        name: "R_23",
                        column: x => x.IdUserSkill,
                        principalTable: "UserSkills",
                        principalColumn: "Id_UserSkill",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillUnits",
                columns: table => new
                {
                    Id_SkillUnit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unitname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitLevel = table.Column<int>(type: "int", nullable: false),
                    IdUserSkill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKSkillUnit", x => x.Id_SkillUnit);
                    table.ForeignKey(
                        name: "R_11",
                        column: x => x.IdUserSkill,
                        principalTable: "UserSkills",
                        principalColumn: "Id_UserSkill",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id_Category", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Includes programming on different languages as C#, Java, Python, Kotlin, C++", "Programming" },
                    { 2, "Includes different types of software testing", "Testing" },
                    { 3, "Includes db design, processes design, software architecture", "Designing" },
                    { 4, "Includes db design, processes design, software architecture", "Frontend" },
                    { 5, "Includes db design, processes design, software architecture", "Database" },
                    { 6, "Includes db design, processes design, software architecture", "Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id_Company", "Address", "ContactPhone", "Description", "EmployeesCount", "Name", "Specialization" },
                values: new object[] { 1, "Lviv, Grabovskogo 11", "032-297-46-55", "Some description about company", 500, "InterLogic", "Software" });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id_Employer", "Email", "Firstname", "IdCompany", "Lastname", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "melnykmyk@gmail.com", "Mykola", 1, "Melnyk", "_Aa123456", "HR" },
                    { 2, "shevchenkovol@gmail.com", "Volodymyr", 1, "Shevchenko", "_Aa123456", "HR" },
                    { 3, "boikoolek@gmail.com", "Oleksandr", 1, "Boiko", "_Aa123456", "Mentor" },
                    { 4, "kovalenkoiv@gmail.com", "Ivan", 1, "Kovalenko", "_Aa123456", "Mentor" },
                    { 5, "bondarenkovas@gmail.com", "Vasyl", 1, "Bondarenko", "_Aa123456", "Mentor" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id_Employee", "DevLevel", "Email", "Experience", "Firstname", "IdCompany", "IdMentor", "Lastname", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Trainee C#", "ilivocs@gmail.com", 5.0, "Oksana", 1, 3, "Iliv", "_Aa123456", "User" },
                    { 2, "Junior C#", "turyanmykh@gmail.com", 5.0, "Mykhailo", 1, 3, "Turianskyi", "_Aa123456", "User" },
                    { 3, "Middle C#", "stasenoleks@gmail.com", 5.0, "Oleksandr", 1, 3, "Stasenko", "_Aa123456", "User" },
                    { 4, "Senior C#", "pynzynyura@gmail.com", 5.0, "Yurii", 1, 4, "Pynzyn", "_Aa123456", "User" },
                    { 5, "Middle C#", "hladyoandr@gmail.com", 5.0, "Andrii", 1, 4, "Hlado", "_Aa123456", "User" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id_Training", "Description", "EndDate", "IdCategory", "IdCoach", "Payment", "StartDate", "TrainingLevel", "TrainingTitle" },
                values: new object[,]
                {
                    { 1, "Learn multithreading in c#", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Multithreading" },
                    { 2, "Learn Parallel in c#", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Parallel programming" },
                    { 3, "Learn LINQ in c#", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "LINQ" },
                    { 4, "Learn reflection in c#", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Reflection" },
                    { 5, "Learn file system in c#", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Work with file system" },
                    { 6, "Learn alpha testing", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Alpha testing" },
                    { 7, "Learn smoke testing", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Smoke testing" },
                    { 8, "Learn new feature testing", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "New feature testing" },
                    { 9, "Learn regression testing", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Regression testing" },
                    { 10, "Learn acceptance testing", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Acceptance testing" }
                });

            migrationBuilder.InsertData(
                table: "TrainingMembers",
                columns: new[] { "Id_TrainingMember", "IdMember", "IdTraining", "IsEnded" },
                values: new object[,]
                {
                    { 12, 2, 8, false },
                    { 2, 2, 1, false },
                    { 3, 3, 2, false },
                    { 4, 4, 2, false },
                    { 9, 4, 3, false },
                    { 1, 1, 1, false },
                    { 5, 5, 6, false },
                    { 6, 1, 6, false },
                    { 7, 2, 7, false },
                    { 8, 3, 7, false },
                    { 10, 5, 3, false },
                    { 11, 1, 8, false }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "EndDate", "IdCategory", "IdEmployee", "SkillLevel", "Skillname", "StartDate" },
                values: new object[,]
                {
                    { 24, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "Python OOP", new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "React Hooks", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "React Forms", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "React basics", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "Angular HTTP", new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "Angular Directives", new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "Angular basics", new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "Vue Routing", new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "Vue Components", new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 4, "Vue Forms", new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "Python built-in modules", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 4, "Joining tables", new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Classes OOP", new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, "C# Exception", new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Delegate", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "C# Interface", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, "C# Collections", new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, "C# String", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "By object of testing", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "By testing purposes", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "According to the knowledge of the system", new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "By the degree of automation", new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "By the degree of isolation of the components", new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, "IDEF designing", new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, "UML designing", new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, "Design patterns", new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 4, "Kotlin language basics", new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 4, "Kotlin functional programming", new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 4, "Kotlin OOP", new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 4, "T-SQL basics", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "EndDate", "IdCategory", "IdEmployee", "SkillLevel", "Skillname", "StartDate" },
                values: new object[] { 20, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 4, "T-SQL basics. DML", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "EndDate", "IdCategory", "IdEmployee", "SkillLevel", "Skillname", "StartDate" },
                values: new object[] { 22, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "Python basics", new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "EndDate", "IdCategory", "IdEmployee", "SkillLevel", "Skillname", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "С# Basics", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id_Certificate", "CertificateTitle", "DateOfIssue", "ExpiryDate", "IdPublisher", "IdRecipient", "IdUserSkill", "SkillLevel" },
                values: new object[,]
                {
                    { 1, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 5 },
                    { 3, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, 5 },
                    { 5, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 5 },
                    { 2, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 4 },
                    { 10, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 5 },
                    { 4, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, 4 },
                    { 6, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 4 },
                    { 7, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 5 },
                    { 9, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 4 },
                    { 8, "Our company present you certificate", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id_Comment", "CommentText", "IdEmployer", "IdUserSkill" },
                values: new object[,]
                {
                    { 1, "Need to learn C#", 1, 1 },
                    { 3, "Need to learn C#", 1, 3 },
                    { 5, "Need to learn C#", 1, 5 },
                    { 4, "Need to learn C#", 1, 4 },
                    { 2, "Need to learn C#", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id_Notification", "IdEmployee", "IdEmployer", "IdUserSkill", "IsRead", "NotificationText", "SendingDate" },
                values: new object[,]
                {
                    { 2, 1, 1, 9, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 1, 12, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, 1, 8, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, 10, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 1, 11, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SkillMetrics",
                columns: new[] { "Id_SkillMetric", "IdUserSkill", "MetricInfluence", "MetricName", "MetricValue" },
                values: new object[,]
                {
                    { 60, 20, 0.29999999999999999, "Use in practice", 5 },
                    { 62, 21, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 63, 21, 0.29999999999999999, "Use in practice", 5 },
                    { 64, 22, 0.29999999999999999, "Interest in studying", 3 },
                    { 59, 20, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 58, 20, 0.29999999999999999, "Interest in studying", 3 },
                    { 57, 19, 0.29999999999999999, "Use in practice", 5 },
                    { 56, 19, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 55, 19, 0.29999999999999999, "Interest in studying", 3 },
                    { 61, 21, 0.29999999999999999, "Interest in studying", 3 },
                    { 50, 17, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 53, 18, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 52, 18, 0.29999999999999999, "Interest in studying", 3 },
                    { 51, 17, 0.29999999999999999, "Use in practice", 5 },
                    { 65, 22, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 49, 17, 0.29999999999999999, "Interest in studying", 3 },
                    { 47, 16, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 46, 16, 0.29999999999999999, "Interest in studying", 3 },
                    { 45, 15, 0.29999999999999999, "Use in practice", 5 },
                    { 44, 15, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 43, 15, 0.29999999999999999, "Interest in studying", 3 },
                    { 42, 14, 0.29999999999999999, "Use in practice", 5 }
                });

            migrationBuilder.InsertData(
                table: "SkillMetrics",
                columns: new[] { "Id_SkillMetric", "IdUserSkill", "MetricInfluence", "MetricName", "MetricValue" },
                values: new object[,]
                {
                    { 41, 14, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 40, 14, 0.29999999999999999, "Interest in studying", 3 },
                    { 39, 13, 0.29999999999999999, "Use in practice", 5 },
                    { 54, 18, 0.29999999999999999, "Use in practice", 5 },
                    { 66, 22, 0.29999999999999999, "Use in practice", 5 },
                    { 74, 25, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 68, 23, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 99, 33, 0.29999999999999999, "Use in practice", 5 },
                    { 98, 33, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 97, 33, 0.29999999999999999, "Interest in studying", 3 },
                    { 96, 32, 0.29999999999999999, "Use in practice", 5 },
                    { 95, 32, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 94, 32, 0.29999999999999999, "Interest in studying", 3 },
                    { 93, 31, 0.29999999999999999, "Use in practice", 5 },
                    { 92, 31, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 91, 31, 0.29999999999999999, "Interest in studying", 3 },
                    { 90, 30, 0.29999999999999999, "Use in practice", 5 },
                    { 89, 30, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 88, 30, 0.29999999999999999, "Interest in studying", 3 },
                    { 87, 29, 0.29999999999999999, "Use in practice", 5 },
                    { 86, 29, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 85, 29, 0.29999999999999999, "Interest in studying", 3 },
                    { 84, 28, 0.29999999999999999, "Use in practice", 5 },
                    { 83, 28, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 69, 23, 0.29999999999999999, "Use in practice", 5 },
                    { 70, 24, 0.29999999999999999, "Interest in studying", 3 },
                    { 71, 24, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 72, 24, 0.29999999999999999, "Use in practice", 5 },
                    { 73, 25, 0.29999999999999999, "Interest in studying", 3 },
                    { 38, 13, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 67, 23, 0.29999999999999999, "Interest in studying", 3 },
                    { 75, 25, 0.29999999999999999, "Use in practice", 5 },
                    { 77, 26, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 78, 26, 0.29999999999999999, "Use in practice", 5 },
                    { 79, 27, 0.29999999999999999, "Interest in studying", 3 },
                    { 80, 27, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 81, 27, 0.29999999999999999, "Use in practice", 5 },
                    { 82, 28, 0.29999999999999999, "Interest in studying", 3 },
                    { 76, 26, 0.29999999999999999, "Interest in studying", 3 },
                    { 37, 13, 0.29999999999999999, "Interest in studying", 3 },
                    { 48, 16, 0.29999999999999999, "Use in practice", 5 },
                    { 18, 6, 0.29999999999999999, "Use in practice", 5 }
                });

            migrationBuilder.InsertData(
                table: "SkillMetrics",
                columns: new[] { "Id_SkillMetric", "IdUserSkill", "MetricInfluence", "MetricName", "MetricValue" },
                values: new object[,]
                {
                    { 28, 10, 0.29999999999999999, "Interest in studying", 3 },
                    { 7, 3, 0.29999999999999999, "Interest in studying", 3 },
                    { 14, 5, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 9, 3, 0.29999999999999999, "Use in practice", 5 },
                    { 27, 9, 0.29999999999999999, "Use in practice", 5 },
                    { 26, 9, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 25, 9, 0.29999999999999999, "Interest in studying", 3 },
                    { 10, 4, 0.29999999999999999, "Interest in studying", 3 },
                    { 24, 8, 0.29999999999999999, "Use in practice", 5 },
                    { 23, 8, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 11, 4, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 12, 4, 0.29999999999999999, "Use in practice", 5 },
                    { 22, 8, 0.29999999999999999, "Interest in studying", 3 },
                    { 21, 7, 0.29999999999999999, "Use in practice", 5 },
                    { 20, 7, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 19, 7, 0.29999999999999999, "Interest in studying", 3 },
                    { 17, 6, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 16, 6, 0.29999999999999999, "Interest in studying", 3 },
                    { 13, 5, 0.29999999999999999, "Interest in studying", 3 },
                    { 29, 10, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 30, 10, 0.29999999999999999, "Use in practice", 5 },
                    { 8, 3, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 15, 5, 0.29999999999999999, "Use in practice", 5 },
                    { 6, 2, 0.29999999999999999, "Use in practice", 5 },
                    { 36, 12, 0.29999999999999999, "Use in practice", 5 },
                    { 5, 2, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 4, 2, 0.29999999999999999, "Interest in studying", 3 },
                    { 3, 1, 0.29999999999999999, "Use in practice", 5 },
                    { 35, 12, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 2, 1, 0.40000000000000002, "Quality of the studied material", 4 },
                    { 34, 12, 0.29999999999999999, "Interest in studying", 3 },
                    { 1, 1, 0.29999999999999999, "Interest in studying", 3 },
                    { 33, 11, 0.29999999999999999, "Use in practice", 5 },
                    { 31, 11, 0.29999999999999999, "Interest in studying", 3 },
                    { 32, 11, 0.40000000000000002, "Quality of the studied material", 4 }
                });

            migrationBuilder.InsertData(
                table: "SkillUnits",
                columns: new[] { "Id_SkillUnit", "EndDate", "IdUserSkill", "StartDate", "UnitLevel", "Unitname" },
                values: new object[,]
                {
                    { 88, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Form validation" },
                    { 89, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Refs" },
                    { 71, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Parent and child components" },
                    { 69, new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Component state and behavior" },
                    { 87, new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Working with forms" },
                    { 10, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C# Delegates" },
                    { 11, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C# Lambdas" }
                });

            migrationBuilder.InsertData(
                table: "SkillUnits",
                columns: new[] { "Id_SkillUnit", "EndDate", "IdUserSkill", "StartDate", "UnitLevel", "Unitname" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C# Anonymous methods" },
                    { 68, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Modifiers" },
                    { 67, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Select list" },
                    { 66, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "The input and textarea elements" },
                    { 90, new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "useState" },
                    { 70, new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Props" },
                    { 1, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C# Variables" },
                    { 74, new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Nested routes" },
                    { 72, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Defining routes" },
                    { 82, new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Observable and RxJS library" },
                    { 81, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "HttpClient and Sending Requests" },
                    { 4, new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C# Classes and objects" },
                    { 5, new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C# Structures" },
                    { 6, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C# Access modifiers" },
                    { 80, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, new DateTime(2019, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "ngIf, ngFor, ngSwitch" },
                    { 84, new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Components" },
                    { 79, new DateTime(2019, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, new DateTime(2019, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Getting parameters in directives" },
                    { 78, new DateTime(2019, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "ngClass and ngStyle" },
                    { 85, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Props" },
                    { 86, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "State" },
                    { 77, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Component life cycle" },
                    { 76, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Binding" },
                    { 75, new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Components" },
                    { 7, new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C# Try..catch..finally" },
                    { 3, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C# Cycles" },
                    { 8, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C# Exception types. Exception class" },
                    { 9, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "C# Creating Exception Classes" },
                    { 73, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Route parameters" },
                    { 2, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "C# Data types" },
                    { 83, new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Sending data in a request" },
                    { 28, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Integration testing" },
                    { 64, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Inheritance" },
                    { 44, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Lambda expressions" },
                    { 43, new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Returning the result" },
                    { 42, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Functions and their parameters" },
                    { 21, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Black box" },
                    { 41, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Cycles" },
                    { 40, new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Conditional expressions" },
                    { 39, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Variables" },
                    { 91, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "useEffect" },
                    { 22, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "White box" },
                    { 23, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gray box" }
                });

            migrationBuilder.InsertData(
                table: "SkillUnits",
                columns: new[] { "Id_SkillUnit", "EndDate", "IdUserSkill", "StartDate", "UnitLevel", "Unitname" },
                values: new object[,]
                {
                    { 38, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bridge pattern" },
                    { 37, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Moment pattern" },
                    { 36, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Factory pattern" },
                    { 35, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Component diagram" },
                    { 34, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Use case diagram" },
                    { 33, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Class diagram" },
                    { 24, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Manual testing" },
                    { 25, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Automated testing" },
                    { 26, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Semiautomated testing" },
                    { 32, new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "IDEF3 design" },
                    { 31, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "DFD design" },
                    { 30, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "IDEF0 design" },
                    { 29, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "System testing" },
                    { 20, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Сhange testing" },
                    { 19, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Non-functional testing" },
                    { 45, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Classes and objects" },
                    { 46, new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Visibility modifiers" },
                    { 63, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Encapsulation" },
                    { 13, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "C# Defining interfaces" },
                    { 14, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "C# Template interfaces" },
                    { 62, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Locale module" },
                    { 61, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Math module" },
                    { 60, new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Random module" },
                    { 27, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Component testing" },
                    { 59, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, new DateTime(2020, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "String operations" },
                    { 58, new DateTime(2020, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Conditional expressions" },
                    { 57, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Variables and data types" },
                    { 56, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, new DateTime(2020, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "UNION" },
                    { 65, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Polymorphism" },
                    { 55, new DateTime(2020, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "OUTER JOIN" },
                    { 15, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Security testing" },
                    { 53, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Filtration. WHERE" },
                    { 52, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Data sampling. SELECT command" },
                    { 51, new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Adding data. INSERT command" },
                    { 16, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Performance testing" },
                    { 17, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Smoke testing" },
                    { 50, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Foreign Keys" },
                    { 49, new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Column and table attributes and constraints" },
                    { 48, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Data types" },
                    { 18, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Functional testing" },
                    { 47, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Inheritance" },
                    { 54, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "INNER JOIN" }
                });

            migrationBuilder.InsertData(
                table: "SkillUnits",
                columns: new[] { "Id_SkillUnit", "EndDate", "IdUserSkill", "StartDate", "UnitLevel", "Unitname" },
                values: new object[] { 92, new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "useRef" });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IdPublisher",
                table: "Certificates",
                column: "IdPublisher");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IdRecipient",
                table: "Certificates",
                column: "IdRecipient");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IdUserSkill",
                table: "Certificates",
                column: "IdUserSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdEmployer",
                table: "Comments",
                column: "IdEmployer");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUserSkill",
                table: "Comments",
                column: "IdUserSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdCompany",
                table: "Employees",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdMentor",
                table: "Employees",
                column: "IdMentor");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_IdCompany",
                table: "Employers",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdEmployee",
                table: "Notifications",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdEmployer",
                table: "Notifications",
                column: "IdEmployer");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdUserSkill",
                table: "Notifications",
                column: "IdUserSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_IdEmployee",
                table: "Recommendations",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_IdTraining",
                table: "Recommendations",
                column: "IdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_SkillMetrics_IdUserSkill",
                table: "SkillMetrics",
                column: "IdUserSkill");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUnits_IdUserSkill",
                table: "SkillUnits",
                column: "IdUserSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Statisticses_IdEmployee",
                table: "Statisticses",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingMembers_IdMember",
                table: "TrainingMembers",
                column: "IdMember");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingMembers_IdTraining",
                table: "TrainingMembers",
                column: "IdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IdCategory",
                table: "Trainings",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IdCoach",
                table: "Trainings",
                column: "IdCoach");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_IdCategory",
                table: "UserSkills",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_IdEmployee",
                table: "UserSkills",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "SkillMetrics");

            migrationBuilder.DropTable(
                name: "SkillUnits");

            migrationBuilder.DropTable(
                name: "Statisticses");

            migrationBuilder.DropTable(
                name: "TrainingMembers");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
