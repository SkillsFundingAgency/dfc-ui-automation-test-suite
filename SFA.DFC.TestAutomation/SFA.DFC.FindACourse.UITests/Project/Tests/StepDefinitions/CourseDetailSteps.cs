using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
   public class CourseDetailSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        #endregion
        #region Pages
        private CourseDetailsPage courseDetailsPage;
        #endregion 
        public CourseDetailSteps(ScenarioContext context)
        {
            _context = context;           
            courseDetailsPage = new CourseDetailsPage(_context);
        }
        #region Thens
        [Then(@"I should be able to validate the links")]
        public void ThenIShouldBeAbleToValidateTheLinks()
        {
            courseDetailsPage.VerifyLinks();
        }
      
        [Then(@"I should be able to click the links to access the information")]
        public void ThenIShouldBeAbleToClickTheLinksToAccessTheInformation()
        {
            courseDetailsPage.VerifyIfLinksCanBeClicked();
        }
        #endregion
    }

}
