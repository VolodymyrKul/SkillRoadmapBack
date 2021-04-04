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
    public class StatisticsRepo : BaseRepo<Statistics>, IStatisticsRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public StatisticsRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Statistics>> GetAllAsync()
        {
            return await _context.Set<Statistics>()
                .Include(statistics => statistics.IdEmployeeNavigation)
                .ToListAsync();
        }

        public override async Task<Statistics> GetByIdAsync(int id)
        {
            return await _context.Set<Statistics>()
                .Where(e => e.Id == id)
                .Include(statistics => statistics.IdEmployeeNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
