using Homework_REST.Configuration;
using Microsoft.Extensions.Configuration;

namespace Homework_REST
{
    public class Startup
    {
        private readonly AppSettings _appSettings = new AppSettings();

        public static AppSettings AppSettings { get; private set; }

        public Startup()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            configuration.Bind(_appSettings);

            AppSettings = _appSettings;
        }
    }
}