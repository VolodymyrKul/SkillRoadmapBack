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
        Task<List<CertificateDTO>> GetByRecipient(int recipientId);
        Task<bool> OrderCertificate(OrderCertificateDTO orderCertificateDTO);
        Task<bool> OrderCertificate(CertificateDTO orderCertificateDTO);
        Task<bool> AcceptCertificate(GetCertificateDTO acceptCertificateDTO);
        Task<bool> AcceptCertificate(CertificateDTO acceptCertificateDTO);
        Task DeclineCertificate(OrderCertificateDTO orderCertificateDTO);
        Task DeclineCertificate(CertificateDTO orderCertificateDTO);
        Task<List<GetCertificateDTO>> GetByMentor(string email);
        Task<List<CertificateDTO>> GetByMentor(int mentorId);
    }
}
