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
        public void WhenIClickTheCategoryHealthcare(string selectedCategory)
        {
            exploreCareersJobCategoryPage = new ExploreCareersHomepage(_context)
                .SelectJobCategory(selectedCategory);
            _context.Add("selectedCategory", selectedCategory);
        }

        #endregion

        #region Thens

        #endregion

    }
}
