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
        private readonly ObjectContext _objectContext;
        private SearchResultsPage searchResultsPage;

        public SearchSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            searchResultsPage = _objectContext.Get<SearchResultsPage>();
        }

        [When(@"I select search result '(.*)'")]
        public void WhenISelectSearchResult(int profileToSelect)
        {
            searchResultsPage
                .SelectSearchResult(profileToSelect);
        }

    }
}
