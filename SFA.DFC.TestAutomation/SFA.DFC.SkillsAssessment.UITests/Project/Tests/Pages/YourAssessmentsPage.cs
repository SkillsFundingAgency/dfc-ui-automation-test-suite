﻿using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DFC.SkillsAssessment.UITests.Project.Tests.Pages
{
    public class YourAssessmentsPage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly SkillsAssessmentConfig _config;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By SHCPageTitle = By.CssSelector(".heading-xlarge");
        private By DownloadReportButton = By.CssSelector(".button");
        private List<IWebElement> DocTypeList => _pageHelper.FindElements(By.Id("DownloadType"));
        #endregion
        public YourAssessmentsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetSkillsAssessmentConfig<SkillsAssessmentConfig>();
        }
        public AssessmentTypeHomePage NavigatetoAssessmentHomePage(string assessType, string assessTitle)
        {
            _objectContext.Set("AssessType", assessType);
            _objectContext.Set("AssessTitle", assessTitle);
            _webDriver.Url = _config.BaseUrl + "/skills-assessment/skills-health-check/question?assessmentType=" + assessType;
            return new AssessmentTypeHomePage(_context);
        }
        public void VerifyPageTitle()
        {
            _pageHelper.VerifyText(SHCPageTitle, "Skills Health Check");
        }
        public void DownloadReport()
        {
            _formHelper.ClickElement(DownloadReportButton);
            VerifyIFFileDownloaded(_objectContext.Get("DocFormat"));
        }
        public void ChooseDocType(string docType)
        {
            
            var filteredText = docType.Replace(" ", string.Empty).ToLower();
            _objectContext.Replace("DocFormat", filteredText);
            foreach (var button in DocTypeList)
            {
                var buttonText = button.GetAttribute("value").Replace(" ", string.Empty).ToLower();
                if (buttonText.Contains(filteredText))
                {
                    button.Click();
                }
            }
        }
        public void VerifyIFFileDownloaded(string docType)
        {
            var docExt = docType =="word" ? "docx" : docType;
            var FileName = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\Skills Health Check." + docExt;
            if (!File.Exists(FileName))
            { 
                throw new Exception("File Not Found");
            }                      
        }

    }
}
