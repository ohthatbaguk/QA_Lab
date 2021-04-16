using System.Threading.Tasks;
using Homework_REST.Clients;
using Homework_REST.Configuration;
using Homework_REST.Extensions;
using Homework_REST.Services;
using Homework_REST.Steps;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Homework_REST.Base
{
    public abstract class BaseTest
    {
        protected readonly ClientExtended ClientExtended;
        protected readonly ProjectService ProjectService;
        protected readonly ProjectSteps ProjectSteps;

        public BaseTest(ITestOutputHelper outputHelper)
        {
            
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .ClearProviders()
                    .AddXUnit(outputHelper);
            });
            
            ClientExtended = ClientConfiguration.ConfigureHttpClient(loggerFactory);
            ProjectService = new ProjectService(ClientExtended);
            ProjectSteps = new ProjectSteps(ProjectService);
        }

        protected async Task SetAuthorization()
        {
            var token = $"{Startup.AppSettings.Username}:{Startup.AppSettings.Password}";
             ClientExtended.SetAuthorization(token);
        }
    }
}