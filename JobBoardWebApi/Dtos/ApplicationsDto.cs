using JobBoardWebApi.Enum;

namespace JobBoardWebApi.Dtos
{
    public class ApplicationsDto
    {
        public Guid Id { get; set; }
        public StatusEnum Status { get; set; }
        public string CandidateName { get; set; }
    }
}
     
