﻿using System;
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
                name: "Employers",
                columns: table => new
                {
                    Id_Employer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKEmployer", x => x.Id_Employer);
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
                    IdMentor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKEmployee", x => x.Id_Employee);
                    table.ForeignKey(
                        name: "R_9",
                        column: x => x.IdMentor,
                        principalTable: "Employers",
                        principalColumn: "Id_Employer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id_UserSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skillname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
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
                    NotificationText = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
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
                name: "SkillDistributions",
                columns: table => new
                {
                    Id_SkillDistribution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParentSkill = table.Column<int>(type: "int", nullable: true),
                    IdChildSkill = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKSkillDistribution", x => x.Id_SkillDistribution);
                    table.ForeignKey(
                        name: "R_7",
                        column: x => x.IdParentSkill,
                        principalTable: "UserSkills",
                        principalColumn: "Id_UserSkill",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_8",
                        column: x => x.IdChildSkill,
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
                    { 3, "Includes db design, processes design, software architecture", "Designing" }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id_Employer", "Email", "Firstname", "Lastname", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "melnykmyk@gmail.com", "Mykola", "Melnyk", "_Aa123456", "HR" },
                    { 2, "shevchenkovol@gmail.com", "Volodymyr", "Shevchenko", "_Aa123456", "HR" },
                    { 3, "boikoolek@gmail.com", "Oleksandr", "Boiko", "_Aa123456", "Mentor" },
                    { 4, "kovalenkoiv@gmail.com", "Ivan", "Kovalenko", "_Aa123456", "Mentor" },
                    { 5, "bondarenkovas@gmail.com", "Vasyl", "Bondarenko", "_Aa123456", "Mentor" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id_Employee", "DevLevel", "Email", "Experience", "Firstname", "IdMentor", "Lastname", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Trainee C#", "ilivocs@gmail.com", 5.0, "Oksana", 3, "Iliv", "_Aa123456", "User" },
                    { 2, "Junior C#", "turyanmykh@gmail.com", 5.0, "Mykhailo", 3, "Turianskyi", "_Aa123456", "User" },
                    { 3, "Middle C#", "stasenoleks@gmail.com", 5.0, "Oleksandr", 3, "Stasenko", "_Aa123456", "User" },
                    { 4, "Senior C#", "pynzynyura@gmail.com", 5.0, "Yurii", 4, "Pynzyn", "_Aa123456", "User" },
                    { 5, "Middle C#", "hladyoandr@gmail.com", 5.0, "Andrii", 4, "Hlado", "_Aa123456", "User" }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "EndDate", "IdCategory", "IdEmployee", "SkillLevel", "Skillname", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "С# Basics", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "Smoke testing", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "Functional testing", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "Non-functional testing", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "Сhange testing", new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "Black box", new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "White box", new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "Gray box", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, "Manual testing", new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "Automated testing", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "Semiautomated testing", new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "Component testing", new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "Integration testing", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "System testing", new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, "IDEF designing", new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, "UML designing", new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, "Design patterns", new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1, "IDEF0 design", new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, "DFD design", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3, "IDEF3 design", new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3, "Class diagram", new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, "Use case diagram", new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 5, "Component diagram", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 5, "Factory pattern", new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "Performance testing", new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3, "Moment pattern", new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, "Security testing", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "By the degree of automation", new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Classes OOP", new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, "C# Exception", new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Delegate", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "C# Interface", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, "C# Collections", new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, "C# String", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, "C# Variables", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "C# Data types", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Cycles", new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "C# Classes and objects", new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Structures", new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, "C# Access modifiers", new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, "C# Try..catch..finally", new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Exception types. Exception class", new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "EndDate", "IdCategory", "IdEmployee", "SkillLevel", "Skillname", "StartDate" },
                values: new object[,]
                {
                    { 16, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, "C# Creating Exception Classes", new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, "C# Delegates", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Lambdas", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, "C# Anonymous methods", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, "C# Defining interfaces", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, "C# Template interfaces", new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, "By object of testing", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "By testing purposes", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, "According to the knowledge of the system", new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, "By the degree of isolation of the components", new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, "Bridge pattern", new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id_Comment", "CommentText", "IdEmployer", "IdUserSkill" },
                values: new object[,]
                {
                    { 1, "Need to learn C#", 1, 8 },
                    { 5, "Need to learn C#", 1, 12 },
                    { 2, "Need to learn C#", 1, 9 },
                    { 4, "Need to learn C#", 1, 11 },
                    { 3, "Need to learn C#", 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id_Notification", "IdEmployee", "IdEmployer", "IdUserSkill", "IsRead", "NotificationText", "SendingDate" },
                values: new object[,]
                {
                    { 4, 1, 1, 11, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, 10, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 1, 12, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, 9, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, 1, 8, false, "Need to learn C#", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SkillDistributions",
                columns: new[] { "Id_SkillDistribution", "IdChildSkill", "IdParentSkill" },
                values: new object[,]
                {
                    { 34, 49, 43 },
                    { 21, 33, 24 },
                    { 22, 34, 24 },
                    { 23, 35, 24 },
                    { 24, 36, 25 },
                    { 25, 37, 25 },
                    { 26, 38, 25 },
                    { 27, 39, 26 },
                    { 29, 41, 26 },
                    { 35, 50, 43 },
                    { 30, 45, 42 },
                    { 31, 46, 42 },
                    { 32, 47, 42 },
                    { 20, 32, 23 },
                    { 33, 48, 43 },
                    { 36, 51, 44 },
                    { 28, 40, 26 },
                    { 19, 31, 23 },
                    { 14, 21, 5 },
                    { 17, 29, 22 },
                    { 1, 8, 1 },
                    { 2, 9, 1 },
                    { 3, 10, 1 },
                    { 4, 11, 2 },
                    { 5, 12, 2 },
                    { 6, 13, 2 },
                    { 7, 14, 3 },
                    { 18, 30, 23 },
                    { 8, 15, 3 },
                    { 10, 17, 4 },
                    { 11, 18, 4 },
                    { 12, 19, 4 }
                });

            migrationBuilder.InsertData(
                table: "SkillDistributions",
                columns: new[] { "Id_SkillDistribution", "IdChildSkill", "IdParentSkill" },
                values: new object[,]
                {
                    { 13, 20, 5 },
                    { 37, 52, 44 },
                    { 15, 27, 22 },
                    { 16, 28, 22 },
                    { 9, 16, 3 },
                    { 38, 53, 44 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdEmployer",
                table: "Comments",
                column: "IdEmployer");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUserSkill",
                table: "Comments",
                column: "IdUserSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdMentor",
                table: "Employees",
                column: "IdMentor");

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
                name: "IX_SkillDistributions_IdChildSkill",
                table: "SkillDistributions",
                column: "IdChildSkill");

            migrationBuilder.CreateIndex(
                name: "IX_SkillDistributions_IdParentSkill",
                table: "SkillDistributions",
                column: "IdParentSkill");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SkillDistributions");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}