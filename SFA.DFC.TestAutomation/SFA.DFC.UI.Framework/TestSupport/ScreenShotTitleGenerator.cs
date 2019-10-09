using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public class ScreenShotTitleGenerator
    {
        private int count;

        public ScreenShotTitleGenerator(int start)
        {
            count = start;
        }

        public string GetNextCount()
        {
            return (++count).ToString("D2");
        }
    }
}
