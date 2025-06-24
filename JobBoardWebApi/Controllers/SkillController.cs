using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
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
        private readonly ISkillRepo _skillRepo;

        public SkillController(ISkillRepo skillRepo) {
            _skillRepo = skillRepo;
        }

        [HttpGet("getSkills")]
        public async Task<IActionResult> Get()
        {
            var result = await _skillRepo.GetSkill();

            return Ok(new
            {
                msg = "Get skills successful",
                statusCode = StatusCodes.Status200OK,
                data = result
            });
        }
    }
}
