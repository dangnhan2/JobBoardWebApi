using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobBoardWebApi.Service
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }

    public class JWTService : IJwtService
    {
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _jwtKey;
       
        public JWTService(UserManager<User> userManager)
        {
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
            _userManager = userManager;
           
        }
        public async Task<string> GenerateToken(User user)
        {
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var credentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("FullName", user.FullName),

            };

            var userRole = await _userManager.GetRolesAsync(user);
            claims.AddRange(userRole.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRES_MINUTES"))),
                SigningCredentials = credentials,
                Issuer = issuer,
                Audience = audience,
            };
       

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(jwt);
        }
    }
}
