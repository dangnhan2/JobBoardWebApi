namespace JobBoardWebApi.Dtos
{
    public class CompanyByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<JobDto> Jobs { get; set; } = new List<JobDto>();
    }
}
