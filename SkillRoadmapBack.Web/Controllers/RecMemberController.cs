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
    [Route("api/recmembers")]
    public class RecMemberController : ControllerBase
    {
        private IRecMemberService _recMemberService;

        public RecMemberController(IRecMemberService recMemberService)
        {
            _recMemberService = recMemberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecMemberDTO>>> Get()
        {

            var result = await _recMemberService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecMemberDTO>> getById(int id)
        {
            var result = await _recMemberService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<RecMemberDTO>> Pull(RecMemberDTO order)
        {
            await _recMemberService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<RecMemberDTO>> Update(RecMemberDTO order)
        {
            var result = await _recMemberService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _recMemberService.DeleteAsync(id);
            return NoContent();
        }
    }
}
