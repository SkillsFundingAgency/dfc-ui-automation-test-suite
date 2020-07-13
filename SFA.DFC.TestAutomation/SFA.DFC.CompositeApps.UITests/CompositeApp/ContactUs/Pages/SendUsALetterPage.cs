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
    public class SendUsALetterPage : BasePage
    {
        private readonly PageInteractionHelper _pageHelper;
        private readonly FormCompletionHelper _formHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        protected override string PageTitle => "Send us a letter";

        //protected override By PageHeader => By.ClassName("govuk-breadcrumbs__list-item");

        protected override By PageHeader => By.TagName("govuk-breadcrumbs__list-item");


        private By SendUsALetterOption = By.Id("Sendletter-option");

        private By ContinueButton = By.ClassName("govuk-button");

        private By WhyDoYouWantToContactUsOption = By.CssSelector("div.govuk-radios__item > label");


        public SendUsALetterPage(ScenarioContext context) : base(context)
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

        public SendUsALetterPage ChooseSendUsALetterOption()
        {
            _formHelper.SelectRadioOptionByText(SendUsALetterOption, "Send us a letter");
            _formHelper.ClickElement(ContinueButton);
            return new SendUsALetterPage(_context);
        }
    }
}
