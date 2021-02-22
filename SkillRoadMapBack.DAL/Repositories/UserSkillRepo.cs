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
    public class UserSkillRepo : BaseRepo<UserSkill>, IUserSkillRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public UserSkillRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<UserSkill>> GetAllAsync()
        {
            return await _context.Set<UserSkill>()
                .Include(userSkill => userSkill.IdCategoryNavigation)
                .Include(userSkill => userSkill.IdEmployeeNavigation)
                .ToListAsync();
        }

        public override async Task<UserSkill> GetByIdAsync(int id)
        {
            return await _context.Set<UserSkill>()
                .Where(e => e.Id == id)
                .Include(userSkill => userSkill.IdCategoryNavigation)
                .Include(userSkill => userSkill.IdEmployeeNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
