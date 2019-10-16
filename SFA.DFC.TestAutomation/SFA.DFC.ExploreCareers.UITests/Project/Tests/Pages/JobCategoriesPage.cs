using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobCategoriesPage : BasePage
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        #endregion

        #region Page Attributes
        protected override string PageTitle => "";

        private string selectedCategory = string.Empty;
        protected override By PageHeader => By.ClassName("heading-xlarge");
        private By JobCategoryList => By.CssSelector(".govuk-related-items ul li a");
        private By Breadcrumb => By.ClassName("breadcrumbs");
        private By listOfProfiles => By.ClassName("dfc-code-search-jpTitle");
        private By HomeBreadcrumbLink => By.ClassName("govuk-breadcrumbs__link");

        #endregion

        public JobCategoriesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public JobCategoriesPage SelectJobCategory(string selectedCategory)
        {
            _formHelper.ClickElement(_pageHelper.GetLinkContains(JobCategoryList, selectedCategory));
            return this;
        }

        public JobProfilePage SelectJobProfile(int profileNo)
        {
            List<IWebElement> listOfJPs = _pageHelper.FindElements(listOfProfiles);
            _context.Add("JCProfileSelected", listOfJPs[profileNo-1].Text);
            _formHelper.ClickElement(listOfJPs[profileNo-1]);
            return new JobProfilePage(_context);
        }

        public Homepage SelectHomeBreadcrumb()
        {
            _formHelper.ClickElement(HomeBreadcrumbLink);
            return new Homepage(_context);
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

        public void VerifyCorrectBreadcrumbDisplayed()
        {
            _pageHelper.VerifyText(Breadcrumb, "Home: Explore careers");
            _pageHelper.VerifyText(Breadcrumb, selectedCategory);
        }

    }
}
