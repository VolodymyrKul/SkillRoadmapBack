using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SkillRoadmapBack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillRoadMapBack.DAL
{
    public class CustomDataGenerator
    {
        IRandomizerString randomizerFirstName { get; set; }
        IRandomizerString randomizerLastName { get; set; }
        Random rand { get; set; }
        public CustomDataGenerator()
        {
            randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            randomizerLastName = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            rand = new Random();
        }
        public List<UserSkill> genUserSkills { get; set; }
        public List<SkillUnit> genSkillUnits { get; set; }
        public List<Training> genTrainings { get; set; }
        public List<SkillTemplate> genSkillTemplates { get; set; }
        public List<Requirement> genRequirements { get; set; }
        public List<Statistics> genStatisticss { get; set; }

        public List<Employee> GenerateEmployees(int count, int mentorsCount, int companiesCount)
        {
            //var rand = new Random();
            //var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            //var randomizerLastName = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            List<Employee> employees = new List<Employee>();
            List<string> devTitles = new List<string>() { "C", "C++", "Java", "C#", "Python", "JS", "Kotlin", "Php", "Ruby", "Go", "Swift", "Sql" };
            List<string> devLvls = new List<string>() { "Trainee", "Junior", "Middle", "Senior" };
            for (int i = 0; i < count; i++)
            {
                var firstname = randomizerFirstName.Generate();
                var lastname = randomizerLastName.Generate();
                employees.Add(new Employee
                {
                    Id = i + 1,
                    Firstname = firstname,
                    Lastname = lastname,
                    Email = lastname.ToLower().Substring(0, 2) + "_" + firstname.ToLower().Substring(0, 2) + "@gmail.com",
                    Password = "_Aa123456",
                    Role = "User",
                    DevLevel = "Trainee C#"/*devLvls[rand.Next(0, devLvls.Count + 1)] + " " + devTitles[rand.Next(0, devTitles.Count + 1)]*/,
                    Experience = rand.Next(1, 21),
                    IdMentor = rand.Next(1,mentorsCount),
                    IdCompany = rand.Next(1, companiesCount)
                });
            }
            return employees;
        }

        public List<Employer> GenerateEmployers(int mentorsCount, int hrCount, int companiesCount)
        {
            //var rand = new Random();
            //var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            //var randomizerLastName = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            List<Employer> employers = new List<Employer>();
            List<string> devTitles = new List<string>() { "C", "C++", "Java", "C#", "Python", "JS", "Kotlin", "Php", "Ruby", "Go", "Swift", "Sql" };
            List<string> devLvls = new List<string>() { "Trainee", "Junior", "Middle", "Senior" };
            for (int i = 0; i < mentorsCount; i++)
            {
                var firstname = randomizerFirstName.Generate();
                var lastname = randomizerLastName.Generate();
                employers.Add(new Employer
                {
                    Id = i + 1,
                    Firstname = firstname,
                    Lastname = lastname,
                    Email = lastname.ToLower().Substring(0, 2) + "_" + firstname.ToLower().Substring(0, 2) + "@gmail.com",
                    Password = "_Aa123456",
                    Role = "Mentor",
                    IdCompany = rand.Next(1, companiesCount)
                });
            }
            for (int i = mentorsCount; i < mentorsCount + hrCount; i++)
            {
                var firstname = randomizerFirstName.Generate();
                var lastname = randomizerLastName.Generate();
                employers.Add(new Employer
                {
                    Id = i + 1,
                    Firstname = firstname,
                    Lastname = lastname,
                    Email = lastname.ToLower().Substring(0, 2) + "_" + firstname.ToLower().Substring(0, 2) + "@gmail.com",
                    Password = "_Aa123456",
                    Role = "HR",
                    IdCompany = rand.Next(1, companiesCount)
                });
            }
            return employers;
        }

        public List<UserSkill> GenerateSkills(int userCount)
        {
            List<string> devTitles = new List<string>() 
            {   "C",
                "Java",
                "Python", 
                "C++", 
                "C#", 
                "Visual Basic", 
                "JavaScript", 
                "Assembly", 
                "PHP", 
                "SQL", 
                "Classic Visual Basic", 
                "Delphi",
                "Ruby",
                "Go",
                "Swift",
                "R",
                "Groovy",
                "Perl",
                "MATLAB",
                "Frotran",
                "SAS",
                "Scratch",
                "Objective-C",
                "COBOL",
                "Prolog",
                "Scala",
                "PL/SQL",
                "Transact-SQL",
                "Rust",
                "Ada",
                "D",
                "Julia",
                "FoxPro",
                "Dart",
                "ABAP",
                "Lisp",
                "Lua",
                "Logo",
                "Kotlin",
                "LabVIEW",
                "VBScript",
                "Bash",
                "VHDL",
                "Ladder Logic",
                "Awk",
                "Apex",
                "RPG",
                "Elixir",
                "PowerShell",
                "TypeScript"
            };

            List<UserSkill> userSkills = new List<UserSkill>();
            //Random rand = new Random();

            for(int j = 0; j < userCount; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    int year = 2019 + k;
                    for(int p = 0; p < 3; p++)
                    {
                        int cat = rand.Next(1, 7);
                        int month1 = rand.Next(1, 11);
                        int month2 = rand.Next(1, 11);
                        int date1 = rand.Next(1, 28);
                        int date2 = rand.Next(1, 28);
                        userSkills.Add(new UserSkill
                        {
                            Id = 18 * j + 6 * k + 2 * p + 1,
                            Skillname = devTitles[rand.Next(0, devTitles.Count)] + " language",
                            StartDate = new DateTime(year, month1, date1),
                            EndDate = new DateTime(year, month1 + 2, date1),
                            IdCategory = cat,
                            SkillLevel = rand.Next(1, 6),
                            IdEmployee = j + 1
                        });

                        userSkills.Add(new UserSkill
                        {
                            Id = 18 * j + 6 * k + 2 * p + 2,
                            Skillname = devTitles[rand.Next(0, devTitles.Count)] + " language",
                            StartDate = new DateTime(year, month2, date2),
                            EndDate = new DateTime(year, month2 + 2, date2),
                            IdCategory = cat,
                            SkillLevel = rand.Next(1, 6),
                            IdEmployee = j + 1
                        });
                    }
                }
            }
            genUserSkills = userSkills;
            return userSkills;
        }

        public List<SkillUnit> GenerateUnits()
        {
            //Random rand = new Random();
            List<string> SkillUnitsTitle = new List<string>()
            {
                "Inside a program",
                "Command-line arguments",
                "Programming Concepts",
                "Statements",
                "Expressions",
                "Operators",
                "Types",
                "Classes",
                "Structs",
                "Records",
                "Interfaces",
                "Delegates",
                "Arrays",
                "Strings",
                "Indexers",
                "Events",
                "Generics",
                "Namespaces",
                "XML documentation",
                "Exceptions",
                "Exception Handling",
                "File system",
                "Registry",
                "Interoperability"
            };
            List<SkillUnit> skillUnits = new List<SkillUnit>();
            for(int i = 0; i < genUserSkills.Count; i++)
            {
                string skill = genUserSkills[i].Skillname.Substring(0, genUserSkills[i].Skillname.Length - 9);
                DateTime newDate = genUserSkills[i].StartDate.AddDays(rand.Next(11,19));
                DateTime secDate = newDate;
                skillUnits.Add(new SkillUnit
                {
                    Id = i * 4 + 1,
                    Unitname = SkillUnitsTitle[rand.Next(0, SkillUnitsTitle.Count)],
                    StartDate = genUserSkills[i].StartDate,
                    EndDate = newDate,
                    UnitLevel = rand.Next(1,6),
                    IdUserSkill = genUserSkills[i].Id
                });
                newDate = newDate.AddDays(rand.Next(11, 19));
                skillUnits.Add(new SkillUnit
                {
                    Id = i * 4 + 2,
                    Unitname = SkillUnitsTitle[rand.Next(0, SkillUnitsTitle.Count)],
                    StartDate = secDate,
                    EndDate = newDate,
                    UnitLevel = rand.Next(1, 6),
                    IdUserSkill = genUserSkills[i].Id
                });
                secDate = newDate;
                newDate = newDate.AddDays(rand.Next(11, 19));
                skillUnits.Add(new SkillUnit
                {
                    Id = i * 4 + 3,
                    Unitname = SkillUnitsTitle[rand.Next(0, SkillUnitsTitle.Count)],
                    StartDate = secDate,
                    EndDate = newDate,
                    UnitLevel = rand.Next(1, 6),
                    IdUserSkill = genUserSkills[i].Id
                });
                skillUnits.Add(new SkillUnit
                {
                    Id = i * 4 + 4,
                    Unitname = SkillUnitsTitle[rand.Next(0, SkillUnitsTitle.Count)],
                    StartDate = newDate,
                    EndDate = genUserSkills[i].EndDate,
                    UnitLevel = rand.Next(1, 6),
                    IdUserSkill = genUserSkills[i].Id
                });
            }
            genSkillUnits = skillUnits;
            return skillUnits;
        }

        public List<SkillMetric> GenerateMetrics() 
        {
            List<string> SkillMetricsTitle = new List<string>()
            {
                "Goal management",
                "Subjective assessment",
                "Production defects",
                "Number of errors",
                "Net Promoter Score",
                "Feedback",
                "Forced rating",
                "Number of sales",
                "Number of units produced",
                "Processing time",
                "Work efficiency",
                "The pass rate",
                "Overtime"
            };
            //Random rand = new Random();
            List<SkillMetric> skillMetrics = new List<SkillMetric>();
            for (int i = 0; i < genUserSkills.Count; i++)
            {
                skillMetrics.Add(new SkillMetric
                {
                    Id = i * 3 + 1,
                    IdUserSkill = genUserSkills[i].Id,
                    MetricName = SkillMetricsTitle[rand.Next(1, SkillMetricsTitle.Count)],
                    MetricValue = rand.Next(1,6),
                    MetricInfluence = 0.4
                });

                skillMetrics.Add(new SkillMetric
                {
                    Id = i * 3 + 2,
                    IdUserSkill = genUserSkills[i].Id,
                    MetricName = SkillMetricsTitle[rand.Next(1, SkillMetricsTitle.Count)],
                    MetricValue = rand.Next(1, 6),
                    MetricInfluence = 0.3
                });

                skillMetrics.Add(new SkillMetric
                {
                    Id = i * 3 + 3,
                    IdUserSkill = genUserSkills[i].Id,
                    MetricName = SkillMetricsTitle[rand.Next(1, SkillMetricsTitle.Count)],
                    MetricValue = rand.Next(1, 6),
                    MetricInfluence = 0.3
                });
            }
            return skillMetrics;
        }

        public List<Comment> GenerateComments(int mentorsCount)
        {
            //Random rand = new Random();
            List<string> SkillUnitsTitle = new List<string>()
            {
                "Inside a program",
                "Command-line arguments",
                "Programming Concepts",
                "Statements",
                "Expressions",
                "Operators",
                "Types",
                "Classes",
                "Structs",
                "Records",
                "Interfaces",
                "Delegates",
                "Arrays",
                "Strings",
                "Indexers",
                "Events",
                "Generics",
                "Namespaces",
                "XML documentation",
                "Exceptions",
                "Exception Handling",
                "File system",
                "Registry",
                "Interoperability"
            };
            List<Comment> comments = new List<Comment>();
            for (int i = 0; i < genUserSkills.Count; i++) 
            {
                for(int j = 0; j < 10; j++)
                {
                    comments.Add(new Comment
                    {
                        Id = i * 10 + j + 1,
                        CommentText = "You need to read this unit: " + SkillUnitsTitle[rand.Next(1, SkillUnitsTitle.Count)],
                        IdEmployer = rand.Next(1, mentorsCount),
                        IdUserSkill = genUserSkills[i].Id
                    });
                }
            }
            return comments;
        }

        public List<Notification> GenerateNotifications(int employerCount)
        {
            //Random rand = new Random();
            
            List<Notification> notifications = new List<Notification>();
            for (int i = 0; i < genUserSkills.Count; i++)
            {
                notifications.Add(new Notification 
                {
                    Id = i * 3 + 1,
                    NotificationText = "I got acquainted with your skill: " + genUserSkills[i].Skillname + ". And I have an offer for you.",
                    SendingDate = new DateTime(2021, rand.Next(1, 11), rand.Next(1,28)),
                    IsRead = false,
                    IdEmployee = genUserSkills[i].IdEmployee,
                    IdEmployer = rand.Next(1,employerCount)
                });
                notifications.Add(new Notification
                {
                    Id = i * 3 + 2,
                    NotificationText = "I got acquainted with your skill: " + genUserSkills[i].Skillname + ". And I have an offer for you.",
                    SendingDate = new DateTime(2021, rand.Next(1, 11), rand.Next(1, 28)),
                    IsRead = false,
                    IdEmployee = genUserSkills[i].IdEmployee,
                    IdEmployer = rand.Next(1, employerCount)
                });
                notifications.Add(new Notification
                {
                    Id = i * 3 + 3,
                    NotificationText = "I got acquainted with your skill: " + genUserSkills[i].Skillname + ". And I have an offer for you.",
                    SendingDate = new DateTime(2021, rand.Next(1, 11), rand.Next(1, 28)),
                    IsRead = false,
                    IdEmployee = genUserSkills[i].IdEmployee,
                    IdEmployer = rand.Next(1, employerCount)
                });
            }
            return notifications;
        }

        public List<Certificate> GenerateCertificate(int employerCount)
        {
            //Random rand = new Random();

            List<Certificate> certificates = new List<Certificate>();
            for (int i = 0; i < genUserSkills.Count; i++)
            {
                DateTime date1 = new DateTime(2020, rand.Next(1, 11), rand.Next(1, 28));
                DateTime date2 = date1.AddDays(rand.Next(100, 251));
                certificates.Add(new Certificate
                {
                    Id = i * 3 + 1,
                    IdUserSkill = genUserSkills[i].Id,
                    IdPublisher = rand.Next(1, employerCount),
                    IdRecipient = genUserSkills[i].IdEmployee,
                    CertificateTitle = "Our company present you certificate",
                    DateOfIssue = date1,
                    ExpiryDate = date2,
                    SkillLevel = rand.Next(2, 6)
                });

                date1 = new DateTime(2020, rand.Next(1, 11), rand.Next(1, 28));
                date2 = date1.AddDays(rand.Next(100, 251));
                certificates.Add(new Certificate
                {
                    Id = i * 3 + 2,
                    IdUserSkill = genUserSkills[i].Id,
                    IdPublisher = rand.Next(1, employerCount),
                    IdRecipient = genUserSkills[i].IdEmployee,
                    CertificateTitle = "Our company present you certificate",
                    DateOfIssue = date1,
                    ExpiryDate = date2,
                    SkillLevel = rand.Next(2, 6)
                });

                date1 = new DateTime(2020, rand.Next(1, 11), rand.Next(1, 28));
                date2 = date1.AddDays(rand.Next(100, 251));
                certificates.Add(new Certificate
                {
                    Id = i * 3 + 3,
                    IdUserSkill = genUserSkills[i].Id,
                    IdPublisher = rand.Next(1, employerCount),
                    IdRecipient = genUserSkills[i].IdEmployee,
                    CertificateTitle = "Our company present you certificate",
                    DateOfIssue = date1,
                    ExpiryDate = date2,
                    SkillLevel = rand.Next(2, 6)
                });
            }
            return certificates;
        }

        public List<Training> GenerateTraining(int mentorsCount)
        {
            //Random rand = new Random();

            List<string> devTitles = new List<string>()
            {   "C",
                "Java",
                "Python",
                "C++",
                "C#",
                "Visual Basic",
                "JavaScript",
                "Assembly",
                "PHP",
                "SQL",
                "Classic Visual Basic",
                "Delphi",
                "Ruby",
                "Go",
                "Swift",
                "R",
                "Groovy",
                "Perl",
                "MATLAB",
                "Frotran",
                "SAS",
                "Scratch",
                "Objective-C",
                "COBOL",
                "Prolog",
                "Scala",
                "PL/SQL",
                "Transact-SQL",
                "Rust",
                "Ada",
                "D",
                "Julia",
                "FoxPro",
                "Dart",
                "ABAP",
                "Lisp",
                "Lua",
                "Logo",
                "Kotlin",
                "LabVIEW",
                "VBScript",
                "Bash",
                "VHDL",
                "Ladder Logic",
                "Awk",
                "Apex",
                "RPG",
                "Elixir",
                "PowerShell",
                "TypeScript"
            };

            List<string> SkillUnitsTitle = new List<string>()
            {
                "Inside a program",
                "Command-line arguments",
                "Programming Concepts",
                "Statements",
                "Expressions",
                "Operators",
                "Types",
                "Classes",
                "Structs",
                "Records",
                "Interfaces",
                "Delegates",
                "Arrays",
                "Strings",
                "Indexers",
                "Events",
                "Generics",
                "Namespaces",
                "XML documentation",
                "Exceptions",
                "Exception Handling",
                "File system",
                "Registry",
                "Interoperability"
            };
            List<Training> trainings = new List<Training>();
            for (int i = 0; i < mentorsCount; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    string titlePart1 = devTitles[rand.Next(1, devTitles.Count)];
                    string titlePart2 = SkillUnitsTitle[rand.Next(1, SkillUnitsTitle.Count)];
                    DateTime date1 = new DateTime(2021, rand.Next(1, 11), rand.Next(1, 28));
                    DateTime date2 = date1.AddDays(rand.Next(30, 90));
                    trainings.Add(new Training
                    {
                        Id = i * 10 + j + 1,
                        TrainingTitle = titlePart1 + ". " + titlePart2,
                        Description = $"In today's world {titlePart1} is one of the most popular and highly paid technologies. As part of our training we will consider such an area of technology as {titlePart2}",
                        TrainingLevel = rand.Next(1, 6),
                        StartDate = date1,
                        EndDate = date2,
                        Payment = rand.Next(0, 2000),
                        IdCoach = i + 1,
                        IdCategory = rand.Next(1, 7)
                    });
                }
            }
            genTrainings = trainings;
            return trainings;
        }

        public List<TrainingMember> GenerateTrainingMember(int employeeCount)
        {
            //Random rand = new Random();
            DateTime currentDate = DateTime.Now;
            List<TrainingMember> trainingMembers = new List<TrainingMember>();
            for (int i = 0; i < genTrainings.Count; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    var diff = genTrainings[i].EndDate - currentDate;
                    trainingMembers.Add(new TrainingMember
                    {
                        Id = i * 10 + j + 1,
                        IdTraining = genTrainings[i].Id,
                        IdMember = rand.Next(1, employeeCount),
                        IsEnded = diff.Days > 0 ? true : false
                    });
                }
            }
            return trainingMembers;
        }

        public List<Recommendation> GenerateRecommendation(int employeeCount)
        {
            //Random rand = new Random();

            List<Recommendation> recommendations = new List<Recommendation>();
            for (int i = 0; i < genTrainings.Count; i++)
            {
                List<int> curList = new List<int>();
                while (curList.Count < 10)
                {
                    int tmp = rand.Next(1, employeeCount);
                    bool IsRepeat = false;
                    foreach (var item in curList)
                    {
                        if (item == tmp)
                        {
                            IsRepeat = true;
                            break;
                        }
                    }
                    if (!IsRepeat)
                    {
                        curList.Add(tmp);
                    }
                }
                for (int j = 0; j < curList.Count; j++)
                {
                    var invNum = rand.Next(1, 6);
                    string invitation = "";
                    if(invNum == 1)
                    {
                        invitation = "Hi. How are you ? I have a great offer. I would like to invite you to join my training in technology such as " + genTrainings[i].TrainingTitle;
                    }
                    if (invNum == 2)
                    {
                        invitation = "Hi there. I opened a training on technology " + genTrainings[i].TrainingTitle + ". Interesting topics will be considered. Wouldn't like to join?";
                    }
                    if (invNum == 3)
                    {
                        invitation = "Only today is a unique offer. You can learn technology " + genTrainings[i].TrainingTitle + " with a great mentor in a training designed specifically for people as smart as you";
                    }
                    if (invNum == 4)
                    {
                        invitation = "You want to know and be able to work with technology " + genTrainings[i].TrainingTitle + " that will be in demand for many years to come. To you to us.";
                    }
                    if (invNum == 5)
                    {
                        invitation = "You dream of becoming a first-class specialist. You just need to gain knowledge in technology " + genTrainings[i].TrainingTitle + ". This training is for you.";
                    }
                    recommendations.Add(new Recommendation
                    {
                        Id = i * curList.Count + j + 1,
                        IdTraining = genTrainings[i].Id,
                        IdEmployee = curList[j],
                        IsUsed = false,
                        Invitation = invitation
                    });
                }
            }
            return recommendations;
        }

        public List<SkillTemplate> GenerateSkillTemplate(int templateCount)
        {
            //Random rand = new Random();

            List<string> devTitles = new List<string>() { "C", "C++", "Java", "C#", "Python", "JS", "Kotlin", "Php", "Ruby", "Go", "Swift", "Sql", "Angular", "React", "VueJs", "Hr", "PM", "DevOps", "Business Analyst", "QA", "Recruiter" };
            List<string> devLvls = new List<string>() { "Trainee", "Junior", "Middle", "Senior" };

            List<SkillTemplate> skillTemplates = new List<SkillTemplate>();
            for (int j = 0; j < templateCount; j++)
            {
                string title = devLvls[rand.Next(1, devLvls.Count)] + " " + devTitles[rand.Next(1, devTitles.Count)];
                skillTemplates.Add(new SkillTemplate
                {
                    Id = j + 1,
                    TemplateTitle = title,
                    Description = $"We are looking for a talented {title} to join our team in Ukraine. If you want to develop your skills and grow alongside the best professionals, this job is for you",
                    AverageSalary = rand.Next(1, 5001)
                });
            }
            genSkillTemplates = skillTemplates;
            return skillTemplates;
        }

        public List<Requirement> GenerateRequirement()
        {
            //Random rand = new Random();

            List<string> devTitles = new List<string>()
            {   "C",
                "Java",
                "Python",
                "C++",
                "C#",
                "Visual Basic",
                "JavaScript",
                "Assembly",
                "PHP",
                "SQL",
                "Classic Visual Basic",
                "Delphi",
                "Ruby",
                "Go",
                "Swift",
                "R",
                "Groovy",
                "Perl",
                "MATLAB",
                "Frotran",
                "SAS",
                "Scratch",
                "Objective-C",
                "COBOL",
                "Prolog",
                "Scala",
                "PL/SQL",
                "Transact-SQL",
                "Rust",
                "Ada",
                "D",
                "Julia",
                "FoxPro",
                "Dart",
                "ABAP",
                "Lisp",
                "Lua",
                "Logo",
                "Kotlin",
                "LabVIEW",
                "VBScript",
                "Bash",
                "VHDL",
                "Ladder Logic",
                "Awk",
                "Apex",
                "RPG",
                "Elixir",
                "PowerShell",
                "TypeScript"
            };

            List<string> SkillUnitsTitle = new List<string>()
            {
                "Inside a program",
                "Command-line arguments",
                "Programming Concepts",
                "Statements",
                "Expressions",
                "Operators",
                "Types",
                "Classes",
                "Structs",
                "Records",
                "Interfaces",
                "Delegates",
                "Arrays",
                "Strings",
                "Indexers",
                "Events",
                "Generics",
                "Namespaces",
                "XML documentation",
                "Exceptions",
                "Exception Handling",
                "File system",
                "Registry",
                "Interoperability"
            };

            List<Requirement> requirements = new List<Requirement>();
            for (int i = 0; i < genSkillTemplates.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    requirements.Add(new Requirement
                    {
                        Id = i * 7 + j + 1,
                        ReqTitle = devTitles[rand.Next(1, devTitles.Count)] + " language. " + SkillUnitsTitle[rand.Next(1,SkillUnitsTitle.Count)],
                        ReqLevel = rand.Next(1, 6),
                        IdSkillTemplate = genSkillTemplates[i].Id
                    });
                }
            }
            genRequirements = requirements;
            return requirements;
        }

        public List<Comparation> GenerateComparation()
        {
            //Random rand = new Random();

            List<(string, int, int)> fullUnits = new List<(string, int, int)>();
            string curSkill = "";
            foreach (var item in genSkillUnits)
            {
                curSkill = genUserSkills.FirstOrDefault(us => us.Id == item.IdUserSkill).Skillname + ". " + item.Unitname;
                var curUnit = (curSkill, (int)genUserSkills.FirstOrDefault(us => us.Id == item.IdUserSkill).IdEmployee, genUserSkills.FirstOrDefault(us => us.Id == item.IdUserSkill).SkillLevel);
                fullUnits.Add(curUnit);
                curSkill = "";
            }
            List<Comparation> comparations = new List<Comparation>();
            int idCounter = 1;
            for (int j = 0; j < genRequirements.Count; j++)
            {
                var curUnits = fullUnits.Where(unit => unit.Item1 == genRequirements[j].ReqTitle);
                foreach (var item in curUnits)
                {
                    comparations.Add(new Comparation
                    {
                        Id = idCounter,
                        IdEmployee = item.Item2,
                        IdRequirement = genRequirements[j].Id,
                        IsMeetCriteria = item.Item3 >= genRequirements[j].ReqLevel ? true : false
                    });
                    idCounter++;
                }
                /*foreach(var item in fullUnits)
                {
                    if (item.Item1 == genRequirements[j].ReqTitle) {
                        comparations.Add(new Comparation
                        {
                            Id = idCounter,
                            IdEmployee = item.Item2,
                            IdRequirement = genRequirements[j].Id,
                            IsMeetCriteria = item.Item3 >= genRequirements[j].ReqLevel ? true : false
                        });
                    }
                    else
                    {
                        comparations.Add(new Comparation
                        {
                            Id = idCounter,
                            IdEmployee = item.Item2,
                            IdRequirement = genRequirements[j].Id,
                            IsMeetCriteria = false
                        });
                    }
                    idCounter++;
                }*/
            }
            return comparations;
        }

        public List<Statistics> GenerateStatistics(int employeeCount)
        {
            //Random rand = new Random();

            List<Statistics> statisticss = new List<Statistics>();

            genStatisticss = new List<Statistics>();
            int idCount = 1;
            for(int i = 0; i < employeeCount; i++)
            {
                int stYear = 2019;
                for(int j = 0; j < 3; j++)
                {

                    var skills = genUserSkills.Where(sk => sk.IdEmployee == i + 1 && sk.StartDate.Year == stYear + j);
                    var myStats = new Statistics();
                    myStats.Id = idCount;
                    myStats.NewSkillCount = skills.Count();
                    myStats.StatYear = stYear + j;
                    myStats.IdEmployee = i + 1;

                    TimeSpan allTimeDiff = new TimeSpan(0);
                    int sumLevel = 0;
                    foreach (var skill in skills)
                    {
                        allTimeDiff = allTimeDiff.Add(skill.EndDate.Subtract(skill.StartDate));
                        sumLevel += skill.SkillLevel;
                    }
                    myStats.StudyingTime = allTimeDiff.Days;
                    myStats.AverageSkillLevel = sumLevel / skills.Count();

                    var anotherStats = genStatisticss;
                    if (anotherStats == null || anotherStats.Count() == 0)
                    {
                        myStats.BetterThanPercent = 100;
                    }
                    else
                    {
                        int MaxNewSkill = anotherStats.Max(stat => stat.NewSkillCount);
                        double NewSkillPercent = 0, StudyingTimePercent = 0, AverageSkillPercent = 0;
                        if (MaxNewSkill == 0)
                        {
                            NewSkillPercent = 100;
                        }
                        else
                        {
                            NewSkillPercent = myStats.NewSkillCount * 1.0 / MaxNewSkill * 100;
                            if(NewSkillPercent > 100)
                            {
                                NewSkillPercent = 100;
                            }
                        }
                        long MaxStudyingTime = anotherStats.Max(stat => stat.StudyingTime);
                        if (MaxStudyingTime == 0)
                        {
                            StudyingTimePercent = 100;
                        }
                        else
                        {
                            StudyingTimePercent = myStats.StudyingTime * 1.0 / MaxStudyingTime * 100;
                            if (StudyingTimePercent > 100)
                            {
                                StudyingTimePercent = 100;
                            }
                        }
                        double MaxAverageSkill = anotherStats.Max(stat => stat.AverageSkillLevel);
                        if (MaxAverageSkill == 0)
                        {
                            AverageSkillPercent = 100;
                        }
                        else
                        {
                            AverageSkillPercent = myStats.AverageSkillLevel * 1.0 / MaxAverageSkill * 100;
                            if (AverageSkillPercent > 100)
                            {
                                AverageSkillPercent = 100;
                            }
                        }
                        myStats.BetterThanPercent = (NewSkillPercent + StudyingTimePercent + AverageSkillPercent) / 3;
                    }

                    idCount++;
                    genStatisticss.Add(myStats);
                    statisticss.Add(myStats);
                }
            }

            return statisticss;
        }
    }
}
