﻿using OpenQA.Selenium;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _frameworkConfig;
        private readonly IWebDriver _webDriver;
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private readonly string _directory;
        #endregion

        protected virtual By PageHeader => By.CssSelector(".heading-xlarge");

        protected abstract string PageTitle { get; }

        public BasePage(ScenarioContext context)
        {
            _context = context;
            _frameworkConfig = context.Get<FrameworkConfig>();
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();
            _directory = context.Get<ObjectContext>().GetDirectory();
        }

        protected bool VerifyPage()
        {
            if (_frameworkConfig.TakeEveryPageScreenShot)
            {
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, _screenShotTitleGenerator.GetNextCount());
            }

            return _pageInteractionHelper.VerifyPage(PageHeader, PageTitle);
        }

        protected bool VerifyPage(Action beforeAction)
        {
            return _pageInteractionHelper.VerifyPage(PageHeader, PageTitle, beforeAction);
        }
    }
}
