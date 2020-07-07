using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Config;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;

namespace SFA.DFC.CompositeApps.UITests.Config
{
    [Binding]
    public class CompositeAppsConfigurationSetup
    {

        private readonly IConfigurationRoot _configurationRoot;
        private readonly ScenarioContext _context;
        private  IConfigSection _configSection;
        private readonly ObjectContext _objectContext;


        public CompositeAppsConfigurationSetup(ScenarioContext context)
        {
            Configurator.InitializeHostingConfig("appsettings.Environment.json");
            _configurationRoot = Configurator.InitializeConfig(new[] { "appsettings.Project.json", "appsettings.json", "appsettings.RestApi.json" });//.GetConfig();
            _configSection = new ConfigSection(_configurationRoot);

            _context = context;
            _objectContext = context.Get<ObjectContext>();


        }

        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var configuration = new FrameworkConfig
            {
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                TakeEveryPageScreenShot = Configurator.IsVstsExecution
            };

            _context.Set(configuration);

            var executionConfig = new EnvironmentConfig { EnvironmentName = Configurator.EnvironmentName, ProjectName = Configurator.ProjectName };

            _context.Set(executionConfig);

            _configSection = _context.Get<IConfigSection>();

            var testExecutionConfig = _configSection.GetConfigSection<TestExecutionConfig>();

            _objectContext.SetBrowser(testExecutionConfig.Browser);

            
        }
    




        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<CompositeAppsConfig>();
            _context.SetCompositeAppsConfig(config);
            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);
            var restApiConfig = _configSection.GetConfigSection<FindACourseApiConfig>();
            _context.SetFindACourseApiConfig(restApiConfig);
            _objectContext.Replace("browser", config.Browser);
        }
    }
}