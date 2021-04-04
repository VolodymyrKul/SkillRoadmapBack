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
        private ICategoryRepo _categoryRepo;
        private ISkillUnitRepo _skillUnitRepo;
        private ICertificateRepo _certificateRepo;
        private ICompanyRepo _companyRepo;
        private IRecommendationRepo _recommendationRepo;
        private ISkillMetricRepo _skillMetricRepo;
        private IStatisticsRepo _statisticsRepo;
        private ITrainingMemberRepo _trainingMemberRepo;
        private ITrainingRepo _trainingRepo; 

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

        public ICategoryRepo CategoryRepo
        {
            get
            {
                return _categoryRepo ??= new CategoryRepo(_context);
            }
        }

        public ISkillUnitRepo SkillUnitRepo
        {
            get
            {
                return _skillUnitRepo ??= new SkillUnitRepo(_context);
            }
        }

        public ICertificateRepo CertificateRepo
        {
            get
            {
                return _certificateRepo ??= new CertificateRepo(_context);
            }
        }

        public ICompanyRepo CompanyRepo
        {
            get
            {
                return _companyRepo ??= new CompanyRepo(_context);
            }
        }

        public IRecommendationRepo RecommendationRepo
        {
            get
            {
                return _recommendationRepo ??= new RecommendationRepo(_context);
            }
        }

        public ISkillMetricRepo SkillMetricRepo
        {
            get
            {
                return _skillMetricRepo ??= new SkillMetricRepo(_context);
            }
        }

        public IStatisticsRepo StatisticsRepo
        {
            get
            {
                return _statisticsRepo ??= new StatisticsRepo(_context);
            }
        }

        public ITrainingMemberRepo TrainingMemberRepo
        {
            get
            {
                return _trainingMemberRepo ??= new TrainingMemberRepo(_context);
            }
        }

        public ITrainingRepo TrainingRepo
        {
            get
            {
                return _trainingRepo ??= new TrainingRepo(_context);
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
