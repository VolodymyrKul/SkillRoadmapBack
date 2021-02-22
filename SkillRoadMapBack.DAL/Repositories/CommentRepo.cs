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
    public class CommentRepo : BaseRepo<Comment>, ICommentRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public CommentRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Set<Comment>()
                .Include(comment => comment.IdEmployerNavigation)
                .Include(comment => comment.IdUserSkillNavigation)
                .ToListAsync();
        }

        public override async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Set<Comment>()
                .Where(e => e.Id == id)
                .Include(comment => comment.IdEmployerNavigation)
                .Include(comment => comment.IdUserSkillNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
