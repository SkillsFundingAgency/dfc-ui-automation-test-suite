﻿using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobCategoriesPage : BasePage
    {
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;

        protected override string PageTitle => "";
        private string selectedCategory = string.Empty;
        protected override By PageHeader => By.ClassName("heading-xlarge");
        private By JobCategoryList => By.CssSelector(".govuk-related-items ul li a");

        public JobCategoriesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public void VerifyCorrectJobCategoryPage()
        {
            _context.TryGetValue("selectedCategory", out selectedCategory);
            _pageHelper.VerifyText(PageHeader, selectedCategory);
        }

        public void VerifySelectedCategoryNotDisplayed()
        {
            var listOfCategories = _pageHelper.FindElements(JobCategoryList);
            bool isCategorydisplayed = true;

            foreach (var category in listOfCategories)
            {
                if (!category.Text.Contains(selectedCategory))
                {
                    isCategorydisplayed = false;
                }
            }

            isCategorydisplayed.Should().BeFalse();
        }

        public JobCategoriesPage SelectJobCategory(string selectedCategory)
        {
            _formHelper.ClickElement(_pageHelper.SelectElementFromList(JobCategoryList, selectedCategory));
            return this;
        }
    }
}