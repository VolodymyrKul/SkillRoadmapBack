﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.Mapping;
using SkillRoadMapBack.DAL;
using SkillRoadMapBack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISkillUnitService, SkillUnitService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<ISkillMetricService, SkillMetricService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingMemberService, TrainingMemberService>();
            services.AddScoped<ISkillTemplateService, SkillTemplateService>();
            services.AddScoped<IRequirementService, RequirementService>();
            services.AddScoped<IComparationService, ComparationService>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkillRoadmap API", Version = "v1" });
            });
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
