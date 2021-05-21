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
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(EmployeeDTO entity)
        {
            var value = new Employee();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployeeRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.EmployeeRepo.GetByIdAsync(id);
            var recommends = (await _unitOfWork.RecommendationRepo.GetAllAsync()).Where(rec => rec.IdEmployee == id);
            await _unitOfWork.RecommendationRepo.DeleteRangeAsync(recommends);
            var stats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).Where(st => st.IdEmployee == id);
            await _unitOfWork.StatisticsRepo.DeleteRangeAsync(stats);
            var certifs = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(cer => cer.IdRecipient == id);
            await _unitOfWork.CertificateRepo.DeleteRangeAsync(certifs);
            var userSkills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(us => us.IdEmployee == id);
            await _unitOfWork.UserSkillRepo.DeleteRangeAsync(userSkills);
            var notifs = (await _unitOfWork.NotificationRepo.GetAllAsync()).Where(notif => notif.IdEmployee == id);
            await _unitOfWork.NotificationRepo.DeleteRangeAsync(notifs);
            var comparations = (await _unitOfWork.ComparationRepo.GetAllAsync()).Where(com => com.IdEmployee == id);
            await _unitOfWork.ComparationRepo.DeleteRangeAsync(comparations);
            await _unitOfWork.EmployeeRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<EmployeeDTO>> GetAll()
        {
            var employees = await _unitOfWork.EmployeeRepo.GetAllAsync();
            List<EmployeeDTO> employeeDTOs = employees.Select(employee => _mapper.Map(employee, new EmployeeDTO())).ToList();
            return employeeDTOs;
        }

        public virtual async Task<EmployeeDTO> GetIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepo.GetByIdAsync(id);
            if (employee == null)
                throw new Exception("Such employee not found");
            var dto = new EmployeeDTO();
            _mapper.Map(employee, dto);
            return dto;
        }

        public virtual async Task<EmployeeDTO> UpdateAsync(EmployeeDTO entity)
        {
            var value = new Employee();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployeeRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<EmployeeInfoDTO> GetInfoAsync(string email)
        {
            var user = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == email);
            var dto = new EmployeeInfoDTO();
            _mapper.Map(user, dto);
            return dto;
        }

        public virtual async Task<EmployeeDTO> GetInfoFullAsync(string email)
        {
            var user = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == email);
            var dto = new EmployeeDTO();
            _mapper.Map(user, dto);
            return dto;
        }

        public virtual async Task<List<EmployeeInfoDTO>> GetAllInfoAsync(string company)
        {
            var users = (await _unitOfWork.EmployeeRepo.GetAllAsync()).Where(u => u.IdCompanyNavigation.Name == company);
            List<EmployeeInfoDTO> employeeInfoDTOs = users.Select(user => _mapper.Map(user, new EmployeeInfoDTO())).ToList();
            return employeeInfoDTOs;
        }

        public virtual async Task<List<EmployeeDTO>> GetAllInfoAsync(int companyId)
        {
            var users = (await _unitOfWork.EmployeeRepo.GetAllAsync()).Where(u => u.IdCompanyNavigation.Id == companyId);
            List<EmployeeDTO> employeeInfoDTOs = users.Select(user => _mapper.Map(user, new EmployeeDTO())).ToList();
            return employeeInfoDTOs;
        }

        public virtual async Task<List<EmployeeInfoDTO>> GetAllByTrainingAsync(string training)
        {
            var trainingMembers = (await _unitOfWork.TrainingMemberRepo.GetAllAsync()).Where(tr => tr.IdTrainingNavigation.TrainingTitle == training);
            List<EmployeeInfoDTO> employeeInfoDTOs = trainingMembers.Select(tr => _mapper.Map(tr.IdMemberNavigation, new EmployeeInfoDTO())).ToList();
            return employeeInfoDTOs;
        }

        public virtual async Task<List<EmployeeDTO>> GetAllByTrainingAsync(int trainingId)
        {
            var trainingMembers = (await _unitOfWork.TrainingMemberRepo.GetAllAsync()).Where(tr => tr.IdTrainingNavigation.Id == trainingId);
            List<EmployeeDTO> employeeInfoDTOs = trainingMembers.Select(tr => _mapper.Map(tr.IdMemberNavigation, new EmployeeDTO())).ToList();
            return employeeInfoDTOs;
        }
    }
}
