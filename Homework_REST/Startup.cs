using Homework_REST.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_REST
{
    public class Startup
    {
        public static AppSettings AppSettings { get; private set; }
        private AppSettings _appSettings;
        
        private IConfiguration Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            

            _appSettings = services
                .BuildServiceProvider()
                .GetService<AppSettings>();
            
            AppSettings = _appSettings;
        }
    }
}