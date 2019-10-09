﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SFA.DFC.UI.FrameworkHelpers
{
    public static class StringExtension
    {
        public static bool ContainsCompareCaseInsensitive(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            var index = text.IndexOf(value, stringComparison);
            return index >= 0;
        }

        public static bool CompareToIgnoreCase(this string strA, string strB)
        {
            return string.Compare(strA.RemoveSpace(), strB, true) == 0;
        }

        public static string RemoveSpace(this string s)
        {
            return Regex.Replace(s, @"\s+", string.Empty);
        }
    }
}
