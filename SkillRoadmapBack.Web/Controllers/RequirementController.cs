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
    [Route("api/requirements")]
    public class RequirementController : ControllerBase
    {
        private IRequirementService _requirementService;

        public RequirementController(IRequirementService requirementService)
        {
            _requirementService = requirementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequirementDTO>>> Get()
        {

            var result = await _requirementService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequirementDTO>> getById(int id)
        {
            var result = await _requirementService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<RequirementDTO>> Pull(RequirementDTO order)
        {
            await _requirementService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<RequirementDTO>> Update(RequirementDTO order)
        {
            var result = await _requirementService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _requirementService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("skilltemplate/{id}")]
        public async Task<ActionResult<List<RequirementDTO>>> getSkillTemplateById(int id)
        {
            var result = await _requirementService.GetSkillTemplateIdAsync(id);
            return Ok(result);
        }
    }
}
