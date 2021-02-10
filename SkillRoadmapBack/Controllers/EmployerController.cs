using Microsoft.AspNetCore.Mvc;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Controllers
{
    [ApiController]
    [Route("api/employers")]
    public class EmployerController : ControllerBase
    {
        private IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployerDTO>>> Get()
        {

            var result = await _employerService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerDTO>> getById(int id)
        {
            var result = await _employerService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<EmployerDTO>> Pull(EmployerDTO order)
        {
            await _employerService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<EmployerDTO>> Update(EmployerDTO order)
        {
            var result = await _employerService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
