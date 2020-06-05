using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.Pages
{
    public class HelpPage : BasePage
    {
        private ScenarioContext _context;

        protected override By PageHeader => By.ClassName("heading-xlarge");
        protected override string PageTitle => "Help using the National Careers Service";

        public HelpPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}
