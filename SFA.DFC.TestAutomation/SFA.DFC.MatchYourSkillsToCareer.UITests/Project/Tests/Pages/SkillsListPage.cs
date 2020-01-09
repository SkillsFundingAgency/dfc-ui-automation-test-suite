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
        private readonly By ButtonSearch= By.Id("searchskills");
        private readonly By ButtonOccupation = By.Id("occupations");
        private readonly By ButtonFindJob = By.Id("findjob");
        private readonly By ButtonFindCareer = By.Id("findcareer");
        private readonly By LinkRemoveSkill = By.Id("removeskill");
        #endregion

        public SkillsListPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public SkillsListPage SearchSkill()
        {
            _formHelper.ClickElement(ButtonSearch);
            return this;
        }
        
        public EnterJobsPage EnterOccupation()
        {
            _formHelper.SelectRadioButton(ButtonOccupation);
            return new EnterJobsPage(_context);
        }

        public SkillsListPage FindJob()
        {
            _formHelper.SelectRadioButton(ButtonFindJob);
            return this;
        }

        public SkillsListPage RemoveSkills()
        {
            _formHelper.SelectRadioButton(LinkRemoveSkill);
            return this;
        }

        public MatchResultsPage ContinueToCareerMatches()
        {
            _formHelper.SelectRadioButton(ButtonFindCareer);
            return new MatchResultsPage(_context);
        }

    }
}
