using Microsoft.Extensions.Configuration;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigurationRoot _configurationRoot;

        private readonly IConfigSection _configSection;

        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configurationRoot = Configurator.GetConfig();
            _configSection = new ConfigSection(_configurationRoot);
        }

        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var configuration = new FrameworkConfig
            {
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                TakeEveryPageScreenShot = TestsExecutionInVsts()
            };

            _context.Set(configuration);
        }

        private bool TestsExecutionInVsts()
        {
            return !string.IsNullOrEmpty(_configurationRoot.GetAgentMachineName());
        }
    }
}
