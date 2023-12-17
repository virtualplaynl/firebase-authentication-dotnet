using System.Text.Json;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Firebase.Auth.Repository
{
    /// <summary>
    /// <see cref="IUserRepository"/> implementation which saves user data application data folder using the <see cref="File"/> API.
    /// </summary>
    /// <inheritdoc />
    public class FileUserRepository : IUserRepository
    {
        public const string UserFileName = "firebase.json";
        
        private readonly string filename;
        private readonly JsonSerializerOptions options;

        /// <summary>
        /// Creates new instance of <see cref="FileUserRepository"/>.
        /// </summary>
        /// <param name="folder"> Name of the subfolder to be created / accessed under <see cref="Environment.SpecialFolder.ApplicationData"/>. </param>
        public FileUserRepository(string folder)
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.filename = Path.Combine(appdata, folder, UserFileName);
            this.options = new();

            Directory.CreateDirectory(Path.Combine(appdata, folder));
        }

        public virtual (UserInfo, FirebaseCredential) ReadUser()
        {
            var content = File.ReadAllText(this.filename);
            var obj = JsonSerializer.Deserialize<UserDal>(content, this.options);
            return (obj.UserInfo, obj.Credential);
        }

        public virtual void SaveUser(User user)
        {
            var content = JsonSerializer.Serialize(new UserDal(user.Info, user.Credential), this.options);
            File.WriteAllText(this.filename, content);
        }

        public virtual void DeleteUser()
        {
            File.Delete(this.filename);
        }

        public bool UserExists()
        {
            return File.Exists(this.filename);
        }


        internal class UserDal
        {
            public UserDal()
            {
            }

            public UserDal(UserInfo userInfo, FirebaseCredential credential)
            {
                this.UserInfo = userInfo;
                this.Credential = credential;
            }

            public UserInfo UserInfo { get; set; }

            public FirebaseCredential Credential { get; set; }
        }
    }
}
