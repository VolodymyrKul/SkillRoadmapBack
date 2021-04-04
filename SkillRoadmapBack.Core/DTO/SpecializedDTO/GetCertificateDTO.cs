using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class GetCertificateDTO
    {
        public string UserSkill { get; set; }
        public string CertificateTitle { get; set; }
        public int SkillLevel { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RecipientNSN { get; set; }
        public string PublisherNSN { get; set; }
    }
}
