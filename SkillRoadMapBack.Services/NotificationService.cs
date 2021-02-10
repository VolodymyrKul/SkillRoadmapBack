using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
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
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(NotificationDTO entity)
        {
            var value = new Notification();
            _mapper.Map(entity, value);
            await _unitOfWork.NotificationRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.NotificationRepo.GetByIdAsync(id);
            await _unitOfWork.NotificationRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<NotificationDTO>> GetAll()
        {
            var notifications = await _unitOfWork.NotificationRepo.GetAllAsync();
            List<NotificationDTO> notificationDTOs = notifications.Select(notification => _mapper.Map(notification, new NotificationDTO())).ToList();
            return notificationDTOs;
        }

        public virtual async Task<NotificationDTO> GetIdAsync(int id)
        {
            var notification = await _unitOfWork.NotificationRepo.GetByIdAsync(id);
            if (notification == null)
                throw new Exception("Such order not found");
            var dto = new NotificationDTO();
            _mapper.Map(notification, dto);
            return dto;
        }

        public virtual async Task<NotificationDTO> UpdateAsync(NotificationDTO entity)
        {
            var value = new Notification();
            _mapper.Map(entity, value);
            await _unitOfWork.NotificationRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
