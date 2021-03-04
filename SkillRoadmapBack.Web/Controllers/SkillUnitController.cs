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
    [Route("api/skillunits")]
    public class SkillUnitController : ControllerBase
    {
        private ISkillUnitService _skillUnitService;

        public SkillUnitController(ISkillUnitService skillUnitService)
        {
            _skillUnitService = skillUnitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillUnitDTO>>> Get()
        {

            var result = await _skillUnitService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillUnitDTO>> getById(int id)
        {
            var result = await _skillUnitService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<SetSkillUnitDTO>> Pull(SetSkillUnitDTO order)
        {
            await _skillUnitService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<SkillUnitDTO>> Update(SkillUnitDTO order)
        {
            var result = await _skillUnitService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _skillUnitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
