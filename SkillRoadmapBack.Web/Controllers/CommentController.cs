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
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDTO>>> Get()
        {

            var result = await _commentService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> getById(int id)
        {
            var result = await _commentService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost("pull")]
        public async Task<ActionResult<CommentDTO>> Pull(CommentDTO order)
        {
            await _commentService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<CommentDTO>> Update(CommentDTO order)
        {
            var result = await _commentService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("byskill/{inemail}")]
        public async Task<ActionResult<List<GetCommentDTO>>> GetByUserSkill(string inemail)
        {
            var result = await _commentService.GetBySkill(inemail);
            return Ok(result);
        }

        [HttpGet("byskillid/{userid}")]
        public async Task<ActionResult<List<CommentDTO>>> GetByUserSkill(int userid)
        {
            var result = await _commentService.GetByEmployee(userid);
            return Ok(result);
        }
    }
}
