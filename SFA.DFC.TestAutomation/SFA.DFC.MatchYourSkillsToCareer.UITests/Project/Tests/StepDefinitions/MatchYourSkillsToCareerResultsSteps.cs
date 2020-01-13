using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerResultsSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private MatchResultsPage matchResultsPage;
       
        #endregion
        public MatchYourSkillsToCareerResultsSteps(ScenarioContext context)
        {
            _context = context;
            matchResultsPage = new MatchResultsPage(_context);
        }

        #region When

        [When(@"I click on the first job")]
        public void WhenIClickOnTheFirstJob()
        {
            matchResultsPage
                .ClickFirstResult();
        }

        #endregion


        #region Then

        [Then(@"I am on the Results page")]
        public void ThenIAmOnTheResultsPage()
        {
            matchResultsPage = new MatchResultsPage(_context);
        }


        #endregion


    }
}
