using System.Net.Http;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Services.Suite;
using Newtonsoft.Json;

namespace Homework_REST.Steps.Suite
{
    public class SuiteSteps
    {
        private readonly SuiteService _suiteService;

        public SuiteSteps(SuiteService suiteService)
        {
            _suiteService = suiteService;
        }
        
        public int GetSuiteId(HttpResponseMessage responseMessage)
        {
            var suiteId = JsonConvert.DeserializeObject<ResponseSuiteModel>
                (responseMessage.Content.ReadAsStringAsync().Result).Id;
            return suiteId;
        }
        
    }
}