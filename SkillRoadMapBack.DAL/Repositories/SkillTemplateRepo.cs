using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class SkillTemplateRepo : BaseRepo<SkillTemplate>, ISkillTemplateRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public SkillTemplateRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
