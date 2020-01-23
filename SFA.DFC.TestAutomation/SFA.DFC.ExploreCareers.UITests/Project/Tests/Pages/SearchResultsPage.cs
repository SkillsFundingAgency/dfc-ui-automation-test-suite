using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
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
        private By SearchField => By.Id("search-main");
        private By ResultCount => By.ClassName("result-count");
        private By HomeBreadcrumbLink => By.ClassName("govuk-breadcrumbs__link");

        private By DidYouMeanText => By.CssSelector(".search-dym span");
        private By DidYouMeanLink => By.CssSelector(".search-dym span a");
        private By SearchResultCategory => By.ClassName("results-categories");
        private By SearchResultCategoryLink => By.CssSelector(".results-categories a");
        #endregion

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public JobProfilePage ClickSearchResult(int resultToSelect)
        {
           var listOfResults = _pageHelper.FindElements(ProfileResults);
            if (listOfResults.Count >= resultToSelect)
            {
                _objectContext.Set("JPSearchResultSelected", _pageHelper.GetText(listOfResults[resultToSelect - 1]));
                _formHelper.ClickElement(listOfResults[resultToSelect - 1]);
            }
            else
            {
                throw new IndexOutOfRangeException("Number of results is lower than selected value");
            }

            return new JobProfilePage(_context);
        }

        public Homepage ClickHomeBreadcrumb()
        {
            _formHelper.ClickElement(HomeBreadcrumbLink);
            return new Homepage(_context);
        }

        public SearchResultsPage ClickDidYouMeanSuggestion()
        {
            _objectContext.Replace("searchedTerm", _pageHelper.GetText(DidYouMeanLink));
            _formHelper.ClickElement(DidYouMeanLink);
            return this;
        }

        public JobCategoriesPage ClickSearchCategory(int categoryToSelect)
        {
            var element = _pageHelper.FindElements(SearchResultCategoryLink);
            _objectContext.Set("selectedCategory", element[categoryToSelect - 1].Text);
            _formHelper.ClickElement(element[categoryToSelect - 1]);
            return new JobCategoriesPage(_context);
        }

        public void VerifySearchResultsPage()
        {
            _pageHelper.IsElementDisplayed(SearchResultsPageTitle).Should().BeTrue();
        }

        public void VerifySearchTermIsDisplayedOnResultsPage()
        {
            string searchTerm = _objectContext.Get("searchedTerm");
            _pageHelper.VerifyValueAttributeOfAnElement(SearchField, searchTerm);
        }

        public void VerifyListOfResultsAredisplayed()
        {
            _pageHelper.GetCountOfElementsGroup(ProfileResults).Should().BeGreaterThan(0);
        }

        public void VerifyNoSearchResultsMessage()
        {
            _pageHelper.IsElementDisplayed(ResultCount).Should().BeTrue();
            _pageHelper.GetText(ResultCount).Should().Contain("0 results found");
        }

        public void VerifyDidYouMeanIsDisplayed()
        {
            _pageHelper.IsElementDisplayed(DidYouMeanText).Should().BeTrue();
            _pageHelper.VerifyText(DidYouMeanText, "Did you mean").Should().BeTrue();
        }

        public void VerifyJobCategoryDisplayedOnSearch()
        {
            _pageHelper.IsElementDisplayed(SearchResultCategory).Should().BeTrue();
        }
    }
}
