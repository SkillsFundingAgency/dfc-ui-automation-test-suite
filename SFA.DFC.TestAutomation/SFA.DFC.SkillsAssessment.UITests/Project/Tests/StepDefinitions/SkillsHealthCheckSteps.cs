using OpenQA.Selenium;
using SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SkillsHealthCheckSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private YourAssessmentsPage yourAssessmentsPage;
        private AssessmentTypeHomePage assessmentTypeHomePage;
        #endregion
        public SkillsHealthCheckSteps(ScenarioContext context)
        {
            _context = context;
            yourAssessmentsPage = new YourAssessmentsPage(_context);
        }
        [Given(@"I select '(.*)' assessment type with title '(.*)'")]
        public void GivenISelectAssessmentTypeWithTitle(string assessType, string assessTitle)
        {

            assessmentTypeHomePage = yourAssessmentsPage.NavigatetoAssessmentHomePage(assessType, assessTitle);
        }
        #region Whens
        [When(@"I complete all the questions")]
        public void WhenICompleteAllTheQuestions()
        {
            yourAssessmentsPage = assessmentTypeHomePage.AnswerAllQuestions();            
        }
        [When(@"I click continue without answering a question")]
        public void WhenIClickContinueWithoutAnsweringAQuestion()
        {
            assessmentTypeHomePage.ClickContinue();
        }
        #endregion
        #region Thens

        [Then(@"I am redirected to the start page for the assessment")]
        public void ThenIAmRedirectedToTheStartPageForTheAssessment()
        {
            assessmentTypeHomePage.VerifyAssessmentTitle();
        }
        [Then(@"I'm redirected to Skills health check page")]
        public void ThenIMRedirectedToSkillsHealthCheckPage()
        {
            yourAssessmentsPage.VerifyPageTitle();
        }
      
        [Then(@"I can download my completed assessment as a '(.*)'")]
        public void ThenICanDownloadMyCompletedAssessmentAsA(string docType)
        {
            yourAssessmentsPage.ChooseDocType(docType);
            yourAssessmentsPage.DownloadReport();
        }        
        [Then(@"an error message should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed()
        {
            assessmentTypeHomePage.VerifyErrorMessage();
        }
        #endregion

    }
}
