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
    public class TrainingMemberRepo : BaseRepo<TrainingMember>, ITrainingMemberRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public TrainingMemberRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<TrainingMember>> GetAllAsync()
        {
            return await _context.Set<TrainingMember>()
                .Include(trainingMember => trainingMember.IdMemberNavigation)
                .Include(trainingMember => trainingMember.IdTrainingNavigation)
                .ToListAsync();
        }

        public override async Task<TrainingMember> GetByIdAsync(int id)
        {
            return await _context.Set<TrainingMember>()
                .Where(e => e.Id == id)
                .Include(trainingMember => trainingMember.IdMemberNavigation)
                .Include(trainingMember => trainingMember.IdTrainingNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
