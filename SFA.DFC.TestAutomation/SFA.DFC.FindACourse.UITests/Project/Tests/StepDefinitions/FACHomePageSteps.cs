using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FACHomePageSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private FACHomePage fACHomePage;
        private CourseResultsPage courseResultsPage;
        #endregion 
        public FACHomePageSteps(ScenarioContext context)
        {
            _context = context;
            fACHomePage = new FACHomePage(_context);
            
        }
        #region Givens
        [Given(@"I have navigated to Find a course page")]
        public void GivenIHaveNavigatedToFindACoursePage()
        {
            fACHomePage.NavigateToFACHomepage();
        }
    
        [Given(@"I have searched for a course '(.*)' for provider '(.*)' and location '(.*)'")]
            public void GivenIHaveSearchedForACourseForProviderAndLocation(string CourseName, string provider, string location)
            {
                fACHomePage.EnterSearchCriteria(CourseName);
                fACHomePage.EnterProvider(provider);
                fACHomePage.EnterLocation(location);
                courseResultsPage = fACHomePage.ClickFindACourse();
                courseResultsPage.VerifyResults();            
            }
        #endregion
        #region Whens
        [When(@"I have entered '(.*)' in the course name")]
         public void WhenIHaveEnteredInTheCourseName(string CourseName)
         {
             fACHomePage.EnterSearchCriteria(CourseName);
         }

        [When(@"I click the Find a course button")]
        public void WhenIClickTheFindACourseButton()
        {
           courseResultsPage= fACHomePage.ClickFindACourse();
        }  
        
        [When(@"I have entered a provider '(.*)' and location '(.*)'")]
        public void WhenIHaveEnteredAProviderAndLocation(string Prov, string Location)
        {
            fACHomePage.EnterProvider(Prov);
            fACHomePage.EnterLocation(Location);            
        }
        #endregion 

    }
}
