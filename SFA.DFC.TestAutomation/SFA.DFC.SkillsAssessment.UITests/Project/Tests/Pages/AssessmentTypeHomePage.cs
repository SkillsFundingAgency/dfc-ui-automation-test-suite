using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using FluentAssertions;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages
{
    public class AssessmentTypeHomePage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By AssessmentPageTitle = By.CssSelector(".govuk-heading-xl");
        private By CountofQues = By.CssSelector(".govuk-caption-xl");
        private List<IWebElement> SelectList => _pageHelper.FindElements(By.ClassName("block-label"));
        private By ContinueButton = By.Name("answerAction");
        private By ErrorMessage = By.Id("QuestionAnswer-error");


        #endregion
        public AssessmentTypeHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }
        public void VerifyAssessmentTitle()
        {
            _pageHelper.WaitForElementToContainText(AssessmentPageTitle, _objectContext.Get("AssessTitle"));
        }

        public YourAssessmentsPage AnswerAllQuestions()
        {
            var NumofQues = _pageHelper.GetText(CountofQues);
            for (int i = 1; i <= int.Parse(NumofQues.Substring(NumofQues.IndexOf("of") + 2)); i++)
            {
                _pageHelper.WaitForElementToContainText(CountofQues, "Question");
                _formHelper.ClickElement(SelectList[1]);
                _formHelper.ClickElement(ContinueButton);
            }
            return new YourAssessmentsPage(_context);
        }

        public AssessmentTypeHomePage ClickContinue()
        {
            _formHelper.ClickElement(ContinueButton);
            return this;
        }
        public void VerifyErrorMessage()
        {
            _pageHelper.VerifyText(ErrorMessage, "Choose an answer").Should().BeTrue();
        }
    }
}
