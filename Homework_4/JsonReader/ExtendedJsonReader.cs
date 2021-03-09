using System;
using System.IO;
using Homework_4.Models;
using log4net;
using Newtonsoft.Json;

namespace Homework_4.JSON
{
    public static class ExtendedJsonReader
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ExtendedJsonReader));

        public static Stores readData(string name)
        {
            Stores stores;
            try
            {
                var str = File.ReadAllText(name);
                stores = JsonConvert.DeserializeObject<Stores>(str);
            }
            catch (Exception exp)
            {
                _log.Error($"Exception - {exp.Message} during deserialization...\n Finishing the program");
                return null;
            }

            return stores;
        }
    }
}