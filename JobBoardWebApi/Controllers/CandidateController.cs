using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        //[Authorize(Roles = SD.AdminRole)]
        [HttpGet("getAllCandidate")]
        public async Task<IActionResult> GetAllCandidate()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return Ok(new
            {
                Message = "Candidates retrieved successfully",
                StatusCode = StatusCodes.Status200OK,
                Data = candidates
            });
        }

        //[Authorize(Roles = SD.AdminRole)]
        [HttpGet("getCandidateById/{id}")]
        public async Task<IActionResult> GetCandidateById(Guid id)
        {
            try
            {
                var candidate = await _candidateService.GetCandidateById(id);
                return Ok(new
                {
                    message = "Candidate retrieved successfully",
                    statusCode = StatusCodes.Status200OK,
                    data = candidate
                });
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        //[Authorize(Roles = SD.CandidateRole)]
        //[Authorize(Roles = SD.AdminRole)]
        [HttpPut("updateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(Guid id, CandidateAction candidateAction)
        {
            try
            {
                await _candidateService.UpdateCandidate(id, candidateAction);
                return Ok(new
                {
                    message = "Updated successful!",
                    statusCode = StatusCodes.Status200OK,

                });
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status404NotFound,
                });
            }
        }

        //[Authorize(Roles = SD.AdminRole)]
        [HttpDelete("deleteCandidate/{id}")]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            try
            {
                await _candidateService.DeleteCandidate(id);
                return Ok(new
                {
                    message = "Candidate deleted successfully",
                    statusCode = StatusCodes.Status200OK
                });
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
