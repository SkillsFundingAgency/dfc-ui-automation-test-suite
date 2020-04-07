using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class DYSACAttributesQuestionsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By NextButton = By.XPath(".//*[@id='main-content']/div/div/div[2]/form/div/div[1]/div[2]/button");
        private readonly By YesRadio = By.Id("selected_answer-1");

        #endregion

        public DYSACAttributesQuestionsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public DYSACAttributesQuestionsPage ClickYes()
        {
            _formHelper.SelectRadioButton(YesRadio);
            return this;
        }

        public DYSACAttributesQuestionsPage ClickNextButton()
        {
            _formHelper.ClickElement(NextButton);
            return this;
        }

        public DYSACResultsPage ClickFinalNextButton()
        {
            _formHelper.ClickElement(NextButton);
            return new DYSACResultsPage(_context);
        }

    }
}
