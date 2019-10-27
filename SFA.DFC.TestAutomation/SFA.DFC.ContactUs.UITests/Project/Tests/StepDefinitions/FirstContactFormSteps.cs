using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DFC.ContactUs.UITests.Project.Tests.Pages;

namespace SFA.DFC.ContactUs.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FirstContactFormSteps
    {
        private readonly ScenarioContext _context;
        #region Pages
        private FirstContactFormPage firstContactFormPage;
        private EnterDetailsPage enterDetailsPage;
        #endregion 
        public FirstContactFormSteps(ScenarioContext context)
        {
            _context = context;
            firstContactFormPage = new FirstContactFormPage(_context);
        }
        [When(@"I complete the first form with '(.*)' option and '(.*)' query")]
        public void WhenICompleteTheFirstFormWithOptionAndQuery(string option, string message)
        {
            firstContactFormPage
                .SelectQueryOption(option)
                .EnterQuery(message);
            enterDetailsPage = firstContactFormPage.ClickContinueFirstForm();
            enterDetailsPage.VerifyDetailsPage();
        }
    }
}
