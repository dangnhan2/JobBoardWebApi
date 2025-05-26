using JobBoardWebApi.Models;

namespace JobBoardWebApi.Service
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
