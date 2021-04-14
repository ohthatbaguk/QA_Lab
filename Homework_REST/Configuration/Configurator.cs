using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Homework_REST.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        private static IConfiguration Configuration => s_configuration.Value;
        public static string AppUrl => Configuration[nameof(AppUrl)];
        public static string Username => Configuration[nameof(Username)];
        public static string Password => Configuration[nameof(Password)];
        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}