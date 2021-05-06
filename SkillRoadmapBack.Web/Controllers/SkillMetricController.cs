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
    [Route("api/skillmetrics")]
    public class SkillMetricController : ControllerBase
    {
        private ISkillMetricService _skillMetricService;

        public SkillMetricController(ISkillMetricService skillMetricService)
        {
            _skillMetricService = skillMetricService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillMetricDTO>>> Get()
        {

            var result = await _skillMetricService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillMetricDTO>> getById(int id)
        {
            var result = await _skillMetricService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<SkillMetricDTO>> Pull(SetSkillMetricDTO order)
        {
            await _skillMetricService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<SkillMetricDTO>> Update(SkillMetricDTO order)
        {
            var result = await _skillMetricService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _skillMetricService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("userskill/{id}")]
        public async Task<ActionResult<SkillMetricDTO>> getByUserSkillId(int id)
        {
            var result = await _skillMetricService.GetUserSkillIdAsync(id);
            return Ok(result);
        }
    }
}
