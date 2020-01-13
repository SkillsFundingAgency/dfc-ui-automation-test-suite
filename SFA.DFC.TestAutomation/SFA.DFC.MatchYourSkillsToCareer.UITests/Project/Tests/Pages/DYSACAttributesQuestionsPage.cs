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
        private readonly By NextButton = By.Id("next");
        private readonly By YesRadio = By.Id("yes");

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

    }
}
