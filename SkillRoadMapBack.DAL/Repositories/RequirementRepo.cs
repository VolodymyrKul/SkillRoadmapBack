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
    public class RequirementRepo : BaseRepo<Requirement>, IRequirementRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public RequirementRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Requirement>> GetAllAsync()
        {
            return await _context.Set<Requirement>()
                .Include(requirement => requirement.IdSkillTemplateNavigation)
                .ToListAsync();
        }

        public override async Task<Requirement> GetByIdAsync(int id)
        {
            return await _context.Set<Requirement>()
                .Where(e => e.Id == id)
                .Include(requirement => requirement.IdSkillTemplateNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
