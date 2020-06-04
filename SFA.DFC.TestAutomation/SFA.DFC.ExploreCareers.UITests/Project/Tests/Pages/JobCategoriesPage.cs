using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
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
        private readonly ObjectContext _objectContext;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";

        private string SelectedCategory;
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
            _objectContext = context.Get<ObjectContext>();
        }

        public JobCategoriesPage ClickJobCategory(string selectedCategory)
        {
            _objectContext.Replace("selectedCategory", selectedCategory);
            _formHelper.ClickElement(_pageHelper.GetLinkContains(JobCategoryList, selectedCategory));
            return this;
        }

        public JobProfilePage ClickJobProfile(int profileNo)
        {
            List<IWebElement> listOfJPs = _pageHelper.FindElements(listOfProfiles);
            _objectContext.Set("JCProfileSelected", _pageHelper.GetText(listOfJPs[profileNo - 1]));
            _formHelper.ClickElement(listOfJPs[profileNo-1]);
            return new JobProfilePage(_context);
        }

        public Homepage ClickHomeBreadcrumb()
        {
            _formHelper.ClickElement(HomeBreadcrumbLink);
            return new Homepage(_context);
        }

        public void VerifyCorrectJobCategoryPage()
        {
            SelectedCategory = _objectContext.Get("selectedCategory");
            _pageHelper.VerifyText(PageHeader, SelectedCategory).Should().BeTrue();
        }

        public void VerifySelectedCategoryNotDisplayed()
        {
            var listOfCategories = _pageHelper.FindElements(JobCategoryList);
            bool isCategoryDisplayed = true;

            foreach (var category in listOfCategories)
            {
                if (!category.Text.Contains(SelectedCategory))
                {
                    isCategoryDisplayed = false;
                }
            }

            isCategoryDisplayed.Should().BeFalse();
        }

        public void VerifyCorrectBreadcrumbDisplayed()
        {
            _pageHelper.VerifyText(Breadcrumb, "Home: Explore careers").Should().BeTrue();
            _pageHelper.VerifyText(Breadcrumb, SelectedCategory).Should().BeTrue();
        }

    }
}
