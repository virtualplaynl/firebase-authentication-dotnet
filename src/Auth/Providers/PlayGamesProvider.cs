namespace Firebase.Auth.Providers
{
    public class PlayGamesProvider : OAuthProvider
    {
        public const string DefaultEmailScope = "email";

        public PlayGamesProvider()
        {
            this.AddScopes(DefaultEmailScope);
        }

        public static AuthCredential GetCredential(string accessToken) => GetCredential(FirebaseProviderType.PlayGames, accessToken, OAuthCredentialTokenType.AccessToken);

        public override FirebaseProviderType ProviderType => FirebaseProviderType.PlayGames;
    }
}
