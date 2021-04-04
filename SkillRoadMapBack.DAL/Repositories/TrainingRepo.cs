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
    public class TrainingRepo : BaseRepo<Training>, ITrainingRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public TrainingRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Training>> GetAllAsync()
        {
            return await _context.Set<Training>()
                .Include(training => training.IdCategoryNavigation)
                .Include(training => training.IdCoachNavigation)
                .ToListAsync();
        }

        public override async Task<Training> GetByIdAsync(int id)
        {
            return await _context.Set<Training>()
                .Where(e => e.Id == id)
                .Include(training => training.IdCategoryNavigation)
                .Include(training => training.IdCoachNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
