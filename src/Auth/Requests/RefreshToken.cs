using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firebase.Auth.Requests
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenResponse
    {
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }

    /// <summary>
    /// Refreshes IdToken using a refresh token.
    /// </summary>
    public class RefreshToken : FirebaseRequestBase<RefreshTokenRequest, RefreshTokenResponse>
    {
        public RefreshToken(FirebaseAuthConfig config) : base(config)
        {
            this.JsonSettingsOverride = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };
        }

        protected override JsonSerializerOptions JsonSettingsOverride { get; }

        protected override string UrlFormat => Endpoints.GoogleRefreshAuth;
    }
}
