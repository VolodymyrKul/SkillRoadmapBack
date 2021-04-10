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
    [Route("api/userskills")]
    public class UserSkillController : ControllerBase
    {
        private IUserSkillService _userSkillService;

        public UserSkillController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserSkillDTO>>> Get()
        {

            var result = await _userSkillService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkillDTO>> getById(int id)
        {
            var result = await _userSkillService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<SetUserSkillDTO>> Pull(SetUserSkillDTO order)
        {
            await _userSkillService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<UserSkillDTO>> Update(UserSkillDTO order)
        {
            var result = await _userSkillService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userSkillService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("byyear/{inuser}/{inyear}")]
        public async Task<ActionResult<List<GetUserSkillDTO>>> GetByUserYear(string inuser, int inyear)
        {
            var result = await _userSkillService.GetByYear(inuser, inyear);
            return Ok(result);
        }

        [HttpGet("byyearid/{userid}/{inyear}")]
        public async Task<ActionResult<List<UserSkillDTO>>> GetByUserYear(int userid, int inyear)
        {
            var result = await _userSkillService.GetByYear(userid, inyear);
            return Ok(result);
        }

        [HttpGet("getyears/{inuser}")]
        public async Task<ActionResult<List<int>>> GetYears(string inuser)
        {
            var result = await _userSkillService.GetYears(inuser);
            return Ok(result);
        }

        [HttpGet("getyearsid/{userid}")]
        public async Task<ActionResult<List<int>>> GetYears(int userid)
        {
            var result = await _userSkillService.GetYears(userid);
            return Ok(result);
        }

        [HttpGet("getonly/{inuser}")]
        public async Task<ActionResult<List<GetUserSkillDTO>>> GetOnly(string inuser)
        {
            var result = await _userSkillService.GetOnlyUSkills(inuser);
            return Ok(result);
        }

        [HttpGet("getonlyid/{userid}")]
        public async Task<ActionResult<List<GetUserSkillDTO>>> GetOnly(int userid)
        {
            var result = await _userSkillService.GetOnlyUSkills(userid);
            return Ok(result);
        }
    }
}
