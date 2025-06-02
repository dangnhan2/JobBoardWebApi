using JobBoardWebApi.Models;

namespace JobBoardWebApi.Dtos
{
    public class CandidatesDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

    }
}
