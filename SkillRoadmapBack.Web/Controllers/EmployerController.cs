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

        [HttpPost("login")]
        public async Task<ActionResult<LoginInfo>> Login(SignInDTO order)
        {
            var result = await _employerService.LoginAsync(order);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(SignInDTO order)
        {
            var result = await _employerService.RegisterAsync(order);
            return Ok(result);
        }

        [HttpGet("getinfo/{email}")]
        public async Task<ActionResult<EmployerInfoDTO>> GetInfo(string email)
        {
            var result = await _employerService.GetInfoAsync(email);
            return Ok(result);
        }

        [HttpGet("getinfofull/{email}")]
        public async Task<ActionResult<EmployerDTO>> GetInfoFull(string email)
        {
            var result = await _employerService.GetInfoFullAsync(email);
            return Ok(result);
        }

        [HttpGet("getallinfo/{company}")]
        public async Task<ActionResult<List<EmployerInfoDTO>>> GetAllInfo(string company)
        {
            var result = await _employerService.GetAllInfoAsync(company);
            return Ok(result);
        }

        [HttpGet("getallinfoid/{companyid}")]
        public async Task<ActionResult<List<EmployerDTO>>> GetAllInfo(int companyid)
        {
            var result = await _employerService.GetAllInfoAsync(companyid);
            return Ok(result);
        }

        [HttpGet("sethr/{email}")]
        public async Task<ActionResult<bool>> SetHr(string email)
        {
            var result = await _employerService.SetAsHr(email);
            return Ok(result);
        }

        [HttpGet("sethrid/{userid}")]
        public async Task<ActionResult<bool>> SetHr(int userid)
        {
            var result = await _employerService.SetAsHr(userid);
            return Ok(result);
        }

        [HttpGet("setmentor/{email}")]
        public async Task<ActionResult<bool>> SetMentor(string email)
        {
            var result = await _employerService.SetAsMentor(email);
            return Ok(result);
        }

        [HttpGet("setmentorid/{userid}")]
        public async Task<ActionResult<bool>> SetMentor(int userid)
        {
            var result = await _employerService.SetAsMentor(userid);
            return Ok(result);
        }
    }
}
