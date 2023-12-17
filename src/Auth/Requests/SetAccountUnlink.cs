using System.Text.Json.Serialization;

namespace Firebase.Auth.Requests
{
    public class SetAccountUnlinkRequest : IdTokenRequest
    {
        [JsonPropertyName("deleteProvider")]
        public FirebaseProviderType[] DeleteProviders { get; set; }
    }

    /// <summary>
    /// Unlink accounts.
    /// </summary>
    public class SetAccountUnlink : FirebaseRequestBase<SetAccountUnlinkRequest, SetAccountInfoResponse>
    {
        public SetAccountUnlink(FirebaseAuthConfig config) : base(config)
        {
        }

        protected override string UrlFormat => Endpoints.GoogleSetAccountUrl;
    }
}
