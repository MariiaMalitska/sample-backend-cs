namespace SampleBackendCs.Models
{
    public class AuthRequest
    {
        private string _identity;
        public string Identity { get => _identity; set => _identity = value; }

        public AuthRequest(string identity)
        {
            this._identity = identity;
        }
    }
}
