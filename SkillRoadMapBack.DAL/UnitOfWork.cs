using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadMapBack.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadMapBack.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SkillRoadMapDbContext _context;
        private ICommentRepo _commentRepo;
        private INotificationRepo _notificationRepo;
        private IEmployeeRepo _employeeRepo;
        private IEmployerRepo _employerRepo;
        private IUserSkillRepo _userSkillRepo;
        private ISkillDistributionRepo _skillDistributionRepo;

        public ICommentRepo CommentRepo
        {
            get
            {
                return _commentRepo ??= new CommentRepo(_context);
            }
        }

        public IEmployeeRepo EmployeeRepo
        {
            get
            {
                return _employeeRepo ??= new EmployeeRepo(_context);
            }
        }

        public IEmployerRepo EmployerRepo 
        {
            get
            {
                return _employerRepo ??= new EmployerRepo(_context);
            }
        }

        public INotificationRepo NotificationRepo
        {
            get
            {
                return _notificationRepo ??= new NotificationRepo(_context);
            }
        }

        public IUserSkillRepo UserSkillRepo
        {
            get
            {
                return _userSkillRepo ??= new UserSkillRepo(_context);
            }
        }

        public ISkillDistributionRepo SkillDistributionRepo
        {
            get
            {
                return _skillDistributionRepo ??= new SkillDistributionRepo(_context);
            }
        }

        public UnitOfWork(SkillRoadMapDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
