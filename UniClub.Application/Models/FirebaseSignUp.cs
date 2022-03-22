namespace UniClub.Application.Models
{
    public class FirebaseSignUp
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; } = true;
    }
}
