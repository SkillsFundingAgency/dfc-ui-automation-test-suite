using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
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
        private readonly ScenarioContext _context;
        private Homepage homepage;
        private JobCategoriesPage jobCategoryPage;

        public JobCategorySteps(ScenarioContext context)
        {
            _context = context;
        }

        #region Whens
        [When(@"I click the category '(.*)'")]
        public void WhenIClickTheCategory(string selectedCategory)
        {
            jobCategoryPage = new Homepage(_context)
                .SelectJobCategory(selectedCategory);
            _context.Add("selectedCategory", selectedCategory);
        }

        [When(@"I select another category '(.*)'")]
        public void WhenISelectAnotherCategory(string selectedCategory)
        {
            jobCategoryPage
                .SelectJobCategory(selectedCategory);
            _context.Remove("selectedCategory");
            _context.Add("selectedCategory", selectedCategory);
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

        #endregion
    }
}
