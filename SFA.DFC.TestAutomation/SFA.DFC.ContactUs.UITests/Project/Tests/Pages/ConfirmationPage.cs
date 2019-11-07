using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
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
            _pageHelper.VerifyText(ConfirmPageTitle, "Thank you for contacting us");
        }
    }
}
