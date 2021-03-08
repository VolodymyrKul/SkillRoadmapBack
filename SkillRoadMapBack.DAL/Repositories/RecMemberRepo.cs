using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class RecMemberRepo : BaseRepo<RecMember>, IRecMemberRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public RecMemberRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
