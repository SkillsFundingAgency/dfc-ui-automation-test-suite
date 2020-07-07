using DFC.TestAutomation.UI.TestSupport;
using DFC.TestAutomation.UI.Helpers;
using OpenQA.Selenium;
using SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Pages
{
    public class CourseSearchPage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "Find a course";

        private By KeywordSearchBox = By.Id("search-input");
        private By KeywordSearchButton = By.ClassName("input-submit-wrapper"); //Pending id
        private By NoResultsMessage = By.ClassName("govuk-body-s"); //Pending id
        private By SingleResult = By.ClassName("govuk-!-margin-top-6"); //Pending id
        private By TotalResultsCountLabel = By.ClassName("govuk-body"); //Pending id

        public CourseSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public void EnterKeywordIntoTheKeywordSearchBox(string keyword)
        {
            _objectContext.Set("Keyword", keyword);
            _formHelper.EnterText(this.KeywordSearchBox, keyword);
        }

        public CourseSearchPage ClickKeywordSearchButton()
        {
            _formHelper.ClickElement(KeywordSearchButton);
            return new CourseSearchPage(_context);
        }

        public bool IsNoResultsMessageDisplayed()
        {
            return _pageHelper.IsElementDisplayed(NoResultsMessage);
        }

        public bool AreOneOrMoreResultsDisplayed()
        {
            return _pageHelper.GetCountOfElementsGroup(SingleResult) > 0;
        }

        public string GetTotalResultsLabel()
        {
            return _pageHelper.GetText(TotalResultsCountLabel);
        }

        public List<Results> GetResults()
        {
            var results = new List<Results>();
            var allResultContainers = _pageHelper.FindElements(SingleResult);

            foreach(var resultContainer in allResultContainers)
            {
                var uiResult = new Results();
                uiResult.courseName = resultContainer.FindElement(By.CssSelector("h2.govuk-heading-m")).Text;
                var startDateStr = resultContainer.FindElement(By.CssSelector("div.govuk-grid-column-one-half > ul.govuk-list > li")).Text.Replace("Start date:", string.Empty).Trim();
                DateTime startDate;
                
                if(DateTime.TryParse(startDateStr, out startDate)) {
                    uiResult.startDate = startDate;
                }

                results.Add(uiResult);
            }

            return results;
        }
    }
}
