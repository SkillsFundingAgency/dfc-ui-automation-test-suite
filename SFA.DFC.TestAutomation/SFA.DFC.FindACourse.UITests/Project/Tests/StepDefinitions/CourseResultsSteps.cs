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
               
        private CourseDetailsPage courseDetailsPage;
        private CourseResultsPage courseResultsPage;

        public CourseResultsSteps(ScenarioContext context)
        {
            _context = context;
            courseResultsPage= new CourseResultsPage(_context);                   
        }
      
        [When(@"I click the course no '(.*)'")]
        public void WhenIClickTheCourseNo(int courseNo)
        {
            courseDetailsPage = courseResultsPage.ClickSelectedCourse(courseNo);
        }
        [Then(@"I should be taken to the course details page")]
        public void ThenIShouldBeTakenToTheCourseDetailsPage()
        {
            courseDetailsPage.VerifyCourseHeader();
        }

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
        [Then(@"the results for the new provider and location should be displayed")]
        public void ThenTheResultsForTheNewProviderAndLocationShouldBeDisplayed()
        {
            courseResultsPage.VerifyFilters();
        }
        [When(@"an error message should be returned ""(.*)""")]
        public void WhenAnErrorMessageShouldBeReturned(string errmsg)
        {
            courseResultsPage.VerifyErrorMessage(errmsg);
        }
        
        [Then(@"the results for the course should be listed")]
        public void ThenTheResultsForTheCourseShouldBeListed()
        {
            courseResultsPage.VerifyResults();
        }
        [When(@"I apply the filter '(.*)'")]
        public void WhenIApplyTheFilter(string filter)
        {
            courseResultsPage.SelectFilter(filter);
        }
        [Then(@"the filter '(.*)' is selected")]
        public void ThenTheFilterIsSelected(string filter)
        {
            courseResultsPage.VerifyIsCourseFilterSelected(filter);
        }
       

    }
}
