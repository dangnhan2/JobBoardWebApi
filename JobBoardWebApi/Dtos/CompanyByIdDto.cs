namespace JobBoardWebApi.Dtos
{
    public class CompanyByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<JobDto> Jobs { get; set; } = new List<JobDto>();
    }
}
