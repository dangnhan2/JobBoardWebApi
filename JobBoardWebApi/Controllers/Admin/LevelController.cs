using JobBoardWebApi.Dtos;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _level;
        public LevelController(ILevelService level)
        {
            _level = level;
        }


        [HttpPost("addLevel")]
        public async Task<IActionResult> Post([FromBody] LevelRequest levelDto)
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
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });

            }
        }

        [HttpPut("updateLevel/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LevelRequest levelDto)
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
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
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
