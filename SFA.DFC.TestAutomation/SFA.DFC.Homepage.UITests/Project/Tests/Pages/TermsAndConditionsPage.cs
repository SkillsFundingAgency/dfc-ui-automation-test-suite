using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.Homepage.UITests.Project.Tests.Pages
{
    public class TermsAndConditionsPage : BasePage
    {
        private ScenarioContext _context;

        protected override string PageTitle => "Terms and conditions";

        public TermsAndConditionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}
