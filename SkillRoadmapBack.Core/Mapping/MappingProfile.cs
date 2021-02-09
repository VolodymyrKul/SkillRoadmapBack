using AutoMapper;
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
            CreateMap<SkillDistribution, SkillDistributionDTO>().ReverseMap();
        }
    }
}
