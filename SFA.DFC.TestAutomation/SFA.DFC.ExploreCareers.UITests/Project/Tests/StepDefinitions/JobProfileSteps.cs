using OpenQA.Selenium;
using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
using SFA.DFC.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class JobProfileSteps
    {

        #region Helpers
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly ExploreCareersConfig _config;
        private JobProfilePage jobProfilePage;
        private CourseDetailsPage courseDetailsPage;
        private FindACourseHomePage findACourseHomePage;
        private ApprenticeshipDetailsPage apprenticeshipDetailsPage;
        private JobProfileFeedbackThankYouPage jobProfileFeedbackThankYouPage;
        private SearchResultsPage searchResultsPage;
        private Homepage homepage;
        #endregion

        public JobProfileSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetExploreCareersConfig<ExploreCareersConfig>();
            jobProfilePage = new JobProfilePage(_context);
            homepage = new Homepage(_context);

        }
        #region Givens

        [Given(@"I navigate to the '(.*)' profile")]
        public void GivenINavigateToTheProfile(string jobProfile)
        {
            _webDriver.Url = _config.BaseUrl + "/job-profiles/" + jobProfile;
        }
        #endregion

        #region Whens
        [When(@"I click on career title '(.*)'")]
        public void WhenIClickOnCareerTitle(int careerSelected)
        {
            jobProfilePage
                .ClickRelatedCareer(careerSelected);
        }

        [When(@"I select course title '(.*)'")]
        public void WhenISelectCourseTitle(int courseToSelect)
        {
            courseDetailsPage = jobProfilePage
                .ClickCourse(courseToSelect);
        }

        [When(@"I click the Find courses near you link")]
        public void WhenIClickTheFindCoursesNearYouLink()
        {
            findACourseHomePage = jobProfilePage
                .ClickFindCoursesNearYouLink();
        }

        [When(@"I select apprenticeship title '(.*)'")]
        public void WhenISelectApprenticeshipTitle(int appToSelect)
        {
            apprenticeshipDetailsPage = jobProfilePage
                .ClickApprenticeship(appToSelect);
        }

        [When(@"I click yes to job profile feedback")]
        public void WhenIClickYesToJobProfileFeedback()
        {
            jobProfilePage
                .ClickYesOnFeedbackBanner();
        }

        [When(@"I click no to job profile feedback")]
        public void WhenIClickNoToJobProfileFeedback()
        {
            jobProfilePage
                .ClickNoOnFeedbackBanner();
        }

        [When(@"I click to go to additional survey")]
        public void WhenIClickToGoToAdditionalSurvey()
        {
            jobProfilePage
                .ClickTakeAdditionalSurveyLink();
        }

        [When(@"I enter the feedback '(.*)'")]
        public void WhenIEnterTheFeedback(string feedback)
        {
            jobProfileFeedbackThankYouPage = jobProfilePage
                .EnterFeedback(feedback);
        }

        [When(@"I search for '(.*)' under the JP search feature")]
        public void WhenISearchForTermUnderTheSearchFeature(string searchTerm)
        {
            searchResultsPage = jobProfilePage
                .SearchOnJobProfile(searchTerm);
        }


        #endregion

        #region Thens

        [Then(@"the related careers section should be displayed")]
        public void ThenTheRelatedCareersSectionShouldBeDisplayed()
        {
            jobProfilePage
                .VerifyRelatedCareersSectionDisplayed();
        }

        [Then(@"there should be no more than (.*) careers")]
        public void ThenThereShouldBeNoMoreThanCareers(int maxNoOfRelatedProfiles)
        {
            jobProfilePage
                .VerifyNumberOfRelatedCareersDisplayed(maxNoOfRelatedProfiles);
        }

        [Then(@"I am redirected to the profile selected")]
        public void ThenIAmRedirectedToTheProfileSelected()
        {
            jobProfilePage
                .VerifyCorrectJobProfilePage();
        }

        [Then(@"related courses are displayed")]
        public void ThenRelatedCoursesAreDisplayed()
        {
            jobProfilePage
                .VerifyCoursesAreDisplayed();
        }

        [Then(@"I am redirected to the correct course details page")]
        public void ThenIAmRedirectedToTheCorrectCourse()
        {
            courseDetailsPage
                .VerifyCorrectCourseDetailsPage();
        }

        [Then(@"I am taken to the Find a Course product")]
        public void ThenIAmTakenToTheFindACourseProduct()
        {
            findACourseHomePage
                .VerifyFindACourseHomepage();
        }

        [Then(@"the related apprenticeship section is displayed")]
        public void ThenTheRelatedApprenticeshipSectionIsDisplayed()
        {
            jobProfilePage
                .VerifyApprenticeAreDisplayed();
        }

        [Then(@"I am redirected to the correct apprenticeships page")]
        public void ThenIAmRedirectedToTheCorrectApprenticeshipsPage()
        {
            apprenticeshipDetailsPage
                .VerifyCorrectApprenticeshipPage();
        }

        [Then(@"all the profile segments are displayed")]
        public void ThenAllTheProfileSegmentsAreDisplayed()
        {
            jobProfilePage
                .VerifyAllProfileSegments();
        }

        [Then(@"the related apprenticeship section is not displayed")]
        public void ThenTheRelatedApprenticeshipSectionIsNotDisplayed()
        {
            jobProfilePage
                .VerifyNoApprenticeshipsDisplayed();
        }

        [Then(@"the thank you message is displayed")]
        public void ThenTheThankYouMessageIsDisplayed()
        {
            jobProfilePage
                .VerifyJPFeedbackThankYouMessage();
        }

        [Then(@"the additional survey message is displayed")]
        public void ThenTheAdditionalSurveyMessageIsDisplayed()
        {
            jobProfilePage
                .VerifyAdditionalSurveyMessage();
        }

        [Then(@"I am redirected to the SurveyMonkey survey")]
        public void ThenIAmRedirectedToTheSurveyMonkeySurvey()
        {
            jobProfilePage
                .VerifySurveyMonkeyScreen();
        }

        [Then(@"I am redirected to the thank you page")]
        public void ThenIAmRedirectedToTheThankYouPage()
        {
            jobProfileFeedbackThankYouPage
                .VerifyThankYouMessage();
        }

        [Then(@"I am redirected to the 404 page")]
        public void ThenIAmRedirectedToThePage()
        {
            jobProfilePage
                .Verify404Page();
        }

        [Then(@"I am redirected to the national careers service homepage")]
        public void ThenIAmRedirectedToTheNationalCareersServiceHomepage()
        {
            homepage
                .VerifyNCSHomePage();
        }

        [Then(@"I am redirected to the explore careers homepage")]
        public void ThenIAmRedirectedToTheExploreCareersHomepage()
        {
            homepage
                .VerifyHomePage();
        }

        #endregion
    }
}
