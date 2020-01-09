using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class MYSTCHomePage : BasePage
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        
        private By StartSkillsHealthCheck = By.CssSelector(".button");

        #endregion
        public MYSTCHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }
        //public YourAssessmentsPage ClickNewHealthCheck()
        //{
        //    _formHelper.ClickElement(StartSkillsHealthCheck);
        //    return new YourAssessmentsPage(_context);
        //}
        
    }
}
