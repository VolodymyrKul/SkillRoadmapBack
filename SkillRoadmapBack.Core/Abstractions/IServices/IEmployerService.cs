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
        Task<List<EmployerInfoDTO>> GetAllInfoAsync(string company);
    }
}
