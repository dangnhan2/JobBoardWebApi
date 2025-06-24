using JobBoardWebApi.Models;

namespace JobBoardWebApi.Dtos
{
    public class UserDto
    {  
        public object Profile { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
