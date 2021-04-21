using Newtonsoft.Json;

namespace Homework_REST.Models.Message
{
    public class Error
    {
        [JsonProperty("error")] public string Message { get; set; }
    }
}