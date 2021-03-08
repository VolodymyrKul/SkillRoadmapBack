using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Recommendation : IBaseEntity
    {
        public Recommendation()
        {
            RecMembers = new HashSet<RecMember>();
        }
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public Employee IdEmployeeNavigation { get; set; }
        public string Title { get; set; }
        public bool IsUsed { get; set; }
        public virtual ICollection<RecMember> RecMembers { get; set; }
    }
}
