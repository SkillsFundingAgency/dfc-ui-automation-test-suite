using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class JobCategorySteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private Homepage homepage;
        private JobCategoriesPage jobCategoryPage;
        private JobProfilePage jobProfilePage;

        #endregion
        public JobCategorySteps(ScenarioContext context)
        {
            _context = context;
            homepage = new Homepage(_context);
            jobCategoryPage = new JobCategoriesPage(_context);
        }

        #region Givens
        [Given(@"I navigate to the category '(.*)'")]
        public void GivenINavigateToTheCategory(string category)
        {
            jobCategoryPage = homepage
                .NavigateToHomepage()
                .ClickJobCategory(category);
        }
        #endregion
        #region Whens
        [When(@"I click the category '(.*)'")]
        public void WhenIClickTheCategory(string selectedCategory)
        {
            jobCategoryPage = homepage
                .ClickJobCategory(selectedCategory);
        }

        [When(@"I select another category '(.*)'")]
        public void WhenISelectAnotherCategory(string selectedCategory)
        {
            jobCategoryPage
                .ClickJobCategory(selectedCategory);
        }

        [When(@"I select profile no '(.*)' in the list")]
        public void WhenISelectProfileNoInTheList(int profileNo)
        {
            jobProfilePage = jobCategoryPage
                .ClickJobProfile(profileNo);
        }


        #endregion

        #region Thens
        [Then(@"I am redirected to the selected Job Category page")]
        public void ThenIAmRedirectedToTheSelectedJobCategoryPage()
        {
            jobCategoryPage
                .VerifyCorrectJobCategoryPage();
        }

        [Then(@"the category is not listed in the displayed categories")]
        public void ThenTheCategoryIsNotListedInTheDisplayedCategories()
        {
            jobCategoryPage
                .VerifySelectedCategoryNotDisplayed();
        }

        [Then(@"the correct breacrumb is displayed")]
        public void ThenTheCorrectBreacrumbIsDisplayed()
        {
            jobCategoryPage
                .VerifyCorrectBreadcrumbDisplayed();
        }

        #endregion
    }
}
