using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class FindACourseHomePage : BasePage
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        #endregion

        #region Page Elements
        protected override string PageTitle => "";
        private By Header => By.ClassName("govuk-heading-xl");
        #endregion

        public FindACourseHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyFindACourseHomepage()
        {
            _pageHelper.VerifyText(Header, "Find a course").Should().BeTrue();
        }

    }
}
