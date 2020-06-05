using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class ContactUsHomePage : BasePage 
    {
        #region Helpers
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ContactUs _config;
        private readonly IWebDriver _webDriver;
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By OnlineMessageLink = By.LinkText("Send us an online message");
        
        #endregion
        public ContactUsHomePage(ScenarioContext context): base(context)
        {
            _context = context;
            _formHelper = context.Get<FormCompletionHelper>();
            _webDriver = context.GetWebDriver();
            _config = context.GetContactUsConfig<ContactUs>();            
        }        
        public ContactUsHomePage  NavigateToContactUsPage()
        {
            _webDriver.Url = _config.BaseUrl + "/contact-us";
            return this;
        }
        public SelectAnOptionPage ClickOnlineMessageLink()
        {
            _formHelper.ClickElement(OnlineMessageLink);
            return new SelectAnOptionPage(_context);
        }
    }
}
