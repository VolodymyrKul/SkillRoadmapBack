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
    public class CertificateRepo : BaseRepo<Certificate>, ICertificateRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public CertificateRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Certificate>> GetAllAsync()
        {
            return await _context.Set<Certificate>()
                .Include(certificate => certificate.IdUserSkillNavigation)
                .Include(certificate => certificate.IdPublisherNavigation)
                .Include(certificate => certificate.IdRecipientNavigation)
                .ToListAsync();
        }

        public override async Task<Certificate> GetByIdAsync(int id)
        {
            return await _context.Set<Certificate>()
                .Where(e => e.Id == id)
                .Include(certificate => certificate.IdUserSkillNavigation)
                .Include(certificate => certificate.IdPublisherNavigation)
                .Include(certificate => certificate.IdRecipientNavigation)
                .FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
