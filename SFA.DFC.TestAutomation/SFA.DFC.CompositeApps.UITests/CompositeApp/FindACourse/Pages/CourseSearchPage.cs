﻿using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
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
    }
}
