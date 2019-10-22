using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FACHomePageSteps
    {
        private readonly ScenarioContext _context;
        private FACHomePage fACHomePage;
        private CourseResultsPage courseResultsPage;
        public FACHomePageSteps(ScenarioContext context)
        {
            _context = context;
            fACHomePage = new FACHomePage(_context);
        }
      
         [When(@"I have entered '(.*)' in the course name")]
         public void WhenIHaveEnteredInTheCourseName(string strCourseName)
         {
             fACHomePage.EnterSearchCriteria(strCourseName);
         }

        [When(@"I click the Find a course button")]
        public void WhenIClickTheFindACourseButton()
        {
           courseResultsPage= fACHomePage.ClickFindACourse();
        }      
        [When(@"I have entered a provider '(.*)' and location '(.*)'")]
        public void WhenIHaveEnteredAProviderAndLocation(string strProv, string strLocation)
        {
            fACHomePage.EnterProvider(strProv);
            fACHomePage.EnterLocation(strLocation);            
        }

        [Given(@"I have searched for '(.*)'")]
        public void GivenIHaveSearchedFor(string strCourseName)
        {
            fACHomePage.EnterSearchCriteria(strCourseName);
            courseResultsPage = fACHomePage.ClickFindACourse();
            courseResultsPage.VerifyResults();
        }
        [Given(@"I have searched for a course '(.*)' for provider '(.*)' and location '(.*)'")]
        public void GivenIHaveSearchedForACourseForProviderAndLocation(string strCourseName, string provider, string location)
        {
            fACHomePage.EnterSearchCriteria(strCourseName);
            fACHomePage.EnterProvider(provider);
            fACHomePage.EnterLocation(location);
            courseResultsPage = fACHomePage.ClickFindACourse();
            courseResultsPage.VerifyResults();
        }
    }
}
