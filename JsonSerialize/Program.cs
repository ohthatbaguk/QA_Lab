using System;
using System.IO;
using System.Reflection;
using JsonSerialize.JSON;
using Newtonsoft.Json;

namespace JsonSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
              var extendedJson = new ExtendedJson();
              extendedJson.FullPathToJsonFile();

        }
    }
}