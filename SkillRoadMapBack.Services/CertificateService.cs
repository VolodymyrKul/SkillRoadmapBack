using AutoMapper;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.Services.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public virtual async Task<List<CertificateDTO>> GetByRecipient(int recipientId)
        {
            var certificates = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(c => c.IdRecipientNavigation.Id == recipientId && c.CertificateTitle != "").ToList();
            List<CertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new CertificateDTO())).ToList();
            return certificateDTOs;
        }

        public virtual async Task<List<GetCertificateDTO>> GetByMentor(string email)
        {
            var certificates = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(c => c.IdPublisherNavigation.Email == email && c.CertificateTitle == "").ToList();
            List<GetCertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new GetCertificateDTO())).ToList();
            return certificateDTOs;
        }

        public virtual async Task<List<CertificateDTO>> GetByMentor(int mentorId)
        {
            var certificates = (await _unitOfWork.CertificateRepo.GetAllAsync()).Where(c => c.IdPublisherNavigation.Id == mentorId && c.CertificateTitle == "").ToList();
            List<CertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new CertificateDTO())).ToList();
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

        public virtual async Task<bool> OrderCertificate(CertificateDTO orderCertificateDTO)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == orderCertificateDTO.RecipientEmail);
            Certificate certificate = new Certificate();
            certificate.IdRecipient = emp.Id;
            certificate.IdPublisher = emp.IdMentor;
            var skill = (await _unitOfWork.UserSkillRepo.GetAllAsync())
                .Where(s => s.IdEmployee == emp.Id)
                .FirstOrDefault(s => s.Skillname == orderCertificateDTO.SkillName);
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

        public virtual async Task<bool> AcceptCertificate(CertificateDTO acceptCertificateDTO)
        {
            string[] Publisher = acceptCertificateDTO.PublisherNSN.Split(' ');
            string[] Recipient = acceptCertificateDTO.RecipientNSN.Split(' ');
            var certificate = (await _unitOfWork.CertificateRepo.GetAllAsync())
                .FirstOrDefault(c => c.CertificateTitle == ""
                && c.IdPublisherNavigation.Firstname == Publisher[0]
                && c.IdPublisherNavigation.Lastname == Publisher[1]
                && c.IdRecipientNavigation.Firstname == Recipient[0]
                && c.IdRecipientNavigation.Lastname == Recipient[1]
                && c.IdUserSkillNavigation.Skillname == acceptCertificateDTO.SkillName);
            if (certificate == null)
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

        public virtual async Task DeclineCertificate(CertificateDTO orderCertificateDTO)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == orderCertificateDTO.RecipientEmail);
            var certificate = (await _unitOfWork.CertificateRepo.GetAllAsync())
                .FirstOrDefault(c => c.CertificateTitle == ""
                && c.IdPublisher == emp.IdMentor
                && c.IdRecipient == emp.Id
                && c.IdUserSkillNavigation.Skillname == orderCertificateDTO.SkillName);
            await _unitOfWork.CertificateRepo.DeleteAsync(certificate);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task PrintCertificate(CertificateDTO orderCertificateDTO)
        {
            var recip = await _unitOfWork.EmployeeRepo.GetByIdAsync((int)orderCertificateDTO.IdRecipient);
            var publish = await _unitOfWork.EmployerRepo.GetByIdAsync((int)orderCertificateDTO.IdPublisher);
            var findMentor = await _unitOfWork.EmployerRepo.GetByIdAsync((int)recip.IdMentor);
            string cerTitleLine = "CERTIFICATE OF COMPLETION";
            string underTitleLine = "THIS IS AWARDED TO";
            string FirstName = recip.Firstname.ToUpper();
            string LastName = recip.Lastname.ToUpper();
            string skillTitle = orderCertificateDTO.SkillName;
            string skillLevel = orderCertificateDTO.SkillLevel.ToString();
            string[] cerText = orderCertificateDTO.CertificateTitle.Split(' ');
            
            string certificateText = cerText[0];
            for(int i = 1;i < cerText.Length; i++)
            {
                certificateText += " "+cerText[i];
                if (i % 10 == 0)
                {
                    certificateText += "\n";
                }
            }
            string signline = "     ________________________________________";
            string whogivementor = "";
            string whogivehr = "";
            string seal = "_______________Approval seal_______________     ";
            string mentor = $"Mentor: {findMentor.Firstname} {findMentor.Lastname}";
            string hrspec = $"HR Manager: {publish.Firstname} {publish.Lastname}";
            for (int i = 0; i < 15; i++)
            {
                whogivementor += " ";
            }
            whogivementor += mentor;

            for (int i = 0; i < 15; i++)
            {
                whogivehr += " ";
            }
            whogivehr += hrspec;

            var pdf = new PdfDocument();
            var pdfPage = pdf.Pages.Add();
            pdfPage.Orientation = PdfSharp.PageOrientation.Landscape;
            var graph = XGraphics.FromPdfPage(pdfPage);
            var titleFont = new XFont("Times New Roman", 32, XFontStyle.Bold);
            var titleLine1Font = new XFont("Times New Roman", 16, XFontStyle.Bold);
            var personFont = new XFont("Times New Roman", 56, XFontStyle.Regular);
            var font = new XFont("Consolas", 8, XFontStyle.Regular);
            var tf = new XTextFormatter(graph);
            var yPoint = 60;

            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(cerTitleLine, titleFont, XBrushes.RoyalBlue, new XRect(32, yPoint, pdfPage.Width, pdfPage.Height),
                XStringFormats.TopLeft);
            yPoint += 64;
            tf.DrawString(underTitleLine, titleLine1Font, XBrushes.Black, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 16;
            tf.DrawString(FirstName, personFont, XBrushes.DarkBlue, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 56;
            tf.DrawString(LastName, personFont, XBrushes.DarkBlue, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 80;
            tf.DrawString($"Skill: {skillTitle}", titleLine1Font, XBrushes.Black, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 16;
            tf.DrawString($"Level: {skillLevel}", titleLine1Font, XBrushes.Black, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 32;
            tf.DrawString(certificateText, titleLine1Font, XBrushes.Black, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 128;

            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(signline, titleLine1Font, XBrushes.Black, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 24;
            tf.DrawString(whogivementor, titleLine1Font, XBrushes.RoyalBlue, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 24;

            tf.DrawString(signline, titleLine1Font, XBrushes.Black, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 24;
            tf.DrawString(whogivehr, titleLine1Font, XBrushes.RoyalBlue, new XRect(16, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);

            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString(seal, titleLine1Font, XBrushes.Black, new XRect(0, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);
            yPoint += 24;
            
            tf.DrawString($"{orderCertificateDTO.DateOfIssue?.ToString("dd/MM/yyyy")}-{orderCertificateDTO.ExpiryDate?.ToString("dd/MM/yyyy")}     ", titleLine1Font, XBrushes.RoyalBlue, new XRect(0, yPoint, pdfPage.Width, pdfPage.Height),
                    XStringFormats.TopLeft);

            var pdfFilename = $"Certificate{orderCertificateDTO.Id}.pdf";
            pdf.Save(pdfFilename);
            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe",
                Path.GetFullPath(pdfFilename));
        }
    }
}
