using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages
{
    public class SHCHomePage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly SkillsAssessmentConfig _config;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By AssessType = By.CssSelector("");
        
        private By StartSkillsHealthCheck = By.CssSelector(".button");

        #endregion
        public SHCHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetSkillsAssessmentConfig<SkillsAssessmentConfig>();
        }
        public YourAssessmentsPage ClickNewHealthCheck()
        {
            _formHelper.ClickElement(StartSkillsHealthCheck);
            return new YourAssessmentsPage(_context);
        }
        
    }
}
