namespace SampleBackendCs.Models
{
    public class AuthRequest
    {
        public string Identity { get; set; }

        public AuthRequest(string identity)
        {
            Identity = identity;
        }
    }
}
