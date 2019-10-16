﻿using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.FindACourse.UITests.Project
{
    [Binding]
    public class ProjectSpecificConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public ProjectSpecificConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<ProjectConfig>();
            _context.SetProjectConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.ReplaceBrowser(config.Browser);
        }
    }
}
