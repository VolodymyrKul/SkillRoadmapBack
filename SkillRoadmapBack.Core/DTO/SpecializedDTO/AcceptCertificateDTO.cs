using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class AcceptCertificateDTO
    {
        public string UserSkillName { get; set; }
        public string CertificateTitle { get; set; }
        public int SkillLevel { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RecipientEmail { get; set; }
        public string PublisherEmail { get; set; }
    }
}
