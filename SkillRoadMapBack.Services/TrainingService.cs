﻿using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
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
    public class TrainingService : BaseService, ITrainingService
    {
        public TrainingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(TrainingDTO entity)
        {
            var value = new Training();
            _mapper.Map(entity, value);
            await _unitOfWork.TrainingRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TrainingRepo.GetByIdAsync(id);
            var trMembers = (await _unitOfWork.TrainingMemberRepo.GetAllAsync()).Where(tm => tm.IdTraining == id);
            await _unitOfWork.TrainingMemberRepo.DeleteRangeAsync(trMembers);
            await _unitOfWork.TrainingRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TrainingDTO>> GetAll()
        {
            var trainings = await _unitOfWork.TrainingRepo.GetAllAsync();
            List<TrainingDTO> trainingDTOs = trainings.Select(training => _mapper.Map(training, new TrainingDTO())).ToList();
            return trainingDTOs;
        }

        public virtual async Task<TrainingDTO> GetIdAsync(int id)
        {
            var training = await _unitOfWork.TrainingRepo.GetByIdAsync(id);
            if (training == null)
                throw new Exception("Such category not found");
            var dto = new TrainingDTO();
            _mapper.Map(training, dto);
            return dto;
        }

        public virtual async Task<TrainingDTO> UpdateAsync(TrainingDTO entity)
        {
            var value = new Training();
            _mapper.Map(entity, value);
            await _unitOfWork.TrainingRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<SetTrainingDTO>> GetByCoach(string coach)
        {
            var trainings = (await _unitOfWork.TrainingRepo.GetAllAsync()).Where(tr => tr.IdCoachNavigation.Email == coach);
            List<SetTrainingDTO> trainingDTOs = trainings.Select(training => _mapper.Map(training, new SetTrainingDTO())).ToList();
            return trainingDTOs;
        }

        public virtual async Task<List<TrainingDTO>> GetByCoach(int coachId)
        {
            var trainings = (await _unitOfWork.TrainingRepo.GetAllAsync()).Where(tr => tr.IdCoachNavigation.Id == coachId);
            List<TrainingDTO> trainingDTOs = trainings.Select(training => _mapper.Map(training, new TrainingDTO())).ToList();
            return trainingDTOs;
        }

        public virtual async Task<List<SetTrainingDTO>> GetByCategory(string category)
        {
            var trainings = (await _unitOfWork.TrainingRepo.GetAllAsync()).Where(tr => tr.IdCategoryNavigation.Title == category);
            List<SetTrainingDTO> trainingDTOs = trainings.Select(training => _mapper.Map(training, new SetTrainingDTO())).ToList();
            return trainingDTOs;
        }

        public virtual async Task<List<TrainingDTO>> GetByCategory(int categoryId)
        {
            var trainings = (await _unitOfWork.TrainingRepo.GetAllAsync()).Where(tr => tr.IdCategoryNavigation.Id == categoryId);
            List<TrainingDTO> trainingDTOs = trainings.Select(training => _mapper.Map(training, new TrainingDTO())).ToList();
            return trainingDTOs;
        }

        public virtual async Task<List<SetTrainingDTO>> GetAllWithCategs()
        {
            var trainings = await _unitOfWork.TrainingRepo.GetAllAsync();
            List<SetTrainingDTO> trainingDTOs = trainings.Select(training => _mapper.Map(training, new SetTrainingDTO())).ToList();
            return trainingDTOs;
        }
    }
}
