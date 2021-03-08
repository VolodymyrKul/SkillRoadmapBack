using SkillRoadmapBack.Core.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions
{
    public interface IUnitOfWork
    {
        ICommentRepo CommentRepo { get; }
        IEmployeeRepo EmployeeRepo { get; }
        IEmployerRepo EmployerRepo { get; }
        INotificationRepo NotificationRepo { get; }
        IUserSkillRepo UserSkillRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ISkillUnitRepo SkillUnitRepo { get; }
        ICertificateRepo CertificateRepo { get; }
        ICompanyRepo CompanyRepo { get; }
        IRecMemberRepo RecMemberRepo { get; }
        IRecommendationRepo RecommendationRepo { get; }
        ISkillMetricRepo SkillMetricRepo { get; }
        IStatisticsRepo StatisticsRepo { get; }
        ITrainingRepo TrainingRepo { get; }
        ITrainingMemberRepo TrainingMemberRepo { get; }
        Task SaveChangesAsync();
    }
}
