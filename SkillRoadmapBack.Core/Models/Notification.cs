using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Notification : IBaseEntity
    {
        public int Id { get; set; }
        public string NotificationText { get; set; }
        public DateTime SendingDate { get; set; }
        public bool IsRead { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdEmployer { get; set; }
        public int? IdUserSkill { get; set; }
        public Employee IdEmployeeNavigation { get; set; }
        public Employer IdEmployerNavigation { get; set; }
        public UserSkill IdUserSkillNavigation { get; set; }
    }
}
