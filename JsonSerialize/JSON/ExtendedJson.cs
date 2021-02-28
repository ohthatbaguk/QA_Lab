using System;
using System.IO;
using System.Reflection;
using JsonSerialize.Object;
using Newtonsoft.Json;

namespace JsonSerialize.JSON
{
    public class ExtendedJson
    {
        public string FullPathToJsonFile()
        {
            var basePath = File.ReadAllText("appsettings.json");
            return basePath;
        }
    }
}