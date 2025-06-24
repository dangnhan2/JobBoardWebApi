using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Recruiter
{
    [Route("api/recruiter/[controller]")]
    [ApiController]
    //[Authorize (Roles = "Recruiter")]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterRepo _recruiterRepo;

        public RecruiterController(IRecruiterRepo recruiterRepo)
        {
            _recruiterRepo = recruiterRepo;
        }

        [HttpGet("GetRecruiterById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _recruiterRepo.GetByIdAsync(id);
                return Ok(new
                {
                    msg = "Recruiter retrieved successfully",
                    statusCode = StatusCodes.Status200OK,
                    data = result
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

        [HttpPut("UpdateRecruiter/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RecruiterPutRequest recruiterPostDto)
        {
            try
            {
                await _recruiterRepo.UpdateRecruiterAsync(id, recruiterPostDto);
                return Ok(new
                {
                    msg = "Recruiter updated successfully",
                    statusCode = StatusCodes.Status200OK
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
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
