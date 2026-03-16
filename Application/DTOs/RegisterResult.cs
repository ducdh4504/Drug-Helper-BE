namespace Application.DTOs
{
    public class RegisterResult
    {
        public bool Success { get; set; }
        public bool EmailExists { get; set; }
        public bool UsernameExists { get; set; }
        public bool EmailNotReal { get; set; }
        public string? Message { get; set; }
    }
}
