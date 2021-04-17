using Newtonsoft.Json;

namespace Homework_REST.Models.SuiteModel
{
    public class ResponseSuiteModel
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("project_id")] public int ProjectId { get; set; }

        [JsonProperty("is_master")] public bool IsMaster { get; set; }

        [JsonProperty("is_baseline")] public bool IsBaseline { get; set; }

        [JsonProperty("is_completed")] public bool? IsCompleted { get; set; }

        [JsonProperty("completed_on")] public bool? CompletedOn { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }
}