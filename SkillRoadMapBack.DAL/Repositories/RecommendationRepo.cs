using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class RecommendationRepo : BaseRepo<Recommendation>, IRecommendationRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public RecommendationRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
