using SFA.DFC.UI.Framework.TestSupport;
using SFA.DFC.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using System.Linq;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.ContactUs.Pages
{
    public class EnterYourDetailsPage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly FormCompletionHelper _retry;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "Enter your details | Contact us | National Careers Service";

        //protected override By PageHeader => By.ClassName("govuk-fieldset__heading");

        private By WhyDoYouWantToContactUsOption = By.CssSelector("div.govuk-radios__item > label");

        private By FirstName = By.Id("FirstName");

        private By FamilyName = By.Id("LastName");

        private By EmailAddress = By.Id("EmailAddress");

        private By TelephoneNumber = By.Id("TelephoneNumber");

        private By DateOfBirth_Day = By.Id("DateOfBirth_Day");

        private By DateOfBirth_Month = By.Id("DateOfBirth_Month");

        private By DateOfBirth_Year = By.Id("DateOfBirth_Year");

        private By Postcode = By.Id("Postcode");

        private By SelectDate = By.Id("TodayPlus1-option");

        private By SelectTime = By.Id("Band2-option");

        private By SendButton = By.Id("EnterYourDetailsSendButton");

        public EnterYourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }


        /// <summary>
        /// returns the number of selectable options available on the contact us homepage
        /// </summary>
        /// <returns></returns>
        public int GetOptionsCount()
        {
            return _pageHelper.FindElements(WhyDoYouWantToContactUsOption).Count();

        }

        public EnterYourDetailsPage EnterDetails()
        {
            _formHelper.EnterText(FirstName, "Test");
            _formHelper.EnterText(FamilyName, "Test");
            _formHelper.EnterText(EmailAddress, "ravi.kammily@methods.co.uk");
            _formHelper.EnterText(TelephoneNumber, "07850677367");
            _formHelper.EnterText(DateOfBirth_Day, "29");
            _formHelper.EnterText(DateOfBirth_Month, "11");
            _formHelper.EnterText(DateOfBirth_Year, "1983");
            _formHelper.EnterText(Postcode, "MK9 2DG");
            _formHelper.ExecuteJavascript("document.getElementById('TermsAndConditionsAccepted').click()");
            _formHelper.ClickElement(SendButton);
            return new EnterYourDetailsPage(_context);
        }

        public EnterYourDetailsPage EnterCallBackDetails()
        {
            _formHelper.EnterText(FirstName, "Test");
            _formHelper.EnterText(FamilyName, "Test");
            _formHelper.EnterText(EmailAddress, "ravi.kammily@methods.co.uk");
            _formHelper.EnterText(TelephoneNumber, "07850677367");
            _formHelper.EnterText(DateOfBirth_Day, "29");
            _formHelper.EnterText(DateOfBirth_Month, "11");
            _formHelper.EnterText(DateOfBirth_Year, "1983");
            _formHelper.EnterText(Postcode, "MK9 2DG");
            _formHelper.SelectRadioButton(SelectDate);
            _formHelper.SelectRadioButton(SelectTime);
            _formHelper.ExecuteJavascript("document.getElementById('TermsAndConditionsAccepted').click()");
            _formHelper.ClickElement(SendButton);
            return new EnterYourDetailsPage(_context);
        }

    }
}
