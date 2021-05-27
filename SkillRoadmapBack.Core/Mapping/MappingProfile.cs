using AutoMapper;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using SkillRoadmapBack.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.SkillName, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname))
                .ForMember(dest => dest.EmployerEmail, opts => opts.MapFrom(item => item.IdEmployerNavigation.Email))
                .ForMember(dest => dest.EmployerNSN, opts => opts.MapFrom(item => item.IdEmployerNavigation.Firstname + " " + item.IdEmployerNavigation.Lastname));
            CreateMap<CommentDTO, Comment>();


            CreateMap<Notification, NotificationDTO>()
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email))
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname))
                .ForMember(dest => dest.EmployerEmail, opts => opts.MapFrom(item => item.IdEmployerNavigation.Email))
                .ForMember(dest => dest.EmployerNSN, opts => opts.MapFrom(item => item.IdEmployerNavigation.Firstname + " " + item.IdEmployerNavigation.Lastname));
            CreateMap<NotificationDTO, Notification>();

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.MentorEmail, opts => opts.MapFrom(item => item.IdEmployerNavigation.Email))
                .ForMember(dest => dest.MentorNSN, opts => opts.MapFrom(item => item.IdEmployerNavigation.Firstname + " " + item.IdEmployerNavigation.Lastname))
                .ForMember(dest => dest.CompanyName, opts => opts.MapFrom(item => item.IdCompanyNavigation.Name));
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<Employer, EmployerDTO>()
                .ForMember(dest => dest.CompanyName, opts => opts.MapFrom(item => item.IdCompanyNavigation.Name));
            CreateMap<EmployerDTO, Employer>();

            CreateMap<UserSkill, UserSkillDTO>()
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email))
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname))
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(item => item.IdCategoryNavigation.Title));
            CreateMap<UserSkillDTO, UserSkill>();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<SkillUnit, SkillUnitDTO>()
                .ForMember(dest => dest.SkillName, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname));
            CreateMap<SkillUnitDTO, SkillUnit>();

            CreateMap<Certificate, CertificateDTO>()
                .ForMember(dest => dest.PublisherEmail, opts => opts.MapFrom(item => item.IdPublisherNavigation.Email))
                .ForMember(dest => dest.PublisherNSN, opts => opts.MapFrom(item => item.IdPublisherNavigation.Firstname + " " + item.IdPublisherNavigation.Lastname))
                .ForMember(dest => dest.RecipientEmail, opts => opts.MapFrom(item => item.IdRecipientNavigation.Email))
                .ForMember(dest => dest.RecipientNSN, opts => opts.MapFrom(item => item.IdRecipientNavigation.Firstname + " " + item.IdRecipientNavigation.Lastname))
                .ForMember(dest => dest.SkillName, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname));
            CreateMap<CertificateDTO, Certificate>();

            CreateMap<Company, CompanyDTO>().ReverseMap();

            CreateMap<Recommendation, RecommendationDTO>()
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email))
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname))
                .ForMember(dest => dest.TrainingTitle, opts => opts.MapFrom(item => item.IdTrainingNavigation.TrainingTitle));
            CreateMap<RecommendationDTO, Recommendation>();

            CreateMap<SkillMetric, SkillMetricDTO>()
                .ForMember(dest => dest.SkillName, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname));
            CreateMap<SkillMetricDTO, SkillMetric>();

            CreateMap<Statistics, StatisticsDTO>()
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email))
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname));
            CreateMap<StatisticsDTO, Statistics>();

            CreateMap<Training, TrainingDTO>()
                .ForMember(dest => dest.CoachEmail, opts => opts.MapFrom(item => item.IdCoachNavigation.Email))
                .ForMember(dest => dest.CoachNSN, opts => opts.MapFrom(item => item.IdCoachNavigation.Firstname + " " + item.IdCoachNavigation.Lastname))
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(item => item.IdCategoryNavigation.Title));
            CreateMap<TrainingDTO, Training>();

            CreateMap<TrainingMember, TrainingMemberDTO>()
                .ForMember(dest => dest.MemberEmail, opts => opts.MapFrom(item => item.IdMemberNavigation.Email))
                .ForMember(dest => dest.MemberNSN, opts => opts.MapFrom(item => item.IdMemberNavigation.Firstname + " " + item.IdMemberNavigation.Lastname))
                .ForMember(dest => dest.TrainingTitle, opts => opts.MapFrom(item => item.IdTrainingNavigation.TrainingTitle));
            CreateMap<TrainingMemberDTO, TrainingMember>();

            CreateMap<UserSkill, GetUserSkillDTO>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(item => item.IdCategoryNavigation.Title))
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email));

            CreateMap<Comment, GetCommentDTO>()
                .ForMember(dest => dest.EmployerEmail, opts => opts.MapFrom(item => item.IdEmployerNavigation.Email))
                .ForMember(dest => dest.UserSkillName, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname));

            CreateMap<Employee, EmployeeInfoDTO>()
                .ForMember(dest => dest.MentorEmail, opts => opts.MapFrom(item => item.IdEmployerNavigation.Email))
                .ForMember(dest => dest.CompanyName, opts => opts.MapFrom(item => item.IdCompanyNavigation.Name));
            CreateMap<Employer, EmployerInfoDTO>()
                .ForMember(dest => dest.CompanyName, opts => opts.MapFrom(item => item.IdCompanyNavigation.Name));

            CreateMap<GetUserSkillDTO, UserSkill>();
            CreateMap<SetSkillUnitDTO, SkillUnit>();
            CreateMap<SetSkillMetricDTO, SkillMetric>();

            CreateMap<Certificate, GetCertificateDTO>()
                .ForMember(dest => dest.UserSkill, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname))
                .ForMember(dest => dest.PublisherNSN, opts => opts.MapFrom(item => item.IdPublisherNavigation.Firstname + " " + item.IdPublisherNavigation.Lastname))
                .ForMember(dest => dest.RecipientNSN, opts => opts.MapFrom(item => item.IdRecipientNavigation.Firstname + " " + item.IdRecipientNavigation.Lastname));

            CreateMap<Notification, GetNotificationDTO>()
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname))
                .ForMember(dest => dest.EmployerNSN, opts => opts.MapFrom(item => item.IdEmployerNavigation.Firstname + " " + item.IdEmployerNavigation.Lastname));

            CreateMap<Training, SetTrainingDTO>()
                .ForMember(dest => dest.CoachEmail, opts => opts.MapFrom(item => item.IdCoachNavigation.Email))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(item => item.IdCategoryNavigation.Title));

            CreateMap<SkillTemplate, SkillTemplateDTO>().ReverseMap();

            CreateMap<Requirement, RequirementDTO>()
                .ForMember(dest => dest.TemplateTitle, opts => opts.MapFrom(item => item.IdSkillTemplateNavigation.TemplateTitle));
            CreateMap<RequirementDTO, Requirement>();

            CreateMap<Comparation, ComparationDTO>()
                .ForMember(dest => dest.ReqTitle, opts => opts.MapFrom(item => item.IdRequirementNavigation.ReqTitle))
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email))
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname));
            CreateMap<ComparationDTO, Comparation>();
        }
    }
}
