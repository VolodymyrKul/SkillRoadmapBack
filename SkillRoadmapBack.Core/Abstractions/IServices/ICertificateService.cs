using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface ICertificateService : IBaseService<CertificateDTO, CertificateDTO>
    {
        Task<List<GetCertificateDTO>> GetByEmail(string email);
        Task<bool> OrderCertificate(OrderCertificateDTO orderCertificateDTO);
        Task<bool> AcceptCertificate(GetCertificateDTO acceptCertificateDTO);
        Task DeclineCertificate(OrderCertificateDTO orderCertificateDTO);
        Task<List<GetCertificateDTO>> GetByMentor(string email);
    }
}
