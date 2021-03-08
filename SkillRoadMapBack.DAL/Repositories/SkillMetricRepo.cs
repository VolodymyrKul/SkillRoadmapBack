using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class SkillMetricRepo : BaseRepo<SkillMetric>, ISkillMetricRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public SkillMetricRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
