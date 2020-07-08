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
            ServicesList.Count.Should().Be(6);
            return this;
        }
    }
}
