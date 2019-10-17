using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;
using FluentAssertions;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApplyFiltersForCourseSearchResultsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private CourseSearchPage courseSearchPage;        

        public ApplyFiltersForCourseSearchResultsSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
            courseSearchPage = new CourseSearchPage(_context);
        }       
        [When(@"I apply the filter hours '(.*)', type '(.*)' and start date '(.*)'")]
        public void WhenIApplyTheFilterHoursTypeAndStartDate(string hours, string type, string date)
        {            
            courseSearchPage.SelectFilter(hours);
            courseSearchPage.SelectFilter(type);
            courseSearchPage.SelectFilter(date);            
        }
        [Then(@"the following filters '(.*)', '(.*)', '(.*)' are selected")]
        public void ThenTheFollowingFiltersAreSelected(string hours, string type, string date)
        {
            courseSearchPage.IsCourseFilterSelected(hours).Should().BeTrue();
            courseSearchPage.IsCourseFilterSelected(type).Should().BeTrue();
            courseSearchPage.IsCourseFilterSelected(date).Should().BeTrue();
        }

    }
}
