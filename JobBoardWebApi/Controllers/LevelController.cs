using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
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


        [HttpPost("addLevel")]
        public async Task<IActionResult> Post([FromBody] LevelAction levelDto)
        {

            try
            {
                await _level.AddLevel(levelDto);
                return Ok(new
                {
                    message = "Add level successfully",
                    statusCode = StatusCodes.Status201Created,
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });

            }
        }

        [HttpPut("updateLevel/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LevelAction levelDto)
        {
            try
            {
                await _level.UpdateLevel(id, levelDto);
                return Ok(new
                {
                    message = "Update level successfully",
                    statusCode = StatusCodes.Status200OK,
                });
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new
                {
                    message = e.Message,
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpDelete("deleteLevel/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _level.DeleteLevel(id);
                return Ok(new
                {
                    message = "Delete level successfully",
                    statusCode = StatusCodes.Status200OK,
                });
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new
                {
                    message = e.Message,
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

        }
    }
}
