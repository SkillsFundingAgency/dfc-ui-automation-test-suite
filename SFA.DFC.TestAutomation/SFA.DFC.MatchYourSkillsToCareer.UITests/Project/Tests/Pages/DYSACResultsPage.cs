using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class DYSACResultsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By AttributeQuestionsButton = By.CssSelector(".govuk-grid-column-two-thirds .app-button");
        private readonly By MatchSkillsButton = By.CssSelector(".TBC");

        #endregion

        public DYSACResultsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
        }


        public DYSACAttributesQuestionsPage ClickAttributeQuestions()
        {
            var listOfProfiles = _pageHelper.FindElements(AttributeQuestionsButton);
            _formHelper.ClickElement(listOfProfiles[1]);
            return new DYSACAttributesQuestionsPage(_context);
        }

        public EnterJobsPage ClickMatchSkills()
        {
            _formHelper.ClickElement(MatchSkillsButton);
            return new EnterJobsPage(_context);
        }

    }
}
