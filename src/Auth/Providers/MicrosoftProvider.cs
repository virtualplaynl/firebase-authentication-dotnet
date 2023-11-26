namespace Firebase.Auth.Providers
{
    public class MicrosoftProvider : OAuthProvider
    {
        public static string[] DefaultScopes { get; } = new[]
        {
            "profile",
            "email",
            "openid",
            "User.Read",
        };

        public MicrosoftProvider()
        {
            AddScopes(DefaultScopes);
        }

        public static AuthCredential GetCredential(string accessToken) => GetCredential(FirebaseProviderType.Microsoft, accessToken, OAuthCredentialTokenType.AccessToken);

        public override FirebaseProviderType ProviderType => FirebaseProviderType.Microsoft;
    }
}
