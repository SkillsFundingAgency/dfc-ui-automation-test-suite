using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApplyFiltersForCourseSearchResultsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private FACHomePage fACHomePage;
        private CourseSearchPage courseSearchPage;

        

        public ApplyFiltersForCourseSearchResultsSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }
       
        [Then(@"the following filters Full time, Online, Today are selected")]
        public void ThenTheFollowingFiltersFullTimeOnlineTodayAreSelected()
        {
            courseSearchPage = new CourseSearchPage(_context);
        }
        [When(@"I apply the filter hours '(.*)', type '(.*)' and start date '(.*)'")]
        public void WhenIApplyTheFilterHoursTypeAndStartDate(string hours, string type, string date)
        {
            courseSearchPage = new CourseSearchPage(_context);
            courseSearchPage.SelectCourseHours(hours);
            courseSearchPage.SelectCourseType(type);
            courseSearchPage.SelectStartDate(date);
        }
        [Then(@"the following filters Full time, Online, From Today are selected")]
        public void ThenTheFollowingFiltersFullTimeOnlineFromTodayAreSelected()
        {
            courseSearchPage = new CourseSearchPage(_context);
        }


    }
}
