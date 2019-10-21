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
        private readonly ScenarioContext _context;
        private SearchResultsPage searchResultsPage;
        private Homepage homepage;

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
            searchResultsPage = new SearchResultsPage(_context);
            homepage = new Homepage(_context);
        }

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
        #endregion

    }
}
