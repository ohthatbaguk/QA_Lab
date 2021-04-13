using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Homework_REST.Extensions;
using Homework_REST.Services;

namespace Homework_REST.Steps
{
    public class ProjectSteps
    {
        public static async Task<HttpResponseMessage> GetProject(HttpClient client, int projectId)
        {
            var response = await ProjectService.GetProject(client, projectId);
            response.VerifyResponseStatusCode(HttpStatusCode.OK, "An error occurred while get project");
            return response.EnsureSuccessStatusCode();
        }
        
    }
}