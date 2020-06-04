using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SFA.DFC.UI.FrameworkHelpers
{
    public class RegexHelper
    {
        private string TrimAnySpace(string value)
        {
            return Regex.Replace(value, @"\s", string.Empty);
        }
    }
}
