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
        private ConfirmRemoveSkillsPage confirmRemoveSkillsPage;
        private RemovedPage removedPage;
       
        #endregion
        public MatchYourSkillsToCareerRemoveSkillsSteps(ScenarioContext context)
        {
            _context = context;
            removeSkillsPage = new RemoveSkillsPage(_context);
            confirmRemoveSkillsPage = new ConfirmRemoveSkillsPage(_context);
            removedPage = new RemovedPage(_context);
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

        [When(@"I click the cancel button on remove skills page")]
        public void WhenIClickTheCancelButtonOnRemoveSkillsPage()
        {
            removeSkillsPage
                .ClickCancel();
        }


        [When(@"I click confirm remove skills")]
        public void WhenIClickConfirmRemoveSkills()
        {
            confirmRemoveSkillsPage
                .ClickRemove();
        }

        [When(@"I click cancel on confirm remove skills page")]
        public void WhenIClickCancelOnConfirmRemoveSkillsPage()
        {
            confirmRemoveSkillsPage
                .ClickCancel();
        }

        [When(@"I click on the add more skills link")]
        public void WhenIClickOnTheAddMoreSkillsLink()
        {
            removedPage
                .ClickAddSkillsLink();
        }

        #endregion


        #region Then

        [Then(@"I am taken to the Remove skills page")]
        public void ThenIAmTakenToTheRemoveSkillsPage()
        {
            removeSkillsPage = new RemoveSkillsPage(_context);
        }
        
        [Then(@"I am taken to the Confirm Remove skills page")]
        public void ThenIAmTakenToTheConfirmRemoveSkillsPage()
        {
            confirmRemoveSkillsPage = new ConfirmRemoveSkillsPage(_context);
        }

        [Then(@"I am taken to Removed page")]
        public void ThenIAmTakenToRemovedPage()
        {
            removedPage = new RemovedPage(_context);
        }

        #endregion


    }
}
