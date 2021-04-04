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
    public class EmployerRepo : BaseRepo<Employer>, IEmployerRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public EmployerRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Employer>> GetAllAsync()
        {
            return await _context.Set<Employer>()
                .Include(employer => employer.IdCompanyNavigation)
                .ToListAsync();
        }

        public override async Task<Employer> GetByIdAsync(int id)
        {
            return await _context.Set<Employer>()
                .Where(e => e.Id == id)
                .Include(employer => employer.IdCompanyNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
