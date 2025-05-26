namespace DY.Application.Authentication.Models
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
    }
}
