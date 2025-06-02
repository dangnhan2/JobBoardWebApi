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
        private readonly ICandidateRepo _candidateRepo;
        private readonly SignInManager<User> _signInManager;
          

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJwtService jwtService, ICandidateRepo candidateRepo, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _candidateRepo = candidateRepo;
            _signInManager = signInManager;
           
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
                ProfilePicUrl = "user.png",
                EmailConfirmed = true,
            };

            var addingUser = await _userManager.CreateAsync(user, register.Password);

            if (!await _roleManager.RoleExistsAsync(SD.Candidate))
            {
                var role = new IdentityRole(SD.Candidate);
                await _roleManager.CreateAsync(role);
            }


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
                IsStudent = false,
                UserId = user.Id,

            };

            await _candidateRepo.Create(candidate);

            await _candidateRepo.SaveChanges();
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

            var dto = new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                ProfilePicUrl = user.ProfilePicUrl,
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
             
            
