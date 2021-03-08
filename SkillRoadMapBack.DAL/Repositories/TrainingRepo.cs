using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class TrainingRepo : BaseRepo<Training>, ITrainingRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public TrainingRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
