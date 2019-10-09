﻿using OpenQA.Selenium.Remote;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly string _directory;
        private readonly string _scenarioTitle;

        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _directory = _objectContext.GetDirectory();
            _scenarioTitle = _context.ScenarioInfo.Title;
        }

        [AfterScenario(Order = 11)]

        public void TakeScreenshotOnFailure()
        {
            var options = _context.Get<FrameworkConfig>();
            var browser = _objectContext.GetBrowser();
            if (_context.TestError != null)
            {
                switch (true)
                {
                    case bool _ when browser.IsCloudExecution():
                        RemoteWebDriver remoteWebDriver = (RemoteWebDriver)_context.GetWebDriver();
                        BrowserStackTeardown.MarkTestAsFailed(remoteWebDriver, options.BrowserStackSetting, _directory, _scenarioTitle, _context.TestError.Message);
                        break;
                    default:
                        var webDriver = _context.GetWebDriver();
                        ScreenshotHelper.TakeScreenShot(webDriver, _directory, _scenarioTitle, true);
                        break;
                }
            }
        }
    }
}
