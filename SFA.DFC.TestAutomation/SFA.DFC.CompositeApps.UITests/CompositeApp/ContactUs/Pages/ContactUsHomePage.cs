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
    public class ContactUsHomePage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "Contact us";
        protected override By PageHeader => By.ClassName("govuk-fieldset__heading");

        private By SelectRadioOption = By.CssSelector("div.govuk-radios__item > label");

        private By SendUsAnOnlineMessageOption = By.XPath("//label[contains(@class,'govuk-label govuk-radios__label')]  [contains(text(),'Send us an online message. We'll email you back')]");

        private By AskUsToCallYouBackOption = By.Id("Callback-option");

        private By SendUsALetterOption = By.Id("Sendletter-option");

        private By ContinueButton = By.Id("HomeContinueButton");

        private By AcceptAllCookies = By.Id("accept-all-cookies");
        
        private By CategoryErrorMessage = By.LinkText("Choose an option");


        public ContactUsHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageHelper = context.Get<PageInteractionHelper>();
            _formHelper = context.Get<FormCompletionHelper>();
        }
        public void clickadviseroption()
        {
            _formHelper.SelectRadioOptionByText(SelectRadioOption, "Send us an online message. We'll email you back");
            int element = _pageHelper.FindElements(SelectRadioOption).Count();
        }

        public void AcceptCookies()
        {
            _formHelper.ClickElement(AcceptAllCookies);

        }

        /// <summary>
        /// returns the number of selectable options available on the contact us homepage
        /// </summary>
        /// <returns></returns>
        public int GetOptionsCount()
        {
            return _pageHelper.FindElements(SelectRadioOption).Count();
        }
        public bool IsAdviserOptionDisplayed()
        {
            return _pageHelper.IsElementDisplayed(SelectRadioOption);
        }
        public bool IsOnlineMessageOptionDisplayed()
        {
            return _pageHelper.IsElementDisplayed(SendUsAnOnlineMessageOption);
        }
        public bool IsCallYouBackOptionDisplayed()
        {
            return _pageHelper.IsElementDisplayed(AskUsToCallYouBackOption);
        }
        public bool IsSendUsALetterOptionDisplayed()
        {
            return _pageHelper.IsElementDisplayed(SendUsALetterOption);
        }
        public ContactUsHomePage ChooseOnlineMessageOption()
        {
            _formHelper.SelectRadioOptionByText(SelectRadioOption, "By email");
            return new ContactUsHomePage(_context);
        }
        public ContactUsHomePage ChooseSendUsALetterOption()
        {
            _formHelper.SelectRadioOptionByText(SelectRadioOption, "By post");
            _formHelper.ClickElement(ContinueButton);
            return new ContactUsHomePage(_context);
        }
        public ContactUsHomePage CallBackOption()
        {
            _formHelper.SelectRadioOptionByText(SelectRadioOption, "Ask us to call you");
            _formHelper.ClickElement(ContinueButton);
            return new ContactUsHomePage(_context);
        }
        public ContactUsHomePage ChatOnline()
        {
            _formHelper.SelectRadioOptionByText(SelectRadioOption, "Chat online");
            _formHelper.ClickElement(ContinueButton);
            return new ContactUsHomePage(_context);
        }
        public ContactUsHomePage ClickContinueButton()
        {
            _formHelper.ClickElement(ContinueButton);
            return new ContactUsHomePage(_context);
        }
        public void VerifyErrorSummary()
        {
            _pageHelper.VerifyText(CategoryErrorMessage, "Choose an option").Should().BeTrue();
        }

    }
}
