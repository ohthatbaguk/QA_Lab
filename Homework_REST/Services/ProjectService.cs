using System.Net.Http;
using System.Threading.Tasks;
using Homework_REST.Clients;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Models.SuiteModel;
using Newtonsoft.Json;

namespace Homework_REST.Services
{
    public class ProjectService
    {
        private readonly ClientExtended _clientExtended;

        public ProjectService(ClientExtended clientExtended)
        {
            _clientExtended = clientExtended;
        }

        public Task<HttpResponseMessage> AddProject(RequestProjectModel projectModel)
        {
            var request = HttpRequestBuilder.Build("index.php?/api/v2/add_project", HttpMethod.Post, projectModel);
            return _clientExtended.ExecuteAsync(request);
        }

        public Task<HttpResponseMessage> DeleteProject(int projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/delete_project/{projectId}", HttpMethod.Post);
            return _clientExtended.ExecuteAsync(request);
        }

        public Task<HttpResponseMessage> GetProject(int projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/get_project/{projectId}", HttpMethod.Get);
            return _clientExtended.ExecuteAsync(request);
        }

        public Task<HttpResponseMessage> AddSuite(int projectId, RequestSuiteModel requestSuiteModel)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/add_suite/{projectId}", HttpMethod.Post,
                requestSuiteModel);
            return _clientExtended.ExecuteAsync(request);
        }

        public Task<HttpResponseMessage> UpdateSuite(int suiteId, RequestSuiteModel requestSuiteModel)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/update_suite/{suiteId}", HttpMethod.Post,
                requestSuiteModel);
            return _clientExtended.ExecuteAsync(request);
        }

        public int GetProjectId(HttpResponseMessage responseMessage)
        {
            var projectId = JsonConvert.DeserializeObject<ResponseProjectModel>
                (responseMessage.Content.ReadAsStringAsync().Result).Id;
            return projectId;
        }

        public int GetSuiteId(HttpResponseMessage responseMessage)
        {
            var suiteId = JsonConvert.DeserializeObject<ResponseSuiteModel>
                (responseMessage.Content.ReadAsStringAsync().Result).Id;
            return suiteId;
        }
    }
}