using Firebase.Auth.Requests;
using System.Threading.Tasks;

namespace Firebase.Auth.Providers
{
    /// <summary>
    /// Base class for Firebase auth providers.
    /// </summary>
    public abstract class FirebaseAuthProvider
    {
        protected FirebaseAuthConfig Config { get; private set; }
        protected CreateAuthUri CreateAuthUri { get; private set; }

        public abstract FirebaseProviderType ProviderType { get; }

        internal virtual void Initialize(FirebaseAuthConfig config)
        {
            Config = config;
            CreateAuthUri = new CreateAuthUri(config);
        }

        protected internal abstract Task<UserCredential> SignInWithCredentialAsync(AuthCredential credential);

        protected internal abstract Task<UserCredential> LinkWithCredentialAsync(string idToken, AuthCredential credential);
    }
}
