using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.ExploreCareers.UITests.Project.Tests.Pages
{
    public class JobProfileFeedbackThankYouPage : BasePage
    {
        #region Helpers
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageHelper;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By ThankYouMessage => By.ClassName("headig-small");

        #endregion
        public JobProfileFeedbackThankYouPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
        }

        public void VerifyThankYouMessage()
        {
            _pageHelper.VerifyText(ThankYouMessage, "Thanks").Should().BeTrue();
        }

    }
}
