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
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public EmployeeRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Set<Employee>()
                .Include(employee => employee.IdEmployerNavigation)
                .ToListAsync();
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Set<Employee>()
                .Where(e => e.Id == id)
                .Include(employee => employee.IdEmployerNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
