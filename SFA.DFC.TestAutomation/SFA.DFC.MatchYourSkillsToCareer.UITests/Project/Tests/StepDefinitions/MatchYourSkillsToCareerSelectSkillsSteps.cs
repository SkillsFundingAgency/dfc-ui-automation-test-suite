using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerSelectSkillsSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private SelectSkillsPage selectSkillsPage;
        private RelatedSkillsPage relatedSkillsPage;

        #endregion
        public MatchYourSkillsToCareerSelectSkillsSteps(ScenarioContext context)
        {
            _context = context;
            selectSkillsPage = new SelectSkillsPage(_context);
            relatedSkillsPage = new RelatedSkillsPage(_context);
        }

        #region When

        [When(@"I select a skill on Select skills page")]
        public void WhenISelectASkillOnSelectSkillsPage()
        {
            selectSkillsPage
                .SelectASkill();
        }

        [When(@"I select a skill on Related skills page")]
        public void WhenISelectASkillOnRelatedSkillsPage()
        {
            relatedSkillsPage
                .SelectASkill();
        }

        [When(@"I click the Add to basket on Select skills page")]
        public void WhenIClickTheAddToBasketOnSelectSkillsPage()
        {
            selectSkillsPage
                .ClickAdd();
        }

        [When(@"I click the Add to basket on Related skills page")]
        public void WhenIClickTheAddToBasketOnRelatedSkillsPage()
        {
            relatedSkillsPage
                .ClickAdd();
        }


        #endregion


        #region Then
        [Then(@"I am taken to the Select skills page")]
        public void ThenIAmTakenToTheEnterYourSkillsPage()
        {
            selectSkillsPage = new SelectSkillsPage(_context);
        }

        #endregion


    }
}
