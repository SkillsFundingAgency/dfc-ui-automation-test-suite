using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class SkillsListPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By ButtonFindCareer = By.Id("basketGovukButtonLinkContinue");
        private readonly By LinkRemoveSkill = By.LinkText("remove");
        private readonly By LinkAddMoreSkills = By.LinkText("Add more skills to this list");
        #endregion

        public SkillsListPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public SkillsListPage RemoveSkills()
        {
            _formHelper.ClickElement(LinkRemoveSkill);
            return this;
        }

        public SkillsListPage AddMoreSkills()
        {
            _formHelper.ClickElement(LinkAddMoreSkills);
            return this;
        }

        public MatchResultsPage ContinueToCareerMatches()
        {
            _formHelper.SelectRadioButton(ButtonFindCareer);
            return new MatchResultsPage(_context);
        }

    }
}
