using System.Text.Json.Serialization;

namespace JobBoardWebApi.Dtos
{
    public class JobForIdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IFormFile? Image { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }
        public string Created_At { get; set; }
        public string Level { get; set; }
        public string Skills { get; set; }
    }
}
