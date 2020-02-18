using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class RelatedSkillsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By FirstSkill= By.Id("firstSkill");
        private readonly By ButtonAdd = By.Id("add");
        #endregion

        public RelatedSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();

        }

        public RelatedSkillsPage SelectFirstSkill()
        {
            _formHelper.SelectRadioButton(FirstSkill);
            return this;
        }
        
        public SkillsListPage ClickAdd()
        {
            _formHelper.ClickElement(ButtonAdd);
            return new SkillsListPage(_context);
        }


    }
}
