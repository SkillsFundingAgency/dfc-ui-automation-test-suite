using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DFC.MatchYourSkillsToCareer.UITests.Project.Tests.Pages
{
    public class MatchResultsPage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;

        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private readonly By FirstResult = By.XPath("//*[@id='app-results-list--long']/div[1]/div/div[1]/h3/a");
        private readonly By CategoryFilter = By.Id("filtercategory");
        private readonly By StrengthFilter = By.Id("filterstrength");
        private readonly By ApplyButton = By.Id("apply");
        #endregion

        public MatchResultsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
        }

        public MatchDetailsPage ClickFirstResult()
        {
            _formHelper.ClickElement(FirstResult);
            return new MatchDetailsPage(_context);
        }
        
        public MatchDetailsPage ClickCategory()
        {
            _formHelper.SelectRadioButton(CategoryFilter);
            return new MatchDetailsPage(_context);
        }

        public MatchResultsPage ClickStrength()
        {
            _formHelper.SelectRadioButton(StrengthFilter);
            return this;
        }

        public MatchResultsPage ClickApply()
        {
            _formHelper.SelectRadioButton(ApplyButton);
            return this;
        }
    }
}
