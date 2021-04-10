using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IEmployerService : IBaseService<EmployerDTO, EmployerDTO>
    {
        Task<LoginInfo> LoginAsync(SignInDTO entity);
        Task<bool> RegisterAsync(SignInDTO entity);
        Task<EmployerInfoDTO> GetInfoAsync(string email);
        Task<EmployerDTO> GetInfoFullAsync(string email);
        Task<List<EmployerInfoDTO>> GetAllInfoAsync(string company);
        Task<List<EmployerDTO>> GetAllInfoAsync(int companyId);
        Task<bool> SetAsHr(string email);
        Task<bool> SetAsHr(int userId);
        Task<bool> SetAsMentor(string email);
        Task<bool> SetAsMentor(int userId);
    }
}
