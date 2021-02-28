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
    public class EmployerService : BaseService, IEmployerService
    {
        public EmployerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(EmployerDTO entity)
        {
            var value = new Employer();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployerRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.EmployerRepo.GetByIdAsync(id);
            await _unitOfWork.EmployerRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<EmployerDTO>> GetAll()
        {
            var employers = await _unitOfWork.EmployerRepo.GetAllAsync();
            List<EmployerDTO> employerDTOs = employers.Select(employer => _mapper.Map(employer, new EmployerDTO())).ToList();
            return employerDTOs;
        }

        public virtual async Task<EmployerDTO> GetIdAsync(int id)
        {
            var employer = await _unitOfWork.EmployerRepo.GetByIdAsync(id);
            if (employer == null)
                throw new Exception("Such employer not found");
            var dto = new EmployerDTO();
            _mapper.Map(employer, dto);
            return dto;
        }

        public virtual async Task<EmployerDTO> UpdateAsync(EmployerDTO entity)
        {
            var value = new Employer();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployerRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<LoginInfo> LoginAsync(SignInDTO entity)
        {
            LoginInfo loginInfo = new LoginInfo();
            var employer = (await _unitOfWork.EmployerRepo.GetAllAsync()).FirstOrDefault(u => u.Email == entity.Email);
            if (employer != null)
            {
                if (employer.Password == entity.Password)
                {
                    loginInfo.IsLogged = true;
                    loginInfo.Role = employer.Role;
                    return loginInfo;
                }
            }
            var employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(u => u.Email == entity.Email);
            if (employee != null)
            {
                if (employee.Password == entity.Password)
                {
                    loginInfo.IsLogged = true;
                    loginInfo.Role = employee.Role;
                    return loginInfo;
                }
            }
            loginInfo.IsLogged = false;
            loginInfo.Role = "No Role";
            return loginInfo;
        }

        public virtual async Task<bool> RegisterAsync(SignInDTO entity)
        {
            var employer = (await _unitOfWork.EmployerRepo.GetAllAsync()).FirstOrDefault(u => u.Email == entity.Email);
            if (employer != null)
            {
                return false;
            }
            var employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(u => u.Email == entity.Email);
            if (employee != null)
            {
                return false;
            }
            Employee newEmployee = new Employee
            {
                Firstname = "Change this first name",
                Lastname = "Change this last name",
                Email = entity.Email,
                Password = entity.Password,
                Role = "Change this role",
                DevLevel = "Change this dev level",
                Experience = 0
            };
            await _unitOfWork.EmployeeRepo.AddAsync(newEmployee);
            return true;
        }

        public virtual async Task<EmployerInfoDTO> GetInfoAsync(string email)
        {
            var user = (await _unitOfWork.EmployerRepo.GetAllAsync()).FirstOrDefault(e => e.Email == email);
            var dto = new EmployerInfoDTO();
            _mapper.Map(user, dto);
            return dto;
        }
    }
}
