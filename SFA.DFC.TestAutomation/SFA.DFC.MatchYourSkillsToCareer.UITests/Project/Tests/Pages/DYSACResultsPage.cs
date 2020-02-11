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

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By AttributeQuestionsButton = By.Id("attributes");
        private readonly By MatchSkillsButton = By.Id("matchskills");

        #endregion

        public DYSACResultsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }


        public DYSACAttributesQuestionsPage ClickAttributeQuestions()
        {
            _formHelper.ClickElement(AttributeQuestionsButton);
            return new DYSACAttributesQuestionsPage(_context);
        }

        public EnterJobsPage ClickMatchSkills()
        {
            _formHelper.ClickElement(MatchSkillsButton);
            return new EnterJobsPage(_context);
        }

    }
}
