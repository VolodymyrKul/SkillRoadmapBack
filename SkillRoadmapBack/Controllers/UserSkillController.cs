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
        public async Task<ActionResult<UserSkillDTO>> Pull(UserSkillDTO order)
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
    }
}
