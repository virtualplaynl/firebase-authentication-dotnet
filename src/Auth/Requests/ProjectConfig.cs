using System.Net.Http;
using System.Text.Json.Serialization;

namespace Firebase.Auth.Requests
{
    public class ProjectConfigResponse
    {
        [JsonPropertyName("projectId")]
        public string ProjectId { get; set; }

        [JsonPropertyName("authorizedDomains")]
        public string[] AuthorizedDomains { get; set; }
    }

    /// <summary>
    /// Get basic config info about the firebase project.
    /// </summary>
    public class ProjectConfig : FirebaseRequestBase<object, ProjectConfigResponse>
    {
        public ProjectConfig(FirebaseAuthConfig config) : base(config)
        {
        }

        protected override string UrlFormat => Endpoints.GoogleProjectConfighUrl;

        protected override HttpMethod Method => HttpMethod.Get;
    }
}
