﻿using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class ConfirmRemoveSkillsPage : BasePage 
    {
        #region Helpers
        private readonly IWebDriver _webDriver;
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By RemoveButton = By.Id("confirmRemoveGovukButtonRemoveSelectedSkills");
        private readonly By CancelButton = By.Id("confirmRemoveGovukButtonLinkCancel");
        #endregion

        public ConfirmRemoveSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _webDriver = context.GetWebDriver();
        }


        public RemovedPage ClickRemove()
        {
            _formHelper.ClickElement(RemoveButton);
            return new RemovedPage(_context);
        }

        public SkillsListPage ClickCancel()
        {
            _formHelper.ClickElement(CancelButton);
            return new SkillsListPage(_context);
        }
    }
}
