using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class RoutePage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By RadioSearchBySkills = By.Id("routeGovUkRadioButtonJobs");
        private readonly By RadioAboutYourself = By.Id("routeGovUkRadioButtonJobsAndSkills");
        private readonly By ButtonContinue = By.Id("routeGovUkButtonContinue");
        #endregion

        public RoutePage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public RoutePage ClickSearchBySkills()
        {
            _formHelper.SelectRadioButton(RadioSearchBySkills);
            return this;
        }
        
        public RoutePage ClickAboutYourself()
        {
            _formHelper.SelectRadioButton(RadioAboutYourself);
            return this;
        }

        public EnterJobsPage ClickContinueToOccupations()
        {
            _formHelper.ClickElement(ButtonContinue);
            return new EnterJobsPage(_context);
        }

        public DYSACTraitsQuestionsPage ClickContinueToDYSAC()
        {
            _formHelper.ClickElement(ButtonContinue);
            return new DYSACTraitsQuestionsPage(_context);
        }

    }
}
