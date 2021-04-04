using Microsoft.EntityFrameworkCore;
using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class RecommendationRepo : BaseRepo<Recommendation>, IRecommendationRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public RecommendationRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Recommendation>> GetAllAsync()
        {
            return await _context.Set<Recommendation>()
                .Include(recommendation => recommendation.IdEmployeeNavigation)
                .Include(recommendation => recommendation.IdTrainingNavigation)
                .ToListAsync();
        }

        public override async Task<Recommendation> GetByIdAsync(int id)
        {
            return await _context.Set<Recommendation>()
                .Where(e => e.Id == id)
                .Include(recommendation => recommendation.IdEmployeeNavigation)
                .Include(recommendation => recommendation.IdTrainingNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
