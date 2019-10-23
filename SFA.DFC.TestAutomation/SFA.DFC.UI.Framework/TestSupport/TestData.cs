using CsvHelper.Configuration.Attributes;

namespace SFA.DFC.UI.Framework.TestSupport
{
    public class TestData
    {
        [Name("Key")]
        public string Key { get; set; }

        [Name("Value")]
        public string Value { get; set; }
    }
}
