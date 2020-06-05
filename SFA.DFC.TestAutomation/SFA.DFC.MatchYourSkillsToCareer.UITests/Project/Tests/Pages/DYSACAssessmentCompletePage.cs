using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class DYSACAssessmentCompletePage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By ResultsButton = By.ClassName("app-button");


        #endregion

        public DYSACAssessmentCompletePage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }


        public DYSACResultsPage ClickResultsButton()
        {
            _formHelper.ClickElement(ResultsButton);
            return new DYSACResultsPage(_context);
        }

    }
}
