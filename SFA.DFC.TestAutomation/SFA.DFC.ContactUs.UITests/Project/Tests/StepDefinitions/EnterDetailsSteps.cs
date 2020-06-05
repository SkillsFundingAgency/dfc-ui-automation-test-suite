using OpenQA.Selenium;
using DFC.TestAutomation.UI.TestSupport;
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
        #region Pages
        private EnterDetailsPage enterDetailsPage;
        private ConfirmationPage confirmationPage;
        #endregion 

        public EnterDetailsSteps(ScenarioContext context)
        {
            _context = context;
            enterDetailsPage = new EnterDetailsPage(_context);
        }
        #region Whens
        [When(@"I complete the form with details '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenICompleteTheFormWithDetails(string fname, string email, string confemail, string dob, string postcode)
        {
            enterDetailsPage.CompleteForm(fname, email, confemail, dob, postcode);
            enterDetailsPage.SelectTermsandConditions();
        }
        [When(@"I click send with nothing selected on the second form")]
       public void WhenIClickSendWithNothingSelectedOnTheSecondForm()
       {
            enterDetailsPage.ClickSendWithError();
        }
      
        [When(@"I click send")]
        public void WhenIClickSend()
        {
            confirmationPage = enterDetailsPage.ClickSend();
        }
        [When(@"I complete the feedback form with details '(.*)','(.*)','(.*)'")]
        public void WhenICompleteTheFeedbackFormWithDetails(string fname, string email, string confemail)
        {
            enterDetailsPage.CompleteFeedbackForm(fname, email, confemail);
            enterDetailsPage.SelectTermsandConditions();
        }

        [When(@"I select '(.*)' for additional contact")]
        public void WhenISelectForAdditionalContact(string consent)
        {
            enterDetailsPage.SelectAddContact(consent);
        }
        #endregion
        #region Thens
        [Then(@"I am directed to the confirmation page")]
        public void ThenIAmDirectedToTheConfirmationPage()
        {
            confirmationPage.VerifyConfirmPage();
        }
        [Then(@"an error message is displayed on the second form")]
        public void ThenAnErrorMessageIsDisplayedOnTheSecondForm()
        {
            enterDetailsPage.VerifyErrorMessages();
        }
        [Then(@"a date of birth error is displayed")]
        public void ThenADateOfBirthErrorIsDisplayed()
        {
            enterDetailsPage.ClickSendWithError();
            enterDetailsPage.VerifyBirthDateErrorMessage();
        }
        #endregion 
    }
}
