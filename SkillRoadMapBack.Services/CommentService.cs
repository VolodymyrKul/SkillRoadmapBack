using AutoMapper;
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
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(CommentDTO entity)
        {
            var value = new Comment();
            _mapper.Map(entity, value);
            await _unitOfWork.CommentRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CommentRepo.GetByIdAsync(id);
            await _unitOfWork.CommentRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CommentDTO>> GetAll()
        {
            var comments = await _unitOfWork.CommentRepo.GetAllAsync();
            List<CommentDTO> commentDTOs = comments.Select(comment => _mapper.Map(comment, new CommentDTO())).ToList();
            return commentDTOs;
        }

        public virtual async Task<CommentDTO> GetIdAsync(int id)
        {
            var comment = await _unitOfWork.CommentRepo.GetByIdAsync(id);
            if (comment == null)
                throw new Exception("Such comment not found");
            var dto = new CommentDTO();
            _mapper.Map(comment, dto);
            return dto;
        }

        public virtual async Task<CommentDTO> UpdateAsync(CommentDTO entity)
        {
            var value = new Comment();
            _mapper.Map(entity, value);
            await _unitOfWork.CommentRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<GetCommentDTO>> GetBySkill(string user)
        {
            Employee employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Email == user);
            var skills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(skill => skill.IdEmployee == employee.Id);
            var allComments = await _unitOfWork.CommentRepo.GetAllAsync();
            List<Comment> comments = new List<Comment>();
            foreach(var skill in skills)
            {
                var comment = allComments.FirstOrDefault(com => com.IdUserSkill == skill.Id);
                if (comment != null)
                {
                    comments.Add(comment);
                }
            }
            List<GetCommentDTO> commentDTOs = comments.Select(comment => _mapper.Map(comment, new GetCommentDTO())).ToList();
            return commentDTOs;
        }

        public virtual async Task<List<CommentDTO>> GetByEmployee(int userId)
        {
            Employee employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Id == userId);
            var skills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(skill => skill.IdEmployee == employee.Id);
            var allComments = await _unitOfWork.CommentRepo.GetAllAsync();
            List<Comment> comments = new List<Comment>();
            foreach (var skill in skills)
            {
                var comment = allComments.FirstOrDefault(com => com.IdUserSkill == skill.Id);
                if (comment != null)
                {
                    comments.Add(comment);
                }
            }
            List<CommentDTO> commentDTOs = comments.Select(comment => _mapper.Map(comment, new CommentDTO())).ToList();
            return commentDTOs;
        }
    }
}
