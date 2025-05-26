using JobBoardWebApi.Models;

namespace JobBoardWebApi.Dtos
{
    public class UserDto
    {
       public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
