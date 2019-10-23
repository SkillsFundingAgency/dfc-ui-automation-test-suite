using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class Homepage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly ExploreCareersConfig _config;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";

        private By JobCategoryList => By.CssSelector(".homepage-jobcategories li a");
        private By SearchField => By.ClassName("search-input");
        private By SubmitSearch => By.ClassName("submit");
        private By AutoSuggestList => By.ClassName("ui-menu-item");

        #endregion

        public Homepage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetExploreCareersConfig<ExploreCareersConfig>();
        }

        public Homepage NavigateToHomepage()
        {
            _webDriver.Url = _config.BaseUrl + "/explore-careers";
            return this;
        }

        public JobCategoriesPage ClickJobCategory(string selectedCategory)
        {
            _objectContext.Set("selectedCategory", selectedCategory);
            _formHelper.ClickElement(_pageHelper.GetLinkContains(JobCategoryList, selectedCategory));
            return new JobCategoriesPage(_context);
        }

        public SearchResultsPage Search(string searchTerm)
        {
            _objectContext.Set("searchedTerm", searchTerm);
            _formHelper.EnterText(SearchField, searchTerm);
            _formHelper.ClickElement(SubmitSearch);
            return new SearchResultsPage(_context);
        }

        public SearchResultsPage ClickSearchButton()
        {
            _formHelper.ClickElement(SubmitSearch);
            return new SearchResultsPage(_context);
        }

        public Homepage EnterSearchTerm(string incompleteSearchTerm)
        {
            _formHelper.EnterText(SearchField, incompleteSearchTerm);
            return new Homepage(_context);
        }

        public Homepage ClickAutoSuggestResult(int resultToSelect)
        {
            List<IWebElement> list = _pageHelper.FindElements(AutoSuggestList);
            _objectContext.Replace("searchedTerm", _pageHelper.GetText(list[resultToSelect - 1]));
            _formHelper.ClickElement(list[resultToSelect - 1]);

            return new Homepage(_context);
        }
        public void VerifyHomePage()
        {
            _pageHelper.VerifyPage(PageHeader, "Explore careers");
        }
    }
}
