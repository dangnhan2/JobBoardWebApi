using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly SignInManager<User> _signInManager;
        private readonly ICandidateService _candidateService;
          

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJwtService jwtService, SignInManager<User> signInManager, ICandidateService candidateService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _signInManager = signInManager;
            _candidateService = candidateService;
           
        }
           

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount(Register register)
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

            await _userManager.AddToRoleAsync(user, SD.Candidate);


            if (!addingUser.Succeeded)
            {
                return BadRequest(new
                {
                    msg = addingUser.Errors,
                    statusCode = StatusCodes.Status400BadRequest,
                });
            }

            var candidate = new Models.Candidate
            {
                Id = Guid.NewGuid(),
                Gender = "",
                UserId = user.Id,

            };

            await _candidateService.CreateAsync(candidate);

            return Ok(new
            {
                message = "Register successful!",
                statusCode = StatusCodes.Status201Created
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email.ToLower());

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            if (user.EmailConfirmed == false) return Unauthorized("Email not confirmed");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid email or password");
            }

            return await Createdtodto(user);
        }

        [Authorize]
        [HttpGet("refreshToken")]
        public async Task<ActionResult<UserDto>> RefreshToken()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name)?.Value);
            return await Createdtodto(user);
        }

        #region private helper method
        private async Task<UserDto> Createdtodto(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var dto = new UserDto
            {
                UserName = user.UserName,
                Id = user.Id,
                Role = roles.FirstOrDefault(),
                Token = await _jwtService.GenerateToken(user)
            };

            return dto;
        }
       
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
             
            
