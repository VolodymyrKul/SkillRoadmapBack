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

                entity.HasData(
                    new Employee {
                        Id = 1,
                        Firstname = "Oksana",
                        Lastname = "Iliv",
                        Email = "ilivocs@gmail.com",
                        Password = "_Aa123456",
                        Role = "User",
                        DevLevel = "Trainee C#",
                        Experience = 5
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
                        Experience = 5
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
                        Experience = 5
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
                        Experience = 5
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
                        Experience = 5
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
                        Role = "Employer"
                    },
                    new Employer
                    {
                        Id = 2,
                        Firstname = "Volodymyr",
                        Lastname = "Shevchenko",
                        Email = "shevchenkovol@gmail.com",
                        Password = "_Aa123456",
                        Role = "Employer"
                    },
                    new Employer
                    {
                        Id = 3,
                        Firstname = "Oleksandr",
                        Lastname = "Boiko",
                        Email = "boikoolek@gmail.com",
                        Password = "_Aa123456",
                        Role = "Employer"
                    },
                    new Employer
                    {
                        Id = 4,
                        Firstname = "Ivan",
                        Lastname = "Kovalenko",
                        Email = "kovalenkoiv@gmail.com",
                        Password = "_Aa123456",
                        Role = "Employer"
                    },
                    new Employer
                    {
                        Id = 5,
                        Firstname = "Vasyl",
                        Lastname = "Bondarenko",
                        Email = "bondarenkovas@gmail.com",
                        Password = "_Aa123456",
                        Role = "Employer"
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

                entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasOne(us => us.IdEmployeeNavigation)
                .WithMany(e => e.UserSkills)
                .HasForeignKey(us => us.IdEmployee)
                .HasConstraintName("R_1");

                entity.HasData(
                    new UserSkill {
                        Id = 1,
                        Skillname = "С# Basics",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    },
                    new UserSkill
                    {
                        Id = 2,
                        Skillname = "C# Classes OOP",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    },
                    new UserSkill
                    {
                        Id = 3,
                        Skillname = "C# Exception",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    },
                    new UserSkill
                    {
                        Id = 4,
                        Skillname = "C# Delegate",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 5,
                        Skillname = "C# Interface",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 6,
                        Skillname = "C# Collections",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 7,
                        Skillname = "C# String",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 8,
                        Skillname = "C# Variables",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 9,
                        Skillname = "C# Data types",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 10,
                        Skillname = "C# Cycles",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 11,
                        Skillname = "C# Classes and objects",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 12,
                        Skillname = "C# Structures",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 13,
                        Skillname = "C# Access modifiers",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 14,
                        Skillname = "C# Try..catch..finally",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 15,
                        Skillname = "C# Exception types. Exception class",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 16,
                        Skillname = "C# Creating Exception Classes",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 17,
                        Skillname = "C# Delegates",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 18,
                        Skillname = "C# Lambdas",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 19,
                        Skillname = "C# Anonymous methods",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
                        IdEmployee = 1
                    }, new UserSkill
                    {
                        Id = 20,
                        Skillname = "C# Defining interfaces",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2021, 2, 1),
                        Category = "Hard skill",
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
                        CommentText = "Tmp",
                        IdEmployer = 1,
                        IdUserSkill = 8
                    },
                    new Comment
                    {
                        Id = 2,
                        CommentText = "Tmp",
                        IdEmployer = 1,
                        IdUserSkill = 9
                    },
                    new Comment
                    {
                        Id = 3,
                        CommentText = "Tmp",
                        IdEmployer = 1,
                        IdUserSkill = 10
                    },
                    new Comment
                    {
                        Id = 4,
                        CommentText = "Tmp",
                        IdEmployer = 1,
                        IdUserSkill = 11
                    },
                    new Comment
                    {
                        Id = 5,
                        CommentText = "Tmp",
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
                        NotificationText = "Tmp",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 8
                    },
                    new Notification
                    {
                        Id = 2,
                        NotificationText = "Tmp",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 9
                    },
                    new Notification
                    {
                        Id = 3,
                        NotificationText = "Tmp",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 10
                    },
                    new Notification
                    {
                        Id = 4,
                        NotificationText = "Tmp",
                        SendingDate = new DateTime(2021, 1, 1),
                        IsRead = false,
                        IdEmployee = 1,
                        IdEmployer = 1,
                        IdUserSkill = 11
                    },
                    new Notification
                    {
                        Id = 5,
                        NotificationText = "Tmp",
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
                    });
            });
        }
    }
}
