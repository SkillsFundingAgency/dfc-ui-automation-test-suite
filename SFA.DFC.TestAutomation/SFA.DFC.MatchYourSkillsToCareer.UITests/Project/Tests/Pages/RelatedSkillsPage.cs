using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class RelatedSkillsPage : BasePage 
    {
        #region Helpers
        private readonly IWebDriver _webDriver;
        private readonly FormCompletionHelper _formHelper;
        private readonly PageInteractionHelper _pageHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private readonly By FirstSkill= By.Id("firstSkill");
        private readonly By ButtonAdd = By.Id("relatedSkillsGovukButtonAdd");
        #endregion

        public RelatedSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _webDriver = context.GetWebDriver();
        }

        public RelatedSkillsPage SelectASkill()
        {
            var checkboxes = _webDriver.FindElements(By.XPath("//*[@id='selectSkills']/div"));
            foreach (var checkbox in checkboxes)
            {
                checkbox.Click();
            }
            return this;
        }
                
        public SkillsListPage ClickAdd()
        {
            _formHelper.ClickElement(ButtonAdd);
            return new SkillsListPage(_context);
        }


    }
}
