using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class MatchDetailsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By LearnMoreAboutThisJob = By.Id("learnmore");

        #endregion

        public MatchDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public MatchDetailsPage ClickLearnMoreAboutThisJob()
        {
            _formHelper.ClickElement(LearnMoreAboutThisJob);
            return this;
        }
        

    }
}
