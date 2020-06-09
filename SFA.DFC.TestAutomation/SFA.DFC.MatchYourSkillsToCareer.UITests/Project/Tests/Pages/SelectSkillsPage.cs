using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
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
        private readonly By FirstSkill = By.Id("selectSkills-GovukCheckbox-http://data.europa.eu/esco/skill/74688c5d-2af1-4f7a-9d1c-00e808eaa1e6");
        private readonly By ButtonAdd = By.Id("selectSkillsGovukButtonAddtoskillslist");
        #endregion

        public SelectSkillsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _webDriver = context.GetWebDriver();
        }

        public SelectSkillsPage SelectASkill()
        {
            var checkboxes = _webDriver.FindElements(By.XPath("//*[@id='selectskills']/div"));   
            foreach (var checkbox in checkboxes)
            {
                checkbox.Click();
            }
            return this;
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
