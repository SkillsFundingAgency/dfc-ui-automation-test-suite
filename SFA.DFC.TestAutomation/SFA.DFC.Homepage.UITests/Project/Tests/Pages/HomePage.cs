using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.Pages
{
    public class HomePage : BasePage
    {
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageHelper;
        private readonly IWebDriver _webDriver;
        private readonly HomepageConfig _config;
        private FormCompletionHelper _formHelper;
        protected override string PageTitle => "";
        private By PrivacyLink => By.PartialLinkText("Privacy and cookies");
        private By TermsLink => By.PartialLinkText("Terms and conditions");
        private By HelpLink => By.ClassName("govuk-footer__link");
        private By InfoSourcesLink => By.PartialLinkText("Information sources");

        public HomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _webDriver = context.GetWebDriver();
            _config = context.GetHomepageConfig<HomepageConfig>();
            _formHelper = context.Get<FormCompletionHelper>();
        }
        public HomePage NavigateToHomepage()
        {
            _webDriver.Url = _config.BaseUrl;
            return this;
        }
        public ServiceStatusPage NavigateToServiceStatusPage()
        {
            _webDriver.Url = _config.BaseUrl + "health/servicestatus";

            return new ServiceStatusPage(_context);
        }
        
        public PrivacyAndCookiesPage ClickPrivacyLink()
        {
            _formHelper.ClickElement(PrivacyLink);
            return new PrivacyAndCookiesPage(_context);
        }

        public TermsAndConditionsPage ClickTandCLink()
        {
            _formHelper.ClickElement(TermsLink);
            return new TermsAndConditionsPage(_context);
        }

        public HelpPage ClickHelpLink()
        {
            _pageHelper.GetLink(HelpLink, "Help").Click();
            return new HelpPage(_context);
        }

        public InformationSourcesPage ClickInfoSourcesLink()
        {
            _formHelper.ClickElement(InfoSourcesLink);
            return new InformationSourcesPage(_context);
        }
    }
}
