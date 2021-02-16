using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillRoadMapBack.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Experience = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKEmployee", x => x.Id_Employee);
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
                name: "UserSkills",
                columns: table => new
                {
                    Id_UserSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skillname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
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
                table: "Employees",
                columns: new[] { "Id_Employee", "DevLevel", "Email", "Experience", "Firstname", "Lastname", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Trainee C#", "ilivocs@gmail.com", 5.0, "Oksana", "Iliv", "_Aa123456", "User" },
                    { 2, "Junior C#", "turyanmykh@gmail.com", 5.0, "Mykhailo", "Turianskyi", "_Aa123456", "User" },
                    { 3, "Middle C#", "stasenoleks@gmail.com", 5.0, "Oleksandr", "Stasenko", "_Aa123456", "User" },
                    { 4, "Senior C#", "pynzynyura@gmail.com", 5.0, "Yurii", "Pynzyn", "_Aa123456", "User" },
                    { 5, "Middle C#", "hladyoandr@gmail.com", 5.0, "Andrii", "Hlado", "_Aa123456", "User" }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id_Employer", "Email", "Firstname", "Lastname", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "melnykmyk@gmail.com", "Mykola", "Melnyk", "_Aa123456", "Employer" },
                    { 2, "shevchenkovol@gmail.com", "Volodymyr", "Shevchenko", "_Aa123456", "Employer" },
                    { 3, "boikoolek@gmail.com", "Oleksandr", "Boiko", "_Aa123456", "Employer" },
                    { 4, "kovalenkoiv@gmail.com", "Ivan", "Kovalenko", "_Aa123456", "Employer" },
                    { 5, "bondarenkovas@gmail.com", "Vasyl", "Bondarenko", "_Aa123456", "Employer" }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "Id_UserSkill", "Category", "EndDate", "IdEmployee", "Skillname", "StartDate" },
                values: new object[,]
                {
                    { 1, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "С# Basics", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Lambdas", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Delegates", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Creating Exception Classes", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Exception types. Exception class", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Try..catch..finally", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Access modifiers", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Structures", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Classes and objects", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Cycles", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Data types", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Variables", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# String", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Collections", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Interface", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Delegate", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Exception", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Classes OOP", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Anonymous methods", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Hard skill", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# Defining interfaces", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id_Comment", "CommentText", "IdEmployer", "IdUserSkill" },
                values: new object[,]
                {
                    { 1, "Tmp", 1, 8 },
                    { 2, "Tmp", 1, 9 },
                    { 3, "Tmp", 1, 10 },
                    { 4, "Tmp", 1, 11 },
                    { 5, "Tmp", 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id_Notification", "IdEmployee", "IdEmployer", "IdUserSkill", "IsRead", "NotificationText", "SendingDate" },
                values: new object[,]
                {
                    { 1, 1, 1, 8, false, "Tmp", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, 9, false, "Tmp", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, 10, false, "Tmp", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 1, 11, false, "Tmp", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 1, 12, false, "Tmp", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SkillDistributions",
                columns: new[] { "Id_SkillDistribution", "IdChildSkill", "IdParentSkill" },
                values: new object[,]
                {
                    { 11, 18, 4 },
                    { 10, 17, 4 },
                    { 9, 16, 3 },
                    { 8, 15, 3 },
                    { 7, 14, 3 },
                    { 4, 11, 2 },
                    { 5, 12, 2 },
                    { 12, 19, 4 },
                    { 3, 10, 1 },
                    { 2, 9, 1 },
                    { 1, 8, 1 },
                    { 6, 13, 2 },
                    { 13, 20, 5 }
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
                name: "Employers");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
