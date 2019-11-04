using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages
{
    public class SkillsAssessmentHomePage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly SkillsAssessmentConfig _config;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By ClickSkillsHealthCheck= By.LinkText("Go to skills health check");

        #endregion
        public SkillsAssessmentHomePage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _webDriver = context.GetWebDriver();
            _config = context.GetSkillsAssessmentConfig<SkillsAssessmentConfig>();
        }

        public SkillsAssessmentHomePage NavigatetoSHCHomePage()
        {
            _webDriver.Url = _config.BaseUrl + "/skills-assessment";
            return this;
        }
        public SHCHomePage ClickGoToSHC()
        {
            _formHelper.ClickElement(ClickSkillsHealthCheck);
            return new SHCHomePage(_context);
        }

    }
}
