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
    [Route("api/skilldistribs")]
    public class SkillDistributionController : ControllerBase
    {
        private ISkillDistributionService _skillDistributionService;

        public SkillDistributionController(ISkillDistributionService skillDistributionService)
        {
            _skillDistributionService = skillDistributionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillDistributionDTO>>> Get()
        {

            var result = await _skillDistributionService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDistributionDTO>> getById(int id)
        {
            var result = await _skillDistributionService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<SkillDistributionDTO>> Pull(SkillDistributionDTO order)
        {
            await _skillDistributionService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<SkillDistributionDTO>> Update(SkillDistributionDTO order)
        {
            var result = await _skillDistributionService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _skillDistributionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
