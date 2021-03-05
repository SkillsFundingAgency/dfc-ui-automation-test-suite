using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.Generic;
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
        private By SHCPageTitle = By.CssSelector(".govuk-heading-xl");
        private By DownloadReportButton = By.CssSelector("#skillsListForm .govuk-grid-column-full .govuk-button");
        private List<IWebElement> DocTypeList => _pageHelper.FindElements(By.Name("DownloadType"));
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
            _pageHelper.WaitForElementToContainText(SHCPageTitle, "Skills Health Check");
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
            var docToLower = docType.ToLowerInvariant();
            var docExt = docToLower == "word" ? "docx" : docToLower;

            object response = ((IJavaScriptExecutor)_webDriver).ExecuteAsyncScript(
               "var url = arguments[0];" +
               "var callback = arguments[arguments.length - 1];" +
               $"var params = 'DownLoadType={docToLower}';" +
               "var xhr = new XMLHttpRequest();" +
               "xhr.open('POST', url , true);" +
               "xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');" +
               "xhr.onreadystatechange = function() {" +
               "  if (xhr.readyState == 4) {" +
               "    callback(xhr.getAllResponseHeaders());" +
               "  }" +
               "};" +
               "xhr.send(params);", "/skills-health-check/your-assessments/DownloadDocument/");

            response.ToString().Should().Contain($"content-type: application/{docExt}");

        }

    }
}

