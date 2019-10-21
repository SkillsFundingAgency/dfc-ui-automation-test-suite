using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;
using FluentAssertions;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CourseResultsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;

        private CourseDetailsPage courseDetailsPage;
        private CourseSearchPage courseSearchPage;
        public CourseResultsSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
            courseSearchPage = new CourseSearchPage(_context);
        }

        [When(@"I click the first course")]
        public void WhenIClickTheFirstCourse()
        {
            courseDetailsPage = courseSearchPage.ClickSelectedCourse();
        }
        [Then(@"I should be taken to the course details page")]
        public void ThenIShouldBeTakenToTheCourseDetailsPage()
        {
            courseDetailsPage.VerifyCourseHeader(_objectContext.Get("CourseDetail"));
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
        [When(@"I change the provider '(.*)' and location '(.*)'")]
        public void WhenIChangeTheProviderAndLocation(string strNewProv, string strNewLocation)
        {
            _objectContext.Replace("ProvName", strNewProv);
            courseSearchPage.EnterProvider(strNewProv);
            _objectContext.Replace("LocationName", strNewLocation);
            courseSearchPage.EnterLocation(strNewLocation);
        }
        [When(@"I have clicked the Apply Filter button")]
        public void WhenIHaveClickedTheApplyFilterButton()
        {
           courseSearchPage.ClickApplyFilter();
        }        
        [Then(@"the results for the new provider and location should be displayed")]
        public void ThenTheResultsForTheNewProviderAndLocationShouldBeDisplayed()
        {
            courseSearchPage.ValidateFilters(_objectContext.Get("ProvName"), _objectContext.Get("LocationName"));
        }
        [Then(@"an error message should be returned ""(.*)""")]
        public void ThenAnErrorMessageShouldBeReturned(string errmsg)
        {
            courseSearchPage.ValidateErrorMessage(errmsg);
        }
        [Then(@"the results for the course should be listed")]
        public void ThenTheResultsForTheCourseShouldBeListed()
          {
              string selectedCourseText = _objectContext.Get("CourseName");
              courseSearchPage.ValidateResults(selectedCourseText);
          }

    }
}
