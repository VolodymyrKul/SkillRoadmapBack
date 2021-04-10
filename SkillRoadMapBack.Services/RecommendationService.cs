﻿using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadMapBack.Services
{
    public class RecommendationService : BaseService, IRecommendationService
    {
        public RecommendationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(RecommendationDTO entity)
        {
            var value = new Recommendation();
            _mapper.Map(entity, value);
            await _unitOfWork.RecommendationRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.RecommendationRepo.GetByIdAsync(id);
            await _unitOfWork.RecommendationRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<RecommendationDTO>> GetAll()
        {
            var recommendations = await _unitOfWork.RecommendationRepo.GetAllAsync();
            List<RecommendationDTO> recommendationDTOs = recommendations.Select(recommendation => _mapper.Map(recommendation, new RecommendationDTO())).ToList();
            return recommendationDTOs;
        }

        public virtual async Task<RecommendationDTO> GetIdAsync(int id)
        {
            var recommendation = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (recommendation == null)
                throw new Exception("Such category not found");
            var dto = new RecommendationDTO();
            _mapper.Map(recommendation, dto);
            return dto;
        }

        public virtual async Task<RecommendationDTO> UpdateAsync(RecommendationDTO entity)
        {
            var value = new Recommendation();
            _mapper.Map(entity, value);
            await _unitOfWork.RecommendationRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}