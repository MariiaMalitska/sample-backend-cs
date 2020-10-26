namespace SampleBackendCs.Models
{
    public class VirgilTokenResponse
    {
        public string VirgilToken { get; set; }

        public VirgilTokenResponse(string virgilToken)
        {
            VirgilToken = virgilToken;
        }
    }
}
