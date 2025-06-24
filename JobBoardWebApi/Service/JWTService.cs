
using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.FlatDto;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobBoardWebApi.Service
{
    public interface IJwtService
    {
        Task<UserDto> GenerateToken(User user);
        Task<UserDto> RefreshToken(string token);
    }

    public class JWTService : IJwtService
    {
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _jwtKey;
        private readonly ApplicationDbContext _context;

        public JWTService(UserManager<User> userManager, ApplicationDbContext context)
        {
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
            _userManager = userManager;
            _context = context;

        }
        public async Task<UserDto> GenerateToken(User user)
        {
                var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
                var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
                var credentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
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
                var token = tokenHandler.WriteToken(jwt);

                var refreshToken = new RefreshToken
                {
                    Jti = jwt.Id,
                    Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString(),
                    IsRevoked = false,
                    Expired_At = DateTime.UtcNow.AddDays(7),
                    UserId = user.Id,
                };

                _context.RefreshTokens.Add(refreshToken);
                await _context.SaveChangesAsync();

                var userDto = new UserDto
                {
                    Profile = await CreateDtoAsync(user),
                    Token = token,
                    RefreshToken = refreshToken.Token,
                };

                return userDto;
           
        }

        public async Task<UserDto> RefreshToken(string token)
        {
            var isExistToken = await _context.RefreshTokens.FirstOrDefaultAsync(f => f.Token == token) ?? throw new ArgumentNullException("Token is invalid");

            if (isExistToken.IsRevoked)
            {
                return null;
            }

            if (isExistToken.Expired_At < DateTime.UtcNow)
            {
                return null;
            }

            //isExistToken.IsRevoked = true;j                                                                                                                       csx                                           cs                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   `
            _context.RefreshTokens.Remove(isExistToken);
            await _context.SaveChangesAsync();

            var newToken = await GenerateToken(isExistToken.User);

            return newToken;
        }

        public async Task<object> CreateDtoAsync(User user)
        {
            // 1. Role
            var roles = await _userManager.GetRolesAsync(user);      // List<string>
            var role = roles.FirstOrDefault();

            object? profile = null;

            switch (role)
            {
                case "Candidate":
                    var candidateFlatDtos = await _context.Set<CandidateFlatDto>()
                              .FromSqlRaw("EXEC GetCandidateByUserId @UserId = {0}", user.Id)
                              .AsNoTracking()
                              .ToListAsync();

                    var candidateToDto = candidateFlatDtos.FirstOrDefault();

                    profile = new CandidateForIdDto
                    {
                        Id = candidateToDto.Id,
                        Role= role,
                        FullName = candidateToDto.FullName,
                        UserName = candidateToDto.UserName,
                        Email = candidateToDto.Email,
                        Gender = candidateToDto.Gender,
                        PhoneNumber = candidateToDto.PhoneNumber,
                        ProfilePicUrl = candidateToDto.ProfilePicUrl,
                        Skills = candidateFlatDtos
                          .Where(f => f.SkillId.HasValue) // chỉ add nếu có
                          .Select(f => new SkillDto
                          {
                              Id = f.SkillId.Value,
                              Name = f.SkillName
                          }).ToList()

                    };
                    break;

                case "Recruiter":
                    var recruiterFlatDtos = await _context.Set<RecruiterFlatDto>().FromSqlRaw("EXEC GetRecruiterByUserId @UserId={0}", user.Id).AsNoTracking().ToListAsync();

                    var recruiterToDto = recruiterFlatDtos.FirstOrDefault();

                    profile = new RecruitersDto
                    {
                        Id = recruiterToDto.Id,
                        Role = role,
                        FullName = recruiterToDto.FullName,
                        Email = recruiterToDto.Email,
                        UserName = recruiterToDto.UserName,
                        ProfilePicUrl = recruiterToDto.ProfilePirUrl,
                        Company = new CompanyDto
                        {
                            Id = recruiterToDto.CompanyId,
                            Name = recruiterToDto.Company,
                            LogoUrl = recruiterToDto.LogoUrl,
                        }
                    };
                    break;

                case "Admin":
                    var adminFlatDto = await _context.Set<AdminFlatDto>().FromSqlRaw("EXEC GetAdminByUserId @UserId={0}", user.Id).AsNoTracking().ToListAsync();
                        
                    var adminToDto = adminFlatDto.FirstOrDefault();

                    profile = new AdminDto
                    {
                        Id = adminToDto.Id,
                        Role = role,
                        FullName = adminToDto.FullName,
                        Email = adminToDto.Email,
                        PhoneNumber = adminToDto.PhoneNumber,
                        ProfilePicUrl = adminToDto.ProfilePicUrl,
                    };
                        break;
                    
                   
            }

            // 4. Build DTO
            return profile;
        }
    }
}
