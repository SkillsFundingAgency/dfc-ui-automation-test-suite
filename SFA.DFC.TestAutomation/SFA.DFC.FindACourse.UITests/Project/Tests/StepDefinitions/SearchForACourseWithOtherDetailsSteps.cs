using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SearchForACourseWithOtherDetailsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;

        private FACHomePage fACHomePage;
        private CourseSearchPage courseSearchPage;
        public SearchForACourseWithOtherDetailsSteps(ScenarioContext context)
        {

            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }
        
        [Given(@"I have entered a provider '(.*)' and location '(.*)'")]
        public void GivenIHaveEnteredAProviderAndLocation(string strProv, string strLocation)
        {
            fACHomePage = new FACHomePage(_context).EnterProvider(strProv);
            _context.Add("ProvName", strProv);
            fACHomePage = new FACHomePage(_context).EnterLocation(strLocation);
            _context.Add("LocationName", strProv);
        }
        
        [When(@"I change the provider '(.*)' and location '(.*)'")]
        public void WhenIChangeTheProviderAndLocation(string strProv1, string strLocation1)
        {
            _context.Remove("ProvName");
            _context.Add("ProvName", strProv1);
            fACHomePage.EnterProvider(strProv1);
            _context.Remove("LocationName");
            _context.Add("LocationName", strLocation1);
            fACHomePage.EnterLocation(strLocation1);
        }
        
        [Then(@"the results for the new provider and location should be displayed")]
        public void ThenTheResultsForTheNewProviderAndLocationShouldBeDisplayed()
        {
            courseSearchPage = new CourseSearchPage(_context);
        }
        [When(@"I have clicked the Apply Filter button")]
        public void WhenIHaveClickedTheApplyFilterButton()
        {
            courseSearchPage = new CourseSearchPage(_context);
            courseSearchPage.ClickApplyFilter();
        }

    }
}
