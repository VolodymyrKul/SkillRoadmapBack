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
    public class TrainingMemberService : BaseService, ITrainingMemberService
    {
        public TrainingMemberService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(TrainingMemberDTO entity)
        {
            var value = new TrainingMember();
            _mapper.Map(entity, value);
            await _unitOfWork.TrainingMemberRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TrainingMemberRepo.GetByIdAsync(id);
            await _unitOfWork.TrainingMemberRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TrainingMemberDTO>> GetAll()
        {
            var trainingMembers = await _unitOfWork.TrainingMemberRepo.GetAllAsync();
            List<TrainingMemberDTO> trainingMemberDTOs = trainingMembers.Select(trainingMember => _mapper.Map(trainingMember, new TrainingMemberDTO())).ToList();
            return trainingMemberDTOs;
        }

        public virtual async Task<TrainingMemberDTO> GetIdAsync(int id)
        {
            var trainingMember = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (trainingMember == null)
                throw new Exception("Such category not found");
            var dto = new TrainingMemberDTO();
            _mapper.Map(trainingMember, dto);
            return dto;
        }

        public virtual async Task<TrainingMemberDTO> UpdateAsync(TrainingMemberDTO entity)
        {
            var value = new TrainingMember();
            _mapper.Map(entity, value);
            await _unitOfWork.TrainingMemberRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<TrainingMemberDTO>> GetTrainingIdAsync(int id)
        {
            var trainingMembers = (await _unitOfWork.TrainingMemberRepo.GetAllAsync()).Where(tm => tm.IdTraining == id);
            List<TrainingMemberDTO> trainingMemberDTOs = trainingMembers.Select(trainingMember => _mapper.Map(trainingMember, new TrainingMemberDTO())).ToList();
            return trainingMemberDTOs;
        }

        public virtual async Task<List<TrainingMemberDTO>> GetMemberIdAsync(int id)
        {
            var trainingMembers = (await _unitOfWork.TrainingMemberRepo.GetAllAsync()).Where(tm => tm.IdMember == id);
            List<TrainingMemberDTO> trainingMemberDTOs = trainingMembers.Select(trainingMember => _mapper.Map(trainingMember, new TrainingMemberDTO())).ToList();
            return trainingMemberDTOs;
        }
    }
}
