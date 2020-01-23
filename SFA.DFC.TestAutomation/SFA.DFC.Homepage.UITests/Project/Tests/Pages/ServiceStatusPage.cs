using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
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
            pageHelper.VerifyText(PageHeader, "Service Status").Should().BeTrue();
            return this;
        }

        public ServiceStatusPage VerifyAllServicesAreRunning()
        {
            ServicesList.Count.Should().Be(5);
            return this;
        }
    }
}
