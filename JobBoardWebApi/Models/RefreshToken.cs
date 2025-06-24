namespace JobBoardWebApi.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Jti { get; set; }
        public string Token { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime Added_AT { get; set; } = DateTime.Now;
        public DateTime Expired_At { get; set; } 
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
