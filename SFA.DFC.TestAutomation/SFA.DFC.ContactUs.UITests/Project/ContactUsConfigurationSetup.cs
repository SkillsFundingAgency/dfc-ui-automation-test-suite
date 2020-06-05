using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DFC.ContactUs.UITests.Project
{
    [Binding]
    public class ContactUsConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public ContactUsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<ContactUs>();
            
          
            _context.SetContactUsConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.Replace("browser", config.Browser);
            _objectContext.Replace("build", config.BuildNumber);
            _objectContext.Replace("EnvironmentName", config.EnvironmentName);
            
            
        }
    }
}
