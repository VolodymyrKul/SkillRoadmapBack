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
    public class NotificationRepo : BaseRepo<Notification>, INotificationRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public NotificationRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _context.Set<Notification>()
                .Include(notification => notification.IdEmployeeNavigation)
                .Include(notification => notification.IdEmployerNavigation)
                .Include(notification => notification.IdUserSkillNavigation)
                .ToListAsync();
        }

        public override async Task<Notification> GetByIdAsync(int id)
        {
            return await _context.Set<Notification>()
                .Where(e => e.Id == id)
                .Include(notification => notification.IdEmployeeNavigation)
                .Include(notification => notification.IdEmployerNavigation)
                .Include(notification => notification.IdUserSkillNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
