using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DYSACSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private DYSACTraitsQuestionsPage dYSACTraitsQuestionsPage;
        private DYSACAssessmentCompletePage dYSACAssessmentCompletePage;
        private DYSACResultsPage dYSACResultsPage;
        private DYSACAttributesQuestionsPage dYSACAttributesQuestionsPage;
       
        #endregion
        public DYSACSteps(ScenarioContext context)
        {
            _context = context;
            dYSACTraitsQuestionsPage = new DYSACTraitsQuestionsPage(_context);
            dYSACAssessmentCompletePage = new DYSACAssessmentCompletePage(_context);
            dYSACResultsPage = new DYSACResultsPage(_context);
            dYSACAttributesQuestionsPage = new DYSACAttributesQuestionsPage(_context);
        }

        #region When

        [When(@"I complete the DYSAC (.*) questions and click to see results")]
        public void WhenICompleteTheDYSACQuestionsAndClickToSeeResults(int p0)
        {
            int i = 0;
            do
            {
                dYSACTraitsQuestionsPage
                    .SelectStronglyAgree()
                    .ClickNextButton();
            } while (i < 39);

            dYSACTraitsQuestionsPage
                .ClickFinalNextButton();

            dYSACAssessmentCompletePage
                .ClickResultsButton();
        }

        [When(@"I choose to answer more questions")]
        public void WhenIChooseToAnswerMoreQuestions()
        {
            dYSACResultsPage
                .ClickAttributeQuestions();
        }

        [When(@"I complete the DYSAC additional questions")]
        public void WhenICompleteTheDYSACAdditionalQuestions()
        {
            int i = 0;
            do
            {
                dYSACAttributesQuestionsPage
                    .ClickYes()
                    .ClickNextButton();
            } while (i < 3);

            dYSACAttributesQuestionsPage
                .ClickFinalNextButton();
        }

        [When(@"I click the link to Match skills")]
        public void WhenIClickTheLinkToMatchSkills()
        {
            dYSACResultsPage
                .ClickMatchSkills();
        }

        #endregion

        #region Then

        [Then(@"I am taken to the DYSAC traits page")]
        public void ThenIAmTakenToTheDYSACTraitsPage()
        {
            dYSACTraitsQuestionsPage = new DYSACTraitsQuestionsPage(_context);
        }

        [Then(@"I am taken to the DYSAC results page")]
        public void ThenIAmTakenToTheDYSACResultsPage()
        {
            dYSACResultsPage = new DYSACResultsPage(_context);
        }

        [Then(@"I am taken to the DYSAC additional questions page")]
        public void ThenIAmTakenToTheDYSACAdditionalQuestionsPage()
        {
            dYSACAttributesQuestionsPage = new DYSACAttributesQuestionsPage(_context);
        }
        #endregion

    }
}
