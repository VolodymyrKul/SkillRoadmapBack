using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IEmployeeService : IBaseService<EmployeeDTO, EmployeeDTO>
    {
        Task<EmployeeInfoDTO> GetInfoAsync(string email);
        Task<EmployeeDTO> GetInfoFullAsync(string email);
        Task<List<EmployeeInfoDTO>> GetAllInfoAsync(string company);
        Task<List<EmployeeDTO>> GetAllInfoAsync(int companyId);
        Task<List<EmployeeInfoDTO>> GetAllByTrainingAsync(string training);
        Task<List<EmployeeDTO>> GetAllByTrainingAsync(int trainingId);
    }
}
