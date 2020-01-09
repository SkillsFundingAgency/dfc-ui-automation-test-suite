using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class EnterSkillsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By TextEntrySkills = By.Id("skills");
        private readonly By ButtonSearch = By.Id("search");
        private readonly By ErrorMsg = By.Id("Errormessage");
        private readonly By ErrorSummary = By.Id("Errorsummary");
        #endregion

        public EnterSkillsPage(ScenarioContext context): base(context)
        {

            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();

        }

        public EnterSkillsPage EnterSkills(string skill)
        {
            _formHelper.EnterText(TextEntrySkills, skill);
            return this;
        }
        
        public EnterSkillsPage ClickSearch()
        {
            _formHelper.ClickElement(ButtonSearch);
            return this;
        }

        public EnterSkillsPage VerifyError()
        {
            _pageHelper.IsElementDisplayed(ErrorSummary);
            _pageHelper.IsElementDisplayed(ErrorMsg);
            return this;
        }

    }
}
