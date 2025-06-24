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
        private readonly ILevelRepo _levelRepo;
        public LevelController(ILevelRepo levelRepo)
        {
            _levelRepo = levelRepo;
        }

        [HttpGet("getLevels")]
        public async Task<IActionResult> Get()
        {
            var levels = await _levelRepo.GetLevels();
            return Ok(new
            {
                message = "Get levels successfully",
                statusCode = StatusCodes.Status200OK,
                data = levels
            });
        }

    }
}
