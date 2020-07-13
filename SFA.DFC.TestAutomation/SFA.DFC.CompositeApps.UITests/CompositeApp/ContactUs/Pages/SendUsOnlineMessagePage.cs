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
    public class SendUsOnlineMessagePage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "How can we help?";

        protected override By PageHeader => By.ClassName("govuk-fieldset__heading");

        private By SpeakToAnAdviserOption = By.Id("SelectedOption");

        private By SendUsAnOnlineMessageOption = By.Id("SendAMessage-option");

        private By AskUsToCallYouBackOption = By.Id("Callback-option");

        private By SendUsALetterOption = By.Id("Sendletter-option");

        //private By ContinueButton = By.ClassName("govuk-button");

        private By NextButton = By.Id("HowCanWeHelpNextButton");


        private By CategoryErrorMessage = By.LinkText("Choose an option");


        private By WhyDoYouWantToContactUsOption = By.CssSelector("div.govuk-radios__item > label");

        private By MoreDetail = By.Id("MoreDetail");



        public SendUsOnlineMessagePage(ScenarioContext context) : base(context)
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

        public SendUsOnlineMessagePage ChooseWhyDoYouWantToContactUsOption()
        {
            _formHelper.SelectRadioOptionByText(WhyDoYouWantToContactUsOption, "Careers advice and guidance");
            _formHelper.EnterText(MoreDetail, " Test");

            _formHelper.ClickElement(NextButton);
            return new SendUsOnlineMessagePage(_context);
        }
    }
}
