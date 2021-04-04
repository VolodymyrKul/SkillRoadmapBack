using Microsoft.AspNetCore.Mvc;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Web.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotificationDTO>>> Get()
        {

            var result = await _notificationService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDTO>> getById(int id)
        {
            var result = await _notificationService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<NotificationDTO>> Pull(NotificationDTO order)
        {
            await _notificationService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<NotificationDTO>> Update(NotificationDTO order)
        {
            var result = await _notificationService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _notificationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("byemployee/{email}")]
        public async Task<ActionResult<List<GetNotificationDTO>>> GetByEmployee(string email)
        {

            var result = await _notificationService.GetByEmployee(email);
            return Ok(result);

        }

        [HttpGet("byemployer/{email}")]
        public async Task<ActionResult<List<GetNotificationDTO>>> GetByEmployer(string email)
        {

            var result = await _notificationService.GetByEmployer(email);
            return Ok(result);

        }
    }
}
