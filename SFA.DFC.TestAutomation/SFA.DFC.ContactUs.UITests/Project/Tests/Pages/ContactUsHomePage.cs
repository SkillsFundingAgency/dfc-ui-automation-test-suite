using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class ContactUsHomePage : BasePage 
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By ContactusPageTitle = By.CssSelector(".govuk-heading-xl");
        private By OnlineMessageLink = By.LinkText("Send us an online message");
        
        #endregion
        public ContactUsHomePage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            VerifyContactusPage();
        }
        public void VerifyContactusPage()
        {
            _pageHelper.VerifyPage(ContactusPageTitle, "Contact us");
        }

        public SelectAnOptionPage ClickOnlineMessageLink()
        {
            _formHelper.ClickElement(OnlineMessageLink);
            return new SelectAnOptionPage(_context);
        }
    }
}
