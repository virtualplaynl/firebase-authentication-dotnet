namespace Firebase.Auth.Providers
{
    public class SteamProvider : OAuthProvider
    {
        public const string DefaultEmailScope = "email";

        public SteamProvider()
        {
            this.AddScopes(DefaultEmailScope);
        }

        public static AuthCredential GetCredential(string accessToken) => GetCredential(FirebaseProviderType.Steam, accessToken, OAuthCredentialTokenType.AccessToken);

        public override FirebaseProviderType ProviderType => FirebaseProviderType.Steam;
    }
}
