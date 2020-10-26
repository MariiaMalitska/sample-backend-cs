namespace SampleBackendCs.Models
{
    public class AuthResponse
    {
        public string AuthToken { get; set; }

        public AuthResponse(string authToken)
        {
            AuthToken = authToken;
        }
    }
}
