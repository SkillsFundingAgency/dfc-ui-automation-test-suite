using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class MoreSkillsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By RadioSearchBySkills = By.Id("skills");
        private readonly By RadioSearchByOccupations = By.Id("occupations");
        private readonly By ButtonContinue = By.Id("continue");
        #endregion

        public MoreSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();

        }

        public MoreSkillsPage ClickSearchBySkills()
        {
            _formHelper.ClickElement(RadioSearchBySkills);
            return this;
        }
        
        public MoreSkillsPage ClickSearchByOccupations()
        {
            _formHelper.ClickElement(RadioSearchByOccupations);
            return this;
        }

        public EnterSkillsPage ClickContinueToSkills()
        {
            _formHelper.ClickElement(ButtonContinue);
            return new EnterSkillsPage(_context);
        }

        public EnterJobsPage ClickContinueToOccupations()
        {
            _formHelper.ClickElement(ButtonContinue);
            return new EnterJobsPage(_context);
        }

    }
}
