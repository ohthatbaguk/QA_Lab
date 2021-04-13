using System.Net.Http;
using System.Threading.Tasks;
using Homework_REST.Clients;
using Homework_REST.Models;
using Newtonsoft.Json;

namespace Homework_REST.Services
{
    public static class ProjectService
    {
        public static Task<HttpResponseMessage> AddProject(HttpClient client, RequestProjectModel projectModel)
        {
            var request = HttpRequestBuilder.Build("index.php?/api/v2/add_project", HttpMethod.Post, projectModel);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }

        public static Task<HttpResponseMessage> DeleteProject(HttpClient client, int projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/delete_project/{projectId}", HttpMethod.Post);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }
        
        public static Task<HttpResponseMessage> DeleteProject(HttpClient client, string projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/delete_project/{projectId}", HttpMethod.Post);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }

        public static Task<HttpResponseMessage> GetProject(HttpClient client, int projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/get_project/{projectId}", HttpMethod.Get);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }
        
        public static Task<HttpResponseMessage> GetProject(HttpClient client, string projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/get_project/{projectId}", HttpMethod.Get);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }
        
        public static Task<HttpResponseMessage> AddSuite(HttpClient client, int projectId, RequestSuiteModel requestSuiteModel)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/add_suite/{projectId}", HttpMethod.Post, requestSuiteModel);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }
        
        public static Task<HttpResponseMessage> UpdateSuite(HttpClient client, int suiteId, RequestSuiteModel requestSuiteModel)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/update_suite/{suiteId}", HttpMethod.Post, requestSuiteModel);
            return ClientExtended.ExecuteAsync<HttpResponseMessage>(client, request);
        }
        
        public static int GetProjectId(HttpResponseMessage responseMessage)
        {
            var projectId = JsonConvert.DeserializeObject<ResponseProjectModel>
                (responseMessage.Content.ReadAsStringAsync().Result).Id;
            return projectId;
        }
    }
}