using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize ("Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _company;
        public CompanyController(ICompanyService company)
        {
            _company = company;
        }

        [HttpPost("createCompany")]
        public async Task<IActionResult> CreateCompany([FromForm] CompanyRequest company)
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
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
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
        public async Task<IActionResult> UpdateCompany(Guid id, [FromForm] CompanyRequest company)
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
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
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
