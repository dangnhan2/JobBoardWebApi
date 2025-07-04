﻿using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Candidate
{
    [Route("api/cadidate_/[controller]")]
    [ApiController]
    [Authorize(Roles = "Candidate")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepo _jobRepo;

        public JobController(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }

        [HttpGet("getAllJobsApproved")]
        public async Task<IActionResult> GetAllJobsApproved([FromQuery] JobQueryParams jobFilter)
        {
            var jobs = await _jobRepo.GetAllJobApprovedAsync(jobFilter);
            return Ok(new
            {
                message = "Jobs retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = jobs
            });
        }
    }
}
