using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;

        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        [HttpGet("GetAllRecruiters")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _recruiterService.GetAllRecruiter();

            return Ok(new
            {
                message = "Recruiters retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = result
            });
        }

        [HttpGet("GetRecruiterById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _recruiterService.GetById(id);
                return Ok(new
                {
                    message = "Recruiter retrieved successfully",
                    statusCode = StatusCodes.Status200OK,
                    data = result
                });

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status404NotFound
                });
            }
        }

       
        [HttpPost("CreateRecruiter")]
        public async Task<IActionResult> Create([FromBody] RecruiterAction recruiterPostDto)
        {
            try
            {
                await _recruiterService.CreateRecruiter(recruiterPostDto);
                return Ok(new
                {
                    Message = "Recruiter created successfully",
                    StatusCode = StatusCodes.Status201Created
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPut("UpdateRecruiter/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RecruiterAction recruiterPostDto)
        {
            try
            {
                await _recruiterService.UpdateRecruiter(id, recruiterPostDto);
                return Ok(new
                {
                    message = "Recruiter updated successfully",
                    statusCode = StatusCodes.Status200OK
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status404NotFound
                });
            }
        }

        [HttpDelete("DeleteRecruiter/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _recruiterService.DeleteRecruiter(id);
                return Ok(new
                {
                    message = "Recruiter deleted successfully",
                    statusCode = StatusCodes.Status200OK
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status404NotFound
                });
            }
        }
    }
}
