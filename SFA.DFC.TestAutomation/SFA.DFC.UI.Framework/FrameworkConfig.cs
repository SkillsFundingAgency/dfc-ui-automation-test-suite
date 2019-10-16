using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DFC.UI.Framework
{
    public class FrameworkConfig
    {
        public TimeOutConfig TimeOutConfig { get; set; }

        public BrowserStackSetting BrowserStackSetting { get; set; }

        public bool TakeEveryPageScreenShot { get; set; }
    }
}
