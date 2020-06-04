using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project
{
    [Binding]
    public class ExploreCareersConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public ExploreCareersConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<ExploreCareersConfig>();
            _context.SetExploreCareersConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.Replace("browser", config.Browser);
            
        }
    }
}
