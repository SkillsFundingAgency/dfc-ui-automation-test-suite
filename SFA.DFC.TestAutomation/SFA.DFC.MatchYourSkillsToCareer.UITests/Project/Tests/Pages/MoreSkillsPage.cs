using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Helpers;
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
        private readonly By RadioSearchByOccupations = By.Id("moreSkillsGovUkRadioButtonJob");
        private readonly By RadioSearchBySkills = By.Id("moreSkillsGovUkRadioButtonSkill");
        private readonly By ButtonContinue = By.Id("moreSkillsGovUkButtonContinue");
        #endregion

        public MoreSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();

        }

        public MoreSkillsPage ClickSearchBySkills()
        {
            _formHelper.SelectRadioButton(RadioSearchBySkills);
            return this;
        }
        
        public MoreSkillsPage ClickSearchByOccupations()
        {
            _formHelper.SelectRadioButton(RadioSearchByOccupations);
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
