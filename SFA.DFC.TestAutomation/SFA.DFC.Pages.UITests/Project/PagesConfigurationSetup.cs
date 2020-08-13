using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DFC.Pages.UITests.Project
{
    [Binding]
    public class PagesConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public PagesConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<PagesConfig>();
            _context.SetExploreCareersConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.Replace("browser", config.Browser);
            
        }
    }
}
