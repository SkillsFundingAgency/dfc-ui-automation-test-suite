using OpenQA.Selenium;
using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private SearchResultsPage searchResultsPage;
        private Homepage homepage;
        #endregion

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            searchResultsPage = new SearchResultsPage(_context);
            homepage = new Homepage(_context);

        }

        #region Givens
        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string searchTerm)
        {
            searchResultsPage = homepage
                .NavigateToHomepage()
                .Search(searchTerm);
        }

        #endregion
        #region Whens

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string searchTerm)
        {
            searchResultsPage = homepage
                .Search(searchTerm);
        }

        [When(@"I select search result '(.*)'")]
        public void WhenISelectSearchResult(int profileToSelect)
        {
            searchResultsPage
                .SelectSearchResult(profileToSelect);
        }

        #endregion

        #region Thens
        [Then(@"I am redirected to the search results page")]
        public void ThenIAmRedirectedToTheSearchResultsPage()
        {
            searchResultsPage
                .VerifySearchResultsPage();
        }

        [Then(@"the search term is displayed in the search field")]
        public void ThenTheSearchTermIsDisplayedInTheSearchField()
        {
            searchResultsPage
                .VerifySearchTermIsDisplayedOnResultsPage();
        }

        [Then(@"a list of results are displayed")]
        public void ThenAListOfResultsAreDisplayed()
        {
            searchResultsPage
                .VerifyListOfResultsAredisplayed();
        }

        [Then(@"the no results message is displaed")]
        public void ThenTheNoResultsMessageIsDisplaed()
        {
            searchResultsPage
                .VerifyNoSearchResultsMessage();
        }

        #endregion

    }
}
