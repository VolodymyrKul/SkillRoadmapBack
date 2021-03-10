using AutoMapper;
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
    public class StatisticsService : BaseService, IStatisticsService
    {
        public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(StatisticsDTO entity)
        {
            var value = new Statistics();
            _mapper.Map(entity, value);
            await _unitOfWork.StatisticsRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.StatisticsRepo.GetByIdAsync(id);
            await _unitOfWork.StatisticsRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<StatisticsDTO>> GetAll()
        {
            var statisticses = await _unitOfWork.StatisticsRepo.GetAllAsync();
            List<StatisticsDTO> statisticsDTOs = statisticses.Select(statistics => _mapper.Map(statistics, new StatisticsDTO())).ToList();
            return statisticsDTOs;
        }

        public virtual async Task<StatisticsDTO> GetIdAsync(int id)
        {
            var statistics = await _unitOfWork.StatisticsRepo.GetByIdAsync(id);
            if (statistics == null)
                throw new Exception("Such category not found");
            var dto = new StatisticsDTO();
            _mapper.Map(statistics, dto);
            return dto;
        }

        public virtual async Task<StatisticsDTO> UpdateAsync(StatisticsDTO entity)
        {
            var value = new Statistics();
            _mapper.Map(entity, value);
            await _unitOfWork.StatisticsRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
