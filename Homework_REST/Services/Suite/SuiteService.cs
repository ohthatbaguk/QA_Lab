using System.Net.Http;
using System.Threading.Tasks;
using Homework_REST.Clients;
using Homework_REST.Models.SuiteModel;

namespace Homework_REST.Services.Suite
{
    public class SuiteService
    {
        private readonly ClientExtended _clientExtended;

        public SuiteService(ClientExtended clientExtended)
        {
            _clientExtended = clientExtended;
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
    }
}