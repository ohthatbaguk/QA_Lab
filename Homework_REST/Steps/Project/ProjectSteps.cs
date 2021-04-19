using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Homework_REST.Extensions;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Services.Project;
using Newtonsoft.Json;

namespace Homework_REST.Steps
{
    public class ProjectSteps
    {
        private readonly ProjectService _projectService;

        public ProjectSteps(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<HttpResponseMessage> GetProject(int projectId)
        {
            var response = await _projectService.GetProject(projectId);
            response.VerifyResponseStatusCode(HttpStatusCode.OK, "An error occurred while get project");
            return response;
        }
        
        public int GetProjectId(HttpResponseMessage responseMessage)
        {
            var projectId = JsonConvert.DeserializeObject<ResponseProjectModel>
                (responseMessage.Content.ReadAsStringAsync().Result).Id;
            return projectId;
        }
    }
}