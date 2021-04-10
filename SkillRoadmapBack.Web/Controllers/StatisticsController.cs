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
    [Route("api/statistics")]
    public class StatisticsController : ControllerBase
    {
        private IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatisticsDTO>>> Get()
        {

            var result = await _statisticsService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatisticsDTO>> getById(int id)
        {
            var result = await _statisticsService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<StatisticsDTO>> Pull(StatisticsDTO order)
        {
            await _statisticsService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<StatisticsDTO>> Update(StatisticsDTO order)
        {
            var result = await _statisticsService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statisticsService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("uptstat/{emp}/{year}")]
        public async Task<ActionResult<StatisticsDTO>> getByEmpAndYear(string emp, int year)
        {
            var result = await _statisticsService.UpdateStats(emp, year);
            return Ok(result);
        }

        [HttpGet("uptstatid/{empid}/{year}")]
        public async Task<ActionResult<StatisticsDTO>> getByEmpAndYear(int empid, int year)
        {
            var result = await _statisticsService.UpdateStats(empid, year);
            return Ok(result);
        }
    }
}
