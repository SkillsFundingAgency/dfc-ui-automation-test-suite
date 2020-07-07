using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class RemoveSkillsPage : BasePage 
    {
        #region Helpers
        private readonly IWebDriver _webDriver;
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By FirstSkill = By.XPath("//*[contains(@id,'removeSkills-GovukCheckbox-http')]");
        private readonly By RemoveButton = By.Id("removeSkillsGovukButtonRemoveSelectSkills");
        private readonly By CancelButton = By.Id("removeSkillsGovukButtonLinkCancel");
        #endregion

        public RemoveSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _webDriver = context.GetWebDriver();
        }

        public RemoveSkillsPage ClickFirstSkill()
        {
            IWebElement checkbox = _webDriver.FindElement(FirstSkill);
            if (!checkbox.Selected)
                checkbox.Click();
            return this;
        }


        public SkillsListPage ClickRemove()
        {
            _formHelper.ClickElement(RemoveButton);
            return new SkillsListPage(_context);
        }

        public SkillsListPage ClickCancel()
        {
            _formHelper.ClickElement(CancelButton);
            return new SkillsListPage(_context);
        }
    }
}
