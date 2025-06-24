using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Candidate_
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize (Roles = "Candidate")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepo _candidateRepo;

        public CandidateController(ICandidateRepo candidateRepo)
        {
            _candidateRepo = candidateRepo;
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

        [HttpGet("getJobsType")]
        public async Task<IActionResult> GetAllJobsType(Guid id, [Required] string type)
        {
            try
            {
                var result = await _candidateRepo.GetJobByCandidate(id, type);
                return Ok(new
                {
                    message = "Candidate retrieved successfully",
                    statusCode = StatusCodes.Status200OK,
                    data = result
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

        [HttpPatch("saveJob/{id}")]
        public async Task<IActionResult> SavedJob(Guid id, SaveJobRequest saveJobRequest)
        {
            try
            {
                await _candidateRepo.SaveJobs(id, saveJobRequest);
                return Ok(new
                {
                    message = "Updated successful!",
                    statusCode = StatusCodes.Status200OK,

                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
        }

        [HttpDelete("deletedJob")]
        public async Task<IActionResult> DeletedSavedJob(Guid id)
        {
            try
            {
                await _candidateRepo.DeleteSavedJob(id);
                return Ok(new
                {
                    message = "Updated successful!",
                    statusCode = StatusCodes.Status200OK,

                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status404NotFound,
                });
            }
        }

        [HttpPut("updateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(Guid id, [FromForm] CandidateRequest candidateAction)
        {
            try
            {
                await _candidateRepo.UpdateCandidateAsync(id, candidateAction);
                return Ok(new
                {
                    message = "Updated successful!",
                    statusCode = StatusCodes.Status200OK,

                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status404NotFound,
                });
            }
        }
    }
}
