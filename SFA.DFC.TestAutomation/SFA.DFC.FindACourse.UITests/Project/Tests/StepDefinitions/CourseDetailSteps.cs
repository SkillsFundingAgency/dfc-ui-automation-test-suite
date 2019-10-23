using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
   public class CourseDetailSteps
    {
        private readonly ScenarioContext _context;
                 

        private CourseDetailsPage courseDetailsPage;
        public CourseDetailSteps(ScenarioContext context)
        {
            _context = context;           
            courseDetailsPage = new CourseDetailsPage(_context);
        }
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
    }

}
