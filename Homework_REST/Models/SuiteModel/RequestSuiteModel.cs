using Newtonsoft.Json;

namespace Homework_REST.Models.SuiteModel
{
    public class RequestSuiteModel
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
    }
}