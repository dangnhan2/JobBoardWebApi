using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterRepo _recruiterRepo;

        public RecruiterController(IRecruiterRepo recruiterRepo)
        {
            _recruiterRepo = recruiterRepo;
        }

        [HttpGet("GetAllRecruiters")]
        public async Task<IActionResult> GetAll([FromQuery] RecruiterQueryParams recruiterFilter)
        {
            var result = await _recruiterRepo.GetAllRecruiterAsync(recruiterFilter);

            return Ok(new
            {
                msg = "Recruiters retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = result
            });
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

        [HttpPost("CreateRecruiter")]
        public async Task<IActionResult> Create([FromBody] RecruiterRequest recruiterPostDto)
        {
            try
            {
                await _recruiterRepo.CreateRecruiterAsync(recruiterPostDto);
                return Ok(new
                {
                    msg = "Recruiter created successfully",
                    StatusCode = StatusCodes.Status201Created
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

        [HttpDelete("DeleteRecruiter/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _recruiterRepo.DeleteRecruiterAsync(id);
                return Ok(new
                {
                    msg = "Recruiter deleted successfully",
                    statusCode = StatusCodes.Status200OK
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
