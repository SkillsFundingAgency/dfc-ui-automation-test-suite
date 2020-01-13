using OpenQA.Selenium;
using SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MatchYourSkillsToCareerNewJobProfileSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private MatchDetailsPage matchDetailsPage;

        #endregion
        public MatchYourSkillsToCareerNewJobProfileSteps(ScenarioContext context)
        {
            _context = context;
            matchDetailsPage = new MatchDetailsPage(_context);
        }

        #region When


        #endregion


        #region Then

        [Then(@"I am taken to the new Job profile page")]
        public void ThenIAmTakenToTheNewJobProfilePage()
        {
            matchDetailsPage = new MatchDetailsPage(_context);
        }


        #endregion


    }
}
