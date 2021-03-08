using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Certificate : IBaseEntity
    {
        public int Id { get; set; }
        public int? IdUserSkill { get; set; }
        public UserSkill IdUserSkillNavigation { get; set; }
        public string CertificateTitle { get; set; }
        public int SkillLevel { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int? IdRecipient { get; set; }
        public Employee IdRecipientNavigation { get; set; }
        public int? IdPublisher { get; set; }
        public Employer IdPublisherNavigation { get; set; }
    }
}
