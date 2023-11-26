namespace Firebase.Auth.Providers
{
    public class YahooProvider : OAuthProvider
    {
        public const string DefaultEmailScope = "email";

        public YahooProvider()
        {
            this.AddScopes(DefaultEmailScope);
        }

        public static AuthCredential GetCredential(string accessToken) => GetCredential(FirebaseProviderType.Yahoo, accessToken, OAuthCredentialTokenType.AccessToken);

        public override FirebaseProviderType ProviderType => FirebaseProviderType.Yahoo;
    }
}
