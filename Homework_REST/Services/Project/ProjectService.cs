using System.Net.Http;
using System.Threading.Tasks;
using Homework_REST.Clients;
using Homework_REST.Models.ProjectModel;

namespace Homework_REST.Services.Project
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
            return DeleteProject(projectId.ToString());
        }

        public Task<HttpResponseMessage> DeleteProject(string projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/delete_project/{projectId}", HttpMethod.Post);
            return _clientExtended.ExecuteAsync(request);
        }

        public Task<HttpResponseMessage> GetProject(int projectId)
        {
            var request = HttpRequestBuilder.Build($"index.php?/api/v2/get_project/{projectId}", HttpMethod.Get);
            return _clientExtended.ExecuteAsync(request);
        }
    }
}