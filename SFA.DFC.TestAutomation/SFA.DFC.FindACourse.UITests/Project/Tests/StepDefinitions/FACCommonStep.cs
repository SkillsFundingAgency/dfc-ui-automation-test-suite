using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.DFC.FindACourse.UITests.Project.Tests.Pages;

namespace SFA.DFC.FindACourse.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FACCommonStep
    {
        
        private readonly FindACourseConfig _config;        
        private readonly IWebDriver _webDriver;
    public FACCommonStep(ScenarioContext context)
        {

            
            _config = context.GetFindACourseConfig<FindACourseConfig>();
            _webDriver = context.GetWebDriver();
           
        }
        [Given(@"I have navigated to Find a course page")]
        public void GivenIHaveNavigatedToFindACoursePage()
        {
            _webDriver.Url = _config.BaseUrl + "/find-a-course";
        }
    }
}
