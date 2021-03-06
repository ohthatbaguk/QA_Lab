using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Homework_REST.Utils
{
    public static class NewtonsoftJsonSerializer
    {
        public static T Deserialize<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static T DefaultDeserialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                });
    }
}