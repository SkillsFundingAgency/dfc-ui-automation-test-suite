using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.Pages
{
    public class PrivacyAndCookiesPage : BasePage
    {
        private ScenarioContext _context;

        protected override string PageTitle => "Privacy and cookies";

        public PrivacyAndCookiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}
