using System.Runtime.Serialization;

namespace Firebase.Auth
{
    /// <summary>
    /// Type of authentication provider.
    /// </summary>
    public enum FirebaseProviderType
    {
        Unknown,

        [EnumMember(Value = "facebook.com")]
        Facebook,

        [EnumMember(Value = "google.com")]
        Google,

        [EnumMember(Value = "playgames.google.com")]
        PlayGames,

        [EnumMember(Value = "github.com")]
        Github,

        [EnumMember(Value = "twitter.com")]
        Twitter,

        [EnumMember(Value = "microsoft.com")]
        Microsoft,

        [EnumMember(Value = "apple.com")]
        Apple,

        [EnumMember(Value = "gc.apple.com")]
        GameCenter,

        [EnumMember(Value = "yahoo.com")]
        Yahoo,

        [EnumMember(Value = "steam.com")]
        Steam,

        [EnumMember(Value = "password")]
        EmailAndPassword,

        [EnumMember(Value = "phone")]
        Phone,

        Anonymous
    } 
}
