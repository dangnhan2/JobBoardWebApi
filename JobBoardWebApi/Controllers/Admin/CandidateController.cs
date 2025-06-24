using JobBoardWebApi.Filter;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    //[Authorize ("Admin")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepo _candidateRepo;

        public CandidateController(ICandidateRepo candidateRepo)
        {
            _candidateRepo = candidateRepo;
        }

        [HttpGet("getAllCandidate")]
        public async Task<IActionResult> GetAllCandidate([FromQuery] CandidateQueryParams candidateFilter)
        {
            var candidates = await _candidateRepo.GetAllCandidatesAsync(candidateFilter);
            return Ok(new
            {
                Message = "Candidates retrieved successfully",
                StatusCode = StatusCodes.Status200OK,
                Data = candidates
            });
        }

        [HttpGet("getCandidateById/{id}")]
        public async Task<IActionResult> GetCandidateById(Guid id)
        {
            try
            {
                var candidate = await _candidateRepo.GetCandidateByIdAsync(id);
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

        [HttpDelete("deleteCandidate/{id}")]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            try
            {
                await _candidateRepo.DeleteCandidateAsync(id);
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
