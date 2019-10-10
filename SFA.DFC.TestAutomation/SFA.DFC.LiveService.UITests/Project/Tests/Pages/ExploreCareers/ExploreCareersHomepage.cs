using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DFC.LiveService.UITests.Project.Tests.Pages.ExploreCareers;

namespace SFA.DFC.LiveService.UITests.Project.Tests.Pages
{
    public class ExploreCareersHomepage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Elements
        private By JobCategoryList => By.CssSelector(".homepage-jobcategories li a");
        #endregion
        protected override string PageTitle => "";

        public ExploreCareersHomepage (ScenarioContext context): base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ExploreCareersJobCategoryPage SelectJobCategory(string selectedCategory)
        {
            _formHelper.ClickElement(_pageHelper.SelectElementFromList(JobCategoryList, selectedCategory));
            return new ExploreCareersJobCategoryPage(_context);
        }
    }
}
