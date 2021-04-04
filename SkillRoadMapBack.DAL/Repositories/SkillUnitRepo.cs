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
    public class SkillUnitRepo : BaseRepo<SkillUnit>, ISkillUnitRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public SkillUnitRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<SkillUnit>> GetAllAsync()
        {
            return await _context.Set<SkillUnit>()
                .Include(skillUnit => skillUnit.IdUserSkillNavigation)
                .ToListAsync();
        }

        public override async Task<SkillUnit> GetByIdAsync(int id)
        {
            return await _context.Set<SkillUnit>()
                .Where(e => e.Id == id)
                .Include(skillUnit => skillUnit.IdUserSkillNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
