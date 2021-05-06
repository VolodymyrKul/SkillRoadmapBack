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
    [Route("api/comparations")]
    public class ComparationController : ControllerBase
    {
        private IComparationService _comparationService;

        public ComparationController(IComparationService comparationService)
        {
            _comparationService = comparationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComparationDTO>>> Get()
        {

            var result = await _comparationService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComparationDTO>> getById(int id)
        {
            var result = await _comparationService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<ComparationDTO>> Pull(ComparationDTO order)
        {
            await _comparationService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<ComparationDTO>> Update(ComparationDTO order)
        {
            var result = await _comparationService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _comparationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("requirement/{id}")]
        public async Task<ActionResult<List<ComparationDTO>>> getRequirementById(int id)
        {
            var result = await _comparationService.GetRequirementIdAsync(id);
            return Ok(result);
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<List<ComparationDTO>>> getEmployeeById(int id)
        {
            var result = await _comparationService.GetEmployeeIdAsync(id);
            return Ok(result);
        }
    }
}
