namespace SampleBackendCs.Models
{
    public class AuthResponse
    {
        private string _authToken;
        public string AuthToken { get => _authToken; set => _authToken = value; }

        public AuthResponse(string authToken)
        {
            this._authToken = authToken;
        }
    }
}
