using Newtonsoft.Json;

namespace Homework_REST.Models
{
    public class ResponseProjectModel
    {
       [JsonProperty("announcement")]
        public string Announcement { get; set; }

        [JsonProperty("completed_on")]
        public int? CompletedOn { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("show_announcement")]
        public bool ShowAnnouncement { get; set; }
        
        [JsonProperty("suite_mode")]
        public int SuiteMode { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
    }
}