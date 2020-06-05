using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
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
        private readonly By NextButton = By.ClassName("btn-next-question");
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
