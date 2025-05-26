using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sprache;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService) { 
          _skillService = skillService;
        }

        [HttpGet("getSkills")]
        public async Task<IActionResult> Get()
        {
            var result = await _skillService.GetSkill();

            return Ok(new
            {
                msg = "Skills retrieved successfully", 
                statusCode = StatusCodes.Status200OK,
                data = result
            });
        }

        [HttpPost("addSkill")]
        public async Task<IActionResult> Add(SkillAction skillAction)
        {
            try
            {
                await _skillService.AddSkill(skillAction);
                return Ok(new
                {
                    msg = "Add skill successfully",
                    statusCode = StatusCodes.Status201Created,

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPut("updateSkill/{id}")]
        public async Task<IActionResult> Update(Guid id, SkillAction skillAction)
        {
            try
            {
                await _skillService.UpdateSkill(id, skillAction);
                return Ok(new
                {
                    msg = "Update skill successfully",
                    statusCode = StatusCodes.Status200OK,

                });
            }catch(KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status404NotFound
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpDelete("deleteSkill/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _skillService.DeleteSkill(id);
                return Ok(new
                {
                    msg = "Delete skill successfully",
                    statusCode = StatusCodes.Status200OK,

                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status404NotFound
                });
            }

        }
    }
}
