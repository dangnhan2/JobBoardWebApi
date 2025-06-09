using JobBoardWebApi.Dtos;
using JobBoardWebApi.Repositories;
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
    }
}
