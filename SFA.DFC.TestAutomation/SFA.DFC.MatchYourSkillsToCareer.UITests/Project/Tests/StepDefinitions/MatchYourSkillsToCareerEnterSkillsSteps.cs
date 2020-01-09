using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerEnterSkillsSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private EnterSkillsPage enterSkillsPage;
        private RelatedSkillsPage relatedSkillsPage;
       
        #endregion
        public MatchYourSkillsToCareerEnterSkillsSteps (ScenarioContext context)
        {
            _context = context;
            enterSkillsPage = new EnterSkillsPage(_context);
        }

        #region When
        [When(@"I enter (.*) on Enter skills page")]
        public void WhenIEnterOnEnterSkillsPage(string skill)
        {
            enterSkillsPage
                .EnterSkills(skill);
        }

        [When(@"I click search button on Enter skills page")]
        public void WhenIClickSearchButtonOnEnterSkillsPage()
        {
            enterSkillsPage
                .ClickSearch();
        }

        #endregion


        #region Then
        [Then(@"I am taken to the Enter your skills page")]
        public void ThenIAmTakenToTheEnterYourSkillsPage()
        {
            enterSkillsPage = new EnterSkillsPage(_context);
        }

        [Then(@"an Error message is displayed on the Enter skills page")]
        public void ThenAnErrorMessageIsDisplayedOnTheEnterSkillsPage()
        {
            enterSkillsPage
                .VerifyError();
        }

        [Then(@"I am taken to the Related skills page")]
        public void ThenIAmTakenToTheRelatedSkillsPage()
        {
            relatedSkillsPage = new RelatedSkillsPage(_context);
        }

        #endregion


    }
}
