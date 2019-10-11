using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class JobProfileSteps
    {

        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly ProjectConfig _config;

        public JobProfileSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
        }

        [Given(@"I navigate to the '(.*)' profile")]
        public void GivenINavigateToTheProfile(string jobProfile)
        {
            _webDriver.Url = _config.BaseUrl + "/job-profiles/" + jobProfile;
        }


    }
}
