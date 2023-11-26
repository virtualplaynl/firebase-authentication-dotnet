namespace Firebase.Auth.Providers
{
    public class GameCenterProvider : OAuthProvider
    {
        public const string DefaultEmailScope = "email";

        public GameCenterProvider()
        {
            this.AddScopes(DefaultEmailScope);
        }

        public static AuthCredential GetCredential(string accessToken) => GetCredential(FirebaseProviderType.GameCenter, accessToken, OAuthCredentialTokenType.AccessToken);

        public override FirebaseProviderType ProviderType => FirebaseProviderType.GameCenter;
    }
}
