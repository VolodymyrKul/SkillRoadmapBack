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
    public class ComparationRepo : BaseRepo<Comparation>, IComparationRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public ComparationRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Comparation>> GetAllAsync()
        {
            return await _context.Set<Comparation>()
                .Include(comparation => comparation.IdEmployeeNavigation)
                .Include(comparation => comparation.IdRequirementNavigation)
                .ToListAsync();
        }

        public override async Task<Comparation> GetByIdAsync(int id)
        {
            return await _context.Set<Comparation>()
                .Where(e => e.Id == id)
                .Include(comparation => comparation.IdEmployeeNavigation)
                .Include(comparation => comparation.IdRequirementNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
