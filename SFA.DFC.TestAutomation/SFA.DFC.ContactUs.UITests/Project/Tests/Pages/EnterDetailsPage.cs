using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;


namespace SFA.DFC.ContactUs.UITests.Project.Tests.Pages
{
    public class EnterDetailsPage : BasePage
    {
        #region Helpers
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        
        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By DetailsPageTitle = By.CssSelector(".govuk-heading-xl");
        private By FirstName = By.Id("Firstname");
        private By LastName = By.Id("Lastname");
        private By EmailAddress = By.Id("EmailAddress");
        private By ConfirmEmail = By.Id("ConfirmEmailAddress");
        private By Day = By.Id("DateOfBirthDay");
        private By Month = By.Id("DateOfBirthMonth");
        private By Year = By.Id("DateOfBirthYear");
        private By PostCode = By.Id("Postcode");
        private By ContactYes = By.Id("radio-inline-1");
        private By ContactNo = By.Id("radio-inline-2");
        private By Terms_Cond = By.Id("AcceptTermsAndConditions");
        private By SendButton = By.CssSelector(".govuk-button");
        #endregion
        public EnterDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
           
        }
        public void VerifyDetailsPage()
        {
            _pageHelper.VerifyPage(DetailsPageTitle, "Enter your details");
        }

        public void CompleteForm(string fname, string lname,string email,string confemail,string dob,string postcode)
        {
            
            _formHelper.EnterText(FirstName, fname);
            _formHelper.EnterText(LastName, lname);
            _formHelper.EnterText(EmailAddress, email);
            _formHelper.EnterText(ConfirmEmail, confemail);
            DateTime birthday = DateTime.ParseExact(dob, "dd/M/yyyy", CultureInfo.InvariantCulture);
            _formHelper.EnterText(Day, birthday.Day.ToString());
            _formHelper.EnterText(Month, birthday.Month.ToString());
            _formHelper.EnterText(Year, birthday.Year.ToString());
            _formHelper.EnterText(PostCode, postcode);
        }

        public void CompleteFeedbackForm(string fname, string lname, string email, string confemail)
        {
            _formHelper.EnterText(FirstName, fname);
            _formHelper.EnterText(LastName, lname);
            _formHelper.EnterText(EmailAddress, email);
            _formHelper.EnterText(ConfirmEmail, confemail);
        }

        public void SelectTermsandConditions()
        {
            _context.GetWebDriver().FindElement(Terms_Cond).Click();
        }

        public ConfirmationPage ClickSend()
        {
            _formHelper.ClickElement(SendButton);
            return new ConfirmationPage(_context);
        }

        public void SelectAddContact(string consent)
        {
            if (consent == "Yes")
            {
                _formHelper.SelectRadioButton(ContactYes);
            }
            else
            {
                _formHelper.SelectRadioButton(ContactNo);
            }
        }
    }
}
