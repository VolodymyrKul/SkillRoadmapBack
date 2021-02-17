﻿using SkillRoadmapBack.Core.Abstractions.IRepositories;
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
        ISkillDistributionRepo SkillDistributionRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        Task SaveChangesAsync();
    }
}
