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
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SkillUnit> SkillUnits { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<RecMember> RecMembers { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<SkillMetric> SkillMetrics { get; set; }
        public virtual DbSet<Statistics> Statisticses { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingMember> TrainingMembers { get; set; }

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

                entity.HasOne(e => e.IdCompanyNavigation)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.IdCompany)
                .HasConstraintName("R_15");

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
                        IdMentor = 3,
                        IdCompany = 1
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
                        IdMentor = 3,
                        IdCompany = 1
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
                        IdMentor = 3,
                        IdCompany = 1
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
                        IdMentor = 4,
                        IdCompany = 1
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
                        IdMentor = 4,
                        IdCompany = 1
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

                entity.HasOne(e => e.IdCompanyNavigation)
                .WithMany(c => c.Employers)
                .HasForeignKey(e => e.IdCompany)
                .HasConstraintName("R_16");

                entity.HasData(
                    new Employer {
                        Id = 1,
                        Firstname = "Mykola",
                        Lastname = "Melnyk",
                        Email = "melnykmyk@gmail.com",
                        Password = "_Aa123456",
                        Role = "HR",
                        IdCompany = 1
                    },
                    new Employer
                    {
                        Id = 2,
                        Firstname = "Volodymyr",
                        Lastname = "Shevchenko",
                        Email = "shevchenkovol@gmail.com",
                        Password = "_Aa123456",
                        Role = "HR",
                        IdCompany = 1
                    },
                    new Employer
                    {
                        Id = 3,
                        Firstname = "Oleksandr",
                        Lastname = "Boiko",
                        Email = "boikoolek@gmail.com",
                        Password = "_Aa123456",
                        Role = "Mentor",
                        IdCompany = 1
                    },
                    new Employer
                    {
                        Id = 4,
                        Firstname = "Ivan",
                        Lastname = "Kovalenko",
                        Email = "kovalenkoiv@gmail.com",
                        Password = "_Aa123456",
                        Role = "Mentor",
                        IdCompany = 1
                    },
                    new Employer
                    {
                        Id = 5,
                        Firstname = "Vasyl",
                        Lastname = "Bondarenko",
                        Email = "bondarenkovas@gmail.com",
                        Password = "_Aa123456",
                        Role = "Mentor",
                        IdCompany = 1
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
                        Skillname = "By object of testing",
                        StartDate = new DateTime(2021, 1, 15),
                        EndDate = new DateTime(2021, 2, 25),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 9,
                        Skillname = "By testing purposes",
                        StartDate = new DateTime(2021, 3, 1),
                        EndDate = new DateTime(2021, 4, 5),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 10,
                        Skillname = "According to the knowledge of the system",
                        StartDate = new DateTime(2021, 4, 10),
                        EndDate = new DateTime(2021, 5, 20),
                        IdCategory = 2,
                        SkillLevel = 5,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 11,
                        Skillname = "By the degree of automation",
                        StartDate = new DateTime(2021, 5, 25),
                        EndDate = new DateTime(2021, 7, 5),
                        IdCategory = 2,
                        SkillLevel = 3,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 12,
                        Skillname = "By the degree of isolation of the components",
                        StartDate = new DateTime(2021, 7, 10),
                        EndDate = new DateTime(2021, 8, 15),
                        IdCategory = 2,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 13,
                        Skillname = "IDEF designing",
                        StartDate = new DateTime(2021, 8, 15),
                        EndDate = new DateTime(2021, 9, 20),
                        IdCategory = 3,
                        SkillLevel = 2,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 14,
                        Skillname = "UML designing",
                        StartDate = new DateTime(2021, 9, 25),
                        EndDate = new DateTime(2021, 11, 1),
                        IdCategory = 3,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 15,
                        Skillname = "Design patterns",
                        StartDate = new DateTime(2021, 11, 5),
                        EndDate = new DateTime(2021, 12, 10),
                        IdCategory = 3,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 16,
                        Skillname = "Kotlin language basics",
                        StartDate = new DateTime(2020, 2, 10),
                        EndDate = new DateTime(2020, 3, 10),
                        IdCategory = 6,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 17,
                        Skillname = "Kotlin functional programming",
                        StartDate = new DateTime(2020, 3, 10),
                        EndDate = new DateTime(2020, 4, 10),
                        IdCategory = 6,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 18,
                        Skillname = "Kotlin OOP",
                        StartDate = new DateTime(2020, 4, 10),
                        EndDate = new DateTime(2020, 5, 10),
                        IdCategory = 6,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 19,
                        Skillname = "T-SQL basics",
                        StartDate = new DateTime(2020, 5, 10),
                        EndDate = new DateTime(2020, 6, 10),
                        IdCategory = 5,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 20,
                        Skillname = "T-SQL basics. DML",
                        StartDate = new DateTime(2020, 6, 10),
                        EndDate = new DateTime(2020, 7, 10),
                        IdCategory = 5,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 21,
                        Skillname = "Joining tables",
                        StartDate = new DateTime(2020, 7, 10),
                        EndDate = new DateTime(2020, 8, 10),
                        IdCategory = 5,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 22,
                        Skillname = "Python basics",
                        StartDate = new DateTime(2020, 8, 10),
                        EndDate = new DateTime(2020, 9, 10),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 23,
                        Skillname = "Python built-in modules",
                        StartDate = new DateTime(2020, 9, 10),
                        EndDate = new DateTime(2020, 10, 10),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 24,
                        Skillname = "Python OOP",
                        StartDate = new DateTime(2020, 10, 10),
                        EndDate = new DateTime(2020, 11, 10),
                        IdCategory = 1,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 25,
                        Skillname = "Vue Forms",
                        StartDate = new DateTime(2019, 3, 10),
                        EndDate = new DateTime(2019, 4, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 26,
                        Skillname = "Vue Components",
                        StartDate = new DateTime(2019, 4, 10),
                        EndDate = new DateTime(2019, 5, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 27,
                        Skillname = "Vue Routing",
                        StartDate = new DateTime(2019, 5, 10),
                        EndDate = new DateTime(2019, 6, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 28,
                        Skillname = "Angular basics",
                        StartDate = new DateTime(2019, 6, 10),
                        EndDate = new DateTime(2019, 7, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 29,
                        Skillname = "Angular Directives",
                        StartDate = new DateTime(2019, 7, 10),
                        EndDate = new DateTime(2019, 8, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 30,
                        Skillname = "Angular HTTP",
                        StartDate = new DateTime(2019, 8, 10),
                        EndDate = new DateTime(2019, 9, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 31,
                        Skillname = "React basics",
                        StartDate = new DateTime(2019, 9, 10),
                        EndDate = new DateTime(2019, 10, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 32,
                        Skillname = "React Forms",
                        StartDate = new DateTime(2019, 10, 10),
                        EndDate = new DateTime(2019, 11, 10),
                        IdCategory = 4,
                        SkillLevel = 4,
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 33,
                        Skillname = "React Hooks",
                        StartDate = new DateTime(2019, 11, 10),
                        EndDate = new DateTime(2019, 12, 10),
                        IdCategory = 4,
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
                        IdUserSkill = 1
                    },
                    new Comment
                    {
                        Id = 2,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 2
                    },
                    new Comment
                    {
                        Id = 3,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 3
                    },
                    new Comment
                    {
                        Id = 4,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 4
                    },
                    new Comment
                    {
                        Id = 5,
                        CommentText = "Need to learn C#",
                        IdEmployer = 1,
                        IdUserSkill = 5
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
                    },
                    new Category
                    {
                        Id = 4,
                        Title = "Frontend",
                        Description = "Includes db design, processes design, software architecture"
                    },
                    new Category
                    {
                        Id = 5,
                        Title = "Database",
                        Description = "Includes db design, processes design, software architecture"
                    },
                    new Category
                    {
                        Id = 6,
                        Title = "Mobile",
                        Description = "Includes db design, processes design, software architecture"
                    });
            });

            modelBuilder.Entity<SkillUnit>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKSkillUnit");

                entity.Property(e => e.Id)
                .HasColumnName("Id_SkillUnit");

                entity.Property(e => e.Unitname)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(su => su.IdUserSkillNavigation)
                .WithMany(us => us.SkillUnits)
                .HasForeignKey(su => su.IdUserSkill)
                .HasConstraintName("R_11");

                entity.HasData(
                    new SkillUnit
                    {
                        Id = 1,
                        Unitname = "C# Variables",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 1, 10),
                        UnitLevel = 2,
                        IdUserSkill = 1
                    }, new SkillUnit
                    {
                        Id = 2,
                        Unitname = "C# Data types",
                        StartDate = new DateTime(2021, 1, 10),
                        EndDate = new DateTime(2021, 1, 25),
                        UnitLevel = 3,
                        IdUserSkill = 1
                    }, new SkillUnit
                    {
                        Id = 3,
                        Unitname = "C# Cycles",
                        StartDate = new DateTime(2021, 1, 25),
                        EndDate = new DateTime(2021, 2, 15),
                        UnitLevel = 4,
                        IdUserSkill = 1
                    }, new SkillUnit
                    {
                        Id = 4,
                        Unitname = "C# Classes and objects",
                        StartDate = new DateTime(2021, 2, 20),
                        EndDate = new DateTime(2021, 3, 5),
                        UnitLevel = 3,
                        IdUserSkill = 2
                    }, new SkillUnit
                    {
                        Id = 5,
                        Unitname = "C# Structures",
                        StartDate = new DateTime(2021, 3, 5),
                        EndDate = new DateTime(2021, 3, 20),
                        UnitLevel = 4,
                        IdUserSkill = 2
                    }, new SkillUnit
                    {
                        Id = 6,
                        Unitname = "C# Access modifiers",
                        StartDate = new DateTime(2021, 3, 20),
                        EndDate = new DateTime(2021, 4, 1),
                        UnitLevel = 5,
                        IdUserSkill = 2
                    }, new SkillUnit
                    {
                        Id = 7,
                        Unitname = "C# Try..catch..finally",
                        StartDate = new DateTime(2021, 4, 5),
                        EndDate = new DateTime(2021, 4, 10),
                        UnitLevel = 5,
                        IdUserSkill = 3
                    }, new SkillUnit
                    {
                        Id = 8,
                        Unitname = "C# Exception types. Exception class",
                        StartDate = new DateTime(2021, 4, 10),
                        EndDate = new DateTime(2021, 4, 20),
                        UnitLevel = 4,
                        IdUserSkill = 3
                    }, new SkillUnit
                    {
                        Id = 9,
                        Unitname = "C# Creating Exception Classes",
                        StartDate = new DateTime(2021, 4, 20),
                        EndDate = new DateTime(2021, 5, 10),
                        UnitLevel = 5,
                        IdUserSkill = 3
                    }, new SkillUnit
                    {
                        Id = 10,
                        Unitname = "C# Delegates",
                        StartDate = new DateTime(2021, 5, 15),
                        EndDate = new DateTime(2021, 6, 1),
                        UnitLevel = 3,
                        IdUserSkill = 4
                    }, new SkillUnit
                    {
                        Id = 11,
                        Unitname = "C# Lambdas",
                        StartDate = new DateTime(2021, 6, 1),
                        EndDate = new DateTime(2021, 6, 10),
                        UnitLevel = 4,
                        IdUserSkill = 4
                    }, new SkillUnit
                    {
                        Id = 12,
                        Unitname = "C# Anonymous methods",
                        StartDate = new DateTime(2021, 6, 10),
                        EndDate = new DateTime(2021, 6, 20),
                        UnitLevel = 5,
                        IdUserSkill = 4
                    }, new SkillUnit
                    {
                        Id = 13,
                        Unitname = "C# Defining interfaces",
                        StartDate = new DateTime(2021, 6, 25),
                        EndDate = new DateTime(2021, 7, 15),
                        UnitLevel = 2,
                        IdUserSkill = 5
                    }, new SkillUnit
                    {
                        Id = 14,
                        Unitname = "C# Template interfaces",
                        StartDate = new DateTime(2021, 7, 15),
                        EndDate = new DateTime(2021, 8, 10),
                        UnitLevel = 4,
                        IdUserSkill = 5
                    }, new SkillUnit
                    {
                        Id = 15,
                        Unitname = "Security testing",
                        StartDate = new DateTime(2021, 1, 15),
                        EndDate = new DateTime(2021, 1, 25),
                        UnitLevel = 2,
                        IdUserSkill = 8
                    }, new SkillUnit
                    {
                        Id = 16,
                        Unitname = "Performance testing",
                        StartDate = new DateTime(2021, 1, 25),
                        EndDate = new DateTime(2021, 2, 15),
                        UnitLevel = 3,
                        IdUserSkill = 8
                    }, new SkillUnit
                    {
                        Id = 17,
                        Unitname = "Smoke testing",
                        StartDate = new DateTime(2021, 2, 15),
                        EndDate = new DateTime(2021, 2, 25),
                        UnitLevel = 4,
                        IdUserSkill = 8
                    }, new SkillUnit
                    {
                        Id = 18,
                        Unitname = "Functional testing",
                        StartDate = new DateTime(2021, 3, 1),
                        EndDate = new DateTime(2021, 3, 10),
                        UnitLevel = 3,
                        IdUserSkill = 9
                    }, new SkillUnit
                    {
                        Id = 19,
                        Unitname = "Non-functional testing",
                        StartDate = new DateTime(2021, 3, 10),
                        EndDate = new DateTime(2021, 3, 25),
                        UnitLevel = 4,
                        IdUserSkill = 9
                    }, new SkillUnit
                    {
                        Id = 20,
                        Unitname = "Сhange testing",
                        StartDate = new DateTime(2021, 3, 25),
                        EndDate = new DateTime(2021, 4, 5),
                        UnitLevel = 5,
                        IdUserSkill = 9
                    }, new SkillUnit
                    {
                        Id = 21,
                        Unitname = "Black box",
                        StartDate = new DateTime(2021, 4, 10),
                        EndDate = new DateTime(2021, 4, 20),
                        UnitLevel = 5,
                        IdUserSkill = 10
                    }, new SkillUnit
                    {
                        Id = 22,
                        Unitname = "White box",
                        StartDate = new DateTime(2021, 4, 20),
                        EndDate = new DateTime(2021, 5, 5),
                        UnitLevel = 5,
                        IdUserSkill = 10
                    }, new SkillUnit
                    {
                        Id = 23,
                        Unitname = "Gray box",
                        StartDate = new DateTime(2021, 5, 5),
                        EndDate = new DateTime(2021, 5, 20),
                        UnitLevel = 5,
                        IdUserSkill = 10
                    }, new SkillUnit
                    {
                        Id = 24,
                        Unitname = "Manual testing",
                        StartDate = new DateTime(2021, 5, 25),
                        EndDate = new DateTime(2021, 6, 10),
                        UnitLevel = 2,
                        IdUserSkill = 11
                    }, new SkillUnit
                    {
                        Id = 25,
                        Unitname = "Automated testing",
                        StartDate = new DateTime(2021, 6, 10),
                        EndDate = new DateTime(2021, 6, 20),
                        UnitLevel = 3,
                        IdUserSkill = 11
                    }, new SkillUnit
                    {
                        Id = 26,
                        Unitname = "Semiautomated testing",
                        StartDate = new DateTime(2021, 6, 20),
                        EndDate = new DateTime(2021, 7, 5),
                        UnitLevel = 4,
                        IdUserSkill = 11
                    }, new SkillUnit
                    {
                        Id = 27,
                        Unitname = "Component testing",
                        StartDate = new DateTime(2021, 7, 10),
                        EndDate = new DateTime(2021, 7, 25),
                        UnitLevel = 3,
                        IdUserSkill = 12
                    }, new SkillUnit
                    {
                        Id = 28,
                        Unitname = "Integration testing",
                        StartDate = new DateTime(2021, 7, 25),
                        EndDate = new DateTime(2021, 8, 10),
                        UnitLevel = 4,
                        IdUserSkill = 12
                    }, new SkillUnit
                    {
                        Id = 29,
                        Unitname = "System testing",
                        StartDate = new DateTime(2021, 8, 10),
                        EndDate = new DateTime(2021, 8, 15),
                        UnitLevel = 5,
                        IdUserSkill = 12
                    }, new SkillUnit
                    {
                        Id = 30,
                        Unitname = "IDEF0 design",
                        StartDate = new DateTime(2021, 8, 15),
                        EndDate = new DateTime(2021, 9, 1),
                        UnitLevel = 1,
                        IdUserSkill = 13
                    }, new SkillUnit
                    {
                        Id = 31,
                        Unitname = "DFD design",
                        StartDate = new DateTime(2021, 9, 1),
                        EndDate = new DateTime(2021, 9, 10),
                        UnitLevel = 2,
                        IdUserSkill = 13
                    }, new SkillUnit
                    {
                        Id = 32,
                        Unitname = "IDEF3 design",
                        StartDate = new DateTime(2021, 9, 10),
                        EndDate = new DateTime(2021, 9, 20),
                        UnitLevel = 3,
                        IdUserSkill = 13
                    }, new SkillUnit
                    {
                        Id = 33,
                        Unitname = "Class diagram",
                        StartDate = new DateTime(2021, 9, 25),
                        EndDate = new DateTime(2021, 10, 5),
                        UnitLevel = 3,
                        IdUserSkill = 14
                    }, new SkillUnit
                    {
                        Id = 34,
                        Unitname = "Use case diagram",
                        StartDate = new DateTime(2021, 10, 5),
                        EndDate = new DateTime(2021, 10, 15),
                        UnitLevel = 4,
                        IdUserSkill = 14
                    }, new SkillUnit
                    {
                        Id = 35,
                        Unitname = "Component diagram",
                        StartDate = new DateTime(2021, 10, 15),
                        EndDate = new DateTime(2021, 11, 1),
                        UnitLevel = 5,
                        IdUserSkill = 14
                    }, new SkillUnit
                    {
                        Id = 36,
                        Unitname = "Factory pattern",
                        StartDate = new DateTime(2021, 11, 5),
                        EndDate = new DateTime(2021, 11, 15),
                        UnitLevel = 5,
                        IdUserSkill = 15
                    }, new SkillUnit
                    {
                        Id = 37,
                        Unitname = "Moment pattern",
                        StartDate = new DateTime(2021, 11, 15),
                        EndDate = new DateTime(2021, 12, 1),
                        UnitLevel = 3,
                        IdUserSkill = 15
                    }, new SkillUnit
                    {
                        Id = 38,
                        Unitname = "Bridge pattern",
                        StartDate = new DateTime(2021, 12, 1),
                        EndDate = new DateTime(2021, 12, 10),
                        UnitLevel = 4,
                        IdUserSkill = 15
                    }, new SkillUnit
                    {
                        Id = 39,
                        Unitname = "Variables",
                        StartDate = new DateTime(2020, 2, 10),
                        EndDate = new DateTime(2020, 2, 20),
                        UnitLevel = 4,
                        IdUserSkill = 16
                    }, new SkillUnit
                    {
                        Id = 40,
                        Unitname = "Conditional expressions",
                        StartDate = new DateTime(2020, 2, 20),
                        EndDate = new DateTime(2020, 2, 28),
                        UnitLevel = 4,
                        IdUserSkill = 16
                    }, new SkillUnit
                    {
                        Id = 41,
                        Unitname = "Cycles",
                        StartDate = new DateTime(2020, 2, 28),
                        EndDate = new DateTime(2020, 3, 10),
                        UnitLevel = 4,
                        IdUserSkill = 16
                    }, new SkillUnit
                    {
                        Id = 42,
                        Unitname = "Functions and their parameters",
                        StartDate = new DateTime(2020, 3, 10),
                        EndDate = new DateTime(2020, 3, 20),
                        UnitLevel = 4,
                        IdUserSkill = 17
                    }, new SkillUnit
                    {
                        Id = 43,
                        Unitname = "Returning the result",
                        StartDate = new DateTime(2020, 3, 20),
                        EndDate = new DateTime(2020, 3, 30),
                        UnitLevel = 4,
                        IdUserSkill = 17
                    }, new SkillUnit
                    {
                        Id = 44,
                        Unitname = "Lambda expressions",
                        StartDate = new DateTime(2020, 3, 30),
                        EndDate = new DateTime(2020, 4, 10),
                        UnitLevel = 4,
                        IdUserSkill = 17
                    }, new SkillUnit
                    {
                        Id = 45,
                        Unitname = "Classes and objects",
                        StartDate = new DateTime(2020, 4, 10),
                        EndDate = new DateTime(2020, 4, 20),
                        UnitLevel = 4,
                        IdUserSkill = 18
                    }, new SkillUnit
                    {
                        Id = 46,
                        Unitname = "Visibility modifiers",
                        StartDate = new DateTime(2020, 4, 20),
                        EndDate = new DateTime(2020, 4, 30),
                        UnitLevel = 4,
                        IdUserSkill = 18
                    }, new SkillUnit
                    {
                        Id = 47,
                        Unitname = "Inheritance",
                        StartDate = new DateTime(2020, 4, 30),
                        EndDate = new DateTime(2020, 5, 10),
                        UnitLevel = 4,
                        IdUserSkill = 18
                    }, new SkillUnit
                    {
                        Id = 48,
                        Unitname = "Data types",
                        StartDate = new DateTime(2020, 5, 10),
                        EndDate = new DateTime(2020, 5, 20),
                        UnitLevel = 4,
                        IdUserSkill = 19
                    }, new SkillUnit
                    {
                        Id = 49,
                        Unitname = "Column and table attributes and constraints",
                        StartDate = new DateTime(2020, 5, 20),
                        EndDate = new DateTime(2020, 5, 30),
                        UnitLevel = 4,
                        IdUserSkill = 19
                    }, new SkillUnit
                    {
                        Id = 50,
                        Unitname = "Foreign Keys",
                        StartDate = new DateTime(2020, 5, 30),
                        EndDate = new DateTime(2020, 6, 10),
                        UnitLevel = 4,
                        IdUserSkill = 19
                    }, new SkillUnit
                    {
                        Id = 51,
                        Unitname = "Adding data. INSERT command",
                        StartDate = new DateTime(2020, 6, 10),
                        EndDate = new DateTime(2020, 6, 20),
                        UnitLevel = 4,
                        IdUserSkill = 20
                    }, new SkillUnit
                    {
                        Id = 52,
                        Unitname = "Data sampling. SELECT command",
                        StartDate = new DateTime(2020, 6, 20),
                        EndDate = new DateTime(2020, 6, 30),
                        UnitLevel = 4,
                        IdUserSkill = 20
                    }, new SkillUnit
                    {
                        Id = 53,
                        Unitname = "Filtration. WHERE",
                        StartDate = new DateTime(2020, 6, 30),
                        EndDate = new DateTime(2020, 7, 10),
                        UnitLevel = 4,
                        IdUserSkill = 20
                    }, new SkillUnit
                    {
                        Id = 54,
                        Unitname = "INNER JOIN",
                        StartDate = new DateTime(2020, 7, 10),
                        EndDate = new DateTime(2020, 7, 20),
                        UnitLevel = 4,
                        IdUserSkill = 21
                    }, new SkillUnit
                    {
                        Id = 55,
                        Unitname = "OUTER JOIN",
                        StartDate = new DateTime(2020, 7, 20),
                        EndDate = new DateTime(2020, 7, 30),
                        UnitLevel = 4,
                        IdUserSkill = 21
                    }, new SkillUnit
                    {
                        Id = 56,
                        Unitname = "UNION",
                        StartDate = new DateTime(2020, 7, 30),
                        EndDate = new DateTime(2020, 8, 10),
                        UnitLevel = 4,
                        IdUserSkill = 21
                    }, new SkillUnit
                    {
                        Id = 57,
                        Unitname = "Variables and data types",
                        StartDate = new DateTime(2020, 8, 10),
                        EndDate = new DateTime(2020, 8, 20),
                        UnitLevel = 4,
                        IdUserSkill = 22
                    }, new SkillUnit
                    {
                        Id = 58,
                        Unitname = "Conditional expressions",
                        StartDate = new DateTime(2020, 8, 20),
                        EndDate = new DateTime(2020, 8, 30),
                        UnitLevel = 4,
                        IdUserSkill = 22
                    }, new SkillUnit
                    {
                        Id = 59,
                        Unitname = "String operations",
                        StartDate = new DateTime(2020, 8, 30),
                        EndDate = new DateTime(2020, 9, 10),
                        UnitLevel = 4,
                        IdUserSkill = 22
                    }, new SkillUnit
                    {
                        Id = 60,
                        Unitname = "Random module",
                        StartDate = new DateTime(2020, 9, 10),
                        EndDate = new DateTime(2020, 9, 20),
                        UnitLevel = 4,
                        IdUserSkill = 23
                    }, new SkillUnit
                    {
                        Id = 61,
                        Unitname = "Math module",
                        StartDate = new DateTime(2020, 9, 20),
                        EndDate = new DateTime(2020, 9, 30),
                        UnitLevel = 4,
                        IdUserSkill = 23
                    }, new SkillUnit
                    {
                        Id = 62,
                        Unitname = "Locale module",
                        StartDate = new DateTime(2020, 9, 30),
                        EndDate = new DateTime(2020, 10, 10),
                        UnitLevel = 4,
                        IdUserSkill = 23
                    }, new SkillUnit
                    {
                        Id = 63,
                        Unitname = "Encapsulation",
                        StartDate = new DateTime(2020, 10, 10),
                        EndDate = new DateTime(2020, 10, 20),
                        UnitLevel = 4,
                        IdUserSkill = 24
                    }, new SkillUnit
                    {
                        Id = 64,
                        Unitname = "Inheritance",
                        StartDate = new DateTime(2020, 10, 20),
                        EndDate = new DateTime(2020, 10, 30),
                        UnitLevel = 4,
                        IdUserSkill = 24
                    }, new SkillUnit
                    {
                        Id = 65,
                        Unitname = "Polymorphism",
                        StartDate = new DateTime(2020, 10, 30),
                        EndDate = new DateTime(2020, 11, 10),
                        UnitLevel = 4,
                        IdUserSkill = 24
                    }, new SkillUnit
                    {
                        Id = 66,
                        Unitname = "The input and textarea elements",
                        StartDate = new DateTime(2019, 3, 10),
                        EndDate = new DateTime(2019, 3, 20),
                        UnitLevel = 4,
                        IdUserSkill = 25
                    }, new SkillUnit
                    {
                        Id = 67,
                        Unitname = "Select list",
                        StartDate = new DateTime(2019, 3, 20),
                        EndDate = new DateTime(2019, 3, 30),
                        UnitLevel = 4,
                        IdUserSkill = 25
                    }, new SkillUnit
                    {
                        Id = 68,
                        Unitname = "Modifiers",
                        StartDate = new DateTime(2019, 3, 30),
                        EndDate = new DateTime(2019, 4, 10),
                        UnitLevel = 4,
                        IdUserSkill = 25
                    }, new SkillUnit
                    {
                        Id = 69,
                        Unitname = "Component state and behavior",
                        StartDate = new DateTime(2019, 4, 10),
                        EndDate = new DateTime(2019, 4, 20),
                        UnitLevel = 4,
                        IdUserSkill = 26
                    }, new SkillUnit
                    {
                        Id = 70,
                        Unitname = "Props",
                        StartDate = new DateTime(2019, 4, 20),
                        EndDate = new DateTime(2019, 4, 30),
                        UnitLevel = 4,
                        IdUserSkill = 26
                    }, new SkillUnit
                    {
                        Id = 71,
                        Unitname = "Parent and child components",
                        StartDate = new DateTime(2019, 4, 30),
                        EndDate = new DateTime(2019, 5, 10),
                        UnitLevel = 4,
                        IdUserSkill = 26
                    }, new SkillUnit
                    {
                        Id = 72,
                        Unitname = "Defining routes",
                        StartDate = new DateTime(2019, 5, 10),
                        EndDate = new DateTime(2019, 5, 20),
                        UnitLevel = 4,
                        IdUserSkill = 27
                    }, new SkillUnit
                    {
                        Id = 73,
                        Unitname = "Route parameters",
                        StartDate = new DateTime(2019, 5, 20),
                        EndDate = new DateTime(2019, 5, 30),
                        UnitLevel = 4,
                        IdUserSkill = 27
                    }, new SkillUnit
                    {
                        Id = 74,
                        Unitname = "Nested routes",
                        StartDate = new DateTime(2019, 5, 30),
                        EndDate = new DateTime(2019, 6, 10),
                        UnitLevel = 4,
                        IdUserSkill = 27
                    }, new SkillUnit
                    {
                        Id = 75,
                        Unitname = "Components",
                        StartDate = new DateTime(2019, 6, 10),
                        EndDate = new DateTime(2019, 6, 20),
                        UnitLevel = 4,
                        IdUserSkill = 28
                    }, new SkillUnit
                    {
                        Id = 76,
                        Unitname = "Binding",
                        StartDate = new DateTime(2019, 6, 20),
                        EndDate = new DateTime(2019, 6, 30),
                        UnitLevel = 4,
                        IdUserSkill = 28
                    }, new SkillUnit
                    {
                        Id = 77,
                        Unitname = "Component life cycle",
                        StartDate = new DateTime(2019, 6, 30),
                        EndDate = new DateTime(2019, 7, 10),
                        UnitLevel = 4,
                        IdUserSkill = 28
                    }, new SkillUnit
                    {
                        Id = 78,
                        Unitname = "ngClass and ngStyle",
                        StartDate = new DateTime(2019, 7, 10),
                        EndDate = new DateTime(2019, 7, 20),
                        UnitLevel = 4,
                        IdUserSkill = 29
                    }, new SkillUnit
                    {
                        Id = 79,
                        Unitname = "Getting parameters in directives",
                        StartDate = new DateTime(2019, 7, 20),
                        EndDate = new DateTime(2019, 7, 30),
                        UnitLevel = 4,
                        IdUserSkill = 29
                    }, new SkillUnit
                    {
                        Id = 80,
                        Unitname = "ngIf, ngFor, ngSwitch",
                        StartDate = new DateTime(2019, 7, 30),
                        EndDate = new DateTime(2019, 8, 10),
                        UnitLevel = 4,
                        IdUserSkill = 29
                    }, new SkillUnit
                    {
                        Id = 81,
                        Unitname = "HttpClient and Sending Requests",
                        StartDate = new DateTime(2019, 8, 10),
                        EndDate = new DateTime(2019, 8, 20),
                        UnitLevel = 4,
                        IdUserSkill = 30
                    }, new SkillUnit
                    {
                        Id = 82,
                        Unitname = "Observable and RxJS library",
                        StartDate = new DateTime(2019, 8, 20),
                        EndDate = new DateTime(2019, 8, 30),
                        UnitLevel = 4,
                        IdUserSkill = 30
                    }, new SkillUnit
                    {
                        Id = 83,
                        Unitname = "Sending data in a request",
                        StartDate = new DateTime(2019, 8, 30),
                        EndDate = new DateTime(2019, 9, 10),
                        UnitLevel = 4,
                        IdUserSkill = 30
                    }, new SkillUnit
                    {
                        Id = 84,
                        Unitname = "Components",
                        StartDate = new DateTime(2019, 9, 10),
                        EndDate = new DateTime(2019, 9, 20),
                        UnitLevel = 4,
                        IdUserSkill = 31
                    }, new SkillUnit
                    {
                        Id = 85,
                        Unitname = "Props",
                        StartDate = new DateTime(2019, 9, 20),
                        EndDate = new DateTime(2019, 9, 30),
                        UnitLevel = 4,
                        IdUserSkill = 31
                    }, new SkillUnit
                    {
                        Id = 86,
                        Unitname = "State",
                        StartDate = new DateTime(2019, 9, 30),
                        EndDate = new DateTime(2019, 10, 10),
                        UnitLevel = 4,
                        IdUserSkill = 31
                    }, new SkillUnit
                    {
                        Id = 87,
                        Unitname = "Working with forms",
                        StartDate = new DateTime(2019, 10, 10),
                        EndDate = new DateTime(2019, 10, 20),
                        UnitLevel = 4,
                        IdUserSkill = 32
                    }, new SkillUnit
                    {
                        Id = 88,
                        Unitname = "Form validation",
                        StartDate = new DateTime(2019, 10, 20),
                        EndDate = new DateTime(2019, 10, 30),
                        UnitLevel = 4,
                        IdUserSkill = 32
                    }, new SkillUnit
                    {
                        Id = 89,
                        Unitname = "Refs",
                        StartDate = new DateTime(2019, 10, 30),
                        EndDate = new DateTime(2019, 11, 10),
                        UnitLevel = 4,
                        IdUserSkill = 32
                    }, new SkillUnit
                    {
                        Id = 90,
                        Unitname = "useState",
                        StartDate = new DateTime(2019, 11, 10),
                        EndDate = new DateTime(2019, 11, 20),
                        UnitLevel = 4,
                        IdUserSkill = 33
                    }, new SkillUnit
                    {
                        Id = 91,
                        Unitname = "useEffect",
                        StartDate = new DateTime(2019, 11, 20),
                        EndDate = new DateTime(2019, 11, 30),
                        UnitLevel = 4,
                        IdUserSkill = 33
                    }, new SkillUnit
                    {
                        Id = 92,
                        Unitname = "useRef",
                        StartDate = new DateTime(2019, 11, 30),
                        EndDate = new DateTime(2019, 12, 10),
                        UnitLevel = 4,
                        IdUserSkill = 33
                    });
            });
            
            modelBuilder.Entity<Certificate>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKCertificate");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Certificate");

                entity.Property(e => e.CertificateTitle)
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.HasOne(c => c.IdPublisherNavigation)
                .WithMany(e => e.Certificates)
                .HasForeignKey(c => c.IdPublisher)
                .HasConstraintName("R_17");

                entity.HasOne(c => c.IdRecipientNavigation)
                .WithMany(e => e.Certificates)
                .HasForeignKey(c => c.IdRecipient)
                .HasConstraintName("R_18");

                entity.HasOne(c => c.IdUserSkillNavigation)
                .WithMany(e => e.Certificates)
                .HasForeignKey(c => c.IdUserSkill)
                .HasConstraintName("R_19");
            });

            modelBuilder.Entity<Company>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKCompany");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Company");

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.HasData(
                    new Company 
                    {
                        Id = 1,
                        Name = "InterLogic",
                        EmployeesCount = 500,
                        Description = "Some description about company",
                        Specialization = "Software",
                        Address = "Lviv, Grabovskogo 11",
                        ContactPhone = "032-297-46-55"
                    });
            });

            modelBuilder.Entity<RecMember>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKRecMember");

                entity.Property(e => e.Id)
                .HasColumnName("Id_RecMember");

                entity.HasOne(rm => rm.IdRecommendNavigation)
                .WithMany(r => r.RecMembers)
                .HasForeignKey(rm => rm.IdRecommend)
                .HasConstraintName("R_20");

                entity.HasOne(rm => rm.IdTrainingNavigation)
                .WithMany(t => t.RecMembers)
                .HasForeignKey(rm => rm.IdTraining)
                .HasConstraintName("R_21");
            });

            modelBuilder.Entity<Recommendation>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKRecommendation");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Recommendation");

                entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.HasOne(r => r.IdEmployeeNavigation)
                .WithMany(e => e.Recommendations)
                .HasForeignKey(r => r.IdEmployee)
                .HasConstraintName("R_22");
            });

            modelBuilder.Entity<SkillMetric>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKSkillMetric");

                entity.Property(e => e.Id)
                .HasColumnName("Id_SkillMetric");

                entity.Property(e => e.MetricName)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasOne(m => m.IdSkillUnitNavigation)
                .WithMany(s => s.SkillMetrics)
                .HasForeignKey(m => m.IdSkillUnit)
                .HasConstraintName("R_23");
            });

            modelBuilder.Entity<Statistics>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKStatistics");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Statistics");

                entity.HasOne(s => s.IdEmployeeNavigation)
                .WithMany(e => e.Statisticses)
                .HasForeignKey(s => s.IdEmployee)
                .HasConstraintName("R_24");
            });

            modelBuilder.Entity<Training>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKTraining");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Training");

                entity.Property(e => e.TrainingTitle)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.HasOne(t => t.IdCategoryNavigation)
                .WithMany(c => c.Trainings)
                .HasForeignKey(t => t.IdCategory)
                .HasConstraintName("R_25");

                entity.HasOne(t => t.IdCoachNavigation)
                .WithMany(e => e.Trainings)
                .HasForeignKey(t => t.IdCoach)
                .HasConstraintName("R_26");
            });

            modelBuilder.Entity<TrainingMember>(entity => {
                entity.HasKey(e => e.Id)
                .HasName("XPKTrainingMember");

                entity.Property(e => e.Id)
                .HasColumnName("Id_TrainingMember");

                entity.HasOne(t => t.IdMemberNavigation)
                .WithMany(e => e.TrainingMembers)
                .HasForeignKey(t => t.IdMember)
                .HasConstraintName("R_27");

                entity.HasOne(t => t.IdTrainingNavigation)
                .WithMany(tr => tr.TrainingMembers)
                .HasForeignKey(t => t.IdTraining)
                .HasConstraintName("R_28");
            });
        }
    }
}
