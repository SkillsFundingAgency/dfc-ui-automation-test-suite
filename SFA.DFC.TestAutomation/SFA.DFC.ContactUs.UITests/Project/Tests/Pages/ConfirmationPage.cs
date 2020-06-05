using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class ConfirmationPage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By ConfirmPageTitle = By.ClassName("govuk-heading-xl");

        #endregion
        public ConfirmationPage(ScenarioContext context) : base(context)
        {
           _pageHelper = context.Get<PageInteractionHelper>();           
        }
        public void VerifyConfirmPage()
        {
            _pageHelper.VerifyText(ConfirmPageTitle, "Thank you for contacting us").Should().BeTrue();
        }
    }
}
