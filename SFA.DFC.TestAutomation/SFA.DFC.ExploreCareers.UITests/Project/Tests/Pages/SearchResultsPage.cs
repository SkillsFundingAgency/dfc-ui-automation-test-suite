using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class SearchResultsPage : BasePage
    {
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        private FormCompletionHelper _formHelper;
        private readonly ObjectContext _objectContext;
        protected override string PageTitle => "";
        private By SearchResultsPageTitle => By.ClassName("search-title");
        private By ProfileResults => By.ClassName("dfc-code-search-jpTitle");

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public void VerifySearchResultsPage()
        {
            _pageHelper.IsElementDisplayed(SearchResultsPageTitle);
        }

        public JobProfilePage SelectSearchResult(int resultToSelect)
        {
           var listOfResults = _pageHelper.FindElements(ProfileResults);
            _objectContext.Set("searchResultSelected", listOfResults[resultToSelect - 1].Text);
            _formHelper.ClickElement(listOfResults[resultToSelect - 1]);
            return new JobProfilePage(_context);
        }
    }
}
