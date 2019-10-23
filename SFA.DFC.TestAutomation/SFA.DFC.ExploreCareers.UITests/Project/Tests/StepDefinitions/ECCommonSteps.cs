using OpenQA.Selenium;
using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ECCommonSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private JobCategoriesPage jobCategoryPage;
        private SearchResultsPage searchResultsPage;
        private Homepage homepage;
        #endregion

        public ECCommonSteps(ScenarioContext context)
        {
            _context = context;
            homepage = new Homepage(_context);
            jobCategoryPage = new JobCategoriesPage(_context);
            searchResultsPage = new SearchResultsPage(_context);
        }

        #region Givens
        [Given(@"I navigate to the explore careers homepage")]
        public void GivenINavigateToTheExploreCareersHomepage()
        {
            homepage
                .NavigateToHomepage();
        }

        #endregion

        #region Whens
        [When(@"I click the '(.*)' breadcrumb")]
        public void WhenIClickTheBreadcrumb(string page)
        {
            switch (page.ToLowerInvariant())
            {
                case "job category":
                    jobCategoryPage
                        .ClickHomeBreadcrumb();
                    break;
                case "search":
                    searchResultsPage
                        .ClickHomeBreadcrumb();
                    break;
                default:
                    throw new NotFoundException("Page not found");
            }
        }
        #endregion

        #region Thens
        [Then(@"I am redirected to the explore careers homepage")]
        public void ThenIAmRedirectedToTheExploreCareersHomepage()
        {
            homepage
                .VerifyHomePage();
        }
        #endregion
    }
}

