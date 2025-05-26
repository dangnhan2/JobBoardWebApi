using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(string searching = "")
        {
            var companies = _company.GetAllCompanies(searching);
            return Ok(new
            {
                message = "Companies retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = companies
            });
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            try
            {
                var company = await _company.GetById(id);

                return Ok(new
                {
                    message = "Company retrieved successfully",
                    statusCode = StatusCodes.Status200OK,
                    data = company
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }

        }

        [HttpPost("createCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyAction company)
        {
            try
            {

                await _company.CreateCompany(company);
                return Ok(new
                {
                    message = "Company created successfully",
                    statusCode = StatusCodes.Status201Created
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPut("updateCompany/{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyAction company)
        {
            try
            {
                await _company.UpdateCompany(id, company);
                return Ok(new
                {
                    message = "Company updated successfully",
                    statusCode = StatusCodes.Status200OK,
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
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpDelete("deleteCompany/{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            try
            {
                await _company.DeleteCompany(id);
                return Ok(new
                {
                    message = "Company deleted successfully",
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
