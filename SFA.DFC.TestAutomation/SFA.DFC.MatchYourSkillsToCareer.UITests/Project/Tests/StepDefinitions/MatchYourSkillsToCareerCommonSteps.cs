using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerCommonSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        //private MYSTCHomePage mystcHomePage;
        private MatchYourSkillsToCareerHomePage matchYourSkillsToCareerHomepage;
        private MoreSkillsPage moreSkillsPage;
        private WorkedPage workedPage;
        private RoutePage routePage;
       
        #endregion
        public MatchYourSkillsToCareerCommonSteps(ScenarioContext context)
        {
            _context = context;
            matchYourSkillsToCareerHomepage = new MatchYourSkillsToCareerHomePage(_context);
            moreSkillsPage = new MoreSkillsPage(_context);
            workedPage = new WorkedPage(_context);
            routePage = new RoutePage(_context);
        }

        [Given(@"I have navigated to the Skills Health check page")]
        public void GivenIHaveNavigatedToTheSkillsHealthCheckPage()
        {
            matchYourSkillsToCareerHomepage
                .NavigatetoMYSTCHomePage()
                .ClickGoToMYSTC();
        }

        [Given(@"I have navigated to the Match Skills page and click Start now")]
        public void GivenIHaveNavigatedToTheMatchSkillsPage()
        {
            matchYourSkillsToCareerHomepage
                .NavigatetoMYSTCHomePage()
                .ClickGoToMYSTC();
        }

        #region When
        [When(@"I select the search jobs by entering skills option")]
        public void WhenISelectTheSearchJobsByEnteringSkillsOption()
        {
            moreSkillsPage
                .ClickSearchBySkills()
                .ClickContinueToSkills();
        }

        [When(@"I select the search jobs by entering your job title option")]
        public void WhenISelectTheSearchJobsByEnteringYourJobTitleOption()
        {
            moreSkillsPage
                .ClickSearchByOccupations()
                .ClickContinueToOccupations();
        }

        [When(@"I select Yes and click continue on employment choice")]
        public void WhenISelectYesAndClickContinueOnEmploymentChoice()
        {
            workedPage
                .ClickRadioYes()
                .ClickContinueButton();
        }

        [When(@"I select No and click continue on employment choice")]
        public void WhenISelectNoAndClickContinueOnEmploymentChoice()
        {
            workedPage
                .ClickRadioNo()
                .ClickContinueButton();
        }


        [When(@"I select the Match Skills option and click continue")]
        public void WhenISelectTheMatchSkillsOptionAndClickContinue()
        {
            routePage
                .ClickSearchBySkills()
                .ClickContinueToOccupations();
        }

        [When(@"I select the DYSAC option and click continue")]
        public void WhenISelectTheDYSACOptionAndClickContinue()
        {
            routePage
                .ClickAboutYourself()
                .ClickContinueToDYSAC();
        }

        #endregion


        #region Then

        [Then(@"I am taken to the Skills Entry Choice page")]
        public void ThenIAmTakenToTheSkillsEntryChoicePage()
        {
            routePage = new RoutePage(_context);
        }

        #endregion
    }
}
