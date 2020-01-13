using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class RemoveSkillsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By FirstSkill = By.Id("firstskill");
        private readonly By RemoveButton = By.Id("remove");
        #endregion

        public RemoveSkillsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public RemoveSkillsPage ClickFirstSkill()
        {
            _formHelper.ClickElement(FirstSkill);
            return this;
        }
        

        public SkillsListPage ClickRemove()
        {
            _formHelper.SelectRadioButton(RemoveButton);
            return new SkillsListPage(_context);
        }
    }
}
