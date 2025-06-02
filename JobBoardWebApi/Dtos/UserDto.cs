using JobBoardWebApi.Models;

namespace JobBoardWebApi.Dtos
{
    public class UserDto
    {  
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public CandidatesDto? Candidate { get; set; }  // Optional
        public RecruiterDto? Recruiter { get; set; }  // Optional
    }
}
