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
    public class SkillMetricRepo : BaseRepo<SkillMetric>, ISkillMetricRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public SkillMetricRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<SkillMetric>> GetAllAsync()
        {
            return await _context.Set<SkillMetric>()
                .Include(skillMetric => skillMetric.IdUserSkillNavigation)
                .ToListAsync();
        }

        public override async Task<SkillMetric> GetByIdAsync(int id)
        {
            return await _context.Set<SkillMetric>()
                .Where(e => e.Id == id)
                .Include(skillMetric => skillMetric.IdUserSkillNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
