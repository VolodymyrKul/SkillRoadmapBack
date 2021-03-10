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
    [Route("api/trainings")]
    public class TrainingController : ControllerBase
    {
        private ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainingDTO>>> Get()
        {

            var result = await _trainingService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDTO>> getById(int id)
        {
            var result = await _trainingService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<TrainingDTO>> Pull(TrainingDTO order)
        {
            await _trainingService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<TrainingDTO>> Update(TrainingDTO order)
        {
            var result = await _trainingService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
