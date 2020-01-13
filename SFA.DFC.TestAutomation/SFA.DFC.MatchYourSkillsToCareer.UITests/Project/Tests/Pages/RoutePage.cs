using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
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
        private readonly By RadioSearchBySkills = By.Id("skills");
        private readonly By RadioAboutYourself = By.Id("youself");
        private readonly By ButtonContinue = By.Id("continue");
        #endregion

        public RoutePage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public RoutePage ClickSearchBySkills()
        {
            _formHelper.ClickElement(RadioSearchBySkills);
            return this;
        }
        
        public RoutePage ClickAboutYourself()
        {
            _formHelper.ClickElement(RadioAboutYourself);
            return this;
        }

        public EnterJobsPage ClickContinueToOccupations()
        {
            _formHelper.ClickElement(ButtonContinue);
            return new EnterJobsPage(_context);
        }

    }
}
