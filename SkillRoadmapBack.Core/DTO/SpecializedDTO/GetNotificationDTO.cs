using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class GetNotificationDTO
    {
        public string NotificationText { get; set; }
        public DateTime SendingDate { get; set; }
        public string EmployeeNSN { get; set; }
        public string EmployerNSN { get; set; }
        public string Skillname { get; set; }
    }
}
