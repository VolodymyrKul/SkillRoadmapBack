using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class RequirementDTO
    {
        public int Id { get; set; }
        public string ReqTitle { get; set; }
        public int ReqLevel { get; set; }
        public int IdSkillTemplate { get; set; }
        public string TemplateTitle { get; set; }
    }
}
