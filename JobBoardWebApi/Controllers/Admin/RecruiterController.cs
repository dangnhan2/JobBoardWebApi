using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;

        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        [HttpGet("GetAllRecruiters")]
        public async Task<IActionResult> GetAll([Required] int page, [Required] int pageSize)
        {
            var result = await _recruiterService.GetAllRecruiterAsync(page, pageSize);

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
                var result = await _recruiterService.GetByIdAsync(id);
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
                await _recruiterService.CreateRecruiterAsync(recruiterPostDto);
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
                await _recruiterService.UpdateRecruiterAsync(id, recruiterPostDto);
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
                await _recruiterService.DeleteRecruiterAsync(id);
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
