using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.Pages
{
    public class InformationSourcesPage : BasePage
    {
        private ScenarioContext _context;

        protected override By PageHeader => By.ClassName("filter-results-heading");
        protected override string PageTitle => "Information sources";

        public InformationSourcesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}
