using Microsoft.AspNetCore.Identity;

namespace JobBoardWebApi.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } 
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public Candidate? Candidate { get; set; }
        public Recruiter? Recruiter { get; set; }
        public string ProfilePicUrl { get; set; }

    }
}
