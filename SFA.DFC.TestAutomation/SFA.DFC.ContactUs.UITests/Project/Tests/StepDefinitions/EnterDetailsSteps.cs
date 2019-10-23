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
    public class EnterDetailsSteps
    {
        private readonly ScenarioContext _context;
        private EnterDetailsPage enterDetailsPage;
        private ConfirmationPage confirmationPage;
        

    public EnterDetailsSteps(ScenarioContext context)
        {
            _context = context;
            enterDetailsPage = new EnterDetailsPage(_context);
        }
        [When(@"I complete the form with details '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenICompleteTheFormWithDetails(string fname, string lname, string email, string confemail, string dob, string postcode)
        {
            enterDetailsPage.CompleteForm(fname, lname, email, confemail, dob, postcode);
        }
        [When(@"I select the terms and conditions")]
        public void WhenISelectTheTermsAndConditions()
        {
            enterDetailsPage.SelectTermsandConditions();
        }
        [When(@"I click send")]
        public void WhenIClickSend()
        {
            confirmationPage = enterDetailsPage.ClickSend();
        }
        [Then(@"I am directed to the confirmation page")]
        public void ThenIAmDirectedToTheConfirmationPage()
        {
            confirmationPage.VerifyConfirmPage();
        }
        [When(@"I complete the feedback form with details '(.*)','(.*)','(.*)','(.*)'")]
        public void WhenICompleteTheFeedbackFormWithDetails(string fname, string lname, string email, string confemail)
        {
            enterDetailsPage.CompleteFeedbackForm(fname, lname, email, confemail);
        }
        [When(@"I select '(.*)' for additional contact")]
        public void WhenISelectForAdditionalContact(string consent)
        {
            enterDetailsPage.SelectAddContact(consent);
        }
    }
}
