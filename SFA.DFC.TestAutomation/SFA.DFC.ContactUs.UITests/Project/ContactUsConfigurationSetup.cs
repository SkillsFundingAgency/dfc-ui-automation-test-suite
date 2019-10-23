using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
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
            
           // _context.SetProjectConfig(config);
            _context.SetContactUsConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.Replace("browser", config.Browser);
        }
    }
}
