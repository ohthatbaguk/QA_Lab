using Homework_REST.Clients;
using Homework_REST.Configuration;
using Homework_REST.Extensions;
using Homework_REST.Services.Project;
using Homework_REST.Services.Suite;
using Homework_REST.Steps;
using Homework_REST.Steps.Suite;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Homework_REST.Base
{
    public abstract class BaseTest
    {
        protected readonly ClientExtended ClientExtended;
        protected readonly ProjectService ProjectService;
        protected readonly ProjectSteps ProjectSteps;
        protected readonly SuiteService SuiteService;
        protected readonly SuiteSteps SuiteSteps;

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
            SuiteService = new SuiteService(ClientExtended);
            SuiteSteps = new SuiteSteps(SuiteService);
        }

        protected void SetAuthorization()
        {
            var token = $"{Startup.AppSettings.Users.UserName}:{Startup.AppSettings.Users.Password}";
            ClientExtended.SetAuthorization(token);
        }
    }
}