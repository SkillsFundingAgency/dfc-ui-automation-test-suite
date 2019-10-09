using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class DisposeTeardown
    {
        private readonly ScenarioContext _context;

        public DisposeTeardown(ScenarioContext context)
        {
            _context = context;
        }

        [AfterScenario(Order = 12)]
        public void DisposeOnTestRun()
        {
            var WebDriver = _context.GetWebDriver();
            WebDriver?.Quit();
            WebDriver?.Dispose();
        }
    }
}
