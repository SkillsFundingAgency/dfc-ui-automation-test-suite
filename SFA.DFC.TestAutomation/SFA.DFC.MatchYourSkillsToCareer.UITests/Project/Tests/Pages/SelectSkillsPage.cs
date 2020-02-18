using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class SelectSkillsPage : BasePage 
    {
        #region Helpers
        private readonly IWebDriver _webDriver;
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By Checkboxlist = By.CssSelector("#main-content > div > div > div > div > div > form > div > div > fieldset > div"); 
        private readonly By FirstSkill= By.CssSelector("#selectSkillsGovukCheckbox-74688c5d-2af1-4f7a-9d1c-00e808eaa1e6"); 
        private readonly By ButtonAdd = By.Id("selectSkillsGovukButtonAddtoskillslist");
        #endregion

        public SelectSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _webDriver = context.GetWebDriver();
        }

        public SelectSkillsPage SelectFirstSkill()
        {
            IWebElement checkbox = _webDriver.FindElement(FirstSkill);
            if (!checkbox.Selected)
            checkbox.Click();
            return this;
        }

        public SkillsListPage ClickAdd()
        {
            _formHelper.ClickElement(ButtonAdd);
            return new SkillsListPage(_context);
        }
    }
}
