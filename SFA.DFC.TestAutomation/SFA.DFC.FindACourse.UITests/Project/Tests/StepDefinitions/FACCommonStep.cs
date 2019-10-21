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
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
    public FACCommonStep(ScenarioContext context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }
        [Given(@"I have navigated to Find a course page")]
        public void GivenIHaveNavigatedToFindACoursePage()
        {
            _webDriver.Url = _config.BaseUrl + "/find-a-course";
        }
    }
}
