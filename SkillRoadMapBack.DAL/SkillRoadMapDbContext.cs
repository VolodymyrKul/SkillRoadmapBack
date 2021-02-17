using Microsoft.EntityFrameworkCore;
using SkillRoadmapBack.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL
{
    public class SkillRoadMapDbContext : DbContext
    {
        public SkillRoadMapDbContext()
        {
        }

        public SkillRoadMapDbContext(DbContextOptions<SkillRoadMapDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<SkillDistribution> SkillDistributions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-THTGA2V;Initial Catalog=SkillsRoadMapDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKEmployee");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Employee");

                entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.DevLevel)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(e => e.IdEmployerNavigation)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.IdMentor)
                .HasConstraintName("R_9");

                entity.HasData(
                    new Employee {
                        Id = 1,
                        Firstname = "Oksana",
                        Lastname = "Iliv",
                        Email = "ilivocs@gmail.com",
                        Password = "_Aa123456",
                        Role = "User",
                        DevLevel = "Trainee C#",
                        Experience = 5,
                        IdMentor = 3
                    },
                    new Employee
                    {
                        Id = 2,
                        Firstname = "Mykhailo",
                        Lastname = "Turianskyi",
                        Email = "turyanmykh@gmail.com",
                        Password = "_Aa123456",
                        Role = "User",
                        DevLevel = "Junior C#",
                        Experience = 5,
                        IdMentor = 3
                    },
                    new Employee
                    {
                        Id = 3,
                        Firstname = "Oleksandr",
                        Lastname = "Stasenko",
                        Email = "stasenoleks@gmail.com",
                        Password = "_Aa123456",
                        Role = "User",
                        DevLevel = "Middle C#",
                        Experience = 5,
                        IdMentor = 3
                    },
                    new Employee
                    {
                        Id = 4,
                        Firstname = "Yurii",
                        Lastname = "Pynzyn",
                        Email = "pynzynyura@gmail.com",
                        Password = "_Aa123456",
                        Role = "User",
                        DevLevel = "Senior C#",
                        Experience = 5,
                        IdMentor = 4
                    },
                    new Employee
                    {
                        Id = 5,
                        Firstname = "Andrii",
                        Lastname = "Hlado",
                        Email = "hladyoandr@gmail.com",
                        Password = "_Aa123456",
                        Role = "User",
                        DevLevel = "Middle C#",
                        Experience = 5,
                        IdMentor = 4
                    });
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKEmployer");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Employer");

                entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasData(
                    new Employer {
                        Id = 1,
                        Firstname = "Mykola",
                        Lastname = "Melnyk",
                        Email = "melnykmyk@gmail.com",
                        Password = "_Aa123456",
                        Role = "HR"
                    },
                    new Employer
                    {
                        Id = 2,
                        Firstname = "Volodymyr",
                        Lastname = "Shevchenko",
                        Email = "shevchenkovol@gmail.com",
                        Password = "_Aa123456",
                        Role = "HR"
                    },
                    new Employer
                    {
                        Id = 3,
                        Firstname = "Oleksandr",
                        Lastname = "Boiko",
                        Email = "boikoolek@gmail.com",
                        Password = "_Aa123456",
                        Role = "Mentor"
                    },
                    new Employer
                    {
                        Id = 4,
                        Firstname = "Ivan",
                        Lastname = "Kovalenko",
                        Email = "kovalenkoiv@gmail.com",
                        Password = "_Aa123456",
                        Role = "Mentor"
                    },
                    new Employer
                    {
                        Id = 5,
                        Firstname = "Vasyl",
                        Lastname = "Bondarenko",
                        Email = "bondarenkovas@gmail.com",
                        Password = "_Aa123456",
                        Role = "Mentor"
                    });
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUserSkill");

                entity.Property(e => e.Id)
                .HasColumnName("Id_UserSkill");

                entity.Property(e => e.Skillname)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(us => us.IdCategoryNavigation)
                .WithMany(c => c.UserSkills)
                .HasForeignKey(us => us.IdCategory)
                .HasConstraintName("R_10");

                entity.HasOne(us => us.IdEmployeeNavigation)
                .WithMany(e => e.UserSkills)
                .HasForeignKey(us => us.IdEmployee)
                .HasConstraintName("R_1");

                entity.HasData(
                    new UserSkill {
                        Id = 1,
                        Skillname = "С# Basics",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 15),
                        IdCategory = 1,
                        SkillLevel = 3,
                        IdEmployee = 1
                    },
                    new UserSkill
                    {
                        Id = 2,
                        Skillname = "C# Classes OOP",
                        StartDate = new DateTime(2021, 2, 20),
                        EndDate = new DateTime(2021, 4, 1),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    },
                    new UserSkill
                    {
                        Id = 3,
                        Skillname = "C# Exception",
                        StartDate = new DateTime(2021, 4, 5),
                        EndDate = new DateTime(2021, 5, 10),
                        IdCategory = 1,
                        SkillLevel = 5,
                        IdEmployee = 1
                    },
                    new UserSkill
                    {
                        Id = 4,
                        Skillname = "C# Delegate",
                        StartDate = new DateTime(2021, 5, 15),
                        EndDate = new DateTime(2021, 6, 20),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 5,
                        Skillname = "C# Interface",
                        StartDate = new DateTime(2021, 6, 25),
                        EndDate = new DateTime(2021, 8, 10),
                        IdCategory = 1,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 6,
                        Skillname = "C# Collections",
                        StartDate = new DateTime(2021, 8, 20),
                        EndDate = new DateTime(2021, 9, 25),
                        IdCategory = 1,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 7,
                        Skillname = "C# String",
                        StartDate = new DateTime(2021, 10, 10),
                        EndDate = new DateTime(2021, 11, 5),
                        IdCategory = 1,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 8,
                        Skillname = "C# Variables",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 1, 10),
                        IdCategory = 1,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 9,
                        Skillname = "C# Data types",
                        StartDate = new DateTime(2021, 1, 10),
                        EndDate = new DateTime(2021, 1, 25),
                        IdCategory = 1,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 10,
                        Skillname = "C# Cycles",
                        StartDate = new DateTime(2021, 1, 25),
                        EndDate = new DateTime(2021, 2, 15),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 11,
                        Skillname = "C# Classes and objects",
                        StartDate = new DateTime(2021, 2, 20),
                        EndDate = new DateTime(2021, 3, 5),
                        IdCategory = 1,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 12,
                        Skillname = "C# Structures",
                        StartDate = new DateTime(2021, 3, 5),
                        EndDate = new DateTime(2021, 3, 20),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 13,
                        Skillname = "C# Access modifiers",
                        StartDate = new DateTime(2021, 3, 20),
                        EndDate = new DateTime(2021, 4, 1),
                        IdCategory = 1,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 14,
                        Skillname = "C# Try..catch..finally",
                        StartDate = new DateTime(2021, 4, 5),
                        EndDate = new DateTime(2021, 4, 10),
                        IdCategory = 1,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 15,
                        Skillname = "C# Exception types. Exception class",
                        StartDate = new DateTime(2021, 4, 10),
                        EndDate = new DateTime(2021, 4, 20),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 16,
                        Skillname = "C# Creating Exception Classes",
                        StartDate = new DateTime(2021, 4, 20),
                        EndDate = new DateTime(2021, 5, 10),
                        IdCategory = 1,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 17,
                        Skillname = "C# Delegates",
                        StartDate = new DateTime(2021, 5, 15),
                        EndDate = new DateTime(2021, 6, 1),
                        IdCategory = 1,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 18,
                        Skillname = "C# Lambdas",
                        StartDate = new DateTime(2021, 6, 1),
                        EndDate = new DateTime(2021, 6, 10),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 19,
                        Skillname = "C# Anonymous methods",
                        StartDate = new DateTime(2021, 6, 10),
                        EndDate = new DateTime(2021, 6, 20),
                        IdCategory = 1,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 20,
                        Skillname = "C# Defining interfaces",
                        StartDate = new DateTime(2021, 6, 25),
                        EndDate = new DateTime(2021, 7, 15),
                        IdCategory = 1,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 21,
                        Skillname = "C# Template interfaces",
                        StartDate = new DateTime(2021, 7, 15),
                        EndDate = new DateTime(2021, 8, 10),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 22,
                        Skillname = "By object of testing",
                        StartDate = new DateTime(2021, 1, 15),
                        EndDate = new DateTime(2021, 2, 25),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 23,
                        Skillname = "By testing purposes",
                        StartDate = new DateTime(2021, 3, 1),
                        EndDate = new DateTime(2021, 4, 5),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 24,
                        Skillname = "According to the knowledge of the system",
                        StartDate = new DateTime(2021, 4, 10),
                        EndDate = new DateTime(2021, 5, 20),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 25,
                        Skillname = "By the degree of automation",
                        StartDate = new DateTime(2021, 5, 25),
                        EndDate = new DateTime(2021, 7, 5),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 26,
                        Skillname = "By the degree of isolation of the components",
                        StartDate = new DateTime(2021, 7, 10),
                        EndDate = new DateTime(2021, 8, 15),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 27,
                        Skillname = "Security testing",
                        StartDate = new DateTime(2021, 1, 15),
                        EndDate = new DateTime(2021, 1, 25),
                        IdCategory = 2,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 28,
                        Skillname = "Performance testing",
                        StartDate = new DateTime(2021, 1, 25),
                        EndDate = new DateTime(2021, 2, 15),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 29,
                        Skillname = "Smoke testing",
                        StartDate = new DateTime(2021, 2, 15),
                        EndDate = new DateTime(2021, 2, 25),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 30,
                        Skillname = "Functional testing",
                        StartDate = new DateTime(2021, 3, 1),
                        EndDate = new DateTime(2021, 3, 10),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 31,
                        Skillname = "Non-functional testing",
                        StartDate = new DateTime(2021, 3, 10),
                        EndDate = new DateTime(2021, 3, 25),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 32,
                        Skillname = "Сhange testing",
                        StartDate = new DateTime(2021, 3, 25),
                        EndDate = new DateTime(2021, 4, 5),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 33,
                        Skillname = "Black box",
                        StartDate = new DateTime(2021, 4, 10),
                        EndDate = new DateTime(2021, 4, 20),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 34,
                        Skillname = "White box",
                        StartDate = new DateTime(2021, 4, 20),
                        EndDate = new DateTime(2021, 5, 5),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 35,
                        Skillname = "Gray box",
                        StartDate = new DateTime(2021, 5, 5),
                        EndDate = new DateTime(2021, 5, 20),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 36,
                        Skillname = "Manual testing",
                        StartDate = new DateTime(2021, 5, 25),
                        EndDate = new DateTime(2021, 6, 10),
                        IdCategory = 2,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 37,
                        Skillname = "Automated testing",
                        StartDate = new DateTime(2021, 6, 10),
                        EndDate = new DateTime(2021, 6, 20),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 38,
                        Skillname = "Semiautomated testing",
                        StartDate = new DateTime(2021, 6, 20),
                        EndDate = new DateTime(2021, 7, 5),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 39,
                        Skillname = "Component testing",
                        StartDate = new DateTime(2021, 7, 10),
                        EndDate = new DateTime(2021, 7, 25),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 40,
                        Skillname = "Integration testing",
                        StartDate = new DateTime(2021, 7, 25),
                        EndDate = new DateTime(2021, 8, 10),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 41,
                        Skillname = "System testing",
                        StartDate = new DateTime(2021, 8, 10),
                        EndDate = new DateTime(2021, 8, 15),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 42,
                        Skillname = "IDEF designing",
                        StartDate = new DateTime(2021, 8, 15),
                        EndDate = new DateTime(2021, 9, 20),
                        IdCategory = 3,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 43,
                        Skillname = "UML designing",
                        StartDate = new DateTime(2021, 9, 25),
                        EndDate = new DateTime(2021, 11, 1),
                        IdCategory = 3,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 44,
                        Skillname = "Design patterns",
                        StartDate = new DateTime(2021, 11, 5),
                        EndDate = new DateTime(2021, 12, 10),
                        IdCategory = 3,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 45,
                        Skillname = "IDEF0 design",
                        StartDate = new DateTime(2021, 8, 15),
                        EndDate = new DateTime(2021, 9, 1),
                        IdCategory = 3,
                        SkillLevel = 1,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 46,
                        Skillname = "DFD design",
                        StartDate = new DateTime(2021, 9, 1),
                        EndDate = new DateTime(2021, 9, 10),
                        IdCategory = 3,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 47,
                        Skillname = "IDEF3 design",
                        StartDate = new DateTime(2021, 9, 10),
                        EndDate = new DateTime(2021, 9, 20),
                        IdCategory = 3,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 48,
                        Skillname = "Class diagram",
                        StartDate = new DateTime(2021, 9, 25),
                        EndDate = new DateTime(2021, 10, 5),
                        IdCategory = 3,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 49,
                        Skillname = "Use case diagram",
                        StartDate = new DateTime(2021, 10, 5),
                        EndDate = new DateTime(2021, 10, 15),
                        IdCategory = 3,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 50,
                        Skillname = "Component diagram",
                        StartDate = new DateTime(2021, 10, 15),
                        EndDate = new DateTime(2021, 11, 1),
                        IdCategory = 3,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 51,
                        Skillname = "Factory pattern",
                        StartDate = new DateTime(2021, 11, 5),
                        EndDate = new DateTime(2021, 11, 15),
                        IdCategory = 3,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 52,
                        Skillname = "Moment pattern",
                        StartDate = new DateTime(2021, 11, 15),
                        EndDate = new DateTime(2021, 12, 1),
                        IdCategory = 3,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 53,
                        Skillname = "Bridge pattern",
                        StartDate = new DateTime(2021, 12, 1),
                        EndDate = new DateTime(2021, 12, 10),
                        IdCategory = 3,
                        SkillLevel = 4,
                        IdEmployee = 1
                    });
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKComment");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Comment");

                entity.Property(e => e.CommentText)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(c => c.IdEmployerNavigation)
                .WithMany(e => e.Comments)
                .HasForeignKey(c => c.IdEmployer)
                .HasConstraintName("R_2");

                entity.HasOne(c => c.IdUserSkillNavigation)
                .WithMany(us => us.Comments)
                .HasForeignKey(c => c.IdUserSkill)
                .HasConstraintName("R_3");

                entity.HasData(
                    new Comment {
                        Id = 1,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 8
                    },
                    new Comment
                    {
                        Id = 2,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 9
                    },
                    new Comment
                    {
                        Id = 3,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 10
                    },
                    new Comment
                    {
                        Id = 4,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 11
                    },
                    new Comment
                    {
                        Id = 5,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 12
                    });
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKNotification");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Notification");

                entity.Property(e => e.NotificationText)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(c => c.IdEmployerNavigation)
                .WithMany(e => e.Notifications)
                .HasForeignKey(c => c.IdEmployer)
                .HasConstraintName("R_4");

                entity.HasOne(c => c.IdUserSkillNavigation)
                .WithMany(us => us.Notifications)
                .HasForeignKey(c => c.IdUserSkill)
                .HasConstraintName("R_5");

                entity.HasOne(n => n.IdEmployeeNavigation)
                .WithMany(e => e.Notifications)
                .HasForeignKey(n => n.IdEmployee)
                .HasConstraintName("R_6");

                entity.HasData(
                    new Notification {
                        Id = 1,
                        NotificationText = "Need to learn C#",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 8
                    },
                    new Notification
                    {
                        Id = 2,
                        NotificationText = "Need to learn C#",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 9
                    },
                    new Notification
                    {
                        Id = 3,
                        NotificationText = "Need to learn C#",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 10
                    },
                    new Notification
                    {
                        Id = 4,
                        NotificationText = "Need to learn C#",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 11
                    },
                    new Notification
                    {
                        Id = 5,
                        NotificationText = "Need to learn C#",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 12
                    });
            });

            modelBuilder.Entity<SkillDistribution>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKSkillDistribution");

                entity.Property(e => e.Id)
                .HasColumnName("Id_SkillDistribution");

                entity.HasOne(c => c.IdParentSkillNavigation)
                .WithMany(us => us.ParentSkillDistributions)
                .HasForeignKey(c => c.IdParentSkill)
                .HasConstraintName("R_7");

                entity.HasOne(c => c.IdChildSkillNavigation)
                .WithMany(us => us.ChildSkillDistributions)
                .HasForeignKey(c => c.IdChildSkill)
                .HasConstraintName("R_8");

                entity.HasData(
                    new SkillDistribution {
                        Id = 1,
                        IdParentSkill = 1,
                        IdChildSkill = 8
                    },
                    new SkillDistribution
                    {
                        Id = 2,
                        IdParentSkill = 1,
                        IdChildSkill = 9
                    },
                    new SkillDistribution
                    {
                        Id = 3,
                        IdParentSkill = 1,
                        IdChildSkill = 10
                    },
                    new SkillDistribution
                    {
                        Id = 4,
                        IdParentSkill = 2,
                        IdChildSkill = 11
                    },
                    new SkillDistribution
                    {
                        Id = 5,
                        IdParentSkill = 2,
                        IdChildSkill = 12
                    },
                    new SkillDistribution
                    {
                        Id = 6,
                        IdParentSkill = 2,
                        IdChildSkill = 13
                    },
                    new SkillDistribution
                    {
                        Id = 7,
                        IdParentSkill = 3,
                        IdChildSkill = 14
                    },
                    new SkillDistribution
                    {
                        Id = 8,
                        IdParentSkill = 3,
                        IdChildSkill = 15
                    },
                    new SkillDistribution
                    {
                        Id = 9,
                        IdParentSkill = 3,
                        IdChildSkill = 16
                    },
                    new SkillDistribution
                    {
                        Id = 10,
                        IdParentSkill = 4,
                        IdChildSkill = 17
                    },
                    new SkillDistribution
                    {
                        Id = 11,
                        IdParentSkill = 4,
                        IdChildSkill = 18
                    },
                    new SkillDistribution
                    {
                        Id = 12,
                        IdParentSkill = 4,
                        IdChildSkill = 19
                    },
                    new SkillDistribution
                    {
                        Id = 13,
                        IdParentSkill = 5,
                        IdChildSkill = 20
                    },
                    new SkillDistribution
                    {
                        Id = 14,
                        IdParentSkill = 5,
                        IdChildSkill = 21
                    },
                    new SkillDistribution
                    {
                        Id = 15,
                        IdParentSkill = 22,
                        IdChildSkill = 27
                    },
                    new SkillDistribution
                    {
                        Id = 16,
                        IdParentSkill = 22,
                        IdChildSkill = 28
                    },
                    new SkillDistribution
                    {
                        Id = 17,
                        IdParentSkill = 22,
                        IdChildSkill = 29
                    },
                    new SkillDistribution
                    {
                        Id = 18,
                        IdParentSkill = 23,
                        IdChildSkill = 30
                    },
                    new SkillDistribution
                    {
                        Id = 19,
                        IdParentSkill = 23,
                        IdChildSkill = 31
                    },
                    new SkillDistribution
                    {
                        Id = 20,
                        IdParentSkill = 23,
                        IdChildSkill = 32
                    },
                    new SkillDistribution
                    {
                        Id = 21,
                        IdParentSkill = 24,
                        IdChildSkill = 33
                    },
                    new SkillDistribution
                    {
                        Id = 22,
                        IdParentSkill = 24,
                        IdChildSkill = 34
                    },
                    new SkillDistribution
                    {
                        Id = 23,
                        IdParentSkill = 24,
                        IdChildSkill = 35
                    },
                    new SkillDistribution
                    {
                        Id = 24,
                        IdParentSkill = 25,
                        IdChildSkill = 36
                    },
                    new SkillDistribution
                    {
                        Id = 25,
                        IdParentSkill = 25,
                        IdChildSkill = 37
                    },
                    new SkillDistribution
                    {
                        Id = 26,
                        IdParentSkill = 25,
                        IdChildSkill = 38
                    },
                    new SkillDistribution
                    {
                        Id = 27,
                        IdParentSkill = 26,
                        IdChildSkill = 39
                    },
                    new SkillDistribution
                    {
                        Id = 28,
                        IdParentSkill = 26,
                        IdChildSkill = 40
                    },
                    new SkillDistribution
                    {
                        Id = 29,
                        IdParentSkill = 26,
                        IdChildSkill = 41
                    },
                    new SkillDistribution
                    {
                        Id = 30,
                        IdParentSkill = 42,
                        IdChildSkill = 45
                    },
                    new SkillDistribution
                    {
                        Id = 31,
                        IdParentSkill = 42,
                        IdChildSkill = 46
                    },
                    new SkillDistribution
                    {
                        Id = 32,
                        IdParentSkill = 42,
                        IdChildSkill = 47
                    },
                    new SkillDistribution
                    {
                        Id = 33,
                        IdParentSkill = 43,
                        IdChildSkill = 48
                    },
                    new SkillDistribution
                    {
                        Id = 34,
                        IdParentSkill = 43,
                        IdChildSkill = 49
                    },
                    new SkillDistribution
                    {
                        Id = 35,
                        IdParentSkill = 43,
                        IdChildSkill = 50
                    },
                    new SkillDistribution
                    {
                        Id = 36,
                        IdParentSkill = 44,
                        IdChildSkill = 51
                    },
                    new SkillDistribution
                    {
                        Id = 37,
                        IdParentSkill = 44,
                        IdChildSkill = 52
                    },
                    new SkillDistribution
                    {
                        Id = 38,
                        IdParentSkill = 44,
                        IdChildSkill = 53
                    });
            });

            modelBuilder.Entity<Category>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKCategory");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Category");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.HasData(
                    new Category
                    {
                        Id = 1,
                        Title = "Programming",
                        Description = "Includes programming on different languages as C#, Java, Python, Kotlin, C++"
                    },
                    new Category
                    {
                        Id = 2,
                        Title = "Testing",
                        Description = "Includes different types of software testing"
                    },
                    new Category
                    {
                        Id = 3,
                        Title = "Designing",
                        Description = "Includes db design, processes design, software architecture"
                    });
            });
        }
    }
}
