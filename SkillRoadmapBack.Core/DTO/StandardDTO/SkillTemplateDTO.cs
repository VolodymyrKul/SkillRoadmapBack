using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class SkillTemplateDTO
    {
        public int Id { get; set; }
        public string TemplateTitle { get; set; }
        public string Description { get; set; }
        public int AverageSalary { get; set; }
    }
}
