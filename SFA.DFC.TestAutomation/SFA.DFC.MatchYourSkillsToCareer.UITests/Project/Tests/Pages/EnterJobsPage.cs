using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class EnterJobsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;

        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By TextEntryJob = By.Id("job");
        private readonly By ButtonSearch = By.Id("search");
        private readonly By ErrorSummary = By.Id("errorsummary");
        private readonly By ErrorMsg = By.Id("errormsg");
        #endregion

        public EnterJobsPage(ScenarioContext context): base(context)
        {
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public EnterJobsPage EnterJob(string skill)
        {
            _formHelper.EnterText(TextEntryJob, skill);
            return this;
        }
        
        public EnterJobsPage ClickSearch()
        {
            _formHelper.ClickElement(ButtonSearch);
            return this;
        }

        public EnterJobsPage VerifyError()
        {
            _pageHelper.IsElementDisplayed(ErrorSummary);
            _pageHelper.IsElementDisplayed(ErrorMsg);
            return this;
        }


    }
}
