using JobBoardWebApi.Dtos;
using JobBoardWebApi.QueryParams;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _company;
        public CompanyController(ICompanyService company)
        {
            _company = company;
        }

        [HttpGet("getAll")]
        public IActionResult Get([FromQuery] CompanyQueryParams companyQueryParams)
        {
            var companies = _company.GetAllCompaniesAsync(companyQueryParams);
            return Ok(new
            {
                message = "Companies retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = companies
            });
        }
    }
}
