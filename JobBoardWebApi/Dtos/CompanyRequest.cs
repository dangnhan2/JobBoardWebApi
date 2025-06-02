namespace JobBoardWebApi.Dtos
{
    public class CompanyRequest
    {
        public string Name { get; set; }
        public IFormFile file { get; set; }
    }
}
