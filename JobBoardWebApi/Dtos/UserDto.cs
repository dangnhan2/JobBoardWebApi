using JobBoardWebApi.Models;

namespace JobBoardWebApi.Dtos
{
    public class UserDto
    {  
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
