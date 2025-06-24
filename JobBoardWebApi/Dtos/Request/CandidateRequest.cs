using JobBoardWebApi.Models;

namespace JobBoardWebApi.Dtos.Request
{
    public class CandidateRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ProfilePicUrl { get; set; }
        public HashSet<Guid> Skills { get; set; } = new HashSet<Guid>();
    }
}
