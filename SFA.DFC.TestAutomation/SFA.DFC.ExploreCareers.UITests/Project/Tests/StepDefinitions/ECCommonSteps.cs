using OpenQA.Selenium;
using SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ECCommonSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly IWebDriver _webDriver;

        public ECCommonSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
        }

        #region Givens
        [Given(@"I navigate to the explore careers homepage")]
        public void GivenINavigateToTheExploreCareersHomepage()
        {
            _webDriver.Url = _config.BaseUrl + "/explore-careers";
        }

        #endregion

        #region Whens

        #endregion

        #region Thens

        #endregion
    }
}
