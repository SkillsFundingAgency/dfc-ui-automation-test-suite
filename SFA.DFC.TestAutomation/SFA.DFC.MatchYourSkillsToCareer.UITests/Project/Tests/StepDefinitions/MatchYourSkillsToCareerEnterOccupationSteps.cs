using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerEnterOccupationSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private EnterJobsPage enterJobsPage;
        private MoreSkillsPage moreSkillsPage;
        private MoreJobsPage moreJobsPage;

        #endregion
        public MatchYourSkillsToCareerEnterOccupationSteps(ScenarioContext context)
        {
            _context = context;
            enterJobsPage = new EnterJobsPage(_context);
            moreSkillsPage = new MoreSkillsPage(_context);
            moreJobsPage = new MoreJobsPage(_context);
        }

        #region When

        [When(@"I enter (.*) on the Enter your occupation page")]
        public void WhenIEnterJobOnTheEnterYourOccupationPage(string job)
        {
            enterJobsPage
                .EnterJob(job);             
        }

        [When(@"I enter (.*) on the Enter your job page")]
        public void WhenIEnterJobOnTheEnterYourJobPage(string job)
        {
            moreJobsPage
                .EnterJob(job);
        }


        [When(@"I select (.*) from the drop down list")]
        public void WhenISelectJobFromTheDropDownList(string job)
        {
            enterJobsPage
                .SelectJob(job);
        }


        [When(@"I select (.*) from the dropdown list")]
        public void WhenISelectJobFromTheDropdownList(string job)
        {
            moreJobsPage
                .SelectJob(job);
        }



        [When(@"I click search button on the Enter your occupation page")]
        public void WhenIClickSearchButtonOnTheEnterYourOccupationPage()
        {
            enterJobsPage
                .ClickSearch();
        }

        [When(@"I select skills entry option")]
        public void WhenISelectSkillsEntryOption()
        {
            moreSkillsPage
                .ClickSearchBySkills()
                .ClickContinueToSkills();
        }

        [When(@"I select enter jobs option")]
        public void WhenISelectJobsEntryOption()
        {
            moreSkillsPage
                .ClickSearchByOccupations()
                .ClickContinueToOccupations();
        }

        #endregion


        #region Then

        [Then(@"I am taken to the Enter your occupation page")]
        public void ThenIAmTakenToTheEnterYourOccupationPage()
        {
            enterJobsPage = new EnterJobsPage(_context);
        }

        [Then(@"I am taken to the More Skills page")]
        public void ThenIAmTakenToTheMoreSkillsPage()
        {
            moreSkillsPage = new MoreSkillsPage(_context);
        }

        [Then(@"I am taken to the Enter your job page")]
        public void ThenIAmTakenToTheEnterYourJobPage()
        {
            moreJobsPage = new MoreJobsPage(_context);
        }


        [Then(@"an Error message is displayed on the Enter your occupation page")]
        public void ThenAnErrorMessageIsDisplayedOnTheEnterYourOccupationPage()
        {
            enterJobsPage
                .VerifyError();
        }

        #endregion


    }
}
