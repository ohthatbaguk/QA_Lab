using Newtonsoft.Json;

namespace Homework_REST.Models
{
    public class RequestProjectModel
    {
        [JsonProperty("name")] 
        public string Name { get; set; }
        
        [JsonProperty("announcement")] 
        public string Announcement { get; set; }

        [JsonProperty("show_announcement")]
        public bool ShowAnnouncement { get; set; }
        
    }
}