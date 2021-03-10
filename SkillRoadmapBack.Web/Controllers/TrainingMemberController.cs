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
    [Route("api/trainingmembers")]
    public class TrainingMemberController : ControllerBase
    {
        private ITrainingMemberService _trainingmemberService;

        public TrainingMemberController(ITrainingMemberService trainingmemberService)
        {
            _trainingmemberService = trainingmemberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainingMemberDTO>>> Get()
        {

            var result = await _trainingmemberService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingMemberDTO>> getById(int id)
        {
            var result = await _trainingmemberService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<TrainingMemberDTO>> Pull(TrainingMemberDTO order)
        {
            await _trainingmemberService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<TrainingMemberDTO>> Update(TrainingMemberDTO order)
        {
            var result = await _trainingmemberService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainingmemberService.DeleteAsync(id);
            return NoContent();
        }
    }
}
