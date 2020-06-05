using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;
using FluentAssertions;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CourseResultsSteps
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private CourseDetailsPage courseDetailsPage;
        private CourseResultsPage courseResultsPage;
        private FACHomePage facHomePage;
        #endregion 
        public CourseResultsSteps(ScenarioContext context)
        {
            _context = context;
            courseResultsPage = new CourseResultsPage(_context);  
            facHomePage = new FACHomePage(_context);
        }
        #region Givens
       [Given(@"I have searched for '(.*)'")]
        public void GivenIHaveSearchedFor(string CourseName)
        {
            courseResultsPage = facHomePage
                  .NavigateToFACHomepage()
                  .EnterSearchCriteria(CourseName)
                  .ClickFindACourse();
        }
        [Given(@"I have searched for (.*) and applied filters for provider (.*) and location (.*)")]
        public void GivenIHaveSearchedForAndAppliedFiltersForProviderAndLocation(string CourseName, string Provider, string Location)
        {
            courseResultsPage = facHomePage
                 .NavigateToFACHomepage()
                 .EnterSearchCriteria(CourseName)
                 .EnterProvider(Provider)
                 .EnterLocation(Location)
                 .ClickFindACourse();
        }
        #endregion
        #region Whens
        [When(@"I change the provider '(.*)' and location '(.*)'")]
        public void WhenIChangeTheProviderAndLocation(string strNewProv, string strNewLocation)
        {
            courseResultsPage.EnterProvider(strNewProv);
            courseResultsPage.EnterLocation(strNewLocation);
        }       
        [When(@"I have clicked the Apply Filter button")]
        public void WhenIHaveClickedTheApplyFilterButton()
        {
            courseResultsPage.ClickApplyFilter();
        }
        [When(@"I click the course no '(.*)'")]
        public void WhenIClickTheCourseNo(int courseNo)
        {
            courseDetailsPage = courseResultsPage.ClickSelectedCourse(courseNo);
        }
        [When(@"I apply the filter '(.*)'")]
        public void WhenIApplyTheFilter(string filter)
        {
            courseResultsPage.SelectFilter(filter);
        }
        #endregion
        #region Thens
        [Then(@"I should be taken to the course details page")]
        public void ThenIShouldBeTakenToTheCourseDetailsPage()
        {
            courseDetailsPage.VerifyCourseHeader();
        }
        [Then(@"I should be able to view the results")]
        public void ThenIShouldBeAbleToViewTheResults()
        {
            courseResultsPage.VerifyResults();
        }
        [Then(@"the results for the new provider and location should be displayed")]
        public void ThenTheResultsForTheNewProviderAndLocationShouldBeDisplayed()
        {
            courseResultsPage.VerifyFilters();
        }        
        [Then(@"an error message should be returned")]
        public void ThenAnErrorMessageShouldBeReturned()
        {
            courseResultsPage.VerifyErrorMessage();
        }
        [Then(@"the results for the course should be listed")]
        public void ThenTheResultsForTheCourseShouldBeListed()
        {
            courseResultsPage.VerifyResults();
        }            
        [Then(@"the filter '(.*)' is selected")]
        public void ThenTheFilterIsSelected(string filter)
        {
            courseResultsPage.VerifyIsCourseFilterSelected(filter);
        }
        #endregion 
    }
}
