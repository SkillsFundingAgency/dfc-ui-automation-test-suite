using DFC.TestAutomation.UI.Helpers;
using DFC.TestAutomation.UI.TestSupport;
using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.Pages
{
    public class ServiceStatusPage : BasePage
    {
        private ScenarioContext _context;
        private PageInteractionHelper pageHelper;
        protected override string PageTitle => "";
        private By PageHeader => By.ClassName("heading-medium");
        private List<IWebElement> ServicesList => pageHelper.FindElements(By.ClassName("list-service_Green"));

        public ServiceStatusPage(ScenarioContext context) : base(context)
        {
            _context = context;
            pageHelper = context.Get<PageInteractionHelper>();
        }

        public ServiceStatusPage VerifyServicePageHeader()
        {
            pageHelper.WaitForElementToContainText(PageHeader, "Service Status");
            pageHelper.VerifyText(PageHeader, "Service Status").Should().BeTrue();
            return this;
        }

        public ServiceStatusPage VerifyAllServicesAreRunning()
        {
            var list = pageHelper.FindElements(By.ClassName("list-service"));
            string innerHtml = list[0].GetAttribute("innerHTML");
            innerHtml.Should().NotContain("list-service_Red", "A service is unavailable");
            innerHtml.Should().NotContain("list-service_Amber", "A service is degraded");

            return this;
        }
    }
}
