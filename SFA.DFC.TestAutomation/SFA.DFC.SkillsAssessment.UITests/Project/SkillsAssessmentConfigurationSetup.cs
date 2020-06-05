using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project
{
    [Binding]
    public class SkillsAssessmentConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public SkillsAssessmentConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<SkillsAssessmentConfig>();
            //_context.SetExploreCareersConfig(config);
            _context.SetSkillsAssessmentConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.Replace("browser", config.Browser);
        }
    }
}
