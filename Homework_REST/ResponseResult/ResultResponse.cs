using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Homework_REST.Models;
using Xunit.Abstractions;

namespace Homework_REST.ResponseResult
{
    public static class ResultResponse
    {
        public static string Result(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                
            };
            
            var unPrettyJson = response.Content.ReadAsStringAsync().Result;

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return  JsonSerializer.Serialize(jsonElement, options);
        }
        
        // public static string PrettyJson(string unPrettyJson)
        // {
        //     var options = new JsonSerializerOptions
        //     {
        //         WriteIndented = true
        //     };
        //
        //     var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);
        //
        //     return JsonSerializer.Serialize(jsonElement, options);
        // }
    }
}