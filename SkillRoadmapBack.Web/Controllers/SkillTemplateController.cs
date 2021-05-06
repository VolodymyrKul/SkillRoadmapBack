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
    [Route("api/skilltemplates")]
    public class SkillTemplateController : ControllerBase
    {
        private ISkillTemplateService _skillTemplateService;

        public SkillTemplateController(ISkillTemplateService skillTemplateService)
        {
            _skillTemplateService = skillTemplateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillTemplateDTO>>> Get()
        {

            var result = await _skillTemplateService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillTemplateDTO>> getById(int id)
        {
            var result = await _skillTemplateService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<SkillTemplateDTO>> Pull(SkillTemplateDTO order)
        {
            await _skillTemplateService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<SkillTemplateDTO>> Update(SkillTemplateDTO order)
        {
            var result = await _skillTemplateService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _skillTemplateService.DeleteAsync(id);
            return NoContent();
        }
    }
}
