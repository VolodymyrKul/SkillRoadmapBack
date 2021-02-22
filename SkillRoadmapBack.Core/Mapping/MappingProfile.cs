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

            CreateMap<UserSkill, GetUserSkillDTO>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(item => item.IdCategoryNavigation.Title))
                .ForMember(dest => dest.EmployeeEmail, opts => opts.MapFrom(item => item.IdEmployeeNavigation.Email));

            CreateMap<Comment, GetCommentDTO>()
                .ForMember(dest => dest.EmployerEmail, opts => opts.MapFrom(item => item.IdEmployerNavigation.Email))
                .ForMember(dest => dest.UserSkillName, opts => opts.MapFrom(item => item.IdUserSkillNavigation.Skillname));
        }
    }
}
