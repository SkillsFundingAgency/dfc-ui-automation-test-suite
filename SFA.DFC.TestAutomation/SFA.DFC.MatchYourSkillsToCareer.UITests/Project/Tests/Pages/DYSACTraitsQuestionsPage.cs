using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class DYSACTraitsQuestionsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By NextButton = By.XPath(".//*[@id='main-content']/div/div/form/div[3]/button");
        private readonly By StronglyAgreeRadio = By.Id("selected_answer-1");

        #endregion

        public DYSACTraitsQuestionsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public DYSACTraitsQuestionsPage SelectStronglyAgree()
        {
            _formHelper.SelectRadioButton(StronglyAgreeRadio);
            return this;
        }

        public DYSACTraitsQuestionsPage ClickNextButton()
        {
            _formHelper.ClickElement(NextButton);
            return this;
        }

        public DYSACAssessmentCompletePage ClickFinalNextButton()
        {
            _formHelper.ClickElement(NextButton);
            return new DYSACAssessmentCompletePage(_context);
        }

    }
}
