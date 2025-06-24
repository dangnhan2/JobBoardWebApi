using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Recruiter
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUserService _userService;

        //public UserController(IUserService userService) { 
        //  _userService = userService;
        //}

        //[HttpGet("getUser/{id}")]
        //public async Task<object> GetUserById(string id)
        //{
        //    try
        //    {
        //        var result = await _userService.GetUserId<object>(id);
        //        return Ok(new
        //        {
        //            msg = "User retrived successfull",
        //            statusCode = StatusCodes.Status200OK,
        //            data= result,
        //        });

        //    }
        //    catch (Exception ex) {

        //        return BadRequest(new
        //        {
        //            msg = ex.Message,
        //            statusCode = StatusCodes.Status400BadRequest
        //        });
        //    }
        //}
    }
}
