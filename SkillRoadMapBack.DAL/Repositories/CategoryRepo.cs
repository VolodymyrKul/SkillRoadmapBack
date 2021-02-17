using SkillRoadmapBack.Core.Abstractions.IRepositories;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.DAL.Repositories
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private readonly SkillRoadMapDbContext _context;
        public CategoryRepo(SkillRoadMapDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
