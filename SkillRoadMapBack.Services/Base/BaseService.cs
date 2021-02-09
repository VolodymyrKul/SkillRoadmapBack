using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadMapBack.Services.Base
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
