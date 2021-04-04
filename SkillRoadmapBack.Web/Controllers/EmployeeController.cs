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
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> Get()
        {

            var result = await _employeeService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> getById(int id)
        {
            var result = await _employeeService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<EmployeeDTO>> Pull(EmployeeDTO order)
        {
            await _employeeService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<EmployeeDTO>> Update(EmployeeDTO order)
        {
            var result = await _employeeService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("getinfo/{email}")]
        public async Task<ActionResult<EmployeeInfoDTO>> GetInfo(string email)
        {
            var result = await _employeeService.GetInfoAsync(email);
            return Ok(result);
        }

        [HttpGet("getallinfo/{company}")]
        public async Task<ActionResult<EmployeeInfoDTO>> GetAllInfo(string company)
        {
            var result = await _employeeService.GetAllInfoAsync(company);
            return Ok(result);
        }
    }
}
