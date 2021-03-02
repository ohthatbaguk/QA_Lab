using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Homework_4.JSON
{
    public static class ExtendedJsonReader
    {
        public static string ReadFile()
        {
            string pathToFile = default;
            try
            {
                pathToFile = File.ReadAllText("appsettings.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File cannot read - {ex.Message}");
            }

            return pathToFile;
        }
    }
}