using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Diagnostics;
using System.Security.Claims;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICandidateRepo _candidateRepo;
        private readonly IJwtService _jwtService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICandidateRepo candidateRepo,IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _candidateRepo = candidateRepo;
            _jwtService = jwtService;
           
        }
           

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount(RegisterVM register)
        {
            var isEmailExist = await IsEmailAvailable(register.Email);

            if (!isEmailExist)
            {
                return BadRequest(new
                {
                    msg = "Email already exists",
                    statusCode = StatusCodes.Status400BadRequest
                });
            }

            var user = new User
            {
                FullName = register.FullName,
                Email = register.Email,
                PasswordHash = register.Password,
                UserName = register.FullName,
                Created_At = DateTime.UtcNow,
                ProfilePicUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749112264/user_vga2r2.png",
                EmailConfirmed = true,
            };

            var addingUser = await _userManager.CreateAsync(user, register.Password);

            if (!addingUser.Succeeded)
            {
                return BadRequest(new
                {
                    msg = addingUser.Errors,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }
            await _userManager.AddToRoleAsync(user, "Candidate");



            var candidate = new Models.Candidate
            {
                Id = Guid.NewGuid(),
                Gender = "",
                UserId = user.Id,

            };

            await _candidateRepo.CreateAsync(candidate);

            return Ok(new
            {
                message = "Register successful!",
                statusCode = StatusCodes.Status201Created
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM login)
        {
            var sw = Stopwatch.StartNew();
            var user = await _userManager.FindByEmailAsync(login.Email);
            Log.Information("⏱ Find user: {0} ms", sw.ElapsedMilliseconds);
            if (user == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                if (user.EmailConfirmed == false) return Unauthorized("Email not confirmed");
            sw.Restart();
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            Log.Information("⏱ Verify password: {0} ms", sw.ElapsedMilliseconds);
            if (!result.Succeeded)
                {
                    return Unauthorized("Invalid email or password");
                }
            sw.Restart();
            var userDto = await _jwtService.GenerateToken(user);
            Log.Information("⏱ Generate token: {0} ms", sw.ElapsedMilliseconds);
            Response.Cookies.Append(
                "refresh_token",
                userDto.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Path = "/"
                });
            return Ok(new
            {
                msg = "Login successful!",
                statusCode = StatusCodes.Status200OK,
                data = new
                {
                    Profile = userDto.Profile,
                    Token = userDto.Token
                }
            });
        }

        [Authorize]
        [HttpPost("refreshToken")]
        public async Task<ActionResult<UserDto>> RefreshToken(string token)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name)?.Value);
            return await _jwtService.RefreshToken(token);
        }

        #region private helper method
       
        private async Task<bool> IsEmailAvailable(string email)
        {
            var isEmailExist = await _userManager.FindByEmailAsync(email);

            if (isEmailExist == null)
            {
                return true;
            }

            return false;
        }
        #endregion

    }


}
             
            
