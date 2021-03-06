﻿using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class MatchYourSkillsToCareerHomePage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly AxeHelper _axeHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly MatchYourSkillsToCareerConfig _config;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private By ClickStartButton = By.Id("homeGovukStartButtonLinkStart");
        #endregion

        public MatchYourSkillsToCareerHomePage(ScenarioContext context): base(context)
        {
            _context = context;
            _axeHelper = context.Get<AxeHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetMatchYourSkillsToCareerConfig<MatchYourSkillsToCareerConfig>();
        }

        public MatchYourSkillsToCareerHomePage NavigatetoMYSTCHomePage()
        {
            _webDriver.Url = _config.BaseUrl + "/matchskills";
            //_axeHelper.AxeAnalyzer(_webDriver, _objectContext.GetFile());
            return this;
        }

        public WorkedPage ClickGoToMYSTC()
        {
            _formHelper.ClickElement(ClickStartButton);
            return new WorkedPage(_context);
        }


    }
}
