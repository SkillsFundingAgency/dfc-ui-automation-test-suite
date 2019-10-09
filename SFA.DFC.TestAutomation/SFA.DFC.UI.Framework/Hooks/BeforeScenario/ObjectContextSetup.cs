using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class ObjectContextSetup
    {
        private readonly ScenarioContext _context;

        public ObjectContextSetup(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 0)]
        public void SetObjectContext(ObjectContext objectContext) => _context.Set(objectContext);
    }
}
