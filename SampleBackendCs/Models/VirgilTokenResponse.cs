namespace SampleBackendCs.Models
{
    public class VirgilTokenResponse
    {
        private string _virgilToken;
        public string VirgilToken { get => _virgilToken; set => _virgilToken = value; }

        public VirgilTokenResponse(string virgilToken)
        {
            this._virgilToken = virgilToken;
        }
    }
}
