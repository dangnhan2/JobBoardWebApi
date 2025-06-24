namespace JobBoardWebApi.Dtos.Request
{
    public class RegisterVM
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
