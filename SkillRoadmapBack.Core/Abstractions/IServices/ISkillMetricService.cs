﻿using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface ISkillMetricService : IBaseService<SkillMetricDTO, SetSkillMetricDTO>
    {
    }
}