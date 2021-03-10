using Microsoft.AspNetCore.Mvc;
using SkillRoadmapBack.Core.Abstractions.IServices;
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

        [HttpPut]
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
    }
}
