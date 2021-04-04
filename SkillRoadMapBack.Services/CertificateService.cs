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
    public class CertificateService : BaseService, ICertificateService
    {
        public CertificateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(CertificateDTO entity)
        {
            var value = new Certificate();
            _mapper.Map(entity, value);
            await _unitOfWork.CertificateRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CertificateRepo.GetByIdAsync(id);
            await _unitOfWork.CertificateRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CertificateDTO>> GetAll()
        {
            var certificates = await _unitOfWork.CertificateRepo.GetAllAsync();
            List<CertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new CertificateDTO())).ToList();
            return certificateDTOs;
        }

        public virtual async Task<CertificateDTO> GetIdAsync(int id)
        {
            var certificate = await _unitOfWork.CertificateRepo.GetByIdAsync(id);
            if (certificate == null)
                throw new Exception("Such category not found");
            var dto = new CertificateDTO();
            _mapper.Map(certificate, dto);
            return dto;
        }

        public virtual async Task<CertificateDTO> UpdateAsync(CertificateDTO entity)
        {
            var value = new Certificate();
            _mapper.Map(entity, value);
            await _unitOfWork.CertificateRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<GetCertificateDTO>> GetByEmail(string email)
        {
            var certificates = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(c => c.IdRecipientNavigation.Email == email && c.CertificateTitle != "").ToList();
            List<GetCertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new GetCertificateDTO())).ToList();
            return certificateDTOs;
        }

        public virtual async Task<List<GetCertificateDTO>> GetByMentor(string email)
        {
            var certificates = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(c => c.IdPublisherNavigation.Email == email && c.CertificateTitle == "").ToList();
            List<GetCertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new GetCertificateDTO())).ToList();
            return certificateDTOs;
        }

        public virtual async Task<bool> OrderCertificate(OrderCertificateDTO orderCertificateDTO)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == orderCertificateDTO.RecipientEmail);
            Certificate certificate = new Certificate();
            certificate.IdRecipient = emp.Id;
            certificate.IdPublisher = emp.IdMentor;
            var skill = (await _unitOfWork.UserSkillRepo.GetAllAsync())
                .Where(s => s.IdEmployee == emp.Id)
                .FirstOrDefault(s => s.Skillname == orderCertificateDTO.UserSkillName);
            certificate.IdUserSkill = skill.Id;
            certificate.CertificateTitle = "";
            certificate.SkillLevel = 0;
            await _unitOfWork.CertificateRepo.AddAsync(certificate);
            await _unitOfWork.SaveChangesAsync();

            Notification notification = new Notification();
            notification.IdUserSkill = skill.Id;
            notification.IdEmployer = emp.IdMentor;
            notification.IdEmployee = emp.Id;
            notification.IsRead = false;
            notification.NotificationText = $"Employee {emp.Firstname} {emp.Lastname} wants";
            notification.SendingDate = DateTime.Now;
            await _unitOfWork.NotificationRepo.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AcceptCertificate(GetCertificateDTO acceptCertificateDTO)
        {
            string[] Publisher = acceptCertificateDTO.PublisherNSN.Split(' ');
            string[] Recipient = acceptCertificateDTO.RecipientNSN.Split(' ');
            var certificate = (await _unitOfWork.CertificateRepo.GetAllAsync())
                .FirstOrDefault(c => c.CertificateTitle == ""
                && c.IdPublisherNavigation.Firstname == Publisher[0]
                && c.IdPublisherNavigation.Lastname == Publisher[1]
                && c.IdRecipientNavigation.Firstname == Recipient[0]
                && c.IdRecipientNavigation.Lastname == Recipient[1]
                && c.IdUserSkillNavigation.Skillname == acceptCertificateDTO.UserSkill);
            if(certificate == null)
            {
                return false;
            }
            else
            {
                certificate.CertificateTitle = acceptCertificateDTO.CertificateTitle;
                certificate.DateOfIssue = acceptCertificateDTO.DateOfIssue;
                certificate.ExpiryDate = acceptCertificateDTO.ExpiryDate;
                certificate.SkillLevel = acceptCertificateDTO.SkillLevel;
                await _unitOfWork.CertificateRepo.UpdateAsync(certificate);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
        }

        public virtual async Task DeclineCertificate(OrderCertificateDTO orderCertificateDTO)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == orderCertificateDTO.RecipientEmail);
            var certificate = (await _unitOfWork.CertificateRepo.GetAllAsync())
                .FirstOrDefault(c => c.CertificateTitle == ""
                && c.IdPublisher == emp.IdMentor
                && c.IdRecipient == emp.Id
                && c.IdUserSkillNavigation.Skillname == orderCertificateDTO.UserSkillName);
            await _unitOfWork.CertificateRepo.DeleteAsync(certificate);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
