using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.CompositeApps.UITests.Config
{
    [Binding]
    public class CompositeAppsConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public CompositeAppsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
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