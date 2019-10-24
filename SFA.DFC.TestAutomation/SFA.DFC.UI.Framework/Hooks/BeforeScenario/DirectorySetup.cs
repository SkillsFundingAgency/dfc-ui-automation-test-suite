using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DFC.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class DirectorySetup
    {
        private readonly ObjectContext _objectContext;
        public DirectorySetup(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 4)]
        public void SetUpDirectory()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory
             + "../../"
             + "Project\\Screenshots\\"
             + DateTime.Now.ToString("dd-MM-yyyy")
             + "\\";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            _objectContext.SetDirectory(directory);
        }
    }
}
