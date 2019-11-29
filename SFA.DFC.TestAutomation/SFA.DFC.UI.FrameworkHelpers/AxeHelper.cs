using OpenQA.Selenium;
using System.IO;
using Selenium.Axe;

namespace SFA.DFC.UI.FrameworkHelpers
{
    public class AxeHelper
    {
        private readonly IWebDriver _webDriver;

        public AxeHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void LogResult(IWebDriver webDriver, string axeFile)
        {

            using (StreamWriter sw = new StreamWriter(axeFile, append: true))
            {

                AxeResult results = _webDriver.Analyze();

                if (results.Passes.Length > 0)
                {
                    sw.WriteLine(_webDriver.Title);
                    sw.WriteLine("======================================================");
                    sw.WriteLine(_webDriver.Url.ToLower());
                    sw.WriteLine("\n");

                    if (results.Violations.Length > 0)
                    {
                        foreach (var violation in results.Violations)
                        {
                            sw.WriteLine("Id: " + violation.Id);
                            sw.WriteLine("Description: " + violation.Description);
                            sw.WriteLine("Impact: " + violation.Impact);
                            sw.WriteLine("Help: " + violation.Help);
                            sw.WriteLine("HelpURL: " + violation.HelpUrl);
                            foreach (var node in violation.Nodes)
                            {
                                sw.WriteLine(node.Html);
                                sw.WriteLine("\n");
                            }
                        }
                    }
                }
            }
        }

    }
}
