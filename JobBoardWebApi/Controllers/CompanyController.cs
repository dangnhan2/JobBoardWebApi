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
        private readonly ICompanyRepo _companyRepo;
        public CompanyController(ICompanyRepo companyRepoy)
        {
            _companyRepo = companyRepoy;
        }

        [HttpGet("getAll")]
        public IActionResult Get([FromQuery] CompanyQueryParams companyQueryParams)
        {
            var companies = _companyRepo.GetAllCompaniesAsync(companyQueryParams);
            return Ok(new
            {
                message = "Companies retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = companies
            });
        }
    }
}
