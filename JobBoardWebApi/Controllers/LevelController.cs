using JobBoardWebApi.Dtos;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _level;
        public LevelController(ILevelService level)
        {
            _level = level;
        }

        [HttpGet("getLevels")]
        public async Task<IActionResult> Get()
        {
            var levels = await _level.GetLevels();
            return Ok(new
            {
                message = "Get levels successfully",
                statusCode = StatusCodes.Status200OK,
                data = levels
            });
        }

    }
}
