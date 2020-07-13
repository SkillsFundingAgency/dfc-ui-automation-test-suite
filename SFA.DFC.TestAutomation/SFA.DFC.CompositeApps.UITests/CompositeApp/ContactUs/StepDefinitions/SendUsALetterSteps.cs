using OpenQA.Selenium;
using SFA.DFC.CompositeApps.UITests.CompositeApp.ContactUs.Pages;
using SFA.DFC.CompositeApps.UITests.Config;
using SFA.DFC.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.ContactUs.StepDefinitions
{
    [Binding]
    public class SendUsALetterSteps
    {
        private readonly ScenarioContext _context;
        private ContactUsHomePage _contactUsHomePage;
        private SendUsALetterPage _sendUsALetterPage;
        private readonly IWebDriver _webDriver;
        private readonly CompositeAppsConfig _config;
        private readonly ObjectContext _objectContext;



        public SendUsALetterSteps(ScenarioContext context)
        {
            _context = context;
            _contactUsHomePage = new ContactUsHomePage(context);
            _sendUsALetterPage = new SendUsALetterPage(context);

            _config = context.GetCompositeAppsConfig<CompositeAppsConfig>();
            _webDriver = context.GetWebDriver();
            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"the user chooses the option Send us a letter")]
        public void WhenTheUserChoosesTheOptionSendUsALetter()
        {
            _contactUsHomePage.ChooseSendUsALetterOption();

            _contactUsHomePage.ClickContinueButton();
        }

        [Then(@"the user is presented with Send us a letter page")]
        public void ThenTheUserIsPresentedWithSendUsALetterPage()
        {
            _sendUsALetterPage.VerifyPage();
        }

    }
}
