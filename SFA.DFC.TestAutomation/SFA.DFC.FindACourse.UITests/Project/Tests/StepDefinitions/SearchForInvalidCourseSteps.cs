using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SearchForInvalidCourseSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;


        private FACHomePage fACHomePage;
        private CourseSearchPage courseSearchPage;
        
        public SearchForInvalidCourseSteps (ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }
        [Given(@"I have searched for a Invalid course '(.*)'")]
        public void GivenIHaveSearchedForAInvalidCourse(string coursename)
        {
            fACHomePage = new FACHomePage(_context).EnterSearchCriteria(coursename);
        }
        
        [Then(@"an error message should be returned")]
        public void ThenAnErrorMessageShouldBeReturned()
        {
            courseSearchPage = new CourseSearchPage(_context).ValidateErrorMessage("We didn't find any results for 'NoCourse' with the active filters you've applied. Try searching again.");
        }
    }
}
