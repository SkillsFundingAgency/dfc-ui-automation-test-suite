using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class WorkedPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By RadioYes = By.Id("Yes");
        private readonly By RadioNo = By.Id("No");
        private readonly By ContinueButton = By.Id("continue");
        #endregion

        public WorkedPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public WorkedPage ClickRadioYes()
        {
            _formHelper.ClickElement(RadioYes);
            return this;
        }

        public WorkedPage ClickRadioNo()
        {
            _formHelper.ClickElement(RadioNo);
            return this;
        }

        public RoutePage ClickContinueButton()
        {
            _formHelper.SelectRadioButton(ContinueButton);
            return new RoutePage(_context);
        }
    }
}
