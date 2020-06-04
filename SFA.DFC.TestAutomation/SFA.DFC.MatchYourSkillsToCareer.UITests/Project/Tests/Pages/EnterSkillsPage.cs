using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
using TechTalk.SpecFlow;
using FluentAssertions;

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
        private readonly By TextEntrySkills = By.Id("enterSkillsInputInput");
        private readonly By ButtonSearch = By.Id("enterSkillsGovukSecondaryButtonSearch");
        private readonly By ErrorMsg = By.Id("enterSkillsGovukTextInputErrorSearchError");
        private readonly By ErrorSummary = By.LinkText("Enter a skill");
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
            _pageHelper.IsElementDisplayed(ErrorSummary).Should().BeTrue();
            _pageHelper.IsElementDisplayed(ErrorMsg).Should().BeTrue();
            return this;
        }

    }
}
