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
            var certifs = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(cer => cer.IdPublisher == id);
            await _unitOfWork.CertificateRepo.DeleteRangeAsync(certifs);
            var employees = (await _unitOfWork.EmployeeRepo.GetAllAsync()).Where(emp => emp.IdMentor == id);
            await _unitOfWork.EmployeeRepo.DeleteRangeAsync(employees);
            var notifs = (await _unitOfWork.NotificationRepo.GetAllAsync()).Where(notif => notif.IdEmployer == id);
            await _unitOfWork.NotificationRepo.DeleteRangeAsync(notifs);
            var comments = (await _unitOfWork.CommentRepo.GetAllAsync()).Where(com => com.IdEmployer == id);
            await _unitOfWork.CommentRepo.DeleteRangeAsync(comments);
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

        public virtual async Task<EmployerDTO> GetInfoFullAsync(string email)
        {
            var user = (await _unitOfWork.EmployerRepo.GetAllAsync()).FirstOrDefault(e => e.Email == email);
            var dto = new EmployerDTO();
            _mapper.Map(user, dto);
            return dto;
        }

        public virtual async Task<List<EmployerInfoDTO>> GetAllInfoAsync(string company)
        {
            var users = (await _unitOfWork.EmployerRepo.GetAllAsync()).Where(u => u.IdCompanyNavigation.Name == company);
            List<EmployerInfoDTO> employerInfoDTOs = users.Select(user => _mapper.Map(user, new EmployerInfoDTO())).ToList();
            return employerInfoDTOs;
        }

        public virtual async Task<List<EmployerDTO>> GetAllInfoAsync(int companyId)
        {
            var users = (await _unitOfWork.EmployerRepo.GetAllAsync()).Where(u => u.IdCompanyNavigation.Id == companyId);
            List<EmployerDTO> employerInfoDTOs = users.Select(user => _mapper.Map(user, new EmployerDTO())).ToList();
            return employerInfoDTOs;
        }

        public virtual async Task<bool> SetAsHr(string email)
        {
            var employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Email == email);
            if(employee != null)
            {
                Employer employer = new Employer()
                {
                    Email = employee.Email,
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    IdCompany = employee.IdCompany,
                    Password = employee.Password,
                    Role = "HR"
                };
                await _unitOfWork.EmployerRepo.AddAsync(employer);
                return true;
            }
            return false;
        }

        public virtual async Task<bool> SetAsHr(int userId)
        {
            var employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Id == userId);
            if (employee != null)
            {
                Employer employer = new Employer()
                {
                    Email = employee.Email,
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    IdCompany = employee.IdCompany,
                    Password = employee.Password,
                    Role = "HR"
                };
                await _unitOfWork.EmployerRepo.AddAsync(employer);
                return true;
            }
            return false;
        }

        public virtual async Task<bool> SetAsMentor(string email)
        {
            var employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Email == email);
            if (employee != null)
            {
                Employer employer = new Employer()
                {
                    Email = employee.Email,
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    IdCompany = employee.IdCompany,
                    Password = employee.Password,
                    Role = "Mentor"
                };
                await _unitOfWork.EmployerRepo.AddAsync(employer);
                return true;
            }
            return false;
        }

        public virtual async Task<bool> SetAsMentor(int userId)
        {
            var employee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Id == userId);
            if (employee != null)
            {
                Employer employer = new Employer()
                {
                    Email = employee.Email,
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    IdCompany = employee.IdCompany,
                    Password = employee.Password,
                    Role = "Mentor"
                };
                await _unitOfWork.EmployerRepo.AddAsync(employer);
                return true;
            }
            return false;
        }
    }
}
