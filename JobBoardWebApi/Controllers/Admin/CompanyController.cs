using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    //[Authorize ("Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepo _companyRepo;
        public CompanyController(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet("getCompanyById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _companyRepo.GetByIdAsync(id);
                return Ok(new
                {
                    msg = "Company retrieved successful",
                    statusCode = StatusCodes.Status200OK,
                    data = result
                });
            }catch(KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status404NotFound
                });
            }
        }

        [HttpPost("createCompany")]
        public async Task<IActionResult> CreateCompany([FromForm] CompanyRequest company)
        {
            try
            {

                await _companyRepo.CreateCompanyAsync(company);
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
                await _companyRepo.UpdateCompanyAsync(id, company);
                return Ok(new
                {
                    msg = "Company updated successfully",
                    statusCode = StatusCodes.Status200OK,
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
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpDelete("deleteCompany/{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            try
            {
                await _companyRepo.DeleteCompanyAsync(id);
                return Ok(new
                {
                    msg = "Company deleted successfully",
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
