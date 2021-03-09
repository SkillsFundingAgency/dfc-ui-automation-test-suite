using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages
{
    public class SHCHomePage : BasePage
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        
        private By StartSkillsHealthCheck = By.CssSelector(".button-start");

        #endregion
        public SHCHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }
        public YourAssessmentsPage ClickNewHealthCheck()
        {
            _formHelper.ClickElement(StartSkillsHealthCheck);
            return new YourAssessmentsPage(_context);
        }
        
    }
}
