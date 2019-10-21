using FluentAssertions;
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
        #region Helpers
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        private FormCompletionHelper _formHelper;
        private readonly ObjectContext _objectContext;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private By SearchResultsPageTitle => By.ClassName("search-title");
        private By ProfileResults => By.ClassName("dfc-code-search-jpTitle");
        private By SearchField => By.ClassName("search-input");
        private By ResultCount => By.ClassName("result-count");
        private By HomeBreadcrumbLink => By.ClassName("govuk-breadcrumbs__link");

        #endregion

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public JobProfilePage SelectSearchResult(int resultToSelect)
        {
           var listOfResults = _pageHelper.FindElements(ProfileResults);
            _objectContext.Set("searchResultSelected", _pageHelper.GetText(listOfResults[resultToSelect - 1]));
            _formHelper.ClickElement(listOfResults[resultToSelect - 1]);
            return new JobProfilePage(_context);
        }

        public Homepage SelectHomeBreadcrumb()
        {
            _formHelper.ClickElement(HomeBreadcrumbLink);
            return new Homepage(_context);
        }
        public void VerifySearchResultsPage()
        {
            _pageHelper.IsElementDisplayed(SearchResultsPageTitle);
        }

        public void VerifySearchTermIsDisplayedOnResultsPage()
        {
            string searchTerm = _objectContext.Get("searchResultSelected");
            _pageHelper.VerifyText(SearchField, searchTerm);
        }

        public void VerifyListOfResultsAredisplayed()
        {
            _pageHelper.GetCountOfElementsGroup(ProfileResults).Should().BeGreaterThan(0);
        }

        public void VerifyNoSearchResultsMessage()
        {
            _pageHelper.IsElementDisplayed(ResultCount);
            _pageHelper.GetText(ResultCount).Should().Contain("0 results found");
        }
    }
}
