using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerRemoveSkillsSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private RemoveSkillsPage removeSkillsPage;
       
        #endregion
        public MatchYourSkillsToCareerRemoveSkillsSteps(ScenarioContext context)
        {
            _context = context;
            removeSkillsPage = new RemoveSkillsPage(_context);
        }

        #region When

        [When(@"I select the first skill on remove skills page")]
        public void WhenISelectTheFirstSkillOnRemoveSkillsPage()
        {
            removeSkillsPage
                .ClickFirstSkill();
        }

        [When(@"i click the remove selected skill button")]
        public void WhenIClickTheRemoveSelectedSkillButton()
        {
            removeSkillsPage
                .ClickRemove();
        }

        #endregion


        #region Then

        [Then(@"I am taken to the Remove skills page")]
        public void ThenIAmTakenToTheRemoveSkillsPage()
        {
            removeSkillsPage = new RemoveSkillsPage(_context);
        }

        #endregion


    }
}
