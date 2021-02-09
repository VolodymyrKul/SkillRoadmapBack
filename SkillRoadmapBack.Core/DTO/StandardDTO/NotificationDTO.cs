﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string NotificationText { get; set; }
        public DateTime SendingDate { get; set; }
        public bool IsRead { get; set; }
        public int IdEmployee { get; set; }
        public int IdEmployer { get; set; }
        public int IdUserSkill { get; set; }
    }
}
