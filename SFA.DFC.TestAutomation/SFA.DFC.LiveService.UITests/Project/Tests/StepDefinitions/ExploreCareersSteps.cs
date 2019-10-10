using OpenQA.Selenium;
using SFA.DFC.LiveService.UITests.Project.Tests.Pages;
using SFA.DFC.LiveService.UITests.Project.Tests.Pages.ExploreCareers;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.LiveService.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExploreCareersSteps
    {
        private readonly ScenarioContext _context;
        private ExploreCareersHomepage exploreCareersHomepage;
        private ExploreCareersJobCategoryPage exploreCareersJobCategoryPage;

        public ExploreCareersSteps(ScenarioContext context)
        {
            _context = context;
        }

        #region Whens
        [When(@"I click the category '(.*)'")]
        public void WhenIClickTheCategory(string selectedCategory)
        {
            exploreCareersJobCategoryPage = new ExploreCareersHomepage(_context)
                .SelectJobCategory(selectedCategory);
            _context.Add("selectedCategory", selectedCategory);
        }

        [When(@"I select another category '(.*)'")]
        public void WhenISelectAnotherCategory(string selectedCategory)
        {
            exploreCareersJobCategoryPage
                .SelectJobCategory(selectedCategory);
            _context.Remove("selectedCategory");
            _context.Add("selectedCategory", selectedCategory);
        }


        #endregion

        #region Thens
        [Then(@"I am redirected to the selected Job Category page")]
        public void ThenIAmRedirectedToTheSelectedJobCategoryPage()
        {
            exploreCareersJobCategoryPage
                .VerifyCorrectJobCategoryPage();
        }

        [Then(@"the category is not listed in the displayed categories")]
        public void ThenTheCategoryIsNotListedInTheDisplayedCategories()
        {
            exploreCareersJobCategoryPage
                .VerifySelectedCategoryNotDisplayed();
        }

        #endregion

    }
}
