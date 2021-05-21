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
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(CategoryDTO entity)
        {
            var value = new Category();
            _mapper.Map(entity, value);
            await _unitOfWork.CategoryRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            var userSkills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(us => us.IdCategory == id);
            await _unitOfWork.UserSkillRepo.DeleteRangeAsync(userSkills);
            var trainings = (await _unitOfWork.TrainingRepo.GetAllAsync()).Where(tr => tr.IdCategory == id);
            await _unitOfWork.TrainingRepo.DeleteRangeAsync(trainings);
            await _unitOfWork.CategoryRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CategoryDTO>> GetAll()
        {
            var categories = await _unitOfWork.CategoryRepo.GetAllAsync();
            List<CategoryDTO> categoryDTOs = categories.Select(category => _mapper.Map(category, new CategoryDTO())).ToList();
            return categoryDTOs;
        }

        public virtual async Task<CategoryDTO> GetIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Such category not found");
            var dto = new CategoryDTO();
            _mapper.Map(category, dto);
            return dto;
        }

        public virtual async Task<CategoryDTO> UpdateAsync(CategoryDTO entity)
        {
            var value = new Category();
            _mapper.Map(entity, value);
            await _unitOfWork.CategoryRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
