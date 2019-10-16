using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.LiveService.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {

        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;

        public CommonSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"I navigate to the explore careers homepage")]
        public void GivenINavigateToTheExploreCareersHomepage()
        {
            var url = _config.BaseUrl + "/explore-careers";
            _webDriver.Url = url;
        }

    }
}
