using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
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
        protected override string PageTitle => "Help using Explore careers";

        public HelpPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}
