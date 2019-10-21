using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FaCLandingSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        

        private FACHomePage fACHomePage;
        private CourseSearchPage courseSearchPage;
        public FaCLandingSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            //_webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();    
        }
     
        [When(@"I have searched for a  course '(.*)'")]
        public void WhenIHaveSearchedForACourse(string strCourseName)
        {
            fACHomePage = new FACHomePage(_context);
            fACHomePage.EnterSearchCriteria(strCourseName);
            _objectContext.Set("CourseName", strCourseName);
        }
        [When(@"I click the Find a course button")]
        public void WhenIClickTheFindACourseButton()
        {
           courseSearchPage= fACHomePage.ClickFindACourse();
        }
       
        [When(@"I have entered a provider '(.*)' and location '(.*)'")]
        public void WhenIHaveEnteredAProviderAndLocation(string strProv, string strLocation)
        {
            fACHomePage.EnterProvider(strProv);
            _context.Add("ProvName", strProv);
            fACHomePage.EnterLocation(strLocation);
            _context.Add("LocationName", strLocation);
        }  
    }



}
