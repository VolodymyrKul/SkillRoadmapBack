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
    public class RecMemberService : BaseService, IRecMemberService
    {
        public RecMemberService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(RecMemberDTO entity)
        {
            var value = new RecMember();
            _mapper.Map(entity, value);
            await _unitOfWork.RecMemberRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.RecMemberRepo.GetByIdAsync(id);
            await _unitOfWork.RecMemberRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<RecMemberDTO>> GetAll()
        {
            var recMembers = await _unitOfWork.RecMemberRepo.GetAllAsync();
            List<RecMemberDTO> recMemberDTOs = recMembers.Select(recMember => _mapper.Map(recMember, new RecMemberDTO())).ToList();
            return recMemberDTOs;
        }

        public virtual async Task<RecMemberDTO> GetIdAsync(int id)
        {
            var recMember = await _unitOfWork.RecMemberRepo.GetByIdAsync(id);
            if (recMember == null)
                throw new Exception("Such category not found");
            var dto = new RecMemberDTO();
            _mapper.Map(recMember, dto);
            return dto;
        }

        public virtual async Task<RecMemberDTO> UpdateAsync(RecMemberDTO entity)
        {
            var value = new RecMember();
            _mapper.Map(entity, value);
            await _unitOfWork.RecMemberRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
