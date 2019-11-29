﻿using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class HelpersSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly FrameworkConfig _config;

        public HelpersSetup(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.Get<FrameworkConfig>();
        }

        [BeforeScenario(Order = 4)]
        public void SetUpHelpers()
        {
            var webDriver = _context.GetWebDriver();
            var webDriverwaitHelper = new WebDriverWaitHelper(webDriver, _config.TimeOutConfig);
            var retryHelper = new RetryHelper(webDriver);
            _context.Set(new SqlDatabaseConnectionHelper());
            _context.Set(new PageInteractionHelper(webDriver, webDriverwaitHelper, retryHelper));
            _context.Set(new AxeHelper(webDriver));
            var formCompletionHelper = new FormCompletionHelper(webDriver, webDriverwaitHelper, retryHelper);
            _context.Set(formCompletionHelper);
            _context.Set(new TableRowHelper(webDriver, formCompletionHelper));
            _context.Set(new JavaScriptHelper(webDriver));
            _context.Set(new RandomDataGenerator());
            _context.Set(new RegexHelper());
            _context.Set(new AssertHelper());
            _context.Set(new ScreenShotTitleGenerator(0));
        }
    }
}
