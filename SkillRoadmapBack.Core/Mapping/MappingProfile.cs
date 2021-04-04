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
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employer, EmployerDTO>().ReverseMap();
            CreateMap<UserSkill, UserSkillDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<SkillUnit, SkillUnitDTO>().ReverseMap();
            CreateMap<Certificate, CertificateDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Recommendation, RecommendationDTO>().ReverseMap();
            CreateMap<SkillMetric, SkillMetricDTO>().ReverseMap();
            CreateMap<Statistics, StatisticsDTO>().ReverseMap();
            CreateMap<Training, TrainingDTO>().ReverseMap();
            CreateMap<TrainingMember, TrainingMemberDTO>().ReverseMap();

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
                .ForMember(dest => dest.Skillname, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname))
                .ForMember(dest => dest.EmployeeNSN, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Firstname + " " + item.IdEmployeeNavigation.Lastname))
                .ForMember(dest => dest.EmployerNSN, opts => opts.MapFrom(item => item.IdEmployerNavigation.Firstname + " " + item.IdEmployerNavigation.Lastname));

            CreateMap<Training, SetTrainingDTO>()
                .ForMember(dest => dest.CoachEmail, opts => opts.MapFrom(item => item.IdCoachNavigation.Email))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(item => item.IdCategoryNavigation.Title));
        }
    }
}
