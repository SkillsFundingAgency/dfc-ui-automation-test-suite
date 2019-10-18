﻿using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
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
        #endregion

        #region Page Elements
        protected override string PageTitle => "";

        private By JobCategoryList => By.CssSelector(".homepage-jobcategories li a");
        private By SearchField => By.ClassName("search-input");
        private By SubmitSearch => By.ClassName("submit");
        #endregion

        public Homepage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public JobCategoriesPage SelectJobCategory(string selectedCategory)
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

        public void VerifyHomePage()
        {
            _pageHelper.VerifyPage(PageHeader, "Explore careers");
        }
    }
}
