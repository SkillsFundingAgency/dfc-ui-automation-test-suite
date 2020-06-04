using FluentAssertions;
using OpenQA.Selenium;
using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.Framework.Helpers;
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
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;


        #endregion
        #region Page Elements
        protected override string PageTitle => "";
        private By DetailsPageTitle = By.ClassName("govuk-heading-xl");
        private By FirstName = By.Id("Firstname");
        private By LastName = By.Id("Lastname");
        private By EmailAddress = By.Id("EmailAddress");
        private By ConfirmEmail = By.Id("ConfirmEmailAddress");
        private By Day = By.Id("DateOfBirthDay");
        private By Month = By.Id("DateOfBirthMonth");
        private By Year = By.Id("DateOfBirthYear");
        private By PostCode = By.Id("Postcode");
        private By ContactYes = By.Id("radio-inline-1");
        private By FirstNameError = By.Id("Firstname-error");
        private By LastNameError = By.Id("Lastname-error");
        private By EMailError = By.Id("EmailAddress-error");
        private By PostCodeError = By.Id("Postcode-error");
        private By Terms_CondError = By.Id("AcceptTermsAndConditions-error");
        private By BirthDateError = By.ClassName("field-validation-error");
        private By ContactNo = By.Id("radio-inline-2");
        private IWebElement TermsCond => _webDriver.FindElement(By.ClassName("govuk-checkboxes__input"));
        private By SendButton = By.CssSelector("#userform .govuk-button");
        #endregion
        public EnterDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }
        public EnterDetailsPage VerifyDetailsPage()
        {
            _pageHelper.VerifyPage(DetailsPageTitle, "Enter your details");
            return this;
        }

        public EnterDetailsPage ClickSendWithError()
        {
            _formHelper.ClickElement(SendButton);
            return this;
        }

        public void CompleteForm(string fname,string email,string confemail,string dob,string postcode)
        {          
            
            _formHelper.EnterText(FirstName, fname);
            _formHelper.EnterText(LastName,GetEnvBuild());
            _formHelper.EnterText(EmailAddress, email);
            _formHelper.EnterText(ConfirmEmail, confemail);
            DateTime birthday = DateTime.ParseExact(dob, "dd/M/yyyy", CultureInfo.InvariantCulture);
            _formHelper.EnterText(Day, birthday.Day.ToString());
            _formHelper.EnterText(Month, birthday.Month.ToString());
            _formHelper.EnterText(Year, birthday.Year.ToString());
            _formHelper.EnterText(PostCode, postcode);
        }       

        public string GetEnvBuild()
        {
            return _objectContext.Get("EnvironmentName") + "-" + _objectContext.Get("build");
        }

        public void CompleteFeedbackForm(string fname, string email, string confemail)
        {
            _formHelper.EnterText(FirstName, fname);
            _formHelper.EnterText(LastName,GetEnvBuild());
            _formHelper.EnterText(EmailAddress, email);
            _formHelper.EnterText(ConfirmEmail, confemail);
        }
        public void SelectTermsandConditions()
        {
            //Using this code to select the check box as the select check box function doesn't seem to identify the check box.
            if (TermsCond.Selected==false)
             {
                 TermsCond.Click();
             }
           
            
        }
        public ConfirmationPage ClickSend()
        {
            _formHelper.ClickElement(SendButton);
            return new ConfirmationPage(_context);
        }
        public void SelectAddContact(string consent)
        {
            if (consent.Equals("Yes",StringComparison.OrdinalIgnoreCase))
            {
                _formHelper.SelectRadioButton(ContactYes);
            }
            else
            {
                _formHelper.SelectRadioButton(ContactNo);
            }
        }
        public void VerifyErrorMessages()
        {
            _pageHelper.VerifyText(FirstNameError, "Enter your first name").Should().BeTrue();
            _pageHelper.VerifyText(LastNameError, "Enter your last name").Should().BeTrue();
            _pageHelper.VerifyText(EMailError, "Enter your email address").Should().BeTrue();
            _pageHelper.VerifyText(PostCodeError, "Enter your postcode").Should().BeTrue();
            _pageHelper.VerifyText(Terms_CondError, "You must accept our Terms and Conditions").Should().BeTrue();
        }
        public void VerifyBirthDateErrorMessage()
        {
            _pageHelper.VerifyText(BirthDateError, "You must be over 13 to use this service").Should().BeTrue();
        }
    }
}
