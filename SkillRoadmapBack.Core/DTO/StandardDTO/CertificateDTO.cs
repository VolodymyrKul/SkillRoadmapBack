using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class CertificateDTO
    {
        public int Id { get; set; }
        public int? IdUserSkill { get; set; }
        public string CertificateTitle { get; set; }
        public int SkillLevel { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? IdRecipient { get; set; }
        public int? IdPublisher { get; set; }
        public string SkillName { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientNSN { get; set; }
        public string PublisherEmail { get; set; }
        public string PublisherNSN { get; set; }
    }
}
