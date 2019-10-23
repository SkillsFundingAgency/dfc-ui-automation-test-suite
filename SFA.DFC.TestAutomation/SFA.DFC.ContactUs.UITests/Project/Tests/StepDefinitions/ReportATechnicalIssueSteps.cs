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
    public class ReportATechnicalIssueSteps
    {
        private readonly ScenarioContext _context;

        private ReportaTechnicalIssuePage reportaTechnicalIssuePage;
        private EnterDetailsPage enterDetailsPage;
        public ReportATechnicalIssueSteps(ScenarioContext context)
        {
            _context = context;
            reportaTechnicalIssuePage = new ReportaTechnicalIssuePage(_context);            
        }       
        [When(@"I complete the first technical form with '(.*)' query")]
        public void WhenICompleteTheFirstTechnicalFormWithQuery(string query)
        {
            reportaTechnicalIssuePage.EnterTechnicalQuery(query);
            enterDetailsPage = reportaTechnicalIssuePage.ClickContinueonTechnicalForm();
            enterDetailsPage.VerifyDetailsPage();
        }
    }
}
