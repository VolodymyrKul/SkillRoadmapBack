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
    [Route("api/certificates")]
    public class CertificateController : ControllerBase
    {
        private ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CertificateDTO>>> Get()
        {

            var result = await _certificateService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateDTO>> getById(int id)
        {
            var result = await _certificateService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<CertificateDTO>> Pull(CertificateDTO order)
        {
            await _certificateService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut("update")]
        public async Task<ActionResult<CertificateDTO>> Update(CertificateDTO order)
        {
            var result = await _certificateService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _certificateService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("byuser/{email}")]
        public async Task<ActionResult<List<GetCertificateDTO>>> getByEmail(string email)
        {
            var result = await _certificateService.GetByEmail(email);
            return Ok(result);
        }

        [HttpGet("byuserid/{recipientId}")]
        public async Task<ActionResult<List<CertificateDTO>>> getByEmail(int recipientId)
        {
            var result = await _certificateService.GetByRecipient(recipientId);
            return Ok(result);
        }

        [HttpGet("bymentor/{email}")]
        public async Task<ActionResult<List<GetCertificateDTO>>> getByMentor(string email)
        {
            var result = await _certificateService.GetByMentor(email);
            return Ok(result);
        }

        [HttpGet("bymentorid/{mentorId}")]
        public async Task<ActionResult<List<GetCertificateDTO>>> getByMentor(int mentorId)
        {
            var result = await _certificateService.GetByMentor(mentorId);
            return Ok(result);
        }

        [HttpPost("order")]
        public async Task<ActionResult<bool>> Order(OrderCertificateDTO order)
        {
            await _certificateService.OrderCertificate(order);
            return Ok(order);
        }

        [HttpPost("ordernew")]
        public async Task<ActionResult<bool>> Order(CertificateDTO order)
        {
            await _certificateService.OrderCertificate(order);
            return Ok(order);
        }

        [HttpPut("accept")]
        public async Task<ActionResult<bool>> Accept(GetCertificateDTO order)
        {
            var result = await _certificateService.AcceptCertificate(order);
            return Ok(result);
        }

        [HttpPut("acceptnew")]
        public async Task<ActionResult<bool>> Accept(CertificateDTO order)
        {
            var result = await _certificateService.AcceptCertificate(order);
            return Ok(result);
        }

        [HttpPost("decline")]
        public async Task<IActionResult> Decline(OrderCertificateDTO order)
        {
            await _certificateService.DeclineCertificate(order);
            return NoContent();
        }

        [HttpPost("declinenew")]
        public async Task<IActionResult> Decline(CertificateDTO order)
        {
            await _certificateService.DeclineCertificate(order);
            return NoContent();
        }
        [HttpPost("printcer")]
        public async Task<ActionResult<bool>> PrintCer(CertificateDTO order)
        {
            await _certificateService.PrintCertificate(order);
            return Ok(true);
        }
    }
}
